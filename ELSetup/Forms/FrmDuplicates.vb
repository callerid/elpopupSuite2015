Public Class FrmDuplicates

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim intVal = Integer.Parse(ndNumberOfPackets.Value.ToString())
        Dim hexStr As String = Hex(intVal)

        If (hexStr.Length = 1) Then hexStr = "0" + hexStr

        ELCForm1.BrandValue("^^IdO" + hexStr)
        waitFor(250)
        Close()

    End Sub

    Private Sub FrmDuplicates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ndNumberOfPackets.Value = ELCForm1.NumberOfDuplicates

    End Sub
End Class