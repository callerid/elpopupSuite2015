<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.txtLine1 = New System.Windows.Forms.TextBox()
        Me.txtLine2 = New System.Windows.Forms.TextBox()
        Me.txtLine3 = New System.Windows.Forms.TextBox()
        Me.txtLine4 = New System.Windows.Forms.TextBox()
        Me.DGVCallList = New System.Windows.Forms.DataGridView()
        Me.cName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Phone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Line = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Direction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RealTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RCMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopyNameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.LookupNumberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteRecordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TrayMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowMainWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideMainWindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.QuitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnTest = New System.Windows.Forms.Button()
        Me.HelpProvider1 = New System.Windows.Forms.HelpProvider()
        Me.cbSearch = New System.Windows.Forms.ComboBox()
        Me.txtLine7 = New System.Windows.Forms.TextBox()
        Me.txtLine8 = New System.Windows.Forms.TextBox()
        Me.txtLine5 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLine6 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.txtLine10 = New System.Windows.Forms.TextBox()
        Me.txtLine12 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtLine9 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtLine11 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.timerKeyWatch = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearDatabaseOfALLCallsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DGVCallList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RCMenu.SuspendLayout()
        Me.TrayMenu.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtLine1
        '
        Me.txtLine1.BackColor = System.Drawing.Color.White
        Me.HelpProvider1.SetHelpString(Me.txtLine1, "")
        Me.txtLine1.Location = New System.Drawing.Point(37, 26)
        Me.txtLine1.Name = "txtLine1"
        Me.txtLine1.ReadOnly = True
        Me.HelpProvider1.SetShowHelp(Me.txtLine1, True)
        Me.txtLine1.Size = New System.Drawing.Size(193, 20)
        Me.txtLine1.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.txtLine1, "CallerID on Line 1")
        '
        'txtLine2
        '
        Me.txtLine2.BackColor = System.Drawing.Color.White
        Me.HelpProvider1.SetHelpString(Me.txtLine2, "")
        Me.txtLine2.Location = New System.Drawing.Point(37, 52)
        Me.txtLine2.Name = "txtLine2"
        Me.txtLine2.ReadOnly = True
        Me.HelpProvider1.SetShowHelp(Me.txtLine2, True)
        Me.txtLine2.Size = New System.Drawing.Size(193, 20)
        Me.txtLine2.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.txtLine2, "CallerID on Line 2")
        '
        'txtLine3
        '
        Me.txtLine3.BackColor = System.Drawing.Color.White
        Me.HelpProvider1.SetHelpString(Me.txtLine3, "")
        Me.txtLine3.Location = New System.Drawing.Point(37, 78)
        Me.txtLine3.Name = "txtLine3"
        Me.txtLine3.ReadOnly = True
        Me.HelpProvider1.SetShowHelp(Me.txtLine3, True)
        Me.txtLine3.Size = New System.Drawing.Size(193, 20)
        Me.txtLine3.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.txtLine3, "CallerID on Line 3")
        '
        'txtLine4
        '
        Me.txtLine4.BackColor = System.Drawing.Color.White
        Me.HelpProvider1.SetHelpString(Me.txtLine4, "")
        Me.txtLine4.Location = New System.Drawing.Point(37, 104)
        Me.txtLine4.Name = "txtLine4"
        Me.txtLine4.ReadOnly = True
        Me.HelpProvider1.SetShowHelp(Me.txtLine4, True)
        Me.txtLine4.Size = New System.Drawing.Size(193, 20)
        Me.txtLine4.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.txtLine4, "CallerID on Line 4")
        '
        'DGVCallList
        '
        Me.DGVCallList.AllowUserToAddRows = False
        Me.DGVCallList.AllowUserToDeleteRows = False
        Me.DGVCallList.AllowUserToOrderColumns = True
        Me.DGVCallList.AllowUserToResizeRows = False
        Me.DGVCallList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGVCallList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCallList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cName, Me.Phone, Me.Time, Me.Duration, Me.Line, Me.Direction, Me.RealTime})
        Me.DGVCallList.ContextMenuStrip = Me.RCMenu
        Me.DGVCallList.Location = New System.Drawing.Point(14, 167)
        Me.DGVCallList.Name = "DGVCallList"
        Me.DGVCallList.ReadOnly = True
        Me.DGVCallList.RowHeadersVisible = False
        Me.DGVCallList.Size = New System.Drawing.Size(337, 238)
        Me.DGVCallList.TabIndex = 6
        Me.ToolTip1.SetToolTip(Me.DGVCallList, "Last 500 Callers")
        '
        'cName
        '
        Me.cName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.cName.FillWeight = 30.0!
        Me.cName.HeaderText = "Name"
        Me.cName.Name = "cName"
        Me.cName.ReadOnly = True
        Me.cName.ToolTipText = "Caller's Name/Company"
        Me.cName.Width = 110
        '
        'Phone
        '
        Me.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Phone.FillWeight = 30.0!
        Me.Phone.HeaderText = "Number"
        Me.Phone.Name = "Phone"
        Me.Phone.ReadOnly = True
        Me.Phone.ToolTipText = "Caller's Phone Number"
        Me.Phone.Width = 110
        '
        'Time
        '
        Me.Time.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Time.HeaderText = "Time and Date"
        Me.Time.Name = "Time"
        Me.Time.ReadOnly = True
        Me.Time.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        Me.Time.ToolTipText = "Time that the call started"
        Me.Time.Width = 130
        '
        'Duration
        '
        Me.Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        Me.Duration.ReadOnly = True
        Me.Duration.ToolTipText = "Length of the call"
        Me.Duration.Width = 73
        '
        'Line
        '
        Me.Line.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Line.HeaderText = "Line"
        Me.Line.Name = "Line"
        Me.Line.ReadOnly = True
        Me.Line.ToolTipText = "Line that the call was on"
        Me.Line.Width = 53
        '
        'Direction
        '
        Me.Direction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Direction.HeaderText = "IO"
        Me.Direction.Name = "Direction"
        Me.Direction.ReadOnly = True
        Me.Direction.ToolTipText = "Inbound call or Outbound call"
        Me.Direction.Width = 20
        '
        'RealTime
        '
        Me.RealTime.HeaderText = "RealTime"
        Me.RealTime.Name = "RealTime"
        Me.RealTime.ReadOnly = True
        Me.RealTime.Visible = False
        '
        'RCMenu
        '
        Me.RCMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyNameToolStripMenuItem, Me.CopyNumberToolStripMenuItem, Me.ToolStripSeparator3, Me.LookupNumberToolStripMenuItem, Me.ToolStripSeparator1, Me.DeleteRecordToolStripMenuItem})
        Me.RCMenu.Name = "RCMenu"
        Me.RCMenu.Size = New System.Drawing.Size(162, 104)
        '
        'CopyNameToolStripMenuItem
        '
        Me.CopyNameToolStripMenuItem.Name = "CopyNameToolStripMenuItem"
        Me.CopyNameToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyNameToolStripMenuItem.Text = "Copy Name"
        '
        'CopyNumberToolStripMenuItem
        '
        Me.CopyNumberToolStripMenuItem.Name = "CopyNumberToolStripMenuItem"
        Me.CopyNumberToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CopyNumberToolStripMenuItem.Text = "Copy Number"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(158, 6)
        '
        'LookupNumberToolStripMenuItem
        '
        Me.LookupNumberToolStripMenuItem.Name = "LookupNumberToolStripMenuItem"
        Me.LookupNumberToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.LookupNumberToolStripMenuItem.Text = "Lookup Number"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(158, 6)
        '
        'DeleteRecordToolStripMenuItem
        '
        Me.DeleteRecordToolStripMenuItem.Name = "DeleteRecordToolStripMenuItem"
        Me.DeleteRecordToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.DeleteRecordToolStripMenuItem.Text = "Delete Record(s)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search"
        '
        'TrayMenu
        '
        Me.TrayMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowMainWindowToolStripMenuItem, Me.HideMainWindowToolStripMenuItem, Me.OptionsToolStripMenuItem, Me.UserManualToolStripMenuItem, Me.ToolStripSeparator2, Me.QuitToolStripMenuItem})
        Me.TrayMenu.Name = "TrayMenu"
        Me.TrayMenu.Size = New System.Drawing.Size(182, 120)
        '
        'ShowMainWindowToolStripMenuItem
        '
        Me.ShowMainWindowToolStripMenuItem.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ShowMainWindowToolStripMenuItem.Name = "ShowMainWindowToolStripMenuItem"
        Me.ShowMainWindowToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ShowMainWindowToolStripMenuItem.Text = "Show Main Window"
        '
        'HideMainWindowToolStripMenuItem
        '
        Me.HideMainWindowToolStripMenuItem.Name = "HideMainWindowToolStripMenuItem"
        Me.HideMainWindowToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.HideMainWindowToolStripMenuItem.Text = "Hide Main Window"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'UserManualToolStripMenuItem
        '
        Me.UserManualToolStripMenuItem.Name = "UserManualToolStripMenuItem"
        Me.UserManualToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UserManualToolStripMenuItem.Text = "User Manual"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(178, 6)
        '
        'QuitToolStripMenuItem
        '
        Me.QuitToolStripMenuItem.Name = "QuitToolStripMenuItem"
        Me.QuitToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.QuitToolStripMenuItem.Text = "Quit"
        '
        'TrayIcon
        '
        Me.TrayIcon.ContextMenuStrip = Me.TrayMenu
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "ELPopup"
        Me.TrayIcon.Visible = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "L1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "L2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(19, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "L3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "L4"
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(261, 131)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(79, 20)
        Me.btnTest.TabIndex = 7
        Me.btnTest.Text = "Test Call"
        Me.btnTest.UseVisualStyleBackColor = True
        Me.btnTest.Visible = False
        '
        'cbSearch
        '
        Me.cbSearch.FormattingEnabled = True
        Me.cbSearch.Items.AddRange(New Object() {"", "inbound", "outbound", "today", "yesterday", "morning", "afternoon", "this week", "last week", "this month", "last month"})
        Me.cbSearch.Location = New System.Drawing.Point(65, 130)
        Me.cbSearch.Name = "cbSearch"
        Me.cbSearch.Size = New System.Drawing.Size(165, 21)
        Me.cbSearch.TabIndex = 0
        '
        'txtLine7
        '
        Me.txtLine7.BackColor = System.Drawing.Color.White
        Me.txtLine7.Location = New System.Drawing.Point(261, 78)
        Me.txtLine7.Name = "txtLine7"
        Me.txtLine7.ReadOnly = True
        Me.txtLine7.Size = New System.Drawing.Size(193, 20)
        Me.txtLine7.TabIndex = 3
        Me.txtLine7.Visible = False
        '
        'txtLine8
        '
        Me.txtLine8.BackColor = System.Drawing.Color.White
        Me.txtLine8.Location = New System.Drawing.Point(261, 104)
        Me.txtLine8.Name = "txtLine8"
        Me.txtLine8.ReadOnly = True
        Me.txtLine8.Size = New System.Drawing.Size(193, 20)
        Me.txtLine8.TabIndex = 4
        Me.txtLine8.Visible = False
        '
        'txtLine5
        '
        Me.txtLine5.BackColor = System.Drawing.Color.White
        Me.txtLine5.Location = New System.Drawing.Point(261, 26)
        Me.txtLine5.Name = "txtLine5"
        Me.txtLine5.ReadOnly = True
        Me.txtLine5.Size = New System.Drawing.Size(193, 20)
        Me.txtLine5.TabIndex = 1
        Me.txtLine5.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(236, 107)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "L8"
        Me.Label6.Visible = False
        '
        'txtLine6
        '
        Me.txtLine6.BackColor = System.Drawing.Color.White
        Me.txtLine6.Location = New System.Drawing.Point(261, 52)
        Me.txtLine6.Name = "txtLine6"
        Me.txtLine6.ReadOnly = True
        Me.txtLine6.Size = New System.Drawing.Size(193, 20)
        Me.txtLine6.TabIndex = 2
        Me.txtLine6.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(236, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "L7"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(235, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "L6"
        Me.Label8.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(236, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "L5"
        Me.Label9.Visible = False
        '
        'SerialPort1
        '
        '
        'txtLine10
        '
        Me.txtLine10.BackColor = System.Drawing.Color.White
        Me.txtLine10.Location = New System.Drawing.Point(487, 39)
        Me.txtLine10.Name = "txtLine10"
        Me.txtLine10.ReadOnly = True
        Me.txtLine10.Size = New System.Drawing.Size(193, 20)
        Me.txtLine10.TabIndex = 2
        Me.txtLine10.Visible = False
        '
        'txtLine12
        '
        Me.txtLine12.BackColor = System.Drawing.Color.White
        Me.txtLine12.Location = New System.Drawing.Point(487, 91)
        Me.txtLine12.Name = "txtLine12"
        Me.txtLine12.ReadOnly = True
        Me.txtLine12.Size = New System.Drawing.Size(193, 20)
        Me.txtLine12.TabIndex = 4
        Me.txtLine12.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(462, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(25, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "L12"
        Me.Label10.Visible = False
        '
        'txtLine9
        '
        Me.txtLine9.BackColor = System.Drawing.Color.White
        Me.txtLine9.Location = New System.Drawing.Point(487, 13)
        Me.txtLine9.Name = "txtLine9"
        Me.txtLine9.ReadOnly = True
        Me.txtLine9.Size = New System.Drawing.Size(193, 20)
        Me.txtLine9.TabIndex = 1
        Me.txtLine9.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(462, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "L11"
        Me.Label11.Visible = False
        '
        'txtLine11
        '
        Me.txtLine11.BackColor = System.Drawing.Color.White
        Me.txtLine11.Location = New System.Drawing.Point(487, 65)
        Me.txtLine11.Name = "txtLine11"
        Me.txtLine11.ReadOnly = True
        Me.txtLine11.Size = New System.Drawing.Size(193, 20)
        Me.txtLine11.TabIndex = 3
        Me.txtLine11.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(461, 42)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(25, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "L10"
        Me.Label12.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(462, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(19, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "L9"
        Me.Label13.Visible = False
        '
        'timerKeyWatch
        '
        Me.timerKeyWatch.Enabled = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(362, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearDatabaseOfALLCallsToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ClearDatabaseOfALLCallsToolStripMenuItem
        '
        Me.ClearDatabaseOfALLCallsToolStripMenuItem.Name = "ClearDatabaseOfALLCallsToolStripMenuItem"
        Me.ClearDatabaseOfALLCallsToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.ClearDatabaseOfALLCallsToolStripMenuItem.Text = "&Clear Database of ALL Calls"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 417)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.cbSearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DGVCallList)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtLine2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtLine1)
        Me.Controls.Add(Me.txtLine4)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtLine3)
        Me.Controls.Add(Me.txtLine7)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtLine5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtLine8)
        Me.Controls.Add(Me.txtLine6)
        Me.Controls.Add(Me.txtLine11)
        Me.Controls.Add(Me.txtLine10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtLine9)
        Me.Controls.Add(Me.txtLine12)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(230, 151)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "ELPopup"
        CType(Me.DGVCallList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RCMenu.ResumeLayout(False)
        Me.TrayMenu.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtLine1 As System.Windows.Forms.TextBox
    Friend WithEvents txtLine2 As System.Windows.Forms.TextBox
    Friend WithEvents txtLine3 As System.Windows.Forms.TextBox
    Friend WithEvents txtLine4 As System.Windows.Forms.TextBox
    Friend WithEvents DGVCallList As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CallRecordsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TrayMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayIcon As System.Windows.Forms.NotifyIcon
    Friend WithEvents ShowMainWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideMainWindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents HelpProvider1 As System.Windows.Forms.HelpProvider
    Friend WithEvents cbSearch As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtLine7 As System.Windows.Forms.TextBox
    Friend WithEvents txtLine8 As System.Windows.Forms.TextBox
    Friend WithEvents txtLine5 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtLine6 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RCMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteRecordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LookupNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents UserManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtLine10 As System.Windows.Forms.TextBox
    Friend WithEvents txtLine12 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLine9 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtLine11 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Phone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Time As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Duration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Line As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Direction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RealTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CopyNameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopyNumberToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents timerKeyWatch As System.Windows.Forms.Timer
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearDatabaseOfALLCallsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
