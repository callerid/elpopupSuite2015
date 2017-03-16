Public Class showNumber

    Public Sub setNumber(num As String)
        Label1.Text = num
        setLocation()
    End Sub

    Public Sub setName(name As String)
        Label2.Text = name
        setLocation()
    End Sub

    Private Sub showNumber_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        setLocation()
    End Sub

    Private Sub setLocation()

        Dim labelWidth As Integer = Label1.Width
        
        Dim locationPoint As Point = New Point(Form1.Location.X, Form1.Location.Y + 25)
        If Form1.Width > 304 Then
            locationPoint.X = ((Form1.Width / 2) - (Me.Width / 2)) + locationPoint.X
        End If
        Me.Location = locationPoint
    End Sub

    Private Sub showNumber_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus
        Me.Close()
    End Sub
End Class