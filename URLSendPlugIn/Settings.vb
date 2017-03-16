Imports System.Windows.Forms
Imports CIDClass

Public Class DialogSettings
    Private annoying As Boolean = False
    Private annoyanceCount As Integer = 0
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        My.Settings.URL = tbURL.Text
        My.Settings.TestURL = tbTestURL.Text
        My.Settings.Save()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub DialogSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tbURL.Text = My.Settings.URL
        tbTestURL.Text = My.Settings.TestURL
        If My.Settings.Enabled = True Then ckbEnabled.Checked = True Else ckbEnabled.Checked = False
    End Sub

    Private Sub tbURL_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tbURL.Enter, tbURL.Click
        If Not annoying Then
            annoyanceCount = annoyanceCount + 1
            If annoyanceCount > 4 Then annoying = True
            tbURL.SelectionStart = 0
            tbURL.SelectionLength = tbURL.Text.Length
        End If
    End Sub

    Private Sub btTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btTest.Click

        ' Setup variables for send
        Dim sendURL As String = tbTestURL.Text
        Dim result As Object
        Dim data As Object = Nothing
        Dim item As CIDRecord = data
        Dim webClient As System.Net.WebClient = New System.Net.WebClient()
        
        'item.Name
        sendURL = Strings.Replace(sendURL, "%Name", "CallerID.com")

        'item.Phone
        sendURL = Strings.Replace(sendURL, "%Num", "8002404637")
        sendURL = Strings.Replace(sendURL, "%Phone", "8002404637")

        'item.Line
        sendURL = Strings.Replace(sendURL, "%Line", "01")

        'item.CallTime
        sendURL = Strings.Replace(sendURL, "%Time", DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"))

        'item.Duration
        sendURL = Strings.Replace(sendURL, "%Duration", "0060")

        'item.IsStartRecord
        sendURL = Strings.Replace(sendURL, "%SE", "Start")
        
        'item.Rings
        sendURL = Strings.Replace(sendURL, "%RingNumber", "1")

        'item.RingType
        sendURL = Strings.Replace(sendURL, "%RingType", "A")

        'item.IsInbound
        sendURL = Strings.Replace(sendURL, "%IO", "Inbound")

        'item.DetailType
        sendURL = Strings.Replace(sendURL, "%Status", "")
        
        'TaxiTime mistakes
        sendURL = Strings.Replace(sendURL, "[Place Name here]", "CallerID.com")
        sendURL = Strings.Replace(sendURL, "[Place Tel here]", "8002404637")
        sendURL = Strings.Replace(sendURL, "[Place Line number here]", "01")
        Try
           
            result = webClient.DownloadString(sendURL)
            
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ckbEnabled_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckbEnabled.Click

        ' Set if not set, unset if set - enabled setting
        If My.Settings.Enabled = False Then

            ckbEnabled.Checked = True
            My.Settings.Enabled = True

        Else

            ckbEnabled.Checked = False
            My.Settings.Enabled = False

        End If

    End Sub
End Class
