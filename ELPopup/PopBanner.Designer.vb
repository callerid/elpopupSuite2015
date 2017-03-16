<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PopBanner
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
        Me.lblPopuptext = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblPopuptext
        '
        Me.lblPopuptext.AutoSize = True
        Me.lblPopuptext.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPopuptext.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPopuptext.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPopuptext.Location = New System.Drawing.Point(0, 0)
        Me.lblPopuptext.Name = "lblPopuptext"
        Me.lblPopuptext.Size = New System.Drawing.Size(161, 31)
        Me.lblPopuptext.TabIndex = 0
        Me.lblPopuptext.Text = "Incoming Call"
        '
        'PopBanner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Beige
        Me.ClientSize = New System.Drawing.Size(511, 36)
        Me.Controls.Add(Me.lblPopuptext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PopBanner"
        Me.Text = "PopBanner"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblPopuptext As System.Windows.Forms.Label
End Class
