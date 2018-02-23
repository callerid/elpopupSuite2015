Imports System.Data.SQLite
Imports System.IO
Imports CIDClass
Imports Microsoft.WindowsAPICodePack.Taskbar

Public Class Form1

    Public usingCompTime
    Public sortAscendDuration As Boolean = False
    Public previousReceptions As List(Of String) = New List(Of String)

#Region "Properties"

    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As System.Windows.Forms.Keys) As Integer

    Private allowClose As Boolean = False 'set true before attemping to close the form, or it won't

    Private lastName As String ' Used to baloon tip the last caller (in case you missed it)
    Private lastPhone As String
    Private lastLine As Integer

    Private sortTimeDesc As Boolean = True
    Public bOutboundPopup As Boolean = My.Settings.bOutboundPopup
    Public bInboundPopup As Boolean = My.Settings.bInboundPopup
    Public nPopupTimer As Integer = My.Settings.nPopupTimer
    Public fLog As String = My.Settings.fLog
    Public LogLevel As Integer = My.Settings.LogLevel
    Public sSerial As String = My.Settings.sSerialPort
    Public sIpRelay As String = My.Settings.sIpRelay
    Public sAreaCode As String = My.Settings.sAreaCode

    Public stLookupURL As String = My.Settings.lookupURL

    Public growl As New Growl.Connector.GrowlConnector

    Public bDiagOpen As Boolean = False

    Private sSerialBuffer As String

    Private fDatabase As String = My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\..\CallDatabase.db3"
    Private fPluginDir As String = My.Application.Info.DirectoryPath + "\plugins"

    Public WithEvents UdpReceiver As New UdpReceiverClass

    Private UdpReceiveThread As New System.Threading.Thread(AddressOf UdpReceiver.UdpIdleReceive)
    
    Public pluginList As List(Of IMyPlugIn)

    Public activePopups As New List(Of PopBanner)

    Public Structure WC2DownloadStruct
        Public maxDownloads As Integer
        Public indxDownloads As Integer
        Public dupeDownloads As Integer
        Public newDownloads As Integer
        Public allDownloads As Integer
        Public errorDownloads As Integer
        Public errorFlag As Boolean
        Public errorMessage As String
        Public connected As Boolean
    End Structure
    Public Class PluginValues
        Public Const RECEIVED_NETWORK_DATA As Integer = 1
        Public Const RECEIVED_SERIAL_DATA As Integer = 2
        Public Const POST_PARSE_DATA As Integer = 3
        Public Const PRE_DISPLAY_POPUP As Integer = 4
        Public Const POST_DISPLAY_POPUP As Integer = 5
        Public Const POPUP_CLICKED As Integer = 6
        Public Const OPTIONS_QUERY As Integer = 7
        Public Const OPTIONS_LOAD As Integer = 8
        Public Const PLUGIN_VERSION As Integer = 9
        Public Const PLUGIN_ENABLED As Integer = 10
    End Class
    Public WC2Download As WC2DownloadStruct

    Dim xMainLocation As Integer
    Dim yMainLocation As Integer
#End Region
    Delegate Sub Text_delegate(ByVal [text] As String)
    Delegate Sub Record_delegate(ByVal [record] As CIDRecord)
    Private Declare Function ShellExecute _
                            Lib "shell32.dll" _
                            Alias "ShellExecuteA" ( _
                            ByVal hwnd As Long, _
                            ByVal lpOperation As String, _
                            ByVal lpFile As String, _
                            ByVal lpParameters As String, _
                            ByVal lpDirectory As String, _
                            ByVal nShowCmd As Long) _
                            As Long

    Protected Overrides ReadOnly Property ShowWithoutActivation() As Boolean
        Get
            Return True
        End Get
    End Property



    'This form dosn't hide normally, that causes issues with popups stealing focus.
    'Stealing focus is bad, it's worse than stealing diamonds. While kicking puppies.

    Public Overridable Overloads Sub hide()
        If Not Me.Left = -6000 Then
            xMainLocation = Me.Left
            yMainLocation = Me.Top
        End If
        Me.Left = -6000
        Me.ShowInTaskbar = False
    End Sub
    Public Overridable Overloads Sub show()
        'If Me.Left < -50 Then xMainLocation = 0
        Me.Left = xMainLocation
        If Me.Left < -50 Then xMainLocation = 0
        Me.Top = yMainLocation
        Me.ShowInTaskbar = True
        CreateJumpList()
    End Sub
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'don't close unless the user selects it from the trayicon.
        If e.CloseReason = CloseReason.UserClosing And allowClose = False Then
            e.Cancel = True
            Me.hide()
        End If

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        DGVCallList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        
        If Not My.Computer.FileSystem.FileExists(fDatabase) Then CreateDatabase()
        LoadDGVColumnWidths()
        Me.DGVCallList.Columns("Duration").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If My.Settings.iMainWindowHeight > 0 Then
            Me.Width = My.Settings.iMainWindowWidth
            Me.Height = My.Settings.iMainWindowHeight
        End If
        DGVFill()

        UdpReceiveThread.IsBackground = True
        UdpReceiveThread.Start()

        Debug.WriteLine(fDatabase)
        If My.Settings.bLargeWindow = True Then EightLineSupport()
        If My.Settings.nWindowSize > 8 Then TwelveLineSupport()
        If My.Settings.sSerialPort <> "none" Then startSerialServer()
        WC2Download.connected = False
        loadGrowl()
        Try
            Directory.CreateDirectory(My.Application.Info.DirectoryPath + "\plugins")
        Catch ex As Exception
        End Try

        For Each arg As String In Environment.GetCommandLineArgs()
            'ApplicationEvents.vb responds to arguments that occur after the program is already loaded.
            If arg = "-hide" Then
                hide()
            End If
            If arg = "-diag" Then
                'DiagForm.Show()
                'todo: fix diag form
            End If
            If arg = "-export" Then
                Export_Data()
                allowClose = True
                Me.Close()
            End If
        Next

        If My.Computer.FileSystem.DirectoryExists(fPluginDir) Then

            Dim di As New IO.DirectoryInfo(fPluginDir)
            Dim aryFi As IO.FileInfo() = di.GetFiles("*.dll")
            Dim fi As IO.FileInfo
            pluginList = New List(Of IMyPlugIn)
            For Each fi In aryFi
                Dim pluginName As String = fi.Name
                Dim NewPlugIn As IMyPlugIn = LoadPlugIn(String.Concat(My.Application.Info.DirectoryPath, "\plugins\", pluginName))
                Debug.WriteLine(String.Concat(My.Application.Info.DirectoryPath, "\plugins\", pluginName, ".dll"))
                If NewPlugIn IsNot Nothing Then
                    pluginList.Add(NewPlugIn)
                End If
            Next
        End If

        If Not (My.Settings.sSerialPort = "Do Not Use Serial Server" Or My.Settings.sSerialPort = "none") Then

            Me.UdpReceiver.StopListening()

        Else

            Text = "ELPopup - " + Application.ProductVersion.ToString + " Listening On Port: " + UdpReceiver.boundPort.ToString

        End If

    End Sub

    Public Sub LoadFromSettings()
        bOutboundPopup = My.Settings.bOutboundPopup
        bInboundPopup = My.Settings.bInboundPopup
        nPopupTimer = My.Settings.nPopupTimer
        fLog = My.Settings.fLog
        LogLevel = My.Settings.LogLevel
        sSerial = My.Settings.sSerialPort
        sIpRelay = My.Settings.sIpRelay
        sAreaCode = My.Settings.sAreaCode
    End Sub

    'EL Config and EL Popup use the same port and rarely work at the same time, so EL Config sends an event to EL Popup to shut down it's 
    'network receiver and sents another event when it closes to turn it back on.
    Public Sub NetworkStart()
        If Not UdpReceiveThread.IsAlive Then
            GeneralMessage("EL Popup is now running again.", "EL Popup Resuming")
            UdpReceiveThread = New System.Threading.Thread(AddressOf UdpReceiver.UdpIdleReceive)
            UdpReceiveThread.IsBackground = True
            UdpReceiveThread.Start()
        End If
    End Sub
    Public Sub NetworkEnd()
        GeneralMessage("EL Popup will suspend operation while Config is running.", "EL Popup Suspended")
        If UdpReceiveThread.IsAlive Then UdpReceiveThread.Abort()
        Dim bcast As New Broadcaster("255.255.255.255", 3520, "^^IdX") 'The data receiver blocks the thread abort event, so send one extra thing to get the ball rolling.
        bcast.SendMessage()
    End Sub
    Private Sub loadGrowl()
        'Applications need to register to use Growl, and it's easy enough to register every time the program loads.
        Dim gApplication As New Growl.Connector.Application("EL Popup")
        If File.Exists(Application.StartupPath & "/Phone48.png") Then gApplication.Icon = Application.StartupPath & "/Phone48.png" 'Growl sucks at reading .ico files
        If File.Exists(Application.StartupPath & "/Resources/Phone48.png") Then gApplication.Icon = Application.StartupPath & "/Resources/Phone48.png"
        Dim gNotifyTypeSuccess As New Growl.Connector.NotificationType("INBOUND", "Inbound Call")
        Dim gNotifyTypeFail As New Growl.Connector.NotificationType("OUTBOUND", "Outbound Call")
        Dim gNotifyTypeGeneric As New Growl.Connector.NotificationType("GENERIC", "Generic Info")
        Growl.Register(gApplication, New Growl.Connector.NotificationType() {gNotifyTypeSuccess, gNotifyTypeFail, gNotifyTypeGeneric})
        Dim gNotificationGeneric As New Growl.Connector.Notification("EL Popup", "GENERIC", "ID", "EL Popup", "EL Popup is running.")
        Growl.Notify(gNotificationGeneric)

    End Sub
    Public ReadOnly Property RelayEnabled() As Boolean
        Get
            If sSerial = "none" Then Return False
            If sIpRelay = "none" Then Return False
            Return True
        End Get
    End Property

    Public Sub Log(ByVal LogMessage As String, Optional ByVal iLogLevel As Integer = 1) Handles UdpReceiver.Log
        If iLogLevel <= LogLevel Then
            Try
                Dim log As System.IO.StreamWriter = My.Computer.FileSystem.OpenTextFileWriter(fLog, True)
                log.WriteLine(LogMessage)
                log.Close()
            Catch ex As Exception
                'MsgBox("Could not open the log file for writing. Log file is presumably at " + fLog + vbCr + vbCr + ex.Message)
            End Try
        End If
    End Sub

    Public Sub CreateJumpList(Optional ByVal number As Integer = 0, Optional ByVal outOf As Integer = 0)
        'Create a Windows 7 Jumplist. 
        If Not Me.ShowInTaskbar Then Exit Sub
        If Not TaskbarManager.IsPlatformSupported Then Exit Sub

        Dim jl As JumpList = JumpList.CreateJumpList
        jl.AddUserTasks(New JumpListLink(My.Application.Info.DirectoryPath + "\ELPopup Manual.chm", "Manual"))
        jl.AddUserTasks(New JumpListLink(My.Application.Info.DirectoryPath + "\ELPopup.exe", "Export Data") With {.Arguments = "-export"})
        jl.Refresh()
        Dim tb As TaskbarManager = TaskbarManager.Instance
        If number > 0 Then
            If number = outOf Then
                tb.SetProgressState(TaskbarProgressBarState.NoProgress)
            Else
                tb.SetProgressState(TaskbarProgressBarState.Indeterminate)
                tb.SetProgressValue(number, outOf)
            End If
        Else
            tb.SetProgressState(TaskbarProgressBarState.NoProgress)
        End If
    End Sub
    Public Sub GeneralMessage(ByVal messageText As String, Optional ByVal messageTitle As String = "")
        If Growl.IsGrowlRunning Then
            Growl.Notify(New Growl.Connector.Notification("EL Popup", "GENERIC", "ID", messageTitle, messageText))
        Else
            TrayIcon.ShowBalloonTip(1, messageTitle, messageText, ToolTipIcon.Info)
        End If
    End Sub

    Private Sub removeReceptionFromBuffer(ByVal reception As String)

        Dim indexes As List(Of Integer) = New List(Of Integer)
        Dim cnt As Integer = 0

        For Each rec As String In previousReceptions

            If rec.Contains(reception.Substring(reception.Length - 20)) Then
                indexes.Add(cnt)
            End If
            cnt += 1

        Next

        For i As Integer = indexes.Count - 1 To 0 Step -1
            previousReceptions.RemoveAt(indexes(i))
        Next

    End Sub

    Private Sub DataHandler(ByVal sDataText As String)

        Dim uid As String
        Dim record As New CIDRecord(sDataText)

        If (previousReceptions.Contains(sDataText)) Then
            Exit Sub
        Else
            If (previousReceptions.Count > 30) Then
                previousReceptions.Add(sDataText)
                previousReceptions.RemoveAt(0)
            Else
                previousReceptions.Add(sDataText)
            End If
        End If

        If (Not record.IsDetailed And Not record.CallStart) Then
            removeReceptionFromBuffer(sDataText)
        End If

        ' Added 12/3/2013 - option for using computer time
        If My.Settings.useCompTime = True Then
            record.CallTime = DateTime.Now
        End If

        For Each plugIn As IMyPlugIn In pluginList
            Dim result As Object
            result = plugIn.EventFunction(PluginValues.RECEIVED_NETWORK_DATA, record)
            If TypeOf (result) Is Boolean And result = True Then
                Exit Sub
            End If
        Next

        uid = CIDFunctions.UID_Decoder(sDataText.Substring(5, 6))
        Log("(" + uid + ")" + sDataText.Substring(21), 1)

        If record.IsTimeAutoGenerated Then
            Dim date1 As Date = Date.Now

            Dim bcast As New Broadcaster("255.255.255.255", 3520, "^^Id-" + "Z" + date1.ToString("MMddHHmm") + vbCr)
            bcast.SendMessage()
            If SerialPort1.IsOpen Then
                SerialPort1.Write("Z" + date1.ToString("MMddHHmm") + vbCr)
            End If

        End If

        If Not record.isSpecial Then
            RecordDisplay(record)
        End If
        If record.recordType = CIDRecord.WC2_MEMORY_RECORD Then
            WC2Download.allDownloads = WC2Download.allDownloads + 1
            WC2Download.indxDownloads = record.index
            If WC2Download.indxDownloads <> WC2Download.allDownloads Then
                WC2Download.errorFlag = True
                Try
                    WC2Download.errorDownloads = WC2Download.indxDownloads - WC2Download.allDownloads
                Catch ex As Exception
                End Try
                WC2Download.errorMessage = "Not all of the calls were downloaded from the Whozz Calling? 2"
            End If

            If record.IsTimeAutoGenerated Then
                WC2Download.errorMessage = "A call record has an invalid time stamp."
                WC2Download.errorDownloads = WC2Download.errorDownloads + 1
                WC2Download.errorFlag = True
                Exit Sub
            End If
            If writeRecord(record) Then 'if it was an update (false for new record)
                WC2Download.dupeDownloads = WC2Download.dupeDownloads + 1
            Else
                WC2Download.newDownloads = WC2Download.newDownloads + 1
            End If
        End If
        If record.recordType = CIDRecord.WC2_MEMORY_AMOUNT Then
            WC2Download.connected = True
            WC2Download.maxDownloads = record.index
            WC2Download.errorFlag = False
            WC2Download.errorDownloads = 0
            WC2Download.allDownloads = 0
            WC2Download.indxDownloads = 0
            WC2Download.newDownloads = 0
            WC2Download.dupeDownloads = 0
        End If
    End Sub

    Private Sub DataReceivedEventHandler(ByVal sender As Object) Handles UdpReceiver.DataReceived

        Dim sReceivedText As String

        sReceivedText = sender.sReceivedMessage
        DataHandler(sReceivedText)

    End Sub

    Delegate Sub EndedReceptionCallback()
    Private Sub EndedReceptionHandler() Handles UdpReceiver.EndReceiving

        If Me.InvokeRequired Then
            Dim d As New EndedReceptionCallback(AddressOf EndedReceptionHandler)
            Me.BeginInvoke(d, New Object() {})
        Else
            Text = "ELPopup - " + Application.ProductVersion.ToString + " - BOUND TO SERIAL"
        End If

    End Sub

    Private Sub SerialPort1_DataReceived(ByVal sender As Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        sSerialBuffer = sSerialBuffer + SerialPort1.ReadExisting()
        If bDiagOpen Then
            DiagForm.tbSerialOutput.AppendText(sSerialBuffer)
        End If
        Dim lfPoint As Integer = InStr(sSerialBuffer, vbCrLf)
        If Not lfPoint > 0 Then lfPoint = InStr(sSerialBuffer, "{}")
        Dim sSerialData As String
        If (lfPoint > 0) Then
            lfPoint = lfPoint + 1
            sSerialData = sSerialBuffer.Substring(0, lfPoint - 2)
            sSerialBuffer = sSerialBuffer.Substring(lfPoint)
            DataHandler("^^<U>SERIAL<S>SERIAL$" & sSerialData)
            If (RelayEnabled) And Not (sIpRelay = "none") Then
                Dim bcast As New Broadcaster(sIpRelay, 3520, "^^<U>IRELAY<S>IRELAY$" + sSerialData)
                bcast.SendMessage()
            End If

        End If
    End Sub
    Public Sub DownloadWC2(Optional ByVal downloadMode As Integer = 0)
        'If Options.TabControl1.TabCount = 4 Then Options.TabControl1.TabPages.RemoveAt(3)
        Dim sDownloadMode As String = "F"
        If downloadMode = 0 Then sDownloadMode = "F"
        If downloadMode = 1 Then sDownloadMode = "?"
        Dim bcast As New Broadcaster("255.255.255.255", 3520, "^^Id-" + sDownloadMode)
        bcast.SendMessage()
        If SerialPort1.IsOpen Then
            SerialPort1.Write(sDownloadMode)
        End If
    End Sub

    Public Sub EraseWC2()
        'To erase a Whozz Calling? 2, you need to send Y twice. It would ask "Erase? (Y/N)" if you were to do it manually.
        Dim bcast As New Broadcaster("255.255.255.255", 3520, "^^Id-Y")
        If SerialPort1.IsOpen Then
            SerialPort1.Write("Y")
        End If
        bcast.SendMessage()
        System.Threading.Thread.Sleep(200)
        Dim bcastC As New Broadcaster("255.255.255.255", 3520, "^^Id-Y")
        If SerialPort1.IsOpen Then
            SerialPort1.Write("Y")
        End If
        bcastC.SendMessage()
    End Sub
    Private Sub RecordDisplay(ByVal record As CIDRecord)
        If Me.InvokeRequired Then
            Dim d As New Record_delegate(AddressOf RecordDisplay)
            Me.BeginInvoke(d, New Object() {record})
        Else
            If record.DetailType = "V" Then Exit Sub
            Dim txtLineX As System.Windows.Forms.TextBox = txtLine1

            Select Case record.Line
                Case 1
                    txtLineX = txtLine1
                Case 2
                    txtLineX = txtLine2
                Case 3
                    txtLineX = txtLine3
                Case 4
                    txtLineX = txtLine4
                Case 5
                    txtLineX = txtLine5
                Case 6
                    txtLineX = txtLine6
                Case 7
                    txtLineX = txtLine7
                Case 8
                    txtLineX = txtLine8
                Case 9
                    txtLineX = txtLine9
                Case 10
                    txtLineX = txtLine10
                Case 11
                    txtLineX = txtLine11
                Case 12
                    txtLineX = txtLine12
            End Select
            If record.Line > 4 Then EightLineSupport() ' if more lines come in, add more support
            If record.Line > 8 Then TwelveLineSupport() ' this is totally not scalable.
            'Color settings
            If record.DetailType = "F" Then txtLineX.BackColor = Color.Beige
            If record.DetailType = "R" Then
                txtLineX.BackColor = Color.MistyRose
                txtLineX.Text = ""
            End If

            If record.DetailType = "O" Then txtLineX.BackColor = Color.PaleTurquoise
            If (record.IsEndRecord = True And record.IsDetailed = False) Or record.DetailType = "N" Then
                txtLineX.ForeColor = Color.Gray
                txtLineX.BackColor = Color.White
            Else
                txtLineX.ForeColor = Color.Black
            End If

            'If it's less than a full record, stop here
            If record.DetailType = "I" Or record.DetailType = "O" Then
            Else
                Exit Sub
            End If

            If record.DetailType = "O" Then record.Name = NameFromPhone(SimplifyPhone(record.Phone))
            txtLineX.Text = record.Name + " " + record.Phone

            'No popups on end records or unapproved calls.
            'Always send to Growl because it has it's own filters. Otherwise lookup the option setting.
            Dim bPopupsEnabled As Boolean = True
            Dim bAltPopup As Boolean = False
            Dim stAltPopupText As String = ""
            Dim intAltPopupPosition As Integer = 1
            For Each plugIn As IMyPlugIn In pluginList
                Dim result As Object
                result = plugIn.EventFunction(PluginValues.PRE_DISPLAY_POPUP, record)
                If TypeOf (result) Is Boolean Then
                    If result = True Then bPopupsEnabled = False
                End If
                If TypeOf (result) Is String Then
                    bPopupsEnabled = False
                    stAltPopupText = result
                    bAltPopup = True
                    intAltPopupPosition = record.Line
                End If
            Next
            If bAltPopup Then PopupLite(stAltPopupText, intAltPopupPosition)
            If record.IsEndRecord = False Then
                If record.DetailType = "O" Then
                    Growl.Notify(New Growl.Connector.Notification("EL Popup", "OUTBOUND", "ID", "Line: " + record.Line.ToString + " " + record.Name, _
                                                                      "Outgoing Call" + vbLf + record.Name + vbLf + record.Phone))
                    If bOutboundPopup = True And bPopupsEnabled Then
                        PopupLite(record)
                    End If
                End If

                If record.DetailType = "I" Then
                    Growl.Notify(New Growl.Connector.Notification("EL Popup", "INBOUND", "ID", "Line: " + record.Line.ToString + " " + record.Name + " " + record.Phone, _
                                                                      "Incoming Call" + vbLf + record.Name + vbLf + record.Phone))
                    If bInboundPopup = True And bPopupsEnabled Then
                        PopupLite(record)
                    End If
                End If


                'Set the last data for baloon tips, in case the user missed the popup.
                lastLine = record.Line
                lastName = record.Name
                lastPhone = record.Phone
            End If

            'If Not writeRecord(record) Then DGVAddLineAtStart(record)
            Try
                writeRecord(record)
            Catch ex As Exception
                SqlError(ex)
            End Try

            DGVFill() ' yeah, it refills the list everytime a new call comes in. That way it's always ordered by time



        End If
    End Sub
    Private Sub Popup(ByVal record As CIDRecord)
        'this stuff was written for Windows Presentation Foundation. It has cool transparancy effects and stuff, but it dosn't run on Win2k

        'Dim pWindow As New PopBanner.PopupWindow
        'pWindow.PopupText = record.Line.ToString + ": " + record.Name + " " + record.Phone
        'pWindow.Position = (record.Line - 1) Mod 4
        'If bOpacity = False Then pWindow.AllowsTransparency = False
        'pWindow.Show()
        'Me.Focus()
    End Sub

    Public Overloads Sub PopupLite(ByVal record As CIDRecord)
        Try
            Dim pWindow As New PopBanner
            activePopups.Add(pWindow)
            pWindow.ShowInTaskbar = True
            pWindow.Position = (record.Line - 1) Mod 8
            If Not record.Phone = record.Name Then 'sometimes the name and phone are the same (Private, Outofarea, etc.)
                pWindow.PopupText = record.Line.ToString + ": " + record.Name + " " + record.Phone
            Else
                pWindow.PopupText = record.Line.ToString + ": " + record.Phone
            End If
            pWindow.timeLife = (nPopupTimer * 100) * 0.625
            pWindow.Show()
        Catch ex As Exception
            MsgBox("Error: Could not open standard popup box. But in case you were wondering, the call was from " + record.Name + vbCrLf + vbCrLf + ex.Message)
            Debugger.Break()
        End Try
    End Sub
    Public Overloads Sub PopupLite(ByVal text As String, ByVal position As Integer)

        Dim pWindow As New PopBanner
        activePopups.Add(pWindow)
        pWindow.ShowInTaskbar = True
        pWindow.Position = (position - 1) Mod 8
        pWindow.PopupText = text
        pWindow.timeLife = (nPopupTimer * 100) * 0.625
        Debug.WriteLine(nPopupTimer.ToString + " " + pWindow.timeLife.ToString)
        pWindow.Show()
        'Catch ex As Exception
        'MsgBox("Error: Could not open standard popup box." + vbCrLf + vbCrLf + ex.Message)
        'Debugger.Break()
        'End Try
    End Sub

    Public Sub ClearPopups()
        'Removes any popups that are currently displaying. If you show a "5 second sample" popup, you'll want to remove the previous "6 second" one first.
        For Each popupWindow As PopBanner In activePopups
            If popupWindow.IsDisposed Then Continue For
            popupWindow.Close()
        Next
        activePopups.Clear()
    End Sub

    Private Sub DGV_Color(Optional ByVal ColorRow As Integer = -1) 'Colorize the last item in the list, blue for outbound, green for inbound
        Dim rowNumber, ii As Integer
        If ColorRow = -1 Then rowNumber = DGVCallList.Rows.Count - 1 Else rowNumber = ColorRow
        Try
            For ii = 0 To (DGVCallList.ColumnCount - 1)
                If DGVCallList.Item(5, rowNumber).Value = "I" Then
                    DGVCallList.Item(ii, rowNumber).Style.ForeColor = Color.Green
                Else
                    DGVCallList.Item(ii, rowNumber).Style.ForeColor = Color.Blue
                End If
            Next
        Catch ex As Exception
            MsgBox("There was a problem trying to colorize the Call List" + vbCrLf + ex.Message)
            Debugger.Break()
        End Try
    End Sub

    Public Function startSerialServer()
        Dim errorMessage As String = ""
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
        Try
            SerialPort1.PortName = sSerial
            SerialPort1.Open()
        Catch ex As Exception
            errorMessage = "Cannot connect to " + SerialPort1.PortName + ", that COM port is in use"
        End Try
        Return errorMessage
    End Function
    Public Sub stopSerialServer()
        If SerialPort1.IsOpen Then
            SerialPort1.Close()
        End If
    End Sub

    Private Function writeRecord(ByVal record As CIDRecord)


        Dim SQLconnect As New SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        Dim nInbound As Integer = 0
        Dim fName As String = record.Name.Replace("'", "&#39;")
        Dim bUpdated As Boolean = False
        If record.IsInbound = True Then nInbound = 1

        SQLconnect.ConnectionString = "Data Source=" & fDatabase & ";"
        Try
            SQLconnect.Open()
        Catch ex As Exception
            MsgBox("Could not open database file" + vbCr + ex.Message)
        End Try


        SQLcommand = SQLconnect.CreateCommand

        'Check database for Start Record
        SQLcommand.CommandText = String.Format("UPDATE CallRecords SET Duration =  {0} WHERE Phone = '{1}' AND Time = '{2}' AND Line = {3}", record.Duration.ToString, record.Phone, record.CallTime.ToString("yyyyMMddHHmmss"), record.Line)
        Dim nResultsChanged As Integer
        Try
            nResultsChanged = SQLcommand.ExecuteNonQuery
        Catch ex As Exception
            MsgBox("Could not check to see if Call information was already in database" + vbCrLf + ex.Message + vbCrLf + "Database should be at " + fDatabase)
            Debugger.Break()
        End Try


        'If no start record found, then add this record
        If nResultsChanged > 0 Then
            bUpdated = True
        Else
            Dim query As String = String.Format("INSERT INTO CallRecords (Name,Phone,Time,Duration,Line,Inbound,UID,SN) " + _
                                          "VALUES ('{0}','{1}','{2}',{3},{4},{5},'{6}','{7}')", _
                                          fName, record.Phone, Val(record.CallTime.ToString("yyyyMMddHHmmss")), record.Duration, record.Line.ToString, nInbound, record.UnitID, record.SerialNumber)
            SQLcommand.CommandText = query
            Try
                SQLcommand.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Could not add call information to database" + vbCrLf + ex.Message + vbCrLf + "Database should be at " + fDatabase)
            End Try
        End If
        If record.IsOutbound = False Then 'only do this on inbound records, outbound ones never have callerid
            'Check database for Callers Entry
            Dim sSimplifiedPhone As String = SimplifyPhone(record.Phone)
            SQLcommand.CommandText = String.Format("SELECT * FROM Callers WHERE Name = '{0}' and Phone = '{1}'", fName, sSimplifiedPhone)
            Dim SQLreader As SQLiteDataReader = SQLcommand.ExecuteReader()

            'If no caller entry found, add it.
            If Not SQLreader.HasRows Then
                SQLreader.Close()
                SQLcommand.CommandText = String.Format("INSERT INTO Callers (Name,Phone) VALUES('{0}','{1}')", fName, sSimplifiedPhone)
                SQLcommand.ExecuteNonQuery()
            End If
            If Not SQLreader.IsClosed Then SQLreader.Close()
        End If
        SQLcommand.Dispose()
        SQLconnect.Close()
        SQLconnect.Dispose()
        Return bUpdated
    End Function

    Private Function NameFromPhone(ByVal phoneNumber As String)
        Dim SQLconnect As New SQLiteConnection()
        Dim SQLcommand As SQLiteCommand
        Dim sName As String
        Dim f As New OpenFileDialog
        f.FileName = fDatabase

        SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
        SQLconnect.Open()
        SQLcommand = SQLconnect.CreateCommand
        If phoneNumber.Length = 7 Then phoneNumber = sAreaCode + phoneNumber
        SQLcommand.CommandText = String.Format("SELECT Name FROM Callers WHERE Phone = '{0}'", phoneNumber)
        Dim SQLreader As SQLiteDataReader = SQLcommand.ExecuteReader()
        If SQLreader.HasRows Then
            SQLreader.Read()
            sName = SQLreader("Name")
        Else
            sName = "Outgoing Call"
        End If
        SQLreader.Close()
        SQLconnect.Close()
        SQLcommand.Dispose()
        SQLconnect.Dispose()
        Return sName
    End Function
    Private Function SimplifyPhone(ByVal phoneNumber As String)
        Dim SimplePhone As String = phoneNumber.Replace("-", "")
        If SimplePhone.Length > 0 Then
            If SimplePhone.Substring(0, 1) = "1" Then SimplePhone = SimplePhone.Substring(1)
        End If
        Return SimplePhone
    End Function

    Private Sub DGVAddLineAtStart(ByVal record As CIDRecord)
        'This sub adds a call item to the start of the list without refilling the entire list. I don't actually call it at any point
        Dim sIO As String
        If record.IsInbound = True Then sIO = "I" Else sIO = "O"
        Dim timeRecord As DateTime = record.CallTime
        Dim timeString As String = timeRecord.ToString("MM/dd/yyyy h:mm tt")
        Dim nameString As String = record.Name
        DGVCallList.Rows.Insert(0, nameString, record.Phone, timeString, record.Duration.ToString, record.Line.ToString, sIO)
        DGV_Color(0)
    End Sub

    Public Sub DGVFill(Optional ByVal Query As String = "SELECT * FROM CallRecords ORDER BY time DESC LIMIT 500")
        Try
            DGVCallList.Rows.Clear()
            Debug.WriteLine(Query)
            Dim SQLconnect As New SQLiteConnection()
            Dim SQLcommand As SQLiteCommand

            SQLconnect.ConnectionString = "Data Source=" & fDatabase & ";"
            SQLconnect.Open()
            SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = Query
            Dim SQLreader As SQLiteDataReader = SQLcommand.ExecuteReader()
            While SQLreader.Read()
                Dim sIO As String
                If SQLreader("Inbound") = 1 Then sIO = "I" Else sIO = "O"
                Dim timeRecord As DateTime = DateTime.ParseExact(SQLreader("Time"), "yyyyMMddHHmmss", System.Globalization.DateTimeFormatInfo.CurrentInfo)
                Dim timeString As String = timeRecord.ToString("MM/dd/yyyy h:mm tt")
                Dim nameString As String = SQLreader("Name").ToString.Replace("&#39;", "'")
                Dim durationTime As New TimeSpan(0, 0, SQLreader("Duration"))
                Dim durationString As String = durationTime.ToString
                If durationTime.TotalHours < 1 Then
                    durationString = durationString.Substring(3)
                End If
                If SQLreader("Duration") = 9999 Then
                    durationString = ">" + durationString
                End If
                DGVCallList.Rows.Add(nameString, SQLreader("Phone"), timeString, durationString, SQLreader("Line").ToString, sIO, SQLreader("Time").ToString)
                DGV_Color()
            End While
            SQLreader.Close()
            SQLcommand.Dispose()
            SQLconnect.Close()
            SQLconnect.Dispose()
        Catch ex As Exception
            SqlError(ex)
        End Try
    End Sub

    Private Sub SqlError(ByVal ex As Exception)
        If InStr(ex.Message, "no such table") > 0 Then
            MsgBox("There was a database error. A table was not found." + vbCr + vbCr + "Close this program, then delete the file at " + fDatabase + " and try running it again. This will delete the caller database (however it's probably currupt anyway)", MsgBoxStyle.Critical, "SQL Error")
        Else
            MsgBox("There was a problem trying to fill up the call list with calls" + vbCrLf + ex.Message)
        End If
#If DEBUG Then
        Debugger.Break()
#End If
    End Sub

    Private Sub CreateDatabase()

        Dim SQLconnect As New SQLiteConnection()
        Dim SQLcommand As SQLiteCommand

        SQLconnect.ConnectionString = "Data Source=" & fDatabase & ";"

        Try
            SQLconnect.Open()
        Catch ex As Exception
            SqlError(ex)
        End Try

        'SQLconnect.BeginTransaction()
        SQLcommand = SQLconnect.CreateCommand
        SQLcommand.CommandText = "CREATE TABLE 'Callers' ('idx' INTEGER PRIMARY KEY NOT NULL,'Name' TEXT,'Phone' TEXT);"
        SQLcommand.ExecuteNonQuery()
        SQLcommand.CommandText = "CREATE TABLE 'CallRecords' ('idx' INTEGER PRIMARY KEY NOT NULL,'Name' TEXT,'Phone' TEXT,'Duration' INTEGER,'Time' INTEGER,'Line' INTEGER,'Inbound' INTEGER,'UID' TEXT,'SN' TEXT);"
        SQLcommand.ExecuteNonQuery()
        'SQLcommand.Transaction.Commit()
        SQLcommand.Dispose()
        SQLconnect.Close()
        SQLconnect.Dispose()
    End Sub

    Public Sub Export_Data()
        Dim f As New SaveFileDialog
        f.Filter = "Comma Seperated Values (.csv)|*.csv|Text File (.txt)|*.txt|Other|*.*"
        f.DefaultExt = ".csv"
        f.AddExtension = True
        f.FileName = My.Computer.FileSystem.SpecialDirectories.MyDocuments + "\CallerID data"
        Dim diagResult As System.Windows.Forms.DialogResult = f.ShowDialog
        If diagResult = Windows.Forms.DialogResult.OK Then
            Dim fw As New System.IO.StreamWriter(f.FileName, False)
            Dim Query As String = "SELECT * FROM CallRecords ORDER BY Time"
            Try
                Debug.WriteLine(Query)
                Dim SQLconnect As New SQLiteConnection()
                Dim SQLcommand As SQLiteCommand

                SQLconnect.ConnectionString = "Data Source=" & fDatabase & ";"
                SQLconnect.Open()
                SQLcommand = SQLconnect.CreateCommand
                SQLcommand.CommandText = Query
                Dim SQLreader As SQLiteDataReader = SQLcommand.ExecuteReader()

                While SQLreader.Read()
                    Dim CallDirection As String = "Inbound"
                    If SQLreader("Inbound") = 0 Then CallDirection = "Outbound"
                    Dim timeRecord As DateTime = DateTime.ParseExact(SQLreader("Time"), "yyyyMMddHHmmss", System.Globalization.DateTimeFormatInfo.CurrentInfo)
                    Dim timeString As String = timeRecord.ToString("MM/dd/yyyy hh:mm tt")
                    Dim nameString As String = SQLreader("Name").ToString.Replace("&#39;", "'")
                    Dim csvFormat As String = "{0},{1},{2},{3},{4},{5}"
                    Dim txtFormat As String = "{0} {1} {2} {3} {4} {5}"
                    Dim writeString As String
                    If f.FilterIndex = 1 Then
                        writeString = String.Format(csvFormat, Chr(34) + nameString + Chr(34), SQLreader("Phone"), timeString, SQLreader("Duration").ToString, CallDirection, SQLreader("Line").ToString)
                    Else
                        writeString = String.Format(txtFormat, nameString.PadRight(15, " "), SQLreader("Phone").ToString.PadRight(15, " "), timeString, SQLreader("Duration").ToString.PadLeft(4, "0"), CallDirection.PadRight(8, " "), SQLreader("Line").ToString)
                    End If
                    fw.WriteLine(writeString)
                    Debug.WriteLine(writeString)
                End While
                fw.Close()

                SQLreader.Close()
                SQLcommand.Dispose()
                SQLconnect.Close()
                SQLconnect.Dispose()
            Catch ex As Exception
                SqlError(ex)
            End Try
        End If

    End Sub

    Private Sub EightLineSupport() 'visualize windows for 8 lines instead of 4
        My.Settings.b8LineEver = True
        Label6.Visible = True
        Label7.Visible = True
        Label8.Visible = True
        Label9.Visible = True
        txtLine5.Visible = True
        txtLine6.Visible = True
        txtLine7.Visible = True
        txtLine8.Visible = True
        Me.Width = 475
        My.Settings.bLargeWindow = True
        My.Settings.Save()
    End Sub
    Private Sub TwelveLineSupport() 'visualize windows for 8 lines instead of 4
        My.Settings.b8LineEver = True
        Label13.Visible = True
        Label10.Visible = True
        Label11.Visible = True
        Label12.Visible = True
        txtLine9.Visible = True
        txtLine10.Visible = True
        txtLine11.Visible = True
        txtLine12.Visible = True
        Me.Width = 706
        My.Settings.nWindowSize = 12
        My.Settings.Save()
    End Sub

#Region "Search Related"
    'not much in here yet, but I want to allow searches like "yestarday" and "one hour ago" and "inbound only"
    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSearch.TextChanged
        Dim targetDate As DateTime
        Dim currentDate As DateTime = Today
        Dim deltaDate As DateTime
        Dim sCurrentDate As String = Today.Year.ToString + Today.Month.ToString.PadLeft(2, "0") + Today.Day.ToString.PadLeft(2, "0") + "000000"
        Dim sTargetDate As String
        'Dim sDeltaDate As String
        Dim query As String = "SELECT * FROM CallRecords WHERE "
        Select Case cbSearch.Text.ToLower
            Case "outbound"
                query += "Inbound = 0"
            Case "inbound"
                query += "Inbound = 1"
            Case "line 1"
                query += "Line = 1"
            Case "line 2"
                query += "Line = 2"
            Case "line 3"
                query += "Line = 3"
            Case "line 4"
                query += "Line = 4"
            Case "line 5"
                query += "Line = 5"
            Case "line 6"
                query += "Line = 6"
            Case "line 7"
                query += "Line = 7"
            Case "line 8"
                query += "Line = 8"

            Case "today"
                query += "Time > " + sCurrentDate
            Case "yesterday"
                targetDate = DateAdd(DateInterval.Day, -1, Today)
                sTargetDate = targetDate.Year.ToString + targetDate.Month.ToString.PadLeft(2, "0") + targetDate.Day.ToString.PadLeft(2, "0") + "000000"
                query += "Time > " + sTargetDate + " AND Time < " + sCurrentDate
                DGVFill(query)

            Case "last week"
                targetDate = DateAdd(DateInterval.Day, -Today.DayOfWeek - 7, Today)
                deltaDate = DateAdd(DateInterval.WeekOfYear, 1, targetDate)
                query += "Time > " + targetDate.Year.ToString + targetDate.Month.ToString.PadLeft(2, "0") + targetDate.Day.ToString.PadLeft(2, "0") + "000000 "
                query += "AND Time < " + deltaDate.Year.ToString + deltaDate.Month.ToString.PadLeft(2, "0") + deltaDate.Day.ToString.PadLeft(2, "0") + "000000"

            Case "this week"
                targetDate = DateAdd(DateInterval.Day, -Today.DayOfWeek, Today)
                deltaDate = DateAdd(DateInterval.WeekOfYear, 1, targetDate)
                query += "Time > " + targetDate.Year.ToString + targetDate.Month.ToString.PadLeft(2, "0") + targetDate.Day.ToString.PadLeft(2, "0") + "000000 "
                query += "AND Time < " + deltaDate.Year.ToString + deltaDate.Month.ToString.PadLeft(2, "0") + deltaDate.Day.ToString.PadLeft(2, "0") + "000000"


            Case "last month"
                targetDate = DateAdd(DateInterval.Month, -1, Today)
                sTargetDate = targetDate.Year.ToString + targetDate.Month.ToString.PadLeft(2, "0") + targetDate.Day.ToString.PadLeft(2, "0") + "000000"
                query += "Time > " + targetDate.Year.ToString + targetDate.Month.ToString.PadLeft(2, "0") + "00000000 "
                query += "AND Time < " + currentDate.Year.ToString + currentDate.Month.ToString.PadLeft(2, "0") + "00000000"
            Case "this month"
                query += "Time > " + currentDate.Year.ToString + currentDate.Month.ToString.PadLeft(2, "0") + "00000000 "
                query += "AND Time < " + currentDate.Year.ToString + currentDate.Month.ToString.PadLeft(2, "0") + "99000000"
            Case "morning"
                query += "Time > " + sCurrentDate + " AND Time <" + currentDate.Year.ToString + currentDate.Month.ToString.PadLeft(2, "0") + currentDate.Day.ToString.PadLeft(2, "0") + "120000"
            Case "afternoon"
                targetDate = DateAdd(DateInterval.Day, 1, currentDate)
                sTargetDate = targetDate.Year.ToString + targetDate.Month.ToString.PadLeft(2, "0") + targetDate.Day.ToString.PadLeft(2, "0") + "000000"
                query += "Time > " + currentDate.Year.ToString + currentDate.Month.ToString.PadLeft(2, "0") + currentDate.Day.ToString.PadLeft(2, "0") + "120000 "
                query += "AND Time < " + sTargetDate
            Case Else
                query += String.Format("Name LIKE '%{0}%' OR Phone LIKE '%{0}%'", cbSearch.Text)
        End Select
        DGVFill(query + " ORDER BY Time Desc LIMIT 500")
    End Sub

#End Region

#Region "Tool Strip Menu Items"


    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        If Options.Visible = False Then Options.Show() Else Options.Focus()
    End Sub

    Private Sub ShowMainWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowMainWindowToolStripMenuItem.Click
        Me.show()
    End Sub

    Private Sub HideMainWindowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideMainWindowToolStripMenuItem.Click
        Me.hide()
    End Sub

    Private Sub TrayIcon_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrayIcon.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Left And lastPhone <> "" Then
            TrayIcon.ShowBalloonTip(1, "Last Call", lastName + vbCr + lastPhone + vbCr + "Line " + lastLine.ToString, ToolTipIcon.Info)
        End If
    End Sub

    Private Sub TrayIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Me.show()
    End Sub

    Private Sub QuitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem.Click
        allowClose = True
        SaveDGVColumnWidths()
        Try
            SerialPort1.Dispose()
        Catch ex As Exception
        End Try
        Me.Close()
    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        'Dim x As New Broadcaster("255.255.255.255", 3520, "testtesttest<S>Thisisatestofthesystemthisisonlyatest")
        'x.SendMessage()
        'RecordDisplay(New CIDRecord(CIDFunctions.FakeRecordGenerator))
        'RecordDisplay(New CIDRecord("^^<U>000001<S>585858$02 O E 0876 G 00 03/03 01:09 PM 18159868200"))
        'RecordDisplay(New CIDRecord("^^<U>000001<S>585858$01 I S 0876 G 00 09/13 01:09 PM 000000000000000WWWWWWWWWWWWWWW"))
        Dim x As New Broadcaster("127.0.0.1", 3520, "<U>xxxxxx<S>xxxxxx$02 O S 0000 G A0 03/03 01:09 PM 4429169                  ")

        'RecordDisplay(New CIDRecord("^^<U>00001<S>585858$04 I S 0000 G A0 06/07 08:09 AM 770-263-7111   CallerID.com   "))
        'Export_Data()

        ' ''Dim di As New IO.DirectoryInfo(My.Application.Info.DirectoryPath + "\plugins")
        ' ''Dim aryFi As IO.FileInfo() = di.GetFiles("*.dll")
        ' ''Dim fi As IO.FileInfo

        ' ''For Each fi In aryFi
        ' ''    Dim pluginName As String = fi.Name
        ' ''    Dim NewPlugIn As IMyPlugIn = LoadPlugIn(String.Concat(My.Application.Info.DirectoryPath, "\plugins\", pluginName))
        ' ''    Debug.WriteLine(String.Concat(My.Application.Info.DirectoryPath, "\plugins\", pluginName, ".dll"))
        ' ''    'MsgBox(String.Concat(My.Application.Info.DirectoryPath, "\", cboPlugIns.Text, ".dll"))
        ' ''    If NewPlugIn IsNot Nothing Then
        ' ''        NewPlugIn.MySetting = "TestPlugInSetting" 'txtSetting.Text
        ' ''        'NewPlugIn.TestFunction(New CIDRecord("$04 I S 0000 G A0 06/07 08:09 AM 770-263-7111   CallerID.com   "))
        ' ''    End If
        ' ''Next

    End Sub


    Private Sub DGVCallList_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGVCallList.ColumnHeaderMouseClick
        If e.ColumnIndex = 2 Then
            If sortTimeDesc Then
                DGVCallList.Sort(DGVCallList.Columns.Item(6), System.ComponentModel.ListSortDirection.Descending)
                sortTimeDesc = False
            Else
                DGVCallList.Sort(DGVCallList.Columns.Item(6), System.ComponentModel.ListSortDirection.Ascending)
                sortTimeDesc = True
            End If
        End If
        RCMenu.Hide()
    End Sub

    Private Sub DGVCallList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVCallList.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then

            If DGVCallList.SelectedRows.Count > 1 Then
                CopyNameToolStripMenuItem.Enabled = False
                CopyNumberToolStripMenuItem.Enabled = False
                LookupNumberToolStripMenuItem.Enabled = False

                RCMenu.Show()

            Else

                'Dim hit As DataGridView.HitTestInfo = DGVCallList.HitTest(e.X, e.Y)
                'DGVCallList.ClearSelection()
                'If hit.RowIndex < 0 Then Exit Sub
                'DGVCallList.Rows(hit.RowIndex).Selected = True

                CopyNameToolStripMenuItem.Enabled = True
                CopyNumberToolStripMenuItem.Enabled = True
                LookupNumberToolStripMenuItem.Enabled = True

                RCMenu.Show()

            End If

        End If
    End Sub

    Private Sub DeleteRecordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteRecordToolStripMenuItem.Click

        Dim SQLconnect As New SQLiteConnection()
        Dim SQLcommand As New SQLiteCommand

        Dim f As New OpenFileDialog
        f.FileName = fDatabase

        SQLconnect.ConnectionString = "Data Source=" & f.FileName & ";"
        SQLconnect.Open()

        Dim dgvRows As DataGridViewSelectedRowCollection = DGVCallList.SelectedRows

        For Each row In dgvRows

            Dim stTime As String = row.Cells(6).Value
            Dim nLine As String = row.Cells(4).Value
            Dim stNumber As String = row.Cells(1).Value

            SQLcommand = SQLconnect.CreateCommand
            SQLcommand.CommandText = String.Format("DELETE FROM CallRecords WHERE Phone = '{0}' AND Line = '{1}' AND Time = '{2}'", stNumber, nLine, stTime)
            SQLcommand.ExecuteNonQuery()

            waitFor(30)

        Next
        
        SQLconnect.Close()
        SQLcommand.Dispose()
        SQLconnect.Dispose()

        DGVFill()

    End Sub

    ' Loops for a specificied period of time (milliseconds)
    Public Sub waitFor(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Private Sub LookupNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookupNumberToolStripMenuItem.Click
        Dim dgvRow As DataGridViewSelectedRowCollection = DGVCallList.SelectedRows
        If dgvRow.Count < 1 Then Exit Sub
        Dim stNumber As String = dgvRow.Item(0).Cells("Phone").Value
        stNumber = stNumber.Replace("-", "")
        Dim url As String = stLookupURL
        If stLookupURL = "Whitepages.com" Then url = "http://www.whitepages.com/search/ReversePhone?full_phone=%number"
        If stLookupURL = "Google" Then url = "http://www.google.com/search?q=%number"
        If stLookupURL = "Bing" Then url = "http://www.bing.com/search?q=%number"
        If System.Uri.TryCreate(url, UriKind.Absolute, Nothing) Then
            Try
                System.Diagnostics.Process.Start(url.Replace("%number", stNumber))
            Catch ex As Exception
            End Try
        Else
            GeneralMessage("The attempted URL is invalid: " + url, "Invalid URL")
        End If
        'System.Diagnostics.Process.Start(String.Format("http://www.whitepages.com/search/ReversePhone?full_phone={0}", stNumber))
    End Sub
    Public Function SaveTextToFile(ByVal strData As String, ByVal FullPath As String, Optional ByVal ErrInfo As String = "") As Boolean

        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function

    Private Sub SaveRecordToFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim dgvRow As DataGridViewSelectedRowCollection = DGVCallList.SelectedRows
        If dgvRow.Count < 1 Then Exit Sub
        Dim stTime As String = dgvRow.Item(0).Cells("RealTime").Value
        Dim nLine As String = dgvRow.Item(0).Cells("Line").Value
        Dim stNumber As String = dgvRow.Item(0).Cells("Phone").Value
        Dim f As New OpenFileDialog
        f.FileName = My.Computer.FileSystem.SpecialDirectories.Temp + "\lastcall.txt"
        SaveTextToFile(stNumber, f.FileName)

        DGVFill()
    End Sub

    Private Function LoadPlugIn(ByVal LoadPath As String) As IMyPlugIn
        Dim NewPlugIn As IMyPlugIn = Nothing
        Try
            Dim PlugInAssembly As Reflection.Assembly = Reflection.Assembly.LoadFile(LoadPath)

            Dim Types() As Type
            Dim FoundInterface As Type
            Types = PlugInAssembly.GetTypes
            For Each PlugInType As Type In Types
                FoundInterface = PlugInType.GetInterface("IMyPlugIn")
                If FoundInterface IsNot Nothing Then
                    NewPlugIn = DirectCast(PlugInAssembly.CreateInstance(PlugInType.FullName), IMyPlugIn)
                End If
            Next
        Catch ex As Reflection.ReflectionTypeLoadException
            Debug.WriteLine("Failed to load plugin")
        Catch ex As Exception
            'handle exceptions here
            Debug.WriteLine("Plugin Error: " + LoadPath)

        End Try
        Return NewPlugIn
    End Function

    Private Sub TestCallToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RecordDisplay(New CIDRecord(CIDFunctions.FakeRecordGenerator))
    End Sub


    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        My.Settings.iMainWindowHeight = Me.Height
        My.Settings.iMainWindowWidth = Me.Width
        My.Settings.Save()

    End Sub

    Private Sub SaveDGVColumnWidths()
        My.Settings.iColNameWidth = DGVCallList.Columns.Item(0).Width
        My.Settings.iColNumberWidth = DGVCallList.Columns.Item(1).Width
        My.Settings.iColTimeWidth = DGVCallList.Columns.Item(2).Width
        My.Settings.iColDurationWidth = DGVCallList.Columns.Item(3).Width
        My.Settings.iColLineWidth = DGVCallList.Columns.Item(4).Width
        My.Settings.iColIOWidth = DGVCallList.Columns.Item(5).Width
        My.Settings.Save()
    End Sub
    Private Sub LoadDGVColumnWidths()
        If My.Settings.iColNameWidth > 0 Then
            DGVCallList.Columns.Item(0).Width = My.Settings.iColNameWidth
            DGVCallList.Columns.Item(1).Width = My.Settings.iColNumberWidth
            DGVCallList.Columns.Item(2).Width = My.Settings.iColTimeWidth
            DGVCallList.Columns.Item(3).Width = My.Settings.iColDurationWidth
            DGVCallList.Columns.Item(4).Width = My.Settings.iColLineWidth
            DGVCallList.Columns.Item(5).Width = My.Settings.iColIOWidth
        End If
    End Sub

    Private Sub UserManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManualToolStripMenuItem.Click
        Help.ShowHelp(Me, Application.StartupPath & "\ELPopup Manual.chm")
    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CreateJumpList()
    End Sub
    
    Public Sub showNumberDisplay(num As String, name As String)
        showNumber.Show()
        showNumber.setNumber(num)
        showNumber.setName(Name)
        showNumber.Focus()
    End Sub

    Private Sub CopyNumberToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyNumberToolStripMenuItem.Click
        Dim dgvRow As DataGridViewSelectedRowCollection = DGVCallList.SelectedRows
        If dgvRow.Count < 1 Then Exit Sub
        Dim stNumber As String = dgvRow.Item(0).Cells("Phone").Value
        Clipboard.SetText(stNumber)
    End Sub

    Private Sub CopyNameToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CopyNameToolStripMenuItem.Click
        Dim dgvRow As DataGridViewSelectedRowCollection = DGVCallList.SelectedRows
        If dgvRow.Count < 1 Then Exit Sub
        Dim stName As String = dgvRow.Item(0).Cells("cName").Value
        Clipboard.SetText(stName)
    End Sub

    Private Sub timerKeyWatch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerKeyWatch.Tick

        Dim controlKeyPress As Boolean = GetAsyncKeyState(Keys.ControlKey)
        Dim altKeyPress As Boolean = GetAsyncKeyState(Keys.Menu)
        Dim eKeyPress As Boolean = GetAsyncKeyState(Keys.E)

        If (controlKeyPress AndAlso altKeyPress AndAlso eKeyPress) Then

            Me.show()
            Me.WindowState = FormWindowState.Normal

        End If

    End Sub

    Private Sub DGVCallList_Sorting(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGVCallList.ColumnHeaderMouseClick

        If e.ColumnIndex = 3 Then

            ' Convert to seconds
            For i = 0 To DGVCallList.Rows.Count - 1
                DGVCallList.Rows(i).Cells(3).Value = convertToSeconds(DGVCallList.Rows(i).Cells(3).Value.ToString)
            Next

            ' Sort
            If sortAscendDuration = True Then
                DGVCallList.Sort(DGVCallList.Columns(3), System.ComponentModel.ListSortDirection.Ascending)
                sortAscendDuration = False
            Else
                DGVCallList.Sort(DGVCallList.Columns(3), System.ComponentModel.ListSortDirection.Descending)
                sortAscendDuration = True
            End If

            ' Convert back to H:M:S string
            For i = 0 To DGVCallList.Rows.Count - 1
                DGVCallList.Rows(i).Cells(3).Value = convertBackToTimeDuration(Integer.Parse(DGVCallList.Rows(i).Cells(3).Value))
            Next

        End If

    End Sub

    Public Function convertBackToTimeDuration(seconds As Integer)

        Dim t As TimeSpan = TimeSpan.FromSeconds(seconds)
        Return String.Format("{0:D2}:{1:D2}:{2:D2}", t.Hours, t.Minutes, t.Seconds)

    End Function

    Public Function convertToSeconds(inStr As String)

        If inStr.Equals("00:00") Then Return 0
        
        Dim myArray() As String = inStr.Split(":")
        Dim totalSeconds As Integer = 0
        For i = 0 To myArray.Length - 1

            If myArray.Length = 3 Then

                If i = 0 Then
                    totalSeconds += myArray(i) * 3600
                End If

                If i = 1 Then
                    totalSeconds += myArray(i) * 60
                End If

                If i = 2 Then
                    totalSeconds += myArray(i)
                End If

            End If

            If myArray.Length = 2 Then

                If i = 0 Then
                    totalSeconds += myArray(i) * 60
                End If

                If i = 1 Then
                    totalSeconds += myArray(i)
                End If

            End If

        Next

        Return totalSeconds

    End Function

    Private Sub DGVCallList_ControlAdded(sender As System.Object, e As System.Windows.Forms.ControlEventArgs) Handles DGVCallList.ControlAdded
        For i = 0 To DGVCallList.Columns.Count - 1
            DGVCallList.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub DGVCallList_CellDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVCallList.CellDoubleClick

        If e.RowIndex = -1 Then Exit Sub

        For Each row In DGVCallList.SelectedRows

            Dim tempString As String = row.Cells(1).Value.ToString
            Dim tempName As String = row.Cells(0).Value.ToString
            showNumberDisplay(tempString,tempName)
            Exit For

        Next

    End Sub

    Private Sub ClearDatabaseOfALLCallsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearDatabaseOfALLCallsToolStripMenuItem.Click
        If MessageBox.Show("All calls will be deleted. Are you sure?", "Delete?", MessageBoxButtons.YesNo) = vbYes Then

            File.Delete(My.Computer.FileSystem.SpecialDirectories.CurrentUserApplicationData + "\..\CallDatabase.db3")

            MessageBox.Show("Deleted. Please restart ELPopup by right-clicking on icon in System Tray and selecting 'Quit' and then opening application again.", "Restart Required", MessageBoxButtons.OK)


        End If

    End Sub
End Class