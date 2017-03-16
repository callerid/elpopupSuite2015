Imports CIDClass
Imports System.Web

Public Class AutoPlugIn
    Implements IMyPlugIn

    Private _mySetting As String

    Private sPluginVersion As String = "2.3"

    Private Const RECEIVED_NETWORK_DATA As Integer = 1
    Private Const RECEIVED_SERIAL_DATA As Integer = 2
    Private Const POST_PARSE_DATA As Integer = 3
    Private Const PRE_DISPLAY_POPUP As Integer = 4
    Private Const POST_DISPLAY_POPUP As Integer = 5
    Private Const POPUP_CLICKED As Integer = 6
    Public Const OPTIONS_QUERY As Integer = 7
    Public Const OPTIONS_LOAD As Integer = 8
    Public Const PLUGIN_VERSION As Integer = 9
    Public Const PLUGIN_ENABLED As Integer = 10

    Function PluginName() As String Implements IMyPlugIn.PluginName
        Return "URL Send"
    End Function
    Function PluginDiscription() As String Implements IMyPlugIn.PluginDiscription
        Return "Sends Caller ID data to a URL with a GET request."
    End Function

    Function EventFunction(ByVal eventType As Integer, Optional ByVal data As Object = Nothing) As Object Implements IMyPlugIn.EventFunction
        If eventType = PLUGIN_VERSION Then Return sPluginVersion
        If eventType = OPTIONS_QUERY Then Return True

        If eventType = OPTIONS_LOAD Then
            Dim dialog As New DialogSettings
            dialog.ShowDialog()
        End If

        If eventType = RECEIVED_NETWORK_DATA Then
            Dim sendURL As String = My.Settings.URL
            If Not TypeOf (data) Is CIDRecord Then Return Nothing
            If sendURL.Contains("example.com") Or My.Settings.Enabled = False Then Return Nothing
            Dim item As CIDRecord = data
            Dim result As Object

            Dim nowMonth As String = item.CallTime.Month
            Dim nowDay As String = item.CallTime.Day
            Dim nowHour As String = item.CallTime.Hour
            Dim nowMin As String = item.CallTime.Minute
            Dim nowXM As String = item.CallTime.ToShortTimeString

            ' Convert from 24hr time
            If Integer.Parse(nowHour) > 12 Then nowHour = (Integer.Parse(nowHour) - 12).ToString

            ' Get AM or PM
            If item.CallTime.ToShortTimeString.Contains("PM") Then
                nowXM = "PM"
            Else
                nowXM = "AM"
            End If

            ' Add zeros if needed
            If nowMonth.Length = 1 Then nowMonth = "0" + nowMonth
            If nowDay.Length = 1 Then nowDay = "0" + nowDay
            If nowHour.Length = 1 Then nowHour = "0" + nowHour
            If nowMin.Length = 1 Then nowMin = "0" + nowMin
            
            'If item.Phone = "" Then Return Nothing
            Dim webClient As System.Net.WebClient = New System.Net.WebClient()

            If (Not item.DetailType = "R") And (Not item.DetailType = "F") And (Not item.DetailType = "N") Then

                'item.Name
                sendURL = Strings.Replace(sendURL, "%Name", HttpUtility.UrlEncode(item.Name), 1, , CompareMethod.Text)

                'item.Phone
                sendURL = Strings.Replace(sendURL, "%Num", HttpUtility.UrlEncode(item.Phone), 1, , CompareMethod.Text)
                sendURL = Strings.Replace(sendURL, "%Phone", HttpUtility.UrlEncode(item.Phone), 1, , CompareMethod.Text)

                'item.Line
                sendURL = Strings.Replace(sendURL, "%Line", HttpUtility.UrlEncode(item.Line.ToString), 1, , CompareMethod.Text)

                'item.CallTime
                sendURL = Strings.Replace(sendURL, "%Time", HttpUtility.UrlEncode(nowMonth + "/" + nowDay + "/" + item.CallTime.Year.ToString + " " + nowHour + ":" + nowMin + " " + nowXM), 1, , CompareMethod.Text)

                'item.Duration
                sendURL = Strings.Replace(sendURL, "%Duration", HttpUtility.UrlEncode(item.Duration), 1, , CompareMethod.Text)

                'item.IsStartRecord
                If item.IsStartRecord Then sendURL = Strings.Replace(sendURL, "%SE", HttpUtility.UrlEncode("Start"), 1, , CompareMethod.Text)
                If item.IsEndRecord Then sendURL = Strings.Replace(sendURL, "%SE", HttpUtility.UrlEncode("End"), 1, , CompareMethod.Text)

                'item.Rings
                sendURL = Strings.Replace(sendURL, "%RingNumber", HttpUtility.UrlEncode(item.Rings), 1, , CompareMethod.Text)

                'item.RingType
                sendURL = Strings.Replace(sendURL, "%RingType", HttpUtility.UrlEncode(item.RingType), 1, , CompareMethod.Text)

                'item.IsInbound
                If item.IsInbound Then sendURL = Strings.Replace(sendURL, "%IO", "Inbound", 1, , CompareMethod.Text)
                If item.IsOutbound Then sendURL = Strings.Replace(sendURL, "%IO", "Outbound", 1, , CompareMethod.Text)

                'item.DetailType
                Dim myStatus = item.DetailType
                If myStatus = "R" Then myStatus = "Ring"
                If myStatus = "F" Then myStatus = "Off-Hook"
                If myStatus = "N" Then myStatus = "On-Hook"

                If item.IsDetailed Then sendURL = Strings.Replace(sendURL, "%Status", myStatus, 1, , CompareMethod.Text)
                If Not item.IsDetailed Then sendURL = Strings.Replace(sendURL, "%Status", "", 1, , CompareMethod.Text)

                'TaxiTime mistakes
                sendURL = Strings.Replace(sendURL, "[Place Name here]", HttpUtility.UrlEncode(item.Name), 1, , CompareMethod.Text)
                sendURL = Strings.Replace(sendURL, "[Place Tel here]", HttpUtility.UrlEncode(item.Phone), 1, , CompareMethod.Text)
                sendURL = Strings.Replace(sendURL, "[Place Line number here]", HttpUtility.UrlEncode(item.Line.ToString), 1, , CompareMethod.Text)

            Else

                'item.Name
                sendURL = Strings.Replace(sendURL, "%Name", "")

                'item.Phone
                sendURL = Strings.Replace(sendURL, "%Num", "")
                sendURL = Strings.Replace(sendURL, "%Phone", "")

                'item.Line
                sendURL = Strings.Replace(sendURL, "%Line", HttpUtility.UrlEncode(item.Line.ToString), 1, , CompareMethod.Text)

                'item.CallTime
                sendURL = Strings.Replace(sendURL, "%Time", "")

                'item.Duration
                sendURL = Strings.Replace(sendURL, "%Duration", "")

                'item.IsStartRecord
                sendURL = Strings.Replace(sendURL, "%SE", "")

                'item.Rings
                sendURL = Strings.Replace(sendURL, "%RingNumber", "")

                'item.RingType
                sendURL = Strings.Replace(sendURL, "%RingType", "")

                'item.IsInbound
                sendURL = Strings.Replace(sendURL, "%IO", "")

                'item.DetailType
                Dim myStatus = item.DetailType
                If myStatus = "R" Then myStatus = "Ring"
                If myStatus = "F" Then myStatus = "Off-Hook"
                If myStatus = "N" Then myStatus = "On-Hook"

                If item.IsDetailed Then sendURL = Strings.Replace(sendURL, "%Status", myStatus, 1, , CompareMethod.Text)
                If Not item.IsDetailed Then sendURL = Strings.Replace(sendURL, "%Status", "", 1, , CompareMethod.Text)

                'TaxiTime mistakes
                sendURL = Strings.Replace(sendURL, "[Place Name here]", "CallerID.com")
                sendURL = Strings.Replace(sendURL, "[Place Tel here]", "8002404637")
                sendURL = Strings.Replace(sendURL, "[Place Line number here]", "01")

            End If

                Try
                    If My.Settings.URL.Contains("%IO") And item.IsFullRecord Then
                        Debug.WriteLine(sendURL)
                        result = webClient.DownloadString(sendURL)
                    ElseIf item.IsFullRecord And item.IsStartRecord Then
                        Debug.WriteLine(sendURL)
                        result = webClient.DownloadString(sendURL)
                    ElseIf My.Settings.URL.Contains("%SE") And item.IsFullRecord Then
                        Debug.WriteLine(sendURL)
                        result = webClient.DownloadString(sendURL)
                    ElseIf My.Settings.URL.Contains("%Status") And item.IsDetailed Then
                        Debug.WriteLine(sendURL)
                        result = webClient.DownloadString(sendURL)
                    End If
                Catch ex As Exception

                End Try


            End If

            Return Nothing
    End Function
End Class