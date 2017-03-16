Imports System.Text.RegularExpressions


Public Class Options

    Public dgvReset As Boolean = False
    Public downloadMode As Integer = 0
    Public wc2Enabled As Boolean = False
    Public tabStorage As TabPage
    Public origURLlength As Integer = 0
    Public bLoading = True
    Private Sub Options_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PopulateForm()
        ckbUseCompTime.Checked = My.Settings.useCompTime
    End Sub

    Private Sub PopulateForm()
        bLoading = True
        '8 Line Support
        If My.Settings.b8LineEver Then
            lbl8Line.Visible = True
            btn8LineRevert.Visible = True
            help8LineRevert.Visible = True
        Else
            lbl8Line.Visible = False
            btn8LineRevert.Visible = False
            help8LineRevert.Visible = False
        End If

        origURLlength = cbLookupURL.Items.Count
        Dim cbIndex As Integer = cbLookupURL.Items.IndexOf(My.Settings.lookupURL)
        If cbIndex > -1 Then
            cbLookupURL.SelectedIndex = cbIndex
        Else
            cbLookupURL.Items.Add(My.Settings.lookupURL)
            cbLookupURL.SelectedIndex = origURLlength
        End If


        If My.Settings.bLargeWindow = True Then btn8LineRevert.Enabled = True Else btn8LineRevert.Enabled = False

        Try
            If Not wc2Enabled Then
                tabStorage = TabControl1.TabPages(4)
                TabControl1.Controls.Remove(tabStorage)
            End If
        Catch ex As Exception
        End Try
        'Version Number

        Dim assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly
        Dim assemblyName As System.Reflection.AssemblyName = assembly.GetName
        Dim version As Version = assemblyName.Version
        lblVersion.Text = "v" + version.Major.ToString + "." + version.Minor.ToString + "." + version.Build.ToString
        ToolTip1.SetToolTip(lblVersion, version.ToString)

        txtFilePath.Text = Form1.fLog
        If Form1.LogLevel > 0 Then chkLog.Checked = True Else chkLog.Checked = False
        If Form1.LogLevel > 1 Then chkLogLevel2.Checked = True Else chkLogLevel2.Checked = False

        chkOutboundPopup.Checked = Form1.bOutboundPopup
        chkInboundPopup.Checked = Form1.bInboundPopup

        NUDTimer.Value = Form1.nPopupTimer

        cbSerial.Items.Clear()
        cbSerial.Items.Add("Do Not Use Serial Server")
        If My.Settings.sSerialPort = "none" Then cbSerial.SelectedIndex = cbSerial.Items.Count - 1
        For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
            cbSerial.Items.Add(My.Computer.Ports.SerialPortNames.Item(i))
            If My.Settings.sSerialPort = cbSerial.Items.Item(cbSerial.Items.Count - 1) Then
                cbSerial.SelectedIndex = cbSerial.Items.Count - 1
            End If
        Next

        Form1.DownloadWC2(1)

        Select Case My.Settings.sIpRelay
            Case "none"
                cbIpRelay.Text = "Do Not Relay Data"
            Case "255.255.255.255"
                cbIpRelay.Text = "Entire LAN (255.255.255.255)"
            Case "127.0.0.1"
                cbIpRelay.Text = "Localhost (127.0.0.1)"
            Case Else
                cbIpRelay.Text = My.Settings.sIpRelay
        End Select
        If Form1.pluginList.Count > 0 Then
            lbPlugins.Items.Clear()
        End If

        For Each plugIn As CIDClass.IMyPlugIn In Form1.pluginList
            lbPlugins.Items.Add(plugIn.PluginName)
        Next

        mtbAreaCode.Text = My.Settings.sAreaCode
        updateComStatus()
        updateRelayStatus()
        bLoading = False
    End Sub

    Public Sub AddWc2Tab()
        If Form1.WC2Download.maxDownloads > 0 Then
            TabControl1.Controls.Add(tabStorage)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim f As New SaveFileDialog
        f.DefaultExt = "log"
        f.CreatePrompt = False
        f.FileName = "CallerID.log"
        f.Filter = "log file|*.log|All Files|*.*"
        f.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        f.ShowDialog()

        txtFilePath.Text = f.FileName
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Form1.Export_Data()
    End Sub

    Private Sub cbRelayEnabled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.checked = True Then
            cbIpRelay.Enabled = True
        Else
            cbIpRelay.Enabled = False
        End If
    End Sub


    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Form1.usingCompTime = My.Settings.useCompTime
        My.Settings.useCompTime = False
        Form1.WC2Download.allDownloads = 0
        Form1.WC2Download.dupeDownloads = 0
        Form1.WC2Download.newDownloads = 0
        Form1.WC2Download.errorDownloads = 0
        downloadMode = 1
        dgvReset = False
        Form1.DownloadWC2()

        waitFor(6000)
        My.Settings.useCompTime = Form1.usingCompTime

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

    Private Sub UpdateGUI()

        If Form1.WC2Download.connected Then
            If Not wc2Enabled Then
                AddWc2Tab()
                wc2Enabled = True
                Form1.CreateJumpList(DownloadProgress.Value, DownloadProgress.Maximum)
                Debug.WriteLine(DownloadProgress.Value.ToString + " : " + DownloadProgress.Maximum.ToString)
            End If

            lblReceiveTest.Text = Form1.WC2Download.indxDownloads.ToString + " of " + Form1.WC2Download.maxDownloads.ToString
            lblDupeNew.Text = Form1.WC2Download.dupeDownloads.ToString + " Duplicates, " + Form1.WC2Download.newDownloads.ToString + " New"
            If Form1.WC2Download.indxDownloads >= Form1.WC2Download.maxDownloads And Form1.WC2Download.allDownloads > 0 Then
                downloadMode = 2
                Form1.WC2Download.indxDownloads = Form1.WC2Download.maxDownloads
            End If
            DownloadProgress.Maximum = Form1.WC2Download.maxDownloads
            DownloadProgress.Value = Form1.WC2Download.indxDownloads
            Form1.CreateJumpList(DownloadProgress.Value, DownloadProgress.Maximum)

            If downloadMode = 2 And Not dgvReset Then
                Form1.DGVFill()
                dgvReset = True
                If chkAutoErase.Checked Then
                    If Form1.WC2Download.errorFlag Then
                        MsgBox("There was a problem downloading " + Form1.WC2Download.errorDownloads.ToString + " of the call records. Auto erase has been disabled. You may still erase the WC2 manually." + vbCrLf + "The error was: " + Form1.WC2Download.errorMessage)
                    Else
                        Form1.EraseWC2()
                    End If
                End If
            End If
            
        End If
    End Sub
    Private Sub tiGUI_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tiGUI.Tick
        UpdateGUI()
    End Sub

    Private Sub btnManualErase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnManualErase.Click
        Dim reply As DialogResult = MessageBox.Show("Are you sure? Erasing the WC2 is permanent.", "Are you sure you want to erase?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If reply = Windows.Forms.DialogResult.OK Then
            Form1.EraseWC2()
        End If
    End Sub

    Private Sub NUDTimer_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUDTimer.ValueChanged
        If bLoading = False Then
            Form1.nPopupTimer = NUDTimer.Value
            My.Settings.nPopupTimer = Form1.nPopupTimer
            My.Settings.Save()
            Form1.ClearPopups()
            Form1.PopupLite(NUDTimer.Value.ToString + " Second Popup Sample", 3)
            Form1.PopupLite(New CIDClass.CIDRecord("04" + CIDClass.CIDFunctions.FakeRecordGenerator().Substring(2)))
        End If
    End Sub

    Private Sub chkInboundPopup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInboundPopup.CheckedChanged
        If bLoading = False Then
            Form1.ClearPopups()
            If chkInboundPopup.Checked Then
                Form1.bInboundPopup = True
                Form1.PopupLite("Inbound Popups Turned ON", 1)
            Else
                Form1.bInboundPopup = False
            End If
            My.Settings.bOutboundPopup = Form1.bOutboundPopup
            My.Settings.bInboundPopup = Form1.bInboundPopup
            My.Settings.Save()
        End If
    End Sub

    Private Sub chkOutboundPopup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkOutboundPopup.CheckedChanged
        If bLoading = False Then
            If chkOutboundPopup.Checked Then
                Form1.bOutboundPopup = True
                Form1.PopupLite("Outbound Popups Turned ON", 2)
            Else
                Form1.bOutboundPopup = False
            End If
            My.Settings.bOutboundPopup = Form1.bOutboundPopup
            My.Settings.bInboundPopup = Form1.bInboundPopup
            My.Settings.Save()
        End If
    End Sub

    Private Sub btn8LineRevert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn8LineRevert.Click
        My.Settings.bLargeWindow = False
        My.Settings.nWindowSize = 4
        My.Settings.Save()
        Form1.Label6.Visible = False
        Form1.Label7.Visible = False
        Form1.Label8.Visible = False
        Form1.Label9.Visible = False
        Form1.txtLine5.Visible = False
        Form1.txtLine6.Visible = False
        Form1.txtLine7.Visible = False
        Form1.txtLine8.Visible = False
        btn8LineRevert.Enabled = False

        '12 line
        Form1.Label13.Visible = False
        Form1.Label10.Visible = False
        Form1.Label11.Visible = False
        Form1.Label12.Visible = False
        Form1.txtLine9.Visible = False
        Form1.txtLine10.Visible = False
        Form1.txtLine11.Visible = False
        Form1.txtLine12.Visible = False

    End Sub

    Private Sub cbSerial_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSerial.SelectedIndexChanged
        If bLoading = False Then
            Form1.sSerial = cbSerial.Text
            Dim errorMessage As String = ""
            If cbSerial.SelectedIndex <> 0 Then
                errorMessage = Form1.startSerialServer()
                My.Settings.sSerialPort = cbSerial.Text
            Else
                My.Settings.sSerialPort = "none"
                Form1.SerialPort1.Close()
            End If
            My.Settings.Save()
            updateComStatus(errorMessage)
            updateRelayStatus()
            Form1.DownloadWC2(1)
        End If
    End Sub

    Private Sub cbIpRelay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbIpRelay.TextChanged
        If bLoading = False Then
            Dim ipMatch As System.Text.RegularExpressions.Match
            cbIpRelay.Text = cbIpRelay.Text.Trim
            Select Case cbIpRelay.Text
                Case "Do Not Relay Data"
                    Form1.sIpRelay = "none"
                    My.Settings.sIpRelay = "none"
                Case "Entire LAN (255.255.255.255)"
                    Form1.sIpRelay = "255.255.255.255"
                    My.Settings.sIpRelay = "255.255.255.255"
                Case "Localhost (127.0.0.1)"
                    Form1.sIpRelay = "127.0.0.1"
                    My.Settings.sIpRelay = "127.0.0.1"
                Case Else
                    ipMatch = Regex.Match(cbIpRelay.Text, "(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
                    If Not ipMatch.Success Then
                        Form1.sIpRelay = "none"
                        My.Settings.sIpRelay = "none"
                    Else 'if it's a correct IP
                        Form1.sIpRelay = cbIpRelay.Text
                        My.Settings.sIpRelay = cbIpRelay.Text
                    End If
            End Select
            My.Settings.Save()
        End If
        updateRelayStatus()
        updateComStatus()
    End Sub

    Private Sub updateComStatus(Optional ByVal errorMessage As String = "")
        If Form1.SerialPort1.IsOpen Then
            lblComStatus.Text = "Connected OK on " + Form1.SerialPort1.PortName
        Else
            lblComStatus.Text = "Serial port not connected"
        End If
        If errorMessage <> "" Then
            lblComStatus.Text = errorMessage
        End If
    End Sub

    Private Sub updateRelayStatus()

        Dim ipMatch As System.Text.RegularExpressions.Match
        If Not Form1.SerialPort1.IsOpen Then
            lblRelayStatus.Text = "Relay turned off (No Serial Connection)"
        Else
            Select Case Form1.sIpRelay
                Case "none"
                    ipMatch = Regex.Match(cbIpRelay.Text, "(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")
                    If Not ipMatch.Success Then
                        lblRelayStatus.Text = "Relay turned off, IP address not valid"
                    End If
                    lblRelayStatus.Text = "Relay turned off"
                Case "255.255.255.255"
                    lblRelayStatus.Text = "Relaying data to all LAN addresses"
                Case "127.0.0.1"
                    lblRelayStatus.Text = "Relaying data to this computer (over network)"
                Case Else
                    lblRelayStatus.Text = "Relaying data to " + Form1.sIpRelay
            End Select
        End If 'Serial
    End Sub

    Private Sub chkLog_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLog.CheckedChanged, chkLogLevel2.CheckedChanged
        If Not bLoading Then
            If chkLog.Checked = False Then Form1.LogLevel = 0
            If chkLog.Checked = True Then Form1.LogLevel = 1
            If chkLogLevel2.Checked = True Then Form1.LogLevel = 2
            My.Settings.LogLevel = Form1.LogLevel
            My.Settings.Save()
        End If
    End Sub

    Private Sub txtFilePath_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilePath.TextChanged
        If Not bLoading Then
            Form1.fLog = txtFilePath.Text
            My.Settings.fLog = Form1.fLog
        End If
    End Sub

    Private Sub mtbAreaCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbAreaCode.TextChanged
        If Not bLoading Then
            Form1.sAreaCode = mtbAreaCode.Text
            My.Settings.sAreaCode = Form1.sAreaCode
            My.Settings.Save()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Dim messageResult As MsgBoxResult
        Dim confirmMessage As String
        If Form1.SerialPort1.IsOpen Then
            confirmMessage = "Are you sure you want to reset all the options?" + vbCrLf + "Don't forget which COM port your box is connected to (Currently " + _
            Form1.SerialPort1.PortName + ")."
        Else
            confirmMessage = "Are you sure you want to reset all the options?"
        End If
        messageResult = MsgBox(confirmMessage, MsgBoxStyle.OkCancel, "Are you sure?")
        If messageResult = MsgBoxResult.Ok Then
            My.Settings.Reset()
            My.Settings.Save()
            Form1.LoadFromSettings()
            PopulateForm()
        End If

    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter, PictureBox2.MouseEnter, PictureBox3.MouseEnter, PictureBox4.MouseEnter, help8LineRevert.MouseEnter, helpLookupURL.MouseEnter
        'Relating the ToolTip to the question box, not the mouse pointer.
        'Dim LocalMousePosition As Point
        'LocalMousePosition = Me.PointToClient(Windows.Forms.Cursor.Position)
        'Debug.WriteLine(LocalMousePosition.X.ToString + ", " + LocalMousePosition.Y.ToString)
        ToolTip1.Show(ToolTip1.GetToolTip(sender), Me, sender.Left + 40, sender.Top + 55)
        ToolTip1.Active = True
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave, PictureBox2.MouseLeave, PictureBox3.MouseLeave, PictureBox4.MouseLeave, help8LineRevert.MouseLeave, helpLookupURL.MouseLeave
        ToolTip1.Hide(Me)
    End Sub

    Private Sub lbPlugins_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbPlugins.SelectedIndexChanged
        If sender.SelectedIndex < 0 Then Exit Sub
        Dim pluginResponse As Object
        Dim pluginVersionResponse As Object
        For Each plugIn As CIDClass.IMyPlugIn In Form1.pluginList
            If lbPlugins.Items(lbPlugins.SelectedIndex) = plugIn.PluginName Then
                gbPluginDisc.Text = plugIn.PluginName
                tbPluginDisc.Text = plugIn.PluginDiscription

                pluginVersionResponse = plugIn.EventFunction(Form1.PluginValues.PLUGIN_VERSION)
                If TypeOf (pluginVersionResponse) Is String Then
                    lblPluginVersion.Text = "Version: " + pluginVersionResponse
                Else
                    lblPluginVersion.Text = ""
                End If

                pluginResponse = plugIn.EventFunction(Form1.PluginValues.OPTIONS_QUERY)
                If TypeOf (pluginResponse) Is Boolean And pluginResponse = True Then
                    btnPluginSettings.Enabled = True
                Else
                    btnPluginSettings.Enabled = False
                End If
            End If
        Next
    End Sub

    Private Sub btnPluginSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPluginSettings.Click
        For Each plugIn As CIDClass.IMyPlugIn In Form1.pluginList
            If lbPlugins.Items(lbPlugins.SelectedIndex) = plugIn.PluginName Then
                plugIn.EventFunction(Form1.PluginValues.OPTIONS_LOAD)
                tbPluginDisc.Text = plugIn.PluginDiscription
            End If
        Next
    End Sub

    Private Sub cbLookupURL_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbLookupURL.TextChanged, cbLookupURL.TextUpdate
        If Not bLoading Then
            If cbLookupURL.SelectedIndex = origURLlength - 1 Then
                If cbLookupURL.Items.Count = origURLlength Then
                    cbLookupURL.Items.Add("http://")
                    cbLookupURL.Focus()
                    cbLookupURL.SelectionStart = 7
                End If
                cbLookupURL.SelectedIndex = origURLlength
            Else
                Form1.stLookupURL = cbLookupURL.Text
                My.Settings.lookupURL = Form1.stLookupURL
            End If
        End If
    End Sub

   
    Private Sub ckbUseCompTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbUseCompTime.Click

        If My.Settings.useCompTime = False Then
            My.Settings.useCompTime = True
            ckbUseCompTime.Checked = True
        Else
            My.Settings.useCompTime = False
            ckbUseCompTime.Checked = False
        End If

    End Sub
End Class