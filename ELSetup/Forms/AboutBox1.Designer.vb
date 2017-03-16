<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutBox1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutBox1))
        Me.lbName = New System.Windows.Forms.Label()
        Me.lbVersion = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbName
        '
        Me.lbName.AutoSize = True
        Me.lbName.Location = New System.Drawing.Point(12, 9)
        Me.lbName.Name = "lbName"
        Me.lbName.Size = New System.Drawing.Size(35, 13)
        Me.lbName.TabIndex = 0
        Me.lbName.Text = "Name"
        '
        'lbVersion
        '
        Me.lbVersion.AutoSize = True
        Me.lbVersion.Location = New System.Drawing.Point(12, 35)
        Me.lbVersion.Name = "lbVersion"
        Me.lbVersion.Size = New System.Drawing.Size(42, 13)
        Me.lbVersion.TabIndex = 1
        Me.lbVersion.Text = "Version"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(54, 121)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 39)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Company: CallerID.com" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Copyright 2014"
        '
        'AboutBox1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(181, 154)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbVersion)
        Me.Controls.Add(Me.lbName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AboutBox1"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AboutBox1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbName As System.Windows.Forms.Label
    Friend WithEvents lbVersion As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
