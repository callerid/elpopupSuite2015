Imports CIDClass

Public Class AutoPlugIn
    Implements IMyPlugIn

    Private _mySetting As String

    Private Const RECEIVED_NETWORK_DATA As Integer = 1
    Private Const RECEIVED_SERIAL_DATA As Integer = 2
    Private Const POST_PARSE_DATA As Integer = 3
    Private Const PRE_DISPLAY_POPUP As Integer = 4
    Private Const POST_DISPLAY_POPUP As Integer = 5
    Private Const POPUP_CLICKED As Integer = 6

    Public Function TestFunction(ByVal item As CIDRecord) As String
        Try
            If item.IsInbound Then
                Dim name As String = item.Name
                Dim number As String = item.Phone.Replace("-", "")
                If name.Length > 15 Then name = name.Substring(0, 15)
                If number.Length > 10 Then number = number.Substring(0, 10)
                Shell("C:\Temp\ELPopupScript.exe """ + name + """", AppWinStyle.NormalFocus)
            End If
        Catch ex As Exception

        End Try
        Return ""
    End Function

    Function PluginName() As String Implements IMyPlugIn.PluginName
        Return "AutoPlugIn"
    End Function
    Function PluginDiscription() As String Implements IMyPlugIn.PluginDiscription
        Return "Runs a specific AutoHotKey script every time a call comes in"
    End Function

    Function EventFunction(ByVal eventType As Integer, Optional ByVal data As Object = Nothing) As Object Implements IMyPlugIn.EventFunction
        If eventType = POST_PARSE_DATA Then
            If Not TypeOf (data) Is CIDRecord Then Return False
            Dim item As CIDRecord = data
            Try
                If item.IsInbound Then
                    Dim name As String = item.Name
                    Dim number As String = item.Phone.Replace("-", "")
                    If name.Length > 15 Then name = name.Substring(0, 15)
                    If number.Length > 10 Then number = number.Substring(0, 10)
                    Shell("C:\Temp\ELPopupScript.exe """ + name + """", AppWinStyle.NormalFocus)
                End If
            Catch ex As Exception

            End Try
            Return False
        End If

        If eventType = PRE_DISPLAY_POPUP Then
            If Not TypeOf (data) Is CIDRecord Then Return False
            Dim item As CIDRecord = data
            Try
                If item.IsInbound Then
                    Return "Something else"
                End If
            Catch ex As Exception

            End Try
            Return False
        End If

        If eventType = POPUP_CLICKED Then
            Return True
        End If

        Return False
    End Function
End Class
