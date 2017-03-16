Imports System.Windows.Forms

Public Class DialogSettings

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If tbBlockNumber.Text.Length <> 12 Then
            Dim result As MsgBoxResult = MsgBox("Must be a 12 digit number. Include leading zeros." + vbCrLf + vbCrLf + "Try Again?", MsgBoxStyle.YesNo, "Try again? (Wrong number of digits)")
            If result = MsgBoxResult.Yes Then Exit Sub
            If result = MsgBoxResult.No Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
        My.Settings.BlockNumber = tbBlockNumber.Text
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbBlockNumber.Text = My.Settings.BlockNumber
    End Sub
End Class
