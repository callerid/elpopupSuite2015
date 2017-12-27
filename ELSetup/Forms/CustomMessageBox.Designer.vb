<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomMessageBox
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
        Me.rtbMessage = New System.Windows.Forms.RichTextBox()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rtbMessage
        '
        Me.rtbMessage.BackColor = System.Drawing.SystemColors.Control
        Me.rtbMessage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbMessage.Cursor = System.Windows.Forms.Cursors.Default
        Me.rtbMessage.Location = New System.Drawing.Point(12, 12)
        Me.rtbMessage.Name = "rtbMessage"
        Me.rtbMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbMessage.Size = New System.Drawing.Size(373, 153)
        Me.rtbMessage.TabIndex = 0
        Me.rtbMessage.Text = "Message"
        '
        'btn1
        '
        Me.btn1.Location = New System.Drawing.Point(298, 171)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(87, 26)
        Me.btn1.TabIndex = 1
        Me.btn1.Text = "Button1"
        Me.btn1.UseVisualStyleBackColor = True
        '
        'btn2
        '
        Me.btn2.Location = New System.Drawing.Point(205, 171)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(87, 26)
        Me.btn2.TabIndex = 2
        Me.btn2.Text = "Button2"
        Me.btn2.UseVisualStyleBackColor = True
        '
        'CustomMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 209)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.rtbMessage)
        Me.Name = "CustomMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CustomMessageBox"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rtbMessage As System.Windows.Forms.RichTextBox
    Friend WithEvents btn1 As System.Windows.Forms.Button
    Friend WithEvents btn2 As System.Windows.Forms.Button
End Class
