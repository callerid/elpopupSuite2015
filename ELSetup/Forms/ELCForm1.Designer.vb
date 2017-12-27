<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ELCForm1
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ELCForm1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AutomaticSetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetNetworkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetUnitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DisplayComputersIPAddressToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SetUnitToCurrentTimeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetUnitLineCountTo1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetDeluxeUnitToBasicUnitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ListeningPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSPort = New System.Windows.Forms.ToolStripTextBox()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TMIManual = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.UploadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveDataLocallyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BTEthernetSend = New System.Windows.Forms.Button()
        Me.TBOutgoingMessage = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSConnectedUnits = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbDeluxeUnit = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lbListeningOn = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CBDetectedUnits = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TBUN = New System.Windows.Forms.TextBox()
        Me.TBPort = New System.Windows.Forms.TextBox()
        Me.BTNRefresh = New System.Windows.Forms.Button()
        Me.BTNChangeUid = New System.Windows.Forms.Button()
        Me.BTNChangeIpInt = New System.Windows.Forms.Button()
        Me.BTNChangeMacInt = New System.Windows.Forms.Button()
        Me.BTNChangePort = New System.Windows.Forms.Button()
        Me.BTNChangeIpDest = New System.Windows.Forms.Button()
        Me.BTNChangeMacDest = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.MACInternal = New IPControlsClass.MACInput()
        Me.IPInternal = New IPControlsClass.IPInput()
        Me.IPDest = New IPControlsClass.IPInput()
        Me.MACDest = New IPControlsClass.MACInput()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GBInfo = New System.Windows.Forms.GroupBox()
        Me.LBLinfo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmPassword = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsPassword = New System.Windows.Forms.ToolStripTextBox()
        Me.tbLiteral = New System.Windows.Forms.TextBox()
        Me.btnRetToggles = New System.Windows.Forms.Button()
        Me.dgvPhoneData = New System.Windows.Forms.DataGridView()
        Me.LineNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InOut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartEnd = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chk = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RingType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dayMonth = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CallerID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvCommData = New System.Windows.Forms.DataGridView()
        Me.data = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnClearCommData = New System.Windows.Forms.Button()
        Me.btnClearPhoneData = New System.Windows.Forms.Button()
        Me.timerSendUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.rbTech1 = New System.Windows.Forms.RadioButton()
        Me.rbTech2 = New System.Windows.Forms.RadioButton()
        Me.rbTech3 = New System.Windows.Forms.RadioButton()
        Me.rbTechNone = New System.Windows.Forms.RadioButton()
        Me.sfdSaveLocal = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pbSendingCommand = New System.Windows.Forms.ProgressBar()
        Me.pbSearching = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GBInfo.SuspendLayout()
        Me.cmPassword.SuspendLayout()
        CType(Me.dgvPhoneData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCommData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutomaticSetupToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(619, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AutomaticSetupToolStripMenuItem
        '
        Me.AutomaticSetupToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ResetNetworkToolStripMenuItem, Me.ResetUnitToolStripMenuItem, Me.ToolStripSeparator1, Me.DisplayComputersIPAddressToolStripMenuItem, Me.ToolStripSeparator2, Me.SetUnitToCurrentTimeToolStripMenuItem, Me.SetUnitLineCountTo1ToolStripMenuItem, Me.SetDeluxeUnitToBasicUnitToolStripMenuItem, Me.ToolStripSeparator4, Me.ListeningPortToolStripMenuItem})
        Me.AutomaticSetupToolStripMenuItem.Name = "AutomaticSetupToolStripMenuItem"
        Me.AutomaticSetupToolStripMenuItem.Size = New System.Drawing.Size(72, 20)
        Me.AutomaticSetupToolStripMenuItem.Text = "&Configure"
        '
        'ResetNetworkToolStripMenuItem
        '
        Me.ResetNetworkToolStripMenuItem.Name = "ResetNetworkToolStripMenuItem"
        Me.ResetNetworkToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.ResetNetworkToolStripMenuItem.Tag = "reseteth"
        Me.ResetNetworkToolStripMenuItem.Text = "Reset &Ethernet Defaults"
        '
        'ResetUnitToolStripMenuItem
        '
        Me.ResetUnitToolStripMenuItem.Name = "ResetUnitToolStripMenuItem"
        Me.ResetUnitToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.ResetUnitToolStripMenuItem.Tag = "resetunit"
        Me.ResetUnitToolStripMenuItem.Text = "Set Deluxe Unit Output Defaults"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(237, 6)
        '
        'DisplayComputersIPAddressToolStripMenuItem
        '
        Me.DisplayComputersIPAddressToolStripMenuItem.Name = "DisplayComputersIPAddressToolStripMenuItem"
        Me.DisplayComputersIPAddressToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.DisplayComputersIPAddressToolStripMenuItem.Text = "Display Computer's &IP Address"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(237, 6)
        '
        'SetUnitToCurrentTimeToolStripMenuItem
        '
        Me.SetUnitToCurrentTimeToolStripMenuItem.Name = "SetUnitToCurrentTimeToolStripMenuItem"
        Me.SetUnitToCurrentTimeToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.SetUnitToCurrentTimeToolStripMenuItem.Text = "Set Unit to Current Time"
        '
        'SetUnitLineCountTo1ToolStripMenuItem
        '
        Me.SetUnitLineCountTo1ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4, Me.ToolStripMenuItem5, Me.ToolStripMenuItem6, Me.ToolStripMenuItem7, Me.ToolStripMenuItem8})
        Me.SetUnitLineCountTo1ToolStripMenuItem.Name = "SetUnitLineCountTo1ToolStripMenuItem"
        Me.SetUnitLineCountTo1ToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.SetUnitLineCountTo1ToolStripMenuItem.Text = "Set Unit Line Count"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripMenuItem2.Text = "1"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripMenuItem3.Text = "5"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripMenuItem4.Text = "9"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripMenuItem5.Text = "17"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripMenuItem6.Text = "21"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripMenuItem7.Text = "25"
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(86, 22)
        Me.ToolStripMenuItem8.Text = "33"
        '
        'SetDeluxeUnitToBasicUnitToolStripMenuItem
        '
        Me.SetDeluxeUnitToBasicUnitToolStripMenuItem.Name = "SetDeluxeUnitToBasicUnitToolStripMenuItem"
        Me.SetDeluxeUnitToBasicUnitToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.SetDeluxeUnitToBasicUnitToolStripMenuItem.Text = "Set  Deluxe Unit to Basic Unit"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(237, 6)
        '
        'ListeningPortToolStripMenuItem
        '
        Me.ListeningPortToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSPort})
        Me.ListeningPortToolStripMenuItem.Name = "ListeningPortToolStripMenuItem"
        Me.ListeningPortToolStripMenuItem.Size = New System.Drawing.Size(240, 22)
        Me.ListeningPortToolStripMenuItem.Text = "Listening &Port"
        '
        'TSPort
        '
        Me.TSPort.CausesValidation = False
        Me.TSPort.MaxLength = 6
        Me.TSPort.Name = "TSPort"
        Me.TSPort.Size = New System.Drawing.Size(100, 23)
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.TMIManual, Me.ToolStripSeparator3, Me.UploadDataToolStripMenuItem, Me.SaveDataLocallyToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'TMIManual
        '
        Me.TMIManual.Name = "TMIManual"
        Me.TMIManual.Size = New System.Drawing.Size(223, 22)
        Me.TMIManual.Text = "User &Manual"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(220, 6)
        '
        'UploadDataToolStripMenuItem
        '
        Me.UploadDataToolStripMenuItem.Name = "UploadDataToolStripMenuItem"
        Me.UploadDataToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.UploadDataToolStripMenuItem.Text = "Upload data to CallerID.com"
        '
        'SaveDataLocallyToolStripMenuItem
        '
        Me.SaveDataLocallyToolStripMenuItem.Name = "SaveDataLocallyToolStripMenuItem"
        Me.SaveDataLocallyToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.SaveDataLocallyToolStripMenuItem.Text = "Save data locally"
        '
        'BTEthernetSend
        '
        Me.BTEthernetSend.Location = New System.Drawing.Point(281, 282)
        Me.BTEthernetSend.Name = "BTEthernetSend"
        Me.BTEthernetSend.Size = New System.Drawing.Size(104, 23)
        Me.BTEthernetSend.TabIndex = 3
        Me.BTEthernetSend.Text = "&Send Command"
        Me.BTEthernetSend.UseVisualStyleBackColor = True
        '
        'TBOutgoingMessage
        '
        Me.TBOutgoingMessage.Location = New System.Drawing.Point(210, 284)
        Me.TBOutgoingMessage.Name = "TBOutgoingMessage"
        Me.TBOutgoingMessage.Size = New System.Drawing.Size(65, 20)
        Me.TBOutgoingMessage.TabIndex = 1
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSConnectedUnits, Me.lbDeluxeUnit, Me.lbListeningOn})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 662)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(619, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TSConnectedUnits
        '
        Me.TSConnectedUnits.Name = "TSConnectedUnits"
        Me.TSConnectedUnits.Size = New System.Drawing.Size(360, 17)
        Me.TSConnectedUnits.Spring = True
        Me.TSConnectedUnits.Tag = "units"
        Me.TSConnectedUnits.Text = "No Units Detected"
        Me.TSConnectedUnits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDeluxeUnit
        '
        Me.lbDeluxeUnit.ForeColor = System.Drawing.Color.Maroon
        Me.lbDeluxeUnit.Name = "lbDeluxeUnit"
        Me.lbDeluxeUnit.Size = New System.Drawing.Size(140, 17)
        Me.lbDeluxeUnit.Text = "Deluxe Unit Not Detected"
        '
        'lbListeningOn
        '
        Me.lbListeningOn.Name = "lbListeningOn"
        Me.lbListeningOn.Size = New System.Drawing.Size(104, 17)
        Me.lbListeningOn.Text = "Listening On: 3520"
        '
        'CBDetectedUnits
        '
        Me.CBDetectedUnits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBDetectedUnits.FormattingEnabled = True
        Me.CBDetectedUnits.Location = New System.Drawing.Point(117, 37)
        Me.CBDetectedUnits.Name = "CBDetectedUnits"
        Me.CBDetectedUnits.Size = New System.Drawing.Size(176, 21)
        Me.CBDetectedUnits.TabIndex = 20
        Me.CBDetectedUnits.Tag = "units"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Detected Units"
        '
        'Label11
        '
        Me.Label11.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(93, 29)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Unit Number"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 29)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(93, 29)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Unit IP Address"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 58)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(93, 29)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Unit MAC Address"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(3, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 29)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "Destination IP"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 145)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 32)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Destination MAC"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(3, 87)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(93, 29)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "Port"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TBUN
        '
        Me.TBUN.Location = New System.Drawing.Point(102, 3)
        Me.TBUN.Name = "TBUN"
        Me.TBUN.ReadOnly = True
        Me.TBUN.Size = New System.Drawing.Size(176, 20)
        Me.TBUN.TabIndex = 23
        Me.TBUN.Tag = "uid"
        '
        'TBPort
        '
        Me.TBPort.Location = New System.Drawing.Point(102, 90)
        Me.TBPort.Name = "TBPort"
        Me.TBPort.ReadOnly = True
        Me.TBPort.Size = New System.Drawing.Size(176, 20)
        Me.TBPort.TabIndex = 23
        Me.TBPort.Tag = "port"
        '
        'BTNRefresh
        '
        Me.BTNRefresh.Location = New System.Drawing.Point(299, 37)
        Me.BTNRefresh.Name = "BTNRefresh"
        Me.BTNRefresh.Size = New System.Drawing.Size(75, 23)
        Me.BTNRefresh.TabIndex = 26
        Me.BTNRefresh.Text = "&Refresh"
        Me.BTNRefresh.UseVisualStyleBackColor = True
        '
        'BTNChangeUid
        '
        Me.BTNChangeUid.Location = New System.Drawing.Point(284, 3)
        Me.BTNChangeUid.Name = "BTNChangeUid"
        Me.BTNChangeUid.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeUid.TabIndex = 28
        Me.BTNChangeUid.Tag = "uid"
        Me.BTNChangeUid.Text = "Change"
        Me.BTNChangeUid.UseVisualStyleBackColor = True
        '
        'BTNChangeIpInt
        '
        Me.BTNChangeIpInt.Location = New System.Drawing.Point(284, 32)
        Me.BTNChangeIpInt.Name = "BTNChangeIpInt"
        Me.BTNChangeIpInt.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeIpInt.TabIndex = 29
        Me.BTNChangeIpInt.Tag = "ipint"
        Me.BTNChangeIpInt.Text = "Change"
        Me.BTNChangeIpInt.UseVisualStyleBackColor = True
        '
        'BTNChangeMacInt
        '
        Me.BTNChangeMacInt.Location = New System.Drawing.Point(284, 61)
        Me.BTNChangeMacInt.Name = "BTNChangeMacInt"
        Me.BTNChangeMacInt.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeMacInt.TabIndex = 30
        Me.BTNChangeMacInt.Tag = "macint"
        Me.BTNChangeMacInt.Text = "Locked"
        Me.BTNChangeMacInt.UseVisualStyleBackColor = True
        '
        'BTNChangePort
        '
        Me.BTNChangePort.Location = New System.Drawing.Point(284, 90)
        Me.BTNChangePort.Name = "BTNChangePort"
        Me.BTNChangePort.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangePort.TabIndex = 31
        Me.BTNChangePort.Tag = "port"
        Me.BTNChangePort.Text = "Change"
        Me.BTNChangePort.UseVisualStyleBackColor = True
        '
        'BTNChangeIpDest
        '
        Me.BTNChangeIpDest.Location = New System.Drawing.Point(284, 119)
        Me.BTNChangeIpDest.Name = "BTNChangeIpDest"
        Me.BTNChangeIpDest.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeIpDest.TabIndex = 32
        Me.BTNChangeIpDest.Tag = "ipdest"
        Me.BTNChangeIpDest.Text = "Change"
        Me.BTNChangeIpDest.UseVisualStyleBackColor = True
        '
        'BTNChangeMacDest
        '
        Me.BTNChangeMacDest.Location = New System.Drawing.Point(284, 148)
        Me.BTNChangeMacDest.Name = "BTNChangeMacDest"
        Me.BTNChangeMacDest.Size = New System.Drawing.Size(75, 23)
        Me.BTNChangeMacDest.TabIndex = 33
        Me.BTNChangeMacDest.Tag = "macdest"
        Me.BTNChangeMacDest.Text = "Change"
        Me.BTNChangeMacDest.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.MACInternal, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeMacDest, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeIpDest, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangePort, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeMacInt, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TBUN, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeIpInt, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.BTNChangeUid, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TBPort, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.IPInternal, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.IPDest, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.MACDest, 1, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(16, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(381, 177)
        Me.TableLayoutPanel1.TabIndex = 35
        '
        'MACInternal
        '
        Me.MACInternal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MACInternal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MACInternal.Enabled = False
        Me.MACInternal.Location = New System.Drawing.Point(102, 61)
        Me.MACInternal.Name = "MACInternal"
        Me.MACInternal.Size = New System.Drawing.Size(161, 20)
        Me.MACInternal.TabIndex = 37
        Me.MACInternal.Tag = "macint"
        '
        'IPInternal
        '
        Me.IPInternal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.IPInternal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IPInternal.Enabled = False
        Me.IPInternal.HexIP = "FFFFFFFF"
        Me.IPInternal.Location = New System.Drawing.Point(102, 32)
        Me.IPInternal.MinimumSize = New System.Drawing.Size(125, 20)
        Me.IPInternal.Name = "IPInternal"
        Me.IPInternal.Size = New System.Drawing.Size(125, 20)
        Me.IPInternal.TabIndex = 34
        Me.IPInternal.Tag = "ipint"
        '
        'IPDest
        '
        Me.IPDest.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.IPDest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.IPDest.Enabled = False
        Me.IPDest.HexIP = "FFFFFFFF"
        Me.IPDest.Location = New System.Drawing.Point(102, 119)
        Me.IPDest.MinimumSize = New System.Drawing.Size(125, 20)
        Me.IPDest.Name = "IPDest"
        Me.IPDest.Size = New System.Drawing.Size(125, 20)
        Me.IPDest.TabIndex = 35
        Me.IPDest.Tag = "ipdest"
        '
        'MACDest
        '
        Me.MACDest.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.MACDest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MACDest.Enabled = False
        Me.MACDest.Location = New System.Drawing.Point(102, 148)
        Me.MACDest.Name = "MACDest"
        Me.MACDest.Size = New System.Drawing.Size(161, 20)
        Me.MACDest.TabIndex = 38
        Me.MACDest.Tag = "macdest"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Location = New System.Drawing.Point(26, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(403, 212)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'GBInfo
        '
        Me.GBInfo.Controls.Add(Me.LBLinfo)
        Me.GBInfo.Location = New System.Drawing.Point(435, 64)
        Me.GBInfo.Name = "GBInfo"
        Me.GBInfo.Size = New System.Drawing.Size(172, 212)
        Me.GBInfo.TabIndex = 37
        Me.GBInfo.TabStop = False
        Me.GBInfo.Text = "Info"
        '
        'LBLinfo
        '
        Me.LBLinfo.Location = New System.Drawing.Point(6, 19)
        Me.LBLinfo.Name = "LBLinfo"
        Me.LBLinfo.Size = New System.Drawing.Size(159, 193)
        Me.LBLinfo.TabIndex = 0
        Me.LBLinfo.Text = "Info"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(391, 282)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(202, 28)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "For use with Whozz Calling? " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Deluxe series units."
        '
        'cmPassword
        '
        Me.cmPassword.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPassword})
        Me.cmPassword.Name = "cmPassword"
        Me.cmPassword.Size = New System.Drawing.Size(161, 29)
        '
        'tsPassword
        '
        Me.tsPassword.Name = "tsPassword"
        Me.tsPassword.Size = New System.Drawing.Size(100, 23)
        Me.tsPassword.Text = "Password"
        '
        'tbLiteral
        '
        Me.tbLiteral.Location = New System.Drawing.Point(26, 282)
        Me.tbLiteral.Name = "tbLiteral"
        Me.tbLiteral.Size = New System.Drawing.Size(29, 20)
        Me.tbLiteral.TabIndex = 39
        Me.tbLiteral.Visible = False
        '
        'btnRetToggles
        '
        Me.btnRetToggles.Location = New System.Drawing.Point(75, 282)
        Me.btnRetToggles.Name = "btnRetToggles"
        Me.btnRetToggles.Size = New System.Drawing.Size(105, 23)
        Me.btnRetToggles.TabIndex = 40
        Me.btnRetToggles.Text = "Retrieve Toggles"
        Me.btnRetToggles.UseVisualStyleBackColor = True
        '
        'dgvPhoneData
        '
        Me.dgvPhoneData.AllowUserToAddRows = False
        Me.dgvPhoneData.AllowUserToDeleteRows = False
        Me.dgvPhoneData.AllowUserToResizeRows = False
        Me.dgvPhoneData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPhoneData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPhoneData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPhoneData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPhoneData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LineNumber, Me.InOut, Me.StartEnd, Me.Dur, Me.chk, Me.RingType, Me.dayMonth, Me.time, Me.number, Me.CallerID})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPhoneData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPhoneData.Location = New System.Drawing.Point(0, 459)
        Me.dgvPhoneData.Name = "dgvPhoneData"
        Me.dgvPhoneData.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPhoneData.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPhoneData.RowHeadersVisible = False
        Me.dgvPhoneData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvPhoneData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPhoneData.Size = New System.Drawing.Size(622, 200)
        Me.dgvPhoneData.TabIndex = 41
        '
        'LineNumber
        '
        Me.LineNumber.HeaderText = "Ln"
        Me.LineNumber.Name = "LineNumber"
        Me.LineNumber.ReadOnly = True
        Me.LineNumber.Width = 35
        '
        'InOut
        '
        Me.InOut.HeaderText = "I/O"
        Me.InOut.Name = "InOut"
        Me.InOut.ReadOnly = True
        Me.InOut.Width = 35
        '
        'StartEnd
        '
        Me.StartEnd.HeaderText = "S/E"
        Me.StartEnd.Name = "StartEnd"
        Me.StartEnd.ReadOnly = True
        Me.StartEnd.Width = 35
        '
        'Dur
        '
        Me.Dur.HeaderText = "Dur"
        Me.Dur.Name = "Dur"
        Me.Dur.ReadOnly = True
        Me.Dur.Width = 35
        '
        'chk
        '
        Me.chk.HeaderText = "CS"
        Me.chk.Name = "chk"
        Me.chk.ReadOnly = True
        Me.chk.Width = 35
        '
        'RingType
        '
        Me.RingType.HeaderText = "Ring"
        Me.RingType.Name = "RingType"
        Me.RingType.ReadOnly = True
        Me.RingType.Width = 60
        '
        'dayMonth
        '
        Me.dayMonth.HeaderText = "Date"
        Me.dayMonth.Name = "dayMonth"
        Me.dayMonth.ReadOnly = True
        Me.dayMonth.Width = 65
        '
        'time
        '
        Me.time.HeaderText = "Time"
        Me.time.Name = "time"
        Me.time.ReadOnly = True
        Me.time.Width = 65
        '
        'number
        '
        Me.number.HeaderText = "Number"
        Me.number.Name = "number"
        Me.number.ReadOnly = True
        Me.number.Width = 120
        '
        'CallerID
        '
        Me.CallerID.HeaderText = "Name"
        Me.CallerID.Name = "CallerID"
        Me.CallerID.ReadOnly = True
        Me.CallerID.Width = 130
        '
        'dgvCommData
        '
        Me.dgvCommData.AllowUserToAddRows = False
        Me.dgvCommData.AllowUserToDeleteRows = False
        Me.dgvCommData.BackgroundColor = System.Drawing.Color.White
        Me.dgvCommData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCommData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.data})
        Me.dgvCommData.Location = New System.Drawing.Point(0, 330)
        Me.dgvCommData.Name = "dgvCommData"
        Me.dgvCommData.ReadOnly = True
        Me.dgvCommData.RowHeadersVisible = False
        Me.dgvCommData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvCommData.Size = New System.Drawing.Size(622, 96)
        Me.dgvCommData.TabIndex = 42
        '
        'data
        '
        Me.data.HeaderText = "Data"
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.Width = 618
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 314)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Communication Data"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 440)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Phone Data"
        '
        'btnClearCommData
        '
        Me.btnClearCommData.Location = New System.Drawing.Point(574, 306)
        Me.btnClearCommData.Name = "btnClearCommData"
        Me.btnClearCommData.Size = New System.Drawing.Size(42, 21)
        Me.btnClearCommData.TabIndex = 45
        Me.btnClearCommData.Text = "Clear"
        Me.btnClearCommData.UseVisualStyleBackColor = True
        '
        'btnClearPhoneData
        '
        Me.btnClearPhoneData.Location = New System.Drawing.Point(574, 432)
        Me.btnClearPhoneData.Name = "btnClearPhoneData"
        Me.btnClearPhoneData.Size = New System.Drawing.Size(42, 21)
        Me.btnClearPhoneData.TabIndex = 46
        Me.btnClearPhoneData.Text = "Clear"
        Me.btnClearPhoneData.UseVisualStyleBackColor = True
        '
        'timerSendUpdate
        '
        Me.timerSendUpdate.Enabled = True
        Me.timerSendUpdate.Interval = 2000
        '
        'rbTech1
        '
        Me.rbTech1.AutoCheck = False
        Me.rbTech1.AutoSize = True
        Me.rbTech1.Location = New System.Drawing.Point(492, 17)
        Me.rbTech1.Name = "rbTech1"
        Me.rbTech1.Size = New System.Drawing.Size(38, 17)
        Me.rbTech1.TabIndex = 47
        Me.rbTech1.Text = "T1"
        Me.rbTech1.UseVisualStyleBackColor = True
        '
        'rbTech2
        '
        Me.rbTech2.AutoCheck = False
        Me.rbTech2.AutoSize = True
        Me.rbTech2.Location = New System.Drawing.Point(536, 17)
        Me.rbTech2.Name = "rbTech2"
        Me.rbTech2.Size = New System.Drawing.Size(38, 17)
        Me.rbTech2.TabIndex = 48
        Me.rbTech2.Text = "T2"
        Me.rbTech2.UseVisualStyleBackColor = True
        '
        'rbTech3
        '
        Me.rbTech3.AutoCheck = False
        Me.rbTech3.AutoSize = True
        Me.rbTech3.Location = New System.Drawing.Point(580, 17)
        Me.rbTech3.Name = "rbTech3"
        Me.rbTech3.Size = New System.Drawing.Size(38, 17)
        Me.rbTech3.TabIndex = 49
        Me.rbTech3.Text = "T3"
        Me.rbTech3.UseVisualStyleBackColor = True
        '
        'rbTechNone
        '
        Me.rbTechNone.AutoCheck = False
        Me.rbTechNone.AutoSize = True
        Me.rbTechNone.Checked = True
        Me.rbTechNone.Location = New System.Drawing.Point(435, 17)
        Me.rbTechNone.Name = "rbTechNone"
        Me.rbTechNone.Size = New System.Drawing.Size(51, 17)
        Me.rbTechNone.TabIndex = 50
        Me.rbTechNone.TabStop = True
        Me.rbTechNone.Text = "None"
        Me.rbTechNone.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 250
        '
        'pbSendingCommand
        '
        Me.pbSendingCommand.Location = New System.Drawing.Point(210, 310)
        Me.pbSendingCommand.Name = "pbSendingCommand"
        Me.pbSendingCommand.Size = New System.Drawing.Size(65, 14)
        Me.pbSendingCommand.TabIndex = 51
        Me.pbSendingCommand.Visible = False
        '
        'pbSearching
        '
        Me.pbSearching.Location = New System.Drawing.Point(380, 43)
        Me.pbSearching.Name = "pbSearching"
        Me.pbSearching.Size = New System.Drawing.Size(106, 12)
        Me.pbSearching.TabIndex = 52
        Me.pbSearching.Visible = False
        '
        'ELCForm1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 684)
        Me.Controls.Add(Me.pbSearching)
        Me.Controls.Add(Me.pbSendingCommand)
        Me.Controls.Add(Me.rbTechNone)
        Me.Controls.Add(Me.rbTech3)
        Me.Controls.Add(Me.rbTech2)
        Me.Controls.Add(Me.rbTech1)
        Me.Controls.Add(Me.btnClearPhoneData)
        Me.Controls.Add(Me.btnClearCommData)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvCommData)
        Me.Controls.Add(Me.dgvPhoneData)
        Me.Controls.Add(Me.btnRetToggles)
        Me.Controls.Add(Me.tbLiteral)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GBInfo)
        Me.Controls.Add(Me.BTEthernetSend)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTNRefresh)
        Me.Controls.Add(Me.TBOutgoingMessage)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CBDetectedUnits)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(600, 460)
        Me.Name = "ELCForm1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ethernet Link Config"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GBInfo.ResumeLayout(False)
        Me.cmPassword.ResumeLayout(False)
        Me.cmPassword.PerformLayout()
        CType(Me.dgvPhoneData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCommData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents BTEthernetSend As System.Windows.Forms.Button
    Friend WithEvents TBOutgoingMessage As System.Windows.Forms.TextBox
    Friend WithEvents TSConnectedUnits As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CBDetectedUnits As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TBUN As System.Windows.Forms.TextBox
    Friend WithEvents TBPort As System.Windows.Forms.TextBox
    Friend WithEvents BTNRefresh As System.Windows.Forms.Button
    Friend WithEvents BTNChangeUid As System.Windows.Forms.Button
    Friend WithEvents BTNChangeIpInt As System.Windows.Forms.Button
    Friend WithEvents BTNChangeMacInt As System.Windows.Forms.Button
    Friend WithEvents BTNChangePort As System.Windows.Forms.Button
    Friend WithEvents BTNChangeIpDest As System.Windows.Forms.Button
    Friend WithEvents BTNChangeMacDest As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents IPInternal As IPControlsClass.IPInput
    Friend WithEvents IPDest As IPControlsClass.IPInput
    Friend WithEvents MACInternal As IPControlsClass.MACInput
    Friend WithEvents MACDest As IPControlsClass.MACInput
    Friend WithEvents GBInfo As System.Windows.Forms.GroupBox
    Friend WithEvents LBLinfo As System.Windows.Forms.Label
    Friend WithEvents TMIManual As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AutomaticSetupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetNetworkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ResetUnitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListeningPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSPort As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmPassword As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents tsPassword As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents UploadDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SaveDataLocallyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetUnitToCurrentTimeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetUnitLineCountTo1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tbLiteral As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DisplayComputersIPAddressToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnRetToggles As System.Windows.Forms.Button
    Friend WithEvents dgvPhoneData As System.Windows.Forms.DataGridView
    Friend WithEvents dgvCommData As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LineNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InOut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartEnd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RingType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dayMonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents number As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CallerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents data As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnClearCommData As System.Windows.Forms.Button
    Friend WithEvents btnClearPhoneData As System.Windows.Forms.Button
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents timerSendUpdate As System.Windows.Forms.Timer
    Friend WithEvents rbTech1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbTech2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbTech3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbTechNone As System.Windows.Forms.RadioButton
    Friend WithEvents sfdSaveLocal As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SetDeluxeUnitToBasicUnitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbListeningOn As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lbDeluxeUnit As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents pbSendingCommand As System.Windows.Forms.ProgressBar
    Friend WithEvents pbSearching As System.Windows.Forms.ProgressBar

End Class
