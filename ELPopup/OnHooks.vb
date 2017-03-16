Public Class OnHooks

    Private Sub OnHooks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Location = New Point(screenWidth - (Me.Width) - (Me.Width / 2) - (Me.Width / 3), 0)

    End Sub
End Class