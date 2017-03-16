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
    Public Const OPTIONS_QUERY As Integer = 7
    Public Const OPTIONS_LOAD As Integer = 8

    Function PluginName() As String Implements IMyPlugIn.PluginName
        Return "UBlock (" + My.Settings.BlockNumber + ")"
    End Function
    Function PluginDiscription() As String Implements IMyPlugIn.PluginDiscription
        Return "Blocks a unit from showing up in ELPopup"
    End Function

    Function EventFunction(ByVal eventType As Integer, Optional ByVal data As Object = Nothing) As Object Implements IMyPlugIn.EventFunction
        If eventType = OPTIONS_QUERY Then Return True

        If eventType = OPTIONS_LOAD Then
            Dim dialog As New DialogSettings
            dialog.ShowDialog()
        End If
        If eventType = RECEIVED_NETWORK_DATA Then
            If Not TypeOf (data) Is CIDRecord Then Return Nothing
            Dim item As CIDRecord = data
            If item.UnitID = My.Settings.BlockNumber Then
                Return True
            End If
        End If

        Return Nothing
    End Function
End Class
