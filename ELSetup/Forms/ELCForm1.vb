Imports System.Deployment.Application
Imports System.Diagnostics
Imports Microsoft.Build.Utilities
Imports System.Threading
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Text.RegularExpressions
Imports System.Net.Sockets

Public Class ELCForm1

    Public myUdpRepeater As UdpClient
    Public myTech As IPEndPoint = New IPEndPoint(IPAddress.Parse("72.16.182.60"), 3531)
    Public udpRepeatCode As String = "none"
    Private setToDeluxe As Boolean
    Private vCommandReturned As Boolean = False
    Public prevent8LineWarning As Boolean = False
    Public isDeluxe As Boolean = False
    Private preventDisplayOfCommData As Boolean = False
    Private searchingForUnit As Boolean = False
    Public endSearchAndExit As Boolean = False
    Private loadingIn As Boolean = True
    Public NumberOfDuplicates As Integer = 1
    Public SendingVCommands As Boolean = False

    Private dups As List(Of String)

#Region "Dimensions"
    Private Broadcast As ELCBroadcaster

    Public WithEvents UdpReceiver As New ELCUdpReceiverClass
    Public WithEvents UdpReceiver2 As New ELCUdpReceiverClass
    Private UdpReceiveThread As New System.Threading.Thread(AddressOf UdpReceiver.UdpIdleReceive)
    Private UdpReceiveThread2 As New System.Threading.Thread(AddressOf UdpReceiver2.UdpIdleReceive)

    Private myThread As New System.Threading.Thread(AddressOf EthernetLinkPing)
    Private LEthernetLink As New List(Of EthernetLinkDevice)
    Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
    Public nListeningPort As Integer = My.Settings.ListenPort
    Private stNetworkInfo As String
    Private chkMutex As New myMutex
    Private devMode As Boolean = False
#End Region

#Region "Delegates"
    Delegate Sub setTextBox_Delegate(ByVal ELink As EthernetLinkDevice)
    Delegate Sub IncomingData_Delegate(ByVal [text] As String, ByVal [textUTF7] As String)
    Delegate Sub RunSub_Delegate() 'use to delegate a sub without passing anything
    Delegate Sub AddCBItem_Delegate(ByVal [text] As String)
#End Region

#Region "Events"

    Class myMutex
        Private oMutex As Mutex
        Public Function IdentafoneInstanceRunning(ByVal UserContex As Boolean) As Boolean
            'change the id for every app you deploy ( tools ,create guid )
            Dim progid As String = "MutTracs"
            oMutex = New Mutex(False, String.Concat(progid, CStr(IIf(UserContex, System.Environment.UserName, ""))))
            If oMutex.WaitOne(0, False) = False Then
                oMutex.Close()
                Return True
                End
            End If
            oMutex.Close()
        End Function

        Public Function InstanceRunning(ByVal UserContex As Boolean) As Boolean
            'change the id for every app you deploy ( tools ,create guid )
            Dim progid As String = "MutELConfig"
            oMutex = New Mutex(False, String.Concat(progid, CStr(IIf(UserContex, System.Environment.UserName, ""))))
            If oMutex.WaitOne(0, False) = False Then
                oMutex.Close()
                Return True
                End
            End If

        End Function
    End Class

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dups = New List(Of String)

        Dim chkMutex As myMutex = New myMutex
        'Check for FoneTracs, AKA "SmartCall"
        While chkMutex.IdentafoneInstanceRunning(False)
            Dim msgResult As MsgBoxResult
            msgResult = MsgBox("SmartCall must be closed" + vbCr + vbCr + "ABORT will cancel ELConfig" + vbCr + vbCr + "RETRY will attempt to start ELConfig again. Close SmartCall before selecting this option." + vbCr + vbCr + "IGNORE will run ELConfig even if SmartCall is still running. This may cause connection problems.", MsgBoxStyle.AbortRetryIgnore, "SmartCall is running")
            If msgResult = MsgBoxResult.Abort Then Me.Close() : Exit Sub
            If msgResult = MsgBoxResult.Ignore Then Exit While
        End While
        If chkMutex.InstanceRunning(False) Then
            Me.Close()
            Exit Sub
        End If

        For Each arg As String In Environment.GetCommandLineArgs()
            'ApplicationEvents.vb responds to arguments that occur after the program is already loaded.
            If arg = "-devmode" Then
                devMode = True
                BTNChangeMacInt.Enabled = True
                BTNChangeMacInt.Text = "Change"
                tbLiteral.Visible = True
            End If
        Next

        timerSendUpdate.Start()

        UdpReceiveThread.IsBackground = True
        UdpReceiveThread2.IsBackground = True
        'UdpReceiver.nListenPort = nListeningPort
        UdpReceiver2.SetListenPorts(New Integer() {6699})
        UdpReceiver2.boundPort = 6699
        UdpReceiver2.newPort = 6699
        UdpReceiveThread2.Start()
        UdpReceiveThread.Start()

        infoBox() 'Clear the info text box
        TSPort.Text = nListeningPort.ToString

        Dim mc As New System.Management.ManagementClass("Win32_NetworkAdapterConfiguration")
        Dim nics As System.Management.ManagementObjectCollection
        nics = mc.GetInstances
        For Each nic In nics
            If nic("ipEnabled") = True Then
                Dim stSub, stIP, stInfo As String
                stSub = nic("IPSubnet")(0)
                stIP = nic("IPAddress")(0)
                stInfo = String.Format("{2}" + vbCrLf + "  Your IP is {0}." + vbCrLf + "  Your Subnet mask is {1}", stIP, stSub, nic("Caption").ToString.Substring(11))
                stNetworkInfo += stInfo + vbCrLf + vbCrLf
            End If
        Next
        'RefreshData()
        'EthernetLinkPing()

        ' Show version
        Me.Text = "Ethernet Link Config Plus - Version " + My.Application.Info.Version.ToString

        'BTNRefresh_Click(sender, e)
        RefreshData()

        vCommandReturned = False
        Timer1.Enabled = True
        Timer1.Start()

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If chkMutex.InstanceRunning(False) Then
            Exit Sub 'Only resume ELPopup when this is the last instance closing.
        End If
        Dim procList() As Process = Process.GetProcessesByName("elpopup")
        If procList.Length > 0 Then
            Dim strProcName As String = procList(0).ProcessName
            Dim iProcID As Integer = procList(0).Id
            If My.Computer.FileSystem.FileExists(procList(0).MainModule.FileName) Then
                Dim processProperties As New ProcessStartInfo
                processProperties.FileName = procList(0).MainModule.FileName
                processProperties.Arguments = "-resume"
                Dim myProcess As Process = Process.Start(processProperties)
            End If
        End If
        ProgramClosed = True
    End Sub

    Private Delegate Sub UpdateBoundPortCallback(ByVal bound As String)
    Private Sub UpdateBoundPort(ByVal bound As String)

        If Me.InvokeRequired Then
            Dim d As New UpdateBoundPortCallback(AddressOf UpdateBoundPort)
            Me.Invoke(d, New Object() {bound})
        Else

            lbListeningOn.Text = "Listening on: " + bound
            TSPort.Text = bound

        End If

    End Sub

    Private Sub DataReceivedEventHandler(ByVal sender As Object) Handles UdpReceiver.DataReceived, UdpReceiver2.DataReceived

        UpdateBoundPort(sender.boundPort.ToString)

        Dim sReceivedText As String
        Dim sReceivedTextUTF7 As String

        sReceivedText = sender.sReceivedMessage
        sReceivedTextUTF7 = sender.sReceivedMessageUTF7

        If sReceivedText.Contains("a") And
            sReceivedText.Contains("E") And
            sReceivedText.Contains("C") And
            sReceivedText.Contains("X") And
            sReceivedText.Contains("U") And
            sReceivedText.Contains("K") And
            sReceivedText.Contains("S") And
            sReceivedText.Contains("B") And
            sReceivedText.Contains("D") And
            sReceivedText.Contains("O") And
            sReceivedText.Contains("T") Then

            setToDeluxe = True

        Else
            setToDeluxe = False
        End If

        If sReceivedText.Length = 57 Then
            vCommandReturned = True
            SendingVCommands = False
            updateDeluxedLabel(True)
        End If

        If InStr(sReceivedText, "IdX") > 1 Then ' don't accept ^^IdX echos
        ElseIf sReceivedText.Length = 90 Then 'only setup information totals exactly 90 chars

            searchingForUnit = False

            Dim ELink As New EthernetLinkDevice
            ELink.ImportData(sReceivedText, sReceivedTextUTF7)
            DisplayNumberOfDups(ELink.NumberOfDuplicates)

            'Add new setup information to list
            Dim FMcount As Integer = -1
            Dim ii As Integer = 0
            'check to see if a copy already exists
            If LEthernetLink.Count > 0 Then ' make sure we have something to compare it to.
                For Each ELSerial As EthernetLinkDevice In LEthernetLink
                    If ELSerial.Serial = ELink.Serial Then
                        FMcount = ii
                    End If
                    ii += 1
                Next
            End If
            'if not, add it.
            If FMcount = -1 Then
                LEthernetLink.Add(ELink)
                If CBDetectedUnits.InvokeRequired Then
                    Dim d As New AddCBItem_Delegate(AddressOf AddCBItem)
                    Me.Invoke(d, New Object() {ELink.Serial})
                Else
                    AddCBItem(ELink.Serial) ' Add ethernet link's seral number to list.
                End If
            Else
                'if it already exists, update it in case it changed.
                LEthernetLink(FMcount) = ELink
            End If
        Else

            AddPacketLine(sReceivedText, sReceivedTextUTF7)

            udpRepeat(sReceivedText)

        End If
        sReceivedText = sReceivedText.Replace(vbCr, "?")
        sReceivedText = sReceivedText.Replace(Chr(0), "?")
        Debug.WriteLine(sReceivedText)
    End Sub

    Private Sub ListenerPortChangeHandler(ByVal sender As Object) Handles UdpReceiver.PortChanged, UdpReceiver2.PortChanged
        lbListeningOn.Text = "Listening on: " + sender.boundPort.ToString
    End Sub

    Private Sub CBDetectedUnits_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBDetectedUnits.SelectedIndexChanged
        If Not sender.SelectedItem.ToString.Contains("No") Then setTextBox(LEthernetLink(sender.SelectedIndex))
    End Sub

#End Region

#Region "ButtonClicks"
    Private Sub BTEthernetSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTEthernetSend.Click
        Dim suffix As String = ""
        If TBOutgoingMessage.Text.Length > 0 Then
            If TBOutgoingMessage.Text.Substring(0, 1) = "N" Or TBOutgoingMessage.Text.Substring(0, 1) = "Z" Or TBOutgoingMessage.Text.Substring(0, 1) = "W" Then
                suffix = vbCrLf
                BrandValue("^^Id-" + TBOutgoingMessage.Text.Replace("§", vbCr) + suffix)
            Else

                pbSendingCommand.Visible = True
                pbSendingCommand.Maximum = TBOutgoingMessage.Text.Length + 1
                pbSendingCommand.Value = 1

                For i = 0 To TBOutgoingMessage.Text.Length - 1

                    waitFor(150)
                    BrandValue("^^Id-" + TBOutgoingMessage.Text(i))
                    udpRepeat("SENT COMMAND: " + TBOutgoingMessage.Text(i))

                    If (pbSendingCommand.Value < pbSendingCommand.Maximum) Then pbSendingCommand.Value += 1

                Next

                waitFor(500)
                pbSendingCommand.Visible = False
                pbSendingCommand.Value = 0
                btnRetToggles.PerformClick()
                Return

            End If

            waitFor(500)

            udpRepeat("SENT COMMAND: " + TBOutgoingMessage.Text)

            If toggleCommand() Then btnRetToggles.PerformClick()
        End If
    End Sub

    Private Function toggleCommand() As Boolean

        If TBOutgoingMessage.Text.Contains("Z") Then Return True

        Select Case TBOutgoingMessage.Text.ToLower

            Case "e"
                Return True
            Case "c"
                Return True
            Case "x"
                Return True
            Case "u"
                Return True
            Case "d"
                Return True
            Case "a"
                Return True
            Case "s"
                Return True
            Case "o"
                Return True
            Case "b"
                Return True
            Case "k"
                Return True
            Case "t"
                Return True
            Case Else
                Return False
        End Select

    End Function

    Private Sub BTGenerateCID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TBOutgoingMessage.Text = CIDFunctions.FakeRecordGenerator

    End Sub

    Private Sub BTNRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRefresh.Click

        RefreshData()
        Timer1.Enabled = True
        Timer1.Start()
        waitFor(2000)

        If CBDetectedUnits.Items.Count = 0 Then
            Label9.Text = "No Units Found"
            Label9.Location = New Point(149, Label9.Location.Y)
            CBDetectedUnits.Visible = False
        Else
            Label9.Text = "Detected Units"
            Label9.Location = New Point(38, Label9.Location.Y)
            CBDetectedUnits.Visible = True
        End If

    End Sub
    Private Sub RefreshData()
        LEthernetLink.Clear()
        CBDetectedUnits.Items.Clear()
        TSConnectedUnits.Text = "Refreshing..."
        TBPort.Text = "????"
        'TBSN.Text = "????????????"
        TBUN.Text = "????????????"
        IPDest.Text = "?.?.?.?"
        IPInternal.Text = "?.?.?.?"
        MACDest.Text = "??-??-??-??-??-??"
        MACInternal.Text = "??-??-??-??-??-??"
        Unlock_textbox(Nothing)

        Me.Update()
        Sleep(300)
        EthernetLinkPing()

    End Sub

    Private Sub BTNChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangeUid.Click, BTNChangeIpDest.Click, BTNChangeIpInt.Click, BTNChangeMacDest.Click, BTNChangeMacInt.Click, BTNChangePort.Click

        If sender.Text = "Change" Then
            Unlock_textbox(sender)
        ElseIf sender.text = "Update" Then
            update_ELDevice(sender)
        ElseIf sender.text = "Locked" Then
            cmPassword.Show(MousePosition.X, MousePosition.Y)
        End If

    End Sub

    Private Sub BTNChange_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNChangeUid.MouseEnter, BTNChangeIpDest.MouseEnter, BTNChangeIpInt.MouseEnter, BTNChangeMacDest.MouseEnter, BTNChangeMacInt.MouseEnter, BTNChangePort.MouseEnter, _
    MACDest.MouseEnter, MACInternal.MouseEnter, IPDest.MouseEnter, IPInternal.MouseEnter, TBPort.MouseEnter, TBUN.MouseEnter, TSConnectedUnits.MouseEnter, CBDetectedUnits.MouseEnter, ResetNetworkToolStripMenuItem.MouseEnter, ResetUnitToolStripMenuItem.MouseEnter
        Select Case sender.Tag
            Case "ipdest"
                'infoBox("Destination IP", "This is the address of the device that the Whozz Calling? will send data to." + Environment.NewLine + Environment.NewLine + "255.255.255.255 is a universal address that applies to every computer on the network.")
            Case "ipint"
                'infoBox("Internal IP", "This is the address of the Whozz Calling? device itself." + Environment.NewLine + Environment.NewLine + "it is sometimes necessary for this address to be on the same subnet as the rest of your network.")
            Case "macdest"
                'infoBox("Destination MAC", "This is the physical address of the device that the Whozz Calling? will send data to." + Environment.NewLine + Environment.NewLine + "FF-FF-FF-FF-FF-FF is a universal address that works when the physical address is unknown or not applicable.")
            Case "macint"
                'infoBox("Internal MAC", "This is the physical address of the Whozz Calling? device itself." + Environment.NewLine + Environment.NewLine + "This should not be changed under normal conditions. If it must be changed, make certain the first digit remains '06' so that managed network switches will route the data correctly")
            Case "uid"
                'infoBox("Unit ID Number", "The Unit Number helps differentiate between multiple units on the same network." + Environment.NewLine + Environment.NewLine + "ELPopup ignores this value, but it may be required for other third party applications.")
            Case "sn"
                infoBox("Serial Number", "The Serial Number is unique to each unit, and broadcasted with every unit packet. It cannot be changed.")
            Case "port"
                'infoBox("Port", "This is the port number on which the Whozz Calling? sends data on." + Environment.NewLine + Environment.NewLine + "Warning: Changing the port will interrupt communication with the Ethernet Link device. Only change the port if it is necessary to do so." + Environment.NewLine + Environment.NewLine + "To change this program's listening port, select Configure > Listening Port, then change the port number.")
            Case "reseteth"
                infoBox("Network Reset", "Loads all the network defaults into the Whozz Calling? except MAC address and Serial Number.")
            Case "resetunit"
                infoBox("Unit Reset", "Loads non-network defaults into Whozz Calling? Full Featured units.")
            Case Else
                If CBDetectedUnits.Items.Count > 1 Then
                    infoBox("", "More than one Ethernet Link device has been detected. Any changes here will affect both devices at the same time. To set up only one device, disconnect all other devices first.")
                Else
                    infoBox()
                End If
        End Select
    End Sub

#End Region

#Region "ToolStrip Items"

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub

#End Region

#Region "Subs"
    Public Overloads Sub infoBox(ByVal title As String, Optional ByVal info As String = "")
        'If title.Length > 0 Then GBInfo.Text = "Info" + " (" + title + ")" Else GBInfo.Text = "Info"
        'LBLinfo.Text = info
    End Sub
    Public Overloads Sub infoBox()
        If devMode Then
            infoBox("Dev Mode", "Dev mode active. Pressing ""Enter"" will send the above text ""^^Id{TEXT}"" as a broadcast packet")
        Else
            infoBox("", "")
        End If
    End Sub

    Public Sub AddCBItem(ByVal text As String)

        CBDetectedUnits.Items.Add(text)

        If CBDetectedUnits.Items.Count > 0 Then
            For i = 0 To CBDetectedUnits.Items.Count - 1

                CBDetectedUnits.Items(i) = (CBDetectedUnits.Items(i)).ToString

            Next
        End If

        CBDetectedUnits.SelectedIndex = CBDetectedUnits.Items.Count - 1
        Select Case CBDetectedUnits.Items.Count
            Case 0
                TSConnectedUnits.Text = "No Units Detected"
            Case 1
                TSConnectedUnits.Text = "1 Unit Detected"
            Case Else
                TSConnectedUnits.Text = CBDetectedUnits.Items.Count.ToString + " Units Detected"
        End Select

    End Sub

    Public Sub setTextBox(ByVal eldFound As EthernetLinkDevice) ' populates the form with Ethernet Link data
        If TBUN.InvokeRequired Then
            Dim d As New setTextBox_Delegate(AddressOf setTextBox)
            Me.Invoke(d, New Object() {eldFound})
        Else
            Dim tmpSN As String = eldFound.Serial
            'TBSN.Text = tmpSN.Substring(0, 2) + "-" + tmpSN.Substring(2, 2) + "-" + tmpSN.Substring(4, 6) + "-" + tmpSN.Substring(10)
            TBUN.Text = eldFound.UnitID
            TBPort.Text = eldFound.DestPort
            IPInternal.Text = eldFound.IntIP
            IPDest.Text = eldFound.DestIP
            MACInternal.Text = eldFound.IntMac
            MACDest.Text = eldFound.DestMac
            If (Val(MACInternal.Text.Substring(0, 2)) Mod 2) = 1 Then 'If the MAC address is bugged, allow it to be changed
                BTNChangeMacInt.Text = "Change"
                BTNChangeMacInt.Enabled = True
            End If
        End If

    End Sub

    Public Delegate Sub DisplayNumberOfDups_Delegate(ByVal num As Integer)
    Public Sub DisplayNumberOfDups(ByVal num As Integer)
        If Me.InvokeRequired Then
            Dim d As New DisplayNumberOfDups_Delegate(AddressOf DisplayNumberOfDups)
            Me.Invoke(d, New Object() {num})
        Else
            NumberOfDuplicates = num
            If Not (num > 0 And num < 21) Then
                lbNumberOfDuplicates.Visible = False
                Exit Sub
            Else
                lbNumberOfDuplicates.Text = "# of Dups: " + num.ToString()
                lbNumberOfDuplicates.Visible = True
            End If

        End If

    End Sub


    Public Sub AddPacketLine(ByVal textString As String, ByVal textStringUTF7 As String)
        If dgvCommData.InvokeRequired Then
            Dim d As New IncomingData_Delegate(AddressOf AddPacketLine)
            Me.Invoke(d, New Object() {textString, textStringUTF7})
        Else

            If preventDisplayOfCommData Then Return

            Dim uid As String
            Dim sn As String
            uid = textString.Substring(5, 6)
            sn = textStringUTF7.Substring(14, 6)
            uid = CIDFunctions.UID_Decoder(uid)
            sn = CIDFunctions.UID_Decoder(sn)

            textString = textString.Replace(vbCr, "")
            textString = textString.Replace(vbLf, "")

            textString = textString.Replace(Chr(0), "?")

            Dim lineNumber As String = "  "
            Dim inputOutput As String = " "
            Dim startEnd As String = " "
            Dim duration As String = "    "
            Dim checkSum As String = " "
            Dim ringTypeAndNumber As String = "  "
            Dim dayMonth As String = "     "
            Dim time As String = "       "
            Dim number As String = "           "
            Dim extraNumber As String = ""

            Dim callType As Color = Color.Black

            ' Define mathces
            Dim detailedMatch As Match
            Dim regCallMatch As Match

            If ckbIgnoreDups.Checked Then

                If dups.Contains(textString) Then

                    Exit Sub

                Else

                    If dups.Count > 40 Then

                        dups.RemoveAt(0)
                        dups.Add(textString)

                    Else

                        dups.Add(textString)

                    End If

                End If

            End If

            ' Match for detailed record
            detailedMatch = Regex.Match(textString, ".*(\d\d) ([NFR]) {13}(\d\d/\d\d \d\d:\d\d:\d\d)(.*)")

            ' Match for call record
            regCallMatch = Regex.Match(textString, ".*(\d\d) ([IO]) ([ES]) (\d{4}) ([GB]) (.)(\d) (\d\d/\d\d \d\d:\d\d [AP]M) (.{8,15})(.{8,15}).*")

            '--------------------------------------------------------------
            ' MATCHES
            '--------------------------------------------------------------

            ' Detailed
            If detailedMatch.Success Then

                Dim timeMatch As Match

                callType = Color.Black

                inputOutput = detailedMatch.Groups.Item(2).Value
                lineNumber = detailedMatch.Groups.Item(1).Value
                If lineNumber.Length = 1 Then lineNumber = "0" + lineNumber

                timeMatch = Regex.Match(detailedMatch.Groups.Item(3).Value, "(\d\d\/\d\d) (\d\d:\d\d:\d\d)")

                If timeMatch.Success Then
                    dayMonth = timeMatch.Groups.Item(1).Value
                    time = timeMatch.Groups.Item(2).Value
                Else
                    dayMonth = My.Computer.Clock.LocalTime.Month.ToString + "/" + My.Computer.Clock.LocalTime.Day.ToString
                    time = My.Computer.Clock.LocalTime.ToLongTimeString
                End If


            End If

            ' Regular call
            If regCallMatch.Success = True Then

                Dim timeMatch As Match

                lineNumber = regCallMatch.Groups.Item(1).Value

                If Integer.Parse(lineNumber.Trim()) > 8 Then
                    If Not prevent8LineWarning Then
                        FrmOver8Lines.Show()
                    End If
                End If

                If lineNumber.Length = 1 Then lineNumber = "0" + lineNumber
                startEnd = regCallMatch.Groups.Item(3).Value
                inputOutput = regCallMatch.Groups.Item(2).Value
                duration = regCallMatch.Groups.Item(4).Value
                checkSum = regCallMatch.Groups.Item(5).Value
                ringTypeAndNumber = regCallMatch.Groups.Item(6).Value + regCallMatch.Groups.Item(7).Value

                timeMatch = Regex.Match(regCallMatch.Groups.Item(8).Value, "((\d\d/\d\d) (\d\d:\d\d [AP]M))")

                If timeMatch.Success Then
                    dayMonth = timeMatch.Groups.Item(2).Value
                    time = timeMatch.Groups.Item(3).Value
                Else
                    dayMonth = My.Computer.Clock.LocalTime.Month.ToString + "/" + My.Computer.Clock.LocalTime.Day.ToString
                    time = My.Computer.Clock.LocalTime.ToShortTimeString
                End If

                number = regCallMatch.Groups.Item(9).Value.Trim(" ")
                extraNumber = regCallMatch.Groups.Item(10).Value.Replace(vbCr, "").Trim(" ")

                ' Set for coloring
                If inputOutput.Contains("I") Then
                    callType = Color.Green
                ElseIf inputOutput.Contains("O") Then
                    callType = Color.Blue
                Else
                    callType = Color.Magenta
                End If

            End If

            If detailedMatch.Success = False And regCallMatch.Success = False Then
                If textString.Contains("ok") Then
                    textString = "Unit Updated"
                    dgvCommData.Rows.Add(textString)
                Else
                    dgvCommData.Rows.Add(textString.Substring(21))
                End If


                dgvCommData.FirstDisplayedCell() = dgvCommData.Item(0, dgvCommData.RowCount - 1)
            Else

                ' Add to data to grid view
                dgvPhoneData.Rows.Add()

                ' Call data
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(0).Value = lineNumber
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(0).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(1).Value = inputOutput
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(1).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(2).Value = startEnd
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(2).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(3).Value = duration
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(3).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(4).Value = checkSum
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(4).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(5).Value = ringTypeAndNumber
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(5).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(6).Value = dayMonth
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(6).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(7).Value = time
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(7).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(8).Value = number
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(8).Style.ForeColor = callType
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(9).Value = extraNumber
                dgvPhoneData.Rows.Item(dgvPhoneData.Rows.Count - 1).Cells(9).Style.ForeColor = callType

                ' Update view to last entry
                For i = dgvPhoneData.Rows.Count - 1 To 0 Step -1
                    If dgvPhoneData.Rows(i).Visible = True Then
                        dgvPhoneData.FirstDisplayedCell = dgvPhoneData.Rows(i).Cells(0)
                        Exit For
                    End If
                Next

            End If

            ' Phone data


        End If
    End Sub

    Private Sub EthernetLinkPing() ' search for Ethernet link via the ethernet.

        If (searchingForUnit) Then Return

        TSConnectedUnits.Text = "No units detected"
        CBDetectedUnits.Items.Clear()
        searchingForUnit = True
        Dim repeats As Integer = 20
        If (loadingIn) Then
            repeats = 5
            loadingIn = False
        End If

        TSConnectedUnits.Text = "Searching for units."
        pbSearching.Visible = True
        pbSearching.Maximum = repeats
        pbSearching.Value = 1

        While searchingForUnit And repeats > 0

            If Not Me.Visible Then
                Application.Exit()
                End
                Me.Close()
            End If

            If (endSearchAndExit) Then
                Application.Exit()
                End
                Me.Close()
            End If

            BrandValue("^^IdX" + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0) + Hex(0))
            repeats -= 1
            waitFor(500)

            Select Case TSConnectedUnits.Text

                Case "Searching for units."
                    TSConnectedUnits.Text = "Searching for units.."
                Case "Searching for units.."
                    TSConnectedUnits.Text = "Searching for units..."
                Case Else
                    TSConnectedUnits.Text = "Searching for units."

            End Select

            If (pbSearching.Value < pbSearching.Maximum) Then pbSearching.Value += 1

        End While

        pbSearching.Value = 0
        pbSearching.Visible = False

        If CBDetectedUnits.Items.Count > 1 Then
            TSConnectedUnits.Text = CBDetectedUnits.Items.Count.ToString + " Units Detected"
        ElseIf CBDetectedUnits.Items.Count = 1 Then
            TSConnectedUnits.Text = "1 Unit Detected"
        Else
            TSConnectedUnits.Text = "No Unit Detected"
        End If

        searchingForUnit = False
        preventDisplayOfCommData = True
        BrandValue("^^Id-V")
        waitFor(500)
        preventDisplayOfCommData = False

    End Sub

    Public Sub BrandValue(ByVal sValue As String)
        Debug.WriteLine(sValue)
        If sValue.Length = 0 Then Exit Sub
        If InStr(sValue, "?") > 0 And InStr(sValue, "Id-") = 0 Then Exit Sub
        Dim brBroadcast As New ELCBroadcaster("255.255.255.255", nListeningPort, sValue)
        brBroadcast.nListenPort = nListeningPort
        brBroadcast.SendMessage(UdpReceiver)
    End Sub

    Private Overloads Sub Unlock_textbox(ByVal null As Nullable)
        IPDest.Enabled = False
        IPInternal.Enabled = False
        MACDest.Enabled = False
        MACInternal.Enabled = False
        TBPort.ReadOnly = True
        TBUN.ReadOnly = True
        Dim btnChangeText As String = "Change"
        BTNChangeIpDest.Text = btnChangeText
        BTNChangeIpInt.Text = btnChangeText
        BTNChangeMacDest.Text = btnChangeText
        'BTNChangeMacInt.Text = btnChangeText 'This one is special. It should remain locked.
        BTNChangePort.Text = btnChangeText
        BTNChangeUid.Text = btnChangeText
    End Sub


    Private Overloads Sub Unlock_textbox(ByVal Button As Object)
        Select Case Button.name
            Case "BTNChangeIpDest"
                IPDest.Enabled = True
            Case "BTNChangeIpInt"
                IPInternal.Enabled = True
            Case "BTNChangeMacDest"
                MACDest.Enabled = True
            Case "BTNChangeMacInt"
                MACInternal.Enabled = True
            Case "BTNChangePort"
                TBPort.ReadOnly = False
            Case "BTNChangeUid"
                TBUN.ReadOnly = False
        End Select
        Button.text = "Update"
    End Sub

    Private Delegate Sub updateDeluxedLabelCallback(ByVal value As Boolean)
    Private Sub updateDeluxedLabel(ByVal value As Boolean)

        If Me.InvokeRequired Then
            Dim d As New updateDeluxedLabelCallback(AddressOf updateDeluxedLabel)
            Me.Invoke(d, New Object() {value})
        Else

            If value Then
                lbDeluxeUnit.Text = "Deluxe Unit Detected"
                lbDeluxeUnit.ForeColor = Color.Green
            Else
                lbDeluxeUnit.Text = "Deluxe Unit Not Detected"
                lbDeluxeUnit.ForeColor = Color.Maroon
            End If

        End If

    End Sub

    Private Sub update_ELDevice(ByVal Button As Object)
        Select Case Button.name
            Case "BTNChangeIpDest"
                BrandValue("^^IdD" + IPDest.HexIP)
                IPDest.Enabled = False
            Case "BTNChangeIpInt"
                BrandValue("^^IdI" + IPInternal.HexIP)
                IPInternal.Enabled = False
            Case "BTNChangeMacDest"
                Dim sendCommand As String = "^^IdC" + MACDest.Text.Replace("-", "")
                BrandValue(sendCommand)
                MACDest.Enabled = False
            Case "BTNChangeMacInt"
                BrandValue("^^IdM" + MACInternal.Text.Replace("-", ""))
                MACInternal.Enabled = False
            Case "BTNChangePort"

                ChangedPort(TBPort, False)

            Case "BTNChangeUid"
                BrandValue("^^IdU" + TBUN.Text.PadLeft(12, "0"))
                TBUN.ReadOnly = True
        End Select
        Button.text = "Change"
    End Sub

#End Region

    Private Sub TMIManual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TMIManual.Click
        Help.ShowHelp(Me, Application.StartupPath & "\ELConfig Manual.chm")
    End Sub

    Private Sub TSPort_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TSPort.KeyPress
        If e.KeyChar = Chr(13) Or e.KeyChar = Chr(10) Then ChangedPort(sender, True)
    End Sub

    Private Sub ChangedPort(ByVal sender As Object, ByVal pressAlt As Boolean)

        Try
            Integer.Parse(sender.Text)
        Catch ex As Exception
            MessageBox.Show("Incorrect port - must be numbers only")
            Return
        End Try

        If sender.Text = "6699" Then

            BrandValue("^^IdT" + Hex(Val(sender.Text)).PadLeft(4, "0"))
            If pressAlt Then SendKeys.SendWait("%")
            waitFor(50)
            BTNRefresh_Click(New Object(), New EventArgs())
            Exit Sub

        End If

        BrandValue("^^IdT" + Hex(Val(sender.Text)).PadLeft(4, "0"))
        UdpReceiver.newPort = sender.Text
        UdpReceiver.listening = False
        TBPort.ReadOnly = True
        'LBLinfo.Text = ""
        waitFor(300)
        EthernetLinkPing()
        TBPort.Text = sender.Text

        If pressAlt Then SendKeys.SendWait("%")
        waitFor(50)
        BTNRefresh_Click(New Object(), New EventArgs())

    End Sub


    Private Sub ResetUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetUnitToolStripMenuItem.Click
        BrandValue("^^Id-N0000007701")
        Sleep(100)
        BrandValue("^^Id-R")
        'Dim CharStream As String = "ECXUdASobKT"
        'While CharStream.Length > 0
        ' BrandValue("^^Id-" + CharStream.Substring(0, 1))
        ' If CharStream.Length > 0 Then CharStream = CharStream.Substring(1) Else CharStream = ""
        ' Sleep(100)
        'End While
    End Sub

    Private Sub ChangedPort(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSPort.LostFocus

    End Sub

    Private Sub DisplayComputersIPAddressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayComputersIPAddressToolStripMenuItem.Click
        MsgBox("Your IP: " + getMyIP())
    End Sub

    ' Returns computer IP address
    Public Function getMyIP()

        Dim strHostName As String
        Dim strIPAddress As String
        strHostName = System.Net.Dns.GetHostName()
        strIPAddress = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString
        Return strIPAddress

    End Function

    Private Sub ResetNetworkToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetNetworkToolStripMenuItem.Click
        'BrandValue("")
        BrandValue("^^IdDFFFFFFFF") 'External IP
        Sleep(400)
        BrandValue("^^IdU000000000001") 'Unit ID
        Sleep(400)
        BrandValue("^^IdIC0A8005A") 'Internal IP
        Sleep(400)
        BrandValue("^^IdCFFFFFFFFFFFF") ' Destination MAC address
        'Sleep(400)
        'BrandValue("^^IdM0620101332CC") 'Internal MAC address
        Sleep(400)
        BrandValue("^^IdT0DC0") 'Port Number
        Sleep(400)
        'BrandValue("^^Id-R")
    End Sub

    Private Sub tsPassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tsPassword.KeyUp
        If tsPassword.Text.Length >= 8 Then
            If tsPassword.Text.ToLower.Substring(0, 8) = "callerid" Then 'Super secret password on an open source project. Keep it between us programers. Don't tell the 'normals'. Or do. Whatever.
                cmPassword.Hide()
                BTNChangeMacInt.Enabled = True
                BTNChangeMacInt.Text = "Change"
                BTNChange_Click(BTNChangeMacInt, Nothing)
            End If
        End If
    End Sub

    Private Sub DGVCallData_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim activeRows = dgvCommData.SelectedRows
        My.Computer.Clipboard.SetText(activeRows.Item(0).Cells(2).ToString())
    End Sub


    Private Sub Upload_Debug_Data(Optional ByVal save As Boolean = False)
        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim address As Uri
        Dim data As StringBuilder
        Dim byteData() As Byte
        Dim postStream As Stream = Nothing

        address = New Uri("http://pastebin.com/api/api_post.php")

        ' Create the web request  
        request = DirectCast(WebRequest.Create(address), HttpWebRequest)

        ' Set type to POST  
        request.Method = "POST"
        request.ContentType = "application/x-www-form-urlencoded"

        ' Generate XML
        Dim settings As New XmlWriterSettings
        settings.Indent = True
        settings.IndentChars = "  "
        settings.NewLineOnAttributes = True
        Dim rows As DataGridViewRowCollection = dgvPhoneData.Rows
        Dim memStream As MemoryStream = New MemoryStream()
        Dim writer As XmlWriter = XmlWriter.Create(memStream, settings)
        writer.WriteStartDocument()
        writer.WriteStartElement("ELConfig")
        writer.WriteElementString("Time_Recorded", DateTime.Now.ToString("dddd, dd MMMM yyyy hh:mm tt"))
        writer.WriteElementString("PC_Name", My.Computer.Name)
        writer.WriteElementString("User", My.User.Name)
        writer.WriteElementString("Operating_System", My.Computer.Info.OSFullName)
        writer.WriteElementString("Ethernet_Links_Detected", LEthernetLink.Count.ToString)


        For Each eth As EthernetLinkDevice In LEthernetLink
            writer.WriteStartElement("Ethernet_Link")
            writer.WriteElementString("Serial_Number", eth.Serial)
            writer.WriteElementString("Unit_ID", eth.UnitID)
            writer.WriteElementString("Destination_IP", eth.DestIP)
            writer.WriteElementString("Destination_MAC", eth.DestMac)
            writer.WriteElementString("Destination_Port", eth.DestPort)
            writer.WriteElementString("Internal_IP", eth.IntIP)
            writer.WriteElementString("Internal_MAC", eth.IntMac)
            writer.WriteElementString("Internal_Port", eth.IntPort)
            writer.WriteEndElement()
        Next

        writer.WriteStartElement("Output")
        For Each row As DataGridViewRow In rows
            writer.WriteStartElement("Incoming_Data")
            writer.WriteAttributeString("serial", row.Cells.Item(0).Value)
            writer.WriteString(row.Cells.Item(2).Value)
            writer.WriteEndElement()
        Next
        writer.WriteEndElement()

        writer.WriteEndElement()
        writer.WriteEndDocument()
        writer.Flush()
        writer.Close()

        reader = New StreamReader(memStream)
        memStream.Position = 0
        Dim xmlString As String = reader.ReadToEnd
        If save Then
            Dim saveFile As SaveFileDialog = New SaveFileDialog
            saveFile.CreatePrompt = True
            saveFile.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            saveFile.FileName = "ELConfig_Debug"
            saveFile.Filter = "XML (*.xml) | *.xml| (*.txt) |*.txt"
            If saveFile.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim outfile As New StreamWriter(saveFile.FileName)
                outfile.Write(xmlString)
                outfile.Flush()
                outfile.Close()
            End If

        End If

        If Not save Then
            ' Create the data we want to send  
            data = New StringBuilder()
            data.Append("api_option=" + HttpUtility.UrlEncode("paste"))
            data.Append("&api_dev_key=" + HttpUtility.UrlEncode("c0f83a93e6f40b94afe5eed045a0b0e7"))
            data.Append("&api_user_key=" + HttpUtility.UrlEncode("b8e36fab93a87994d81b674b6d772cd3"))
            data.Append("&api_paste_code=" + HttpUtility.UrlEncode(xmlString))
            data.Append("&api_paste_name=" + HttpUtility.UrlEncode("EC-" + My.Computer.Name))
            data.Append("&api_paste_expire_date=" + HttpUtility.UrlEncode("1H"))
            data.Append("&api_paste_private=" + HttpUtility.UrlEncode("1"))
            data.Append("&api_paste_format=" + HttpUtility.UrlEncode("xml"))

            ' Create a byte array of the data we want to send  
            byteData = UTF8Encoding.UTF8.GetBytes(data.ToString())

            ' Set the content length in the request headers  
            request.ContentLength = byteData.Length

            ' Write data  
            Try
                postStream = request.GetRequestStream()
                postStream.Write(byteData, 0, byteData.Length)
            Finally
                If Not postStream Is Nothing Then postStream.Close()
            End Try

            Try
                ' Get response  
                response = DirectCast(request.GetResponse(), HttpWebResponse)

                ' Get the response stream into a reader  
                reader = New StreamReader(response.GetResponseStream())

                ' Console application output  
                MsgBox("Data has been sent to CallerID.com via " + reader.ReadToEnd + " and will be avaliable for 1 hour." + vbCrLf + "Contact CallerID.com Tech Support at 800.240.4637.", MsgBoxStyle.Information, "Uploaded")
                'Console.WriteLine(reader.ReadToEnd())
            Finally
                If Not response Is Nothing Then response.Close()
            End Try
        End If
    End Sub

    Private Sub UploadDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadDataToolStripMenuItem.Click
        Upload_Debug_Data()
    End Sub

    Private Sub SaveDataLocallyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveDataLocallyToolStripMenuItem.Click

        sfdSaveLocal.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If sfdSaveLocal.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim outputString As New List(Of String)

            Dim start As Integer = 0

            For Each row As DataGridViewRow In dgvPhoneData.Rows()
                outputString.Add(row.Cells(start + 1).Value.ToString + " " + row.Cells(start + 2).Value.ToString + " " + row.Cells(start + 3).Value.ToString + " " + row.Cells(start + 4).Value.ToString + " " + row.Cells(start + 5).Value.ToString + " " + row.Cells(start + 6).Value.ToString + " " + row.Cells(start + 7).Value.ToString + " " + row.Cells(start + 8).Value.ToString + " " + row.Cells(start + 9).Value.ToString)
            Next

            ' Write the string array to a new file named "WriteLines.txt".
            Using outputFile As New StreamWriter(sfdSaveLocal.FileName)
                For Each line As String In outputString
                    outputFile.WriteLine(line + Environment.NewLine)
                Next
            End Using

        End If

        'Upload_Debug_Data(True)
    End Sub

    Private Sub SetUnitToCurrentTimeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetUnitToCurrentTimeToolStripMenuItem.Click
        BrandValue("^^Id-N0000007701" + vbCrLf)
        Sleep(100)
        Dim t As Date = Now
        Dim timeString As String
        timeString = t.Month.ToString.PadLeft(2, "0") + t.Day.ToString.PadLeft(2, "0") + t.Hour.ToString.PadLeft(2, "0") + t.Minute.ToString.PadLeft(2, "0")
        timeString = "^^Id-Z" + timeString + Chr(13)
        BrandValue(timeString)
        Me.Focus()
        waitFor(1000)
        BrandValue("^^Id-V")

    End Sub

    Private Sub SetUnitLineCountTo1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        BrandValue("^^Id-N0000007701" + vbCrLf)
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    Private Sub tbLiteral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbLiteral.KeyPress
        If Asc(e.KeyChar) = 13 Then
            BrandValue("^^Id" + tbLiteral.Text)
            e.Handled = True
        End If

    End Sub

    Private Sub btnRetToggles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRetToggles.Click

        SendingVCommands = True
        Dim sendString As String = "^^Id-V"

        Dim tries As Integer = 10
        While SendingVCommands And tries > 0

            BrandValue(sendString)
            tries -= 1
            waitFor(200)

        End While

    End Sub

    Private Sub btnClearCommData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearCommData.Click
        dgvCommData.Rows.Clear()
    End Sub

    Private Sub btnClearPhoneData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPhoneData.Click
        dgvPhoneData.Rows.Clear()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        BrandValue("^^Id-N0000007705" + vbCrLf)
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        BrandValue("^^Id-N0000007709" + vbCrLf)
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    ' Repeats on 3521 port
    Public Sub udpRepeat(ByVal myMessage As String)

        Try

            If rbTech1.Checked = True Then

                myTech = New IPEndPoint(IPAddress.Parse("72.16.182.60"), 3531)

            ElseIf rbTech2.Checked = True Then

                myTech = New IPEndPoint(IPAddress.Parse("72.16.182.60"), 3532)

            ElseIf rbTech3.Checked = True Then

                myTech = New IPEndPoint(IPAddress.Parse("72.16.182.60"), 3534)

            Else

                Exit Sub

            End If

            ' Connect
            myUdpRepeater = New UdpClient
            myUdpRepeater.Connect(myTech)

            ' Declare local variables
            Dim dataToSend() As Byte

            ' Encode message
            dataToSend = Encoding.ASCII.GetBytes("<" + udpRepeatCode + ">" + myMessage)

            ' Send message
            myUdpRepeater.Send(dataToSend, dataToSend.Length)

            myUdpRepeater.Close()

        Catch ex As Exception

            MsgBox("Exceptions: " + ex.ToString, vbOKOnly, "Exception Thrown")

        End Try

    End Sub

    Private Sub timerSendUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerSendUpdate.Tick

        Dim sendString As String = "<1>" + CBDetectedUnits.Text + "</1>"
        sendString += "<2>upgraded ELConfig</2>"
        sendString += "<3>" + TBUN.Text + "</3>"
        sendString += "<4>" + IPInternal.Text + "</4>"
        sendString += "<5>" + MACInternal.Text + "</5>"
        sendString += "<6>" + TBPort.Text + "</6>"
        sendString += "<7>" + IPDest.Text + "</7>"
        sendString += "<8>" + MACDest.Text + "</8>"
        sendString += "<9>" + getMyIP() + "</9>"
        sendString += "<10>" + lbDeluxeUnit.Text + "</10>"
        sendString += "<11>" + lbListeningOn.Text + "</11>"

        Dim dups As Match = Regex.Match(lbNumberOfDuplicates.Text, "\d{1,2}")

        If (dups.Success) Then
            sendString += "<12>" + dups.Groups(0).Value.ToString() + "</12>"
        End If

        udpRepeat(sendString)

    End Sub

    Private Sub tech_change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTech1.Click, rbTech2.Click, rbTech3.Click

        Dim myResponse As MsgBoxResult = MsgBox("This option sends raw data to a CallerID.com technician but only if they establish the connection. Are you in contact with a CallerID.com representative?", vbYesNo, "Connect")

        udpRepeatCode = InputBox("Enter code supplied by CallerID.com:", "Enter Code", "")

        If myResponse = vbYes Then

            If sender.Equals(rbTech1) Then
                rbTech1.Checked = True
                rbTech2.Checked = False
                rbTech3.Checked = False
                rbTechNone.Checked = False
            End If

            If sender.Equals(rbTech2) Then
                rbTech1.Checked = False
                rbTech2.Checked = True
                rbTech3.Checked = False
                rbTechNone.Checked = False
            End If


            If sender.Equals(rbTech3) Then
                rbTech1.Checked = False
                rbTech2.Checked = False
                rbTech3.Checked = True
                rbTechNone.Checked = False
            End If

        Else

            rbTech1.Checked = False
            rbTech2.Checked = False
            rbTech3.Checked = False
            rbTechNone.Checked = True

        End If

    End Sub

    Private Sub rbTechNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTechNone.Click
        rbTech1.Checked = False
        rbTech2.Checked = False
        rbTech3.Checked = False
        rbTechNone.Checked = True
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        BrandValue("^^Id-N0000007711" + vbCrLf)
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        BrandValue("^^Id-N0000007715" + vbCrLf)
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        BrandValue("^^Id-N0000007719" + vbCrLf)
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        BrandValue("^^Id-N0000007721" + vbCrLf)
        Sleep(100)
        BrandValue("^^Id-V")
    End Sub

    Private Sub SetDeluxeUnitToBasicUnitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetDeluxeUnitToBasicUnitToolStripMenuItem.Click

        BrandValue("^^Id-a")
        waitFor(100)
        BrandValue("^^Id-E")
        waitFor(100)
        BrandValue("^^Id-C")
        waitFor(100)
        BrandValue("^^Id-X")
        waitFor(100)
        BrandValue("^^Id-U")
        waitFor(100)
        BrandValue("^^Id-K")
        waitFor(100)
        BrandValue("^^Id-S")
        waitFor(100)
        BrandValue("^^Id-B")
        waitFor(100)
        BrandValue("^^Id-D")
        waitFor(100)
        BrandValue("^^Id-O")
        waitFor(100)
        BrandValue("^^Id-T")
        waitFor(100)
        BrandValue("^^Id-a")
        waitFor(100)
        BrandValue("^^Id-V")
        waitFor(500)

        If setToDeluxe Then
            MessageBox.Show("Deluxe Unit now set to Basic Output Format.", "Deluxe Unit Set", MessageBoxButtons.OK)
        Else
            MessageBox.Show("Error:  Cannot set format, contact CallerID.com rep.", "Deluxe Unit NOT Set", MessageBoxButtons.OK)
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Stop()
        If TBUN.Text.Contains("?") Then
            FrmNoUnitsFoundTroubleShooting.Show()
        End If

        'TSPort.Text = UdpReceiver.boundPort.ToString

    End Sub

    Private Sub SendDuplicateCallRecordsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendDuplicateCallRecordsToolStripMenuItem.Click
        FrmDuplicates.ShowDialog()
    End Sub

    Private Sub BTNChangeUid_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangeUid.MouseHover
        Me.ttUnitNumber.SetToolTip(BTNChangeUid, "The Unit Number helps differentiate between " + Environment.NewLine + "multiple units on the same network." + Environment.NewLine + Environment.NewLine + "ELPopup ignores this value, but it may be required " + Environment.NewLine + "for other third party applications.")
    End Sub

    Private Sub BTNChangeIpInt_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangeIpInt.MouseHover
        Me.ttUnitIP.SetToolTip(BTNChangeIpInt, "This is the address of the Whozz Calling? device itself." + Environment.NewLine + Environment.NewLine + "It is sometimes necessary for this address to be on the" + Environment.NewLine + "same subnet as the rest of your network.")
    End Sub

    Private Sub BTNChangeMacInt_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangeMacInt.MouseHover
        Me.ttUnitMac.SetToolTip(BTNChangeMacInt, "This is the physical address of the Whozz Calling? device itself." + Environment.NewLine + Environment.NewLine + "This should not be changed under normal conditions. If it must" + Environment.NewLine + "be changed, make certain the first digit remains '06' so that managed" + Environment.NewLine + "network switches will route the data correctly.")
    End Sub

    Private Sub BTNChangePort_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangePort.MouseHover
        Me.ttPort.SetToolTip(BTNChangePort, "This is the port number on which the Whozz Calling? sends data on." + Environment.NewLine + Environment.NewLine + "Warning: Changing the port will interrupt communication with the" + Environment.NewLine + "Ethernet Link device. Only change the port if it is necessary to do so." + Environment.NewLine + Environment.NewLine + "To change this program's listening port, select Configure > Listening Port," + Environment.NewLine + "then change the port number.")
    End Sub

    Private Sub BTNChangeIpDest_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangeIpDest.MouseHover
        Me.ttDestIP.SetToolTip(BTNChangeIpDest, "This is the address of the device that the Whozz Calling? will send data to." + Environment.NewLine + Environment.NewLine + "255.255.255.255 is a universal address that applies to every computer on the network.")
    End Sub

    Private Sub BTNChangeMacDest_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNChangeMacDest.MouseHover
        Me.ttDestMAC.SetToolTip(BTNChangeMacDest, "This is the physical address of the device that the Whozz Calling? will send data to." + Environment.NewLine + Environment.NewLine + "FF-FF-FF-FF-FF-FF is a universal address that works when the " + Environment.NewLine + "physical address is unknown or not applicable.")
    End Sub
End Class

