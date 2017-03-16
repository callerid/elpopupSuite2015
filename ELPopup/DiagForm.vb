Public Class DiagForm


    Private Sub DiagForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.bDiagOpen = False
    End Sub

    Private Sub DiagForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Form1.SerialPort1.ToString
        Form1.bDiagOpen = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not Form1.SerialPort1.IsOpen Then
            Try
                Form1.SerialPort1.Open()
            Catch ex As Exception
                MsgBox("Serial port is closed, for some reason, it could not be opened. (Perhaps it's in use?)")
            End Try

        End If
        Try
            Form1.SerialPort1.Write(tbSerialCommand.Text)
        Catch ex As Exception
        End Try
    End Sub

End Class