<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Options
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Options))
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.chkLog = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NUDTimer = New System.Windows.Forms.NumericUpDown()
        Me.cbSerial = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpPopup = New System.Windows.Forms.TabPage()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkOutboundPopup = New System.Windows.Forms.CheckBox()
        Me.chkInboundPopup = New System.Windows.Forms.CheckBox()
        Me.tpLogging = New System.Windows.Forms.TabPage()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.chkLogLevel2 = New System.Windows.Forms.CheckBox()
        Me.tpServer = New System.Windows.Forms.TabPage()
        Me.lblRelayStatus = New System.Windows.Forms.Label()
        Me.lblComStatus = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.cbIpRelay = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tpMiscOptions = New System.Windows.Forms.TabPage()
        Me.ckbUseCompTime = New System.Windows.Forms.CheckBox()
        Me.cbLookupURL = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.helpLookupURL = New System.Windows.Forms.PictureBox()
        Me.help8LineRevert = New System.Windows.Forms.PictureBox()
        Me.lbl8Line = New System.Windows.Forms.Label()
        Me.btn8LineRevert = New System.Windows.Forms.Button()
        Me.mtbAreaCode = New System.Windows.Forms.MaskedTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tpWC2 = New System.Windows.Forms.TabPage()
        Me.btnManualErase = New System.Windows.Forms.Button()
        Me.chkAutoErase = New System.Windows.Forms.CheckBox()
        Me.lblDupeNew = New System.Windows.Forms.Label()
        Me.lblReceiveTest = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDownload = New System.Windows.Forms.Button()
        Me.DownloadProgress = New System.Windows.Forms.ProgressBar()
        Me.tpPlugins = New System.Windows.Forms.TabPage()
        Me.gbPluginDisc = New System.Windows.Forms.GroupBox()
        Me.tbPluginDisc = New System.Windows.Forms.TextBox()
        Me.lblPluginVersion = New System.Windows.Forms.Label()
        Me.btnPluginSettings = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lbPlugins = New System.Windows.Forms.ListBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.tiGUI = New System.Windows.Forms.Timer(Me.components)
        Me.btnReset = New System.Windows.Forms.Button()
        CType(Me.NUDTimer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpPopup.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpLogging.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpServer.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMiscOptions.SuspendLayout()
        CType(Me.helpLookupURL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.help8LineRevert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpWC2.SuspendLayout()
        Me.tpPlugins.SuspendLayout()
        Me.gbPluginDisc.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(6, 46)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(190, 20)
        Me.txtFilePath.TabIndex = 1
        Me.txtFilePath.TabStop = False
        '
        'chkLog
        '
        Me.chkLog.AutoSize = True
        Me.chkLog.Location = New System.Drawing.Point(6, 23)
        Me.chkLog.Name = "chkLog"
        Me.chkLog.Size = New System.Drawing.Size(75, 17)
        Me.chkLog.TabIndex = 0
        Me.chkLog.Text = "Log to File"
        Me.chkLog.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(202, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(71, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Browse..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(253, 237)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 39)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Export CallerID records to Excel or Text"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(152, 81)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Export..."
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(69, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Popup Length (In Seconds)"
        '
        'NUDTimer
        '
        Me.NUDTimer.Location = New System.Drawing.Point(17, 124)
        Me.NUDTimer.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NUDTimer.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NUDTimer.Name = "NUDTimer"
        Me.NUDTimer.Size = New System.Drawing.Size(46, 20)
        Me.NUDTimer.TabIndex = 1
        Me.NUDTimer.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'cbSerial
        '
        Me.cbSerial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSerial.FormattingEnabled = True
        Me.cbSerial.Location = New System.Drawing.Point(84, 21)
        Me.cbSerial.Name = "cbSerial"
        Me.cbSerial.Size = New System.Drawing.Size(144, 21)
        Me.cbSerial.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Serial Device"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tpPopup)
        Me.TabControl1.Controls.Add(Me.tpLogging)
        Me.TabControl1.Controls.Add(Me.tpServer)
        Me.TabControl1.Controls.Add(Me.tpMiscOptions)
        Me.TabControl1.Controls.Add(Me.tpWC2)
        Me.TabControl1.Controls.Add(Me.tpPlugins)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(317, 219)
        Me.TabControl1.TabIndex = 15
        '
        'tpPopup
        '
        Me.tpPopup.Controls.Add(Me.PictureBox1)
        Me.tpPopup.Controls.Add(Me.chkOutboundPopup)
        Me.tpPopup.Controls.Add(Me.chkInboundPopup)
        Me.tpPopup.Controls.Add(Me.Label1)
        Me.tpPopup.Controls.Add(Me.NUDTimer)
        Me.tpPopup.Location = New System.Drawing.Point(4, 22)
        Me.tpPopup.Name = "tpPopup"
        Me.tpPopup.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPopup.Size = New System.Drawing.Size(309, 193)
        Me.tpPopup.TabIndex = 0
        Me.tpPopup.Text = "Popups"
        Me.tpPopup.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.ELPopup.My.Resources.Resources.Small_Vista_Help_icon_by_Thoosje
        Me.PictureBox1.Location = New System.Drawing.Point(164, 57)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.TabIndex = 16
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, "Appropriate hardware that reports outbound calls is required.")
        '
        'chkOutboundPopup
        '
        Me.chkOutboundPopup.AutoSize = True
        Me.chkOutboundPopup.Location = New System.Drawing.Point(17, 57)
        Me.chkOutboundPopup.Name = "chkOutboundPopup"
        Me.chkOutboundPopup.Size = New System.Drawing.Size(141, 17)
        Me.chkOutboundPopup.TabIndex = 14
        Me.chkOutboundPopup.Text = "Popup on Outbond Calls"
        Me.chkOutboundPopup.UseVisualStyleBackColor = True
        '
        'chkInboundPopup
        '
        Me.chkInboundPopup.AutoSize = True
        Me.chkInboundPopup.Location = New System.Drawing.Point(17, 33)
        Me.chkInboundPopup.Name = "chkInboundPopup"
        Me.chkInboundPopup.Size = New System.Drawing.Size(139, 17)
        Me.chkInboundPopup.TabIndex = 13
        Me.chkInboundPopup.Text = "Popup on Inbound Calls"
        Me.chkInboundPopup.UseVisualStyleBackColor = True
        '
        'tpLogging
        '
        Me.tpLogging.Controls.Add(Me.PictureBox4)
        Me.tpLogging.Controls.Add(Me.chkLogLevel2)
        Me.tpLogging.Controls.Add(Me.Label2)
        Me.tpLogging.Controls.Add(Me.btnExport)
        Me.tpLogging.Controls.Add(Me.Button1)
        Me.tpLogging.Controls.Add(Me.chkLog)
        Me.tpLogging.Controls.Add(Me.txtFilePath)
        Me.tpLogging.Location = New System.Drawing.Point(4, 22)
        Me.tpLogging.Name = "tpLogging"
        Me.tpLogging.Padding = New System.Windows.Forms.Padding(3)
        Me.tpLogging.Size = New System.Drawing.Size(309, 193)
        Me.tpLogging.TabIndex = 1
        Me.tpLogging.Text = "Logging"
        Me.tpLogging.UseVisualStyleBackColor = True
        '
        'PictureBox4
        '
        Me.PictureBox4.BackgroundImage = Global.ELPopup.My.Resources.Resources.Small_Vista_Help_icon_by_Thoosje
        Me.PictureBox4.Location = New System.Drawing.Point(200, 22)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox4.TabIndex = 19
        Me.PictureBox4.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox4, "Detailed Logging is generally used for diagnostic purposes only" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "as it may initia" & _
                "lly appear to show duplicate data. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "For most applications, detailed logging wou" & _
                "ld not be selected.")
        '
        'chkLogLevel2
        '
        Me.chkLogLevel2.AutoSize = True
        Me.chkLogLevel2.Location = New System.Drawing.Point(88, 23)
        Me.chkLogLevel2.Name = "chkLogLevel2"
        Me.chkLogLevel2.Size = New System.Drawing.Size(106, 17)
        Me.chkLogLevel2.TabIndex = 14
        Me.chkLogLevel2.Text = "Detailed Logging"
        Me.chkLogLevel2.UseVisualStyleBackColor = True
        '
        'tpServer
        '
        Me.tpServer.Controls.Add(Me.lblRelayStatus)
        Me.tpServer.Controls.Add(Me.lblComStatus)
        Me.tpServer.Controls.Add(Me.PictureBox3)
        Me.tpServer.Controls.Add(Me.PictureBox2)
        Me.tpServer.Controls.Add(Me.cbIpRelay)
        Me.tpServer.Controls.Add(Me.Label4)
        Me.tpServer.Controls.Add(Me.Label3)
        Me.tpServer.Controls.Add(Me.cbSerial)
        Me.tpServer.Location = New System.Drawing.Point(4, 22)
        Me.tpServer.Name = "tpServer"
        Me.tpServer.Size = New System.Drawing.Size(309, 193)
        Me.tpServer.TabIndex = 2
        Me.tpServer.Text = "Serial Server"
        Me.tpServer.UseVisualStyleBackColor = True
        '
        'lblRelayStatus
        '
        Me.lblRelayStatus.AutoSize = True
        Me.lblRelayStatus.Location = New System.Drawing.Point(3, 150)
        Me.lblRelayStatus.Name = "lblRelayStatus"
        Me.lblRelayStatus.Size = New System.Drawing.Size(34, 13)
        Me.lblRelayStatus.TabIndex = 21
        Me.lblRelayStatus.Text = "Relay"
        '
        'lblComStatus
        '
        Me.lblComStatus.AutoSize = True
        Me.lblComStatus.Location = New System.Drawing.Point(3, 135)
        Me.lblComStatus.Name = "lblComStatus"
        Me.lblComStatus.Size = New System.Drawing.Size(109, 13)
        Me.lblComStatus.TabIndex = 20
        Me.lblComStatus.Text = "COMx Connected OK"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackgroundImage = Global.ELPopup.My.Resources.Resources.Small_Vista_Help_icon_by_Thoosje
        Me.PictureBox3.Location = New System.Drawing.Point(234, 59)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox3.TabIndex = 19
        Me.PictureBox3.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox3, "When using a serial device, ELPopup can relay the data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to other computers connec" & _
                "ted to the local area network" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "using 255.255.255.255." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Localhost selection is pr" & _
                "ovided for advanced users.")
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = Global.ELPopup.My.Resources.Resources.Small_Vista_Help_icon_by_Thoosje
        Me.PictureBox2.Location = New System.Drawing.Point(234, 24)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox2.TabIndex = 18
        Me.PictureBox2.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox2, resources.GetString("PictureBox2.ToolTip"))
        '
        'cbIpRelay
        '
        Me.cbIpRelay.FormattingEnabled = True
        Me.cbIpRelay.Items.AddRange(New Object() {"Do Not Relay Data", "Entire LAN (255.255.255.255)", "Localhost (127.0.0.1)"})
        Me.cbIpRelay.Location = New System.Drawing.Point(84, 56)
        Me.cbIpRelay.Name = "cbIpRelay"
        Me.cbIpRelay.Size = New System.Drawing.Size(144, 21)
        Me.cbIpRelay.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Relay Address"
        Me.ToolTip1.SetToolTip(Me.Label4, "Repeats the information from the serial port to the network. Use this to relay in" & _
                "formation to other computers.")
        '
        'tpMiscOptions
        '
        Me.tpMiscOptions.Controls.Add(Me.ckbUseCompTime)
        Me.tpMiscOptions.Controls.Add(Me.cbLookupURL)
        Me.tpMiscOptions.Controls.Add(Me.Label9)
        Me.tpMiscOptions.Controls.Add(Me.helpLookupURL)
        Me.tpMiscOptions.Controls.Add(Me.help8LineRevert)
        Me.tpMiscOptions.Controls.Add(Me.lbl8Line)
        Me.tpMiscOptions.Controls.Add(Me.btn8LineRevert)
        Me.tpMiscOptions.Controls.Add(Me.mtbAreaCode)
        Me.tpMiscOptions.Controls.Add(Me.Label7)
        Me.tpMiscOptions.Controls.Add(Me.Label5)
        Me.tpMiscOptions.Location = New System.Drawing.Point(4, 22)
        Me.tpMiscOptions.Name = "tpMiscOptions"
        Me.tpMiscOptions.Size = New System.Drawing.Size(309, 193)
        Me.tpMiscOptions.TabIndex = 4
        Me.tpMiscOptions.Text = "Misc"
        Me.tpMiscOptions.UseVisualStyleBackColor = True
        '
        'ckbUseCompTime
        '
        Me.ckbUseCompTime.AutoSize = True
        Me.ckbUseCompTime.Location = New System.Drawing.Point(12, 161)
        Me.ckbUseCompTime.Name = "ckbUseCompTime"
        Me.ckbUseCompTime.Size = New System.Drawing.Size(244, 17)
        Me.ckbUseCompTime.TabIndex = 20
        Me.ckbUseCompTime.Text = "Use Computer Time and Date on Call Records"
        Me.ckbUseCompTime.UseVisualStyleBackColor = True
        '
        'cbLookupURL
        '
        Me.cbLookupURL.FormattingEnabled = True
        Me.cbLookupURL.Items.AddRange(New Object() {"Whitepages.com", "Google", "Bing", "Custom URL"})
        Me.cbLookupURL.Location = New System.Drawing.Point(107, 80)
        Me.cbLookupURL.Name = "cbLookupURL"
        Me.cbLookupURL.Size = New System.Drawing.Size(190, 21)
        Me.cbLookupURL.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Lookup URL"
        '
        'helpLookupURL
        '
        Me.helpLookupURL.BackgroundImage = Global.ELPopup.My.Resources.Resources.Small_Vista_Help_icon_by_Thoosje
        Me.helpLookupURL.Location = New System.Drawing.Point(84, 83)
        Me.helpLookupURL.Name = "helpLookupURL"
        Me.helpLookupURL.Size = New System.Drawing.Size(16, 16)
        Me.helpLookupURL.TabIndex = 17
        Me.helpLookupURL.TabStop = False
        Me.ToolTip1.SetToolTip(Me.helpLookupURL, "If you use a custom URL, the phrase %number will be replaced with the selected te" & _
                "lephone number.")
        '
        'help8LineRevert
        '
        Me.help8LineRevert.BackgroundImage = Global.ELPopup.My.Resources.Resources.Small_Vista_Help_icon_by_Thoosje
        Me.help8LineRevert.Location = New System.Drawing.Point(125, 116)
        Me.help8LineRevert.Name = "help8LineRevert"
        Me.help8LineRevert.Size = New System.Drawing.Size(16, 16)
        Me.help8LineRevert.TabIndex = 17
        Me.help8LineRevert.TabStop = False
        Me.ToolTip1.SetToolTip(Me.help8LineRevert, "8-line mode was activated because a line number above 4 was detected." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Click Reve" & _
                "rt to go back to 4-line mode.")
        '
        'lbl8Line
        '
        Me.lbl8Line.AutoSize = True
        Me.lbl8Line.Location = New System.Drawing.Point(11, 116)
        Me.lbl8Line.Name = "lbl8Line"
        Me.lbl8Line.Size = New System.Drawing.Size(108, 13)
        Me.lbl8Line.TabIndex = 4
        Me.lbl8Line.Text = "Revert to 4-line mode"
        '
        'btn8LineRevert
        '
        Me.btn8LineRevert.Location = New System.Drawing.Point(14, 132)
        Me.btn8LineRevert.Name = "btn8LineRevert"
        Me.btn8LineRevert.Size = New System.Drawing.Size(75, 23)
        Me.btn8LineRevert.TabIndex = 3
        Me.btn8LineRevert.Text = "Revert"
        Me.btn8LineRevert.UseVisualStyleBackColor = True
        '
        'mtbAreaCode
        '
        Me.mtbAreaCode.Location = New System.Drawing.Point(72, 25)
        Me.mtbAreaCode.Mask = "000"
        Me.mtbAreaCode.Name = "mtbAreaCode"
        Me.mtbAreaCode.Size = New System.Drawing.Size(35, 20)
        Me.mtbAreaCode.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(143, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "(For areas with 7 digit dialing)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Area Code"
        '
        'tpWC2
        '
        Me.tpWC2.Controls.Add(Me.btnManualErase)
        Me.tpWC2.Controls.Add(Me.chkAutoErase)
        Me.tpWC2.Controls.Add(Me.lblDupeNew)
        Me.tpWC2.Controls.Add(Me.lblReceiveTest)
        Me.tpWC2.Controls.Add(Me.Label6)
        Me.tpWC2.Controls.Add(Me.btnDownload)
        Me.tpWC2.Controls.Add(Me.DownloadProgress)
        Me.tpWC2.Location = New System.Drawing.Point(4, 22)
        Me.tpWC2.Name = "tpWC2"
        Me.tpWC2.Size = New System.Drawing.Size(309, 193)
        Me.tpWC2.TabIndex = 3
        Me.tpWC2.Text = "WC? 2"
        Me.tpWC2.UseVisualStyleBackColor = True
        '
        'btnManualErase
        '
        Me.btnManualErase.Location = New System.Drawing.Point(17, 42)
        Me.btnManualErase.Name = "btnManualErase"
        Me.btnManualErase.Size = New System.Drawing.Size(75, 23)
        Me.btnManualErase.TabIndex = 23
        Me.btnManualErase.Text = "Erase"
        Me.btnManualErase.UseVisualStyleBackColor = True
        '
        'chkAutoErase
        '
        Me.chkAutoErase.AutoSize = True
        Me.chkAutoErase.Checked = True
        Me.chkAutoErase.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutoErase.Location = New System.Drawing.Point(98, 20)
        Me.chkAutoErase.Name = "chkAutoErase"
        Me.chkAutoErase.Size = New System.Drawing.Size(78, 17)
        Me.chkAutoErase.TabIndex = 22
        Me.chkAutoErase.Text = "Auto-Erase"
        Me.ToolTip1.SetToolTip(Me.chkAutoErase, "Automatically erase WC2 after download.")
        Me.chkAutoErase.UseVisualStyleBackColor = True
        '
        'lblDupeNew
        '
        Me.lblDupeNew.AutoSize = True
        Me.lblDupeNew.Location = New System.Drawing.Point(14, 108)
        Me.lblDupeNew.Name = "lblDupeNew"
        Me.lblDupeNew.Size = New System.Drawing.Size(103, 13)
        Me.lblDupeNew.TabIndex = 21
        Me.lblDupeNew.Text = "0 Duplicates, 0 New"
        '
        'lblReceiveTest
        '
        Me.lblReceiveTest.AutoSize = True
        Me.lblReceiveTest.Location = New System.Drawing.Point(119, 84)
        Me.lblReceiveTest.Name = "lblReceiveTest"
        Me.lblReceiveTest.Size = New System.Drawing.Size(13, 13)
        Me.lblReceiveTest.TabIndex = 20
        Me.lblReceiveTest.Text = "0"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(99, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Download Progress"
        '
        'btnDownload
        '
        Me.btnDownload.Location = New System.Drawing.Point(17, 16)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.Size = New System.Drawing.Size(75, 23)
        Me.btnDownload.TabIndex = 18
        Me.btnDownload.Text = "Download"
        Me.btnDownload.UseVisualStyleBackColor = True
        '
        'DownloadProgress
        '
        Me.DownloadProgress.Location = New System.Drawing.Point(17, 134)
        Me.DownloadProgress.Name = "DownloadProgress"
        Me.DownloadProgress.Size = New System.Drawing.Size(166, 23)
        Me.DownloadProgress.TabIndex = 0
        '
        'tpPlugins
        '
        Me.tpPlugins.Controls.Add(Me.gbPluginDisc)
        Me.tpPlugins.Controls.Add(Me.btnPluginSettings)
        Me.tpPlugins.Controls.Add(Me.Label8)
        Me.tpPlugins.Controls.Add(Me.lbPlugins)
        Me.tpPlugins.Location = New System.Drawing.Point(4, 22)
        Me.tpPlugins.Name = "tpPlugins"
        Me.tpPlugins.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPlugins.Size = New System.Drawing.Size(309, 193)
        Me.tpPlugins.TabIndex = 5
        Me.tpPlugins.Text = "Plugins"
        Me.tpPlugins.UseVisualStyleBackColor = True
        '
        'gbPluginDisc
        '
        Me.gbPluginDisc.Controls.Add(Me.tbPluginDisc)
        Me.gbPluginDisc.Controls.Add(Me.lblPluginVersion)
        Me.gbPluginDisc.Location = New System.Drawing.Point(163, 17)
        Me.gbPluginDisc.Name = "gbPluginDisc"
        Me.gbPluginDisc.Size = New System.Drawing.Size(140, 114)
        Me.gbPluginDisc.TabIndex = 24
        Me.gbPluginDisc.TabStop = False
        Me.gbPluginDisc.Text = "None Selected"
        '
        'tbPluginDisc
        '
        Me.tbPluginDisc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbPluginDisc.Location = New System.Drawing.Point(9, 33)
        Me.tbPluginDisc.Multiline = True
        Me.tbPluginDisc.Name = "tbPluginDisc"
        Me.tbPluginDisc.ReadOnly = True
        Me.tbPluginDisc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbPluginDisc.Size = New System.Drawing.Size(125, 75)
        Me.tbPluginDisc.TabIndex = 1
        '
        'lblPluginVersion
        '
        Me.lblPluginVersion.AutoSize = True
        Me.lblPluginVersion.Location = New System.Drawing.Point(6, 16)
        Me.lblPluginVersion.Name = "lblPluginVersion"
        Me.lblPluginVersion.Size = New System.Drawing.Size(0, 13)
        Me.lblPluginVersion.TabIndex = 0
        '
        'btnPluginSettings
        '
        Me.btnPluginSettings.Enabled = False
        Me.btnPluginSettings.Location = New System.Drawing.Point(163, 137)
        Me.btnPluginSettings.Name = "btnPluginSettings"
        Me.btnPluginSettings.Size = New System.Drawing.Size(137, 23)
        Me.btnPluginSettings.TabIndex = 23
        Me.btnPluginSettings.Text = "Plug-in Settings"
        Me.btnPluginSettings.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Loaded Plug-Ins"
        '
        'lbPlugins
        '
        Me.lbPlugins.FormattingEnabled = True
        Me.lbPlugins.Items.AddRange(New Object() {"None"})
        Me.lbPlugins.Location = New System.Drawing.Point(20, 39)
        Me.lbPlugins.Name = "lbPlugins"
        Me.lbPlugins.Size = New System.Drawing.Size(137, 121)
        Me.lbPlugins.TabIndex = 21
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 200
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ShowAlways = True
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblVersion.Location = New System.Drawing.Point(12, 242)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(22, 13)
        Me.lblVersion.TabIndex = 16
        Me.lblVersion.Text = "0.0"
        Me.ToolTip1.SetToolTip(Me.lblVersion, "0.0.0.0")
        '
        'tiGUI
        '
        Me.tiGUI.Enabled = True
        Me.tiGUI.Interval = 500
        '
        'btnReset
        '
        Me.btnReset.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReset.Location = New System.Drawing.Point(148, 237)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(99, 23)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset to defaults"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'Options
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(341, 269)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Options"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Options"
        CType(Me.NUDTimer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpPopup.ResumeLayout(False)
        Me.tpPopup.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpLogging.ResumeLayout(False)
        Me.tpLogging.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpServer.ResumeLayout(False)
        Me.tpServer.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMiscOptions.ResumeLayout(False)
        Me.tpMiscOptions.PerformLayout()
        CType(Me.helpLookupURL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.help8LineRevert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpWC2.ResumeLayout(False)
        Me.tpWC2.PerformLayout()
        Me.tpPlugins.ResumeLayout(False)
        Me.tpPlugins.PerformLayout()
        Me.gbPluginDisc.ResumeLayout(False)
        Me.gbPluginDisc.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents chkLog As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NUDTimer As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbSerial As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tpPopup As System.Windows.Forms.TabPage
    Friend WithEvents tpLogging As System.Windows.Forms.TabPage
    Friend WithEvents tpServer As System.Windows.Forms.TabPage
    Friend WithEvents cbIpRelay As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents chkLogLevel2 As System.Windows.Forms.CheckBox
    Friend WithEvents tpWC2 As System.Windows.Forms.TabPage
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents DownloadProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblReceiveTest As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tiGUI As System.Windows.Forms.Timer
    Friend WithEvents lblDupeNew As System.Windows.Forms.Label
    Friend WithEvents chkAutoErase As System.Windows.Forms.CheckBox
    Friend WithEvents btnManualErase As System.Windows.Forms.Button
    Friend WithEvents tpMiscOptions As System.Windows.Forms.TabPage
    Friend WithEvents mtbAreaCode As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents chkOutboundPopup As System.Windows.Forms.CheckBox
    Friend WithEvents chkInboundPopup As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents help8LineRevert As System.Windows.Forms.PictureBox
    Friend WithEvents lbl8Line As System.Windows.Forms.Label
    Friend WithEvents btn8LineRevert As System.Windows.Forms.Button
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblComStatus As System.Windows.Forms.Label
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents lblRelayStatus As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents tpPlugins As System.Windows.Forms.TabPage
    Friend WithEvents gbPluginDisc As System.Windows.Forms.GroupBox
    Friend WithEvents btnPluginSettings As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lbPlugins As System.Windows.Forms.ListBox
    Friend WithEvents tbPluginDisc As System.Windows.Forms.TextBox
    Friend WithEvents lblPluginVersion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbLookupURL As System.Windows.Forms.ComboBox
    Friend WithEvents helpLookupURL As System.Windows.Forms.PictureBox
    Friend WithEvents ckbUseCompTime As System.Windows.Forms.CheckBox
End Class
