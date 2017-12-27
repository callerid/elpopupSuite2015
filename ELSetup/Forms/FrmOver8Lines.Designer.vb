<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOver8Lines
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmOver8Lines))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.ckbDoNotShow = New System.Windows.Forms.CheckBox()
        Me.btnMoreInfo = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(297, 69)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.TabStop = False
        Me.TextBox1.Text = "Line number sent is above 8.  Unless you are using multiple units, the line numbe" & _
            "r that your hardware is sending needs to be adjusted."
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(12, 114)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ckbDoNotShow
        '
        Me.ckbDoNotShow.AutoSize = True
        Me.ckbDoNotShow.Location = New System.Drawing.Point(122, 87)
        Me.ckbDoNotShow.Name = "ckbDoNotShow"
        Me.ckbDoNotShow.Size = New System.Drawing.Size(187, 17)
        Me.ckbDoNotShow.TabIndex = 2
        Me.ckbDoNotShow.Text = "Do NOT show this message again"
        Me.ckbDoNotShow.UseVisualStyleBackColor = True
        '
        'btnMoreInfo
        '
        Me.btnMoreInfo.Location = New System.Drawing.Point(234, 114)
        Me.btnMoreInfo.Name = "btnMoreInfo"
        Me.btnMoreInfo.Size = New System.Drawing.Size(75, 23)
        Me.btnMoreInfo.TabIndex = 3
        Me.btnMoreInfo.Text = "More Info"
        Me.btnMoreInfo.UseVisualStyleBackColor = True
        '
        'FrmOver8Lines
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 148)
        Me.Controls.Add(Me.btnMoreInfo)
        Me.Controls.Add(Me.ckbDoNotShow)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TextBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmOver8Lines"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Line Count is over 8 lines"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents ckbDoNotShow As System.Windows.Forms.CheckBox
    Friend WithEvents btnMoreInfo As System.Windows.Forms.Button
End Class
