Public Class CustomMessageBox

    Public Sub New(ByVal title As String, ByVal message As String, ByVal yesButtonText As String, ByVal noButtonText As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = title
        rtbMessage.Text = message
        btn1.Text = yesButtonText
        btn2.Text = noButtonText
        DialogResult = Windows.Forms.DialogResult.Cancel

    End Sub

    Private Sub Btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click

        DialogResult = Windows.Forms.DialogResult.Yes
        Close()

    End Sub

    Private Sub Btn2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn2.Click

        DialogResult = Windows.Forms.DialogResult.No
        Close()

    End Sub
End Class