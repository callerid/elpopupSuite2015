<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OnHooks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OnHooks))
        Me.lbL1 = New System.Windows.Forms.Label()
        Me.lbL2 = New System.Windows.Forms.Label()
        Me.lbL3 = New System.Windows.Forms.Label()
        Me.lbL4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbL1
        '
        Me.lbL1.AutoSize = True
        Me.lbL1.Location = New System.Drawing.Point(12, 9)
        Me.lbL1.Name = "lbL1"
        Me.lbL1.Size = New System.Drawing.Size(22, 13)
        Me.lbL1.TabIndex = 0
        Me.lbL1.Text = "L1:"
        '
        'lbL2
        '
        Me.lbL2.AutoSize = True
        Me.lbL2.Location = New System.Drawing.Point(60, 9)
        Me.lbL2.Name = "lbL2"
        Me.lbL2.Size = New System.Drawing.Size(22, 13)
        Me.lbL2.TabIndex = 1
        Me.lbL2.Text = "L2:"
        '
        'lbL3
        '
        Me.lbL3.AutoSize = True
        Me.lbL3.Location = New System.Drawing.Point(113, 9)
        Me.lbL3.Name = "lbL3"
        Me.lbL3.Size = New System.Drawing.Size(22, 13)
        Me.lbL3.TabIndex = 2
        Me.lbL3.Text = "L3:"
        '
        'lbL4
        '
        Me.lbL4.AutoSize = True
        Me.lbL4.Location = New System.Drawing.Point(161, 9)
        Me.lbL4.Name = "lbL4"
        Me.lbL4.Size = New System.Drawing.Size(22, 13)
        Me.lbL4.TabIndex = 3
        Me.lbL4.Text = "L4:"
        '
        'OnHooks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(212, 33)
        Me.Controls.Add(Me.lbL4)
        Me.Controls.Add(Me.lbL3)
        Me.Controls.Add(Me.lbL2)
        Me.Controls.Add(Me.lbL1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OnHooks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "OnHooks"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbL1 As System.Windows.Forms.Label
    Friend WithEvents lbL2 As System.Windows.Forms.Label
    Friend WithEvents lbL3 As System.Windows.Forms.Label
    Friend WithEvents lbL4 As System.Windows.Forms.Label
End Class
