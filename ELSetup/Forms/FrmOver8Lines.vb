Public Class FrmOver8Lines

    Private Sub FrmOver8Lines_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If ckbDoNotShow.Checked Then
            ELCForm1.prevent8LineWarning = True
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Close()
    End Sub

    Private Sub btnMoreInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoreInfo.Click
        Frm8LineMoreInfo.Show()
    End Sub
End Class