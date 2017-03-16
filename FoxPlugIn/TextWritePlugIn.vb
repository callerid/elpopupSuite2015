Imports CIDClass

Public Class TextWritePlugIn
    Implements IMyPlugIn

    Private _mySetting As String

    Private sPluginVersion As String = "1.1"

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
        Return "Text File Writer"
    End Function
    Function PluginDiscription() As String Implements IMyPlugIn.PluginDiscription
        If My.Settings.writePath.Length < 1 Then
            Return "Writes Caller ID phone number and name to named text file based on line number. (i.e. Line2.txt)"
        End If
        Return "Writes Caller ID phone number and name to named text file based on line number. (i.e. " + My.Settings.writePath + "\line2.txt)"
    End Function

    Function EventFunction(ByVal eventType As Integer, Optional ByVal data As Object = Nothing) As Object Implements IMyPlugIn.EventFunction

        If eventType = PLUGIN_VERSION Then Return sPluginVersion

        If eventType = OPTIONS_QUERY Then Return True

        If eventType = OPTIONS_LOAD Then
            Dim dialog As New System.Windows.Forms.FolderBrowserDialog
            dialog.Description = "Select folder to store per-line text files"
            If My.Settings.writePath.Length = 0 Then
                dialog.RootFolder = Environment.SpecialFolder.MyComputer
            Else
                dialog.SelectedPath = My.Settings.writePath
            End If
            dialog.RootFolder = Environment.SpecialFolder.MyComputer
            Dim dlgResults As System.Windows.Forms.DialogResult = dialog.ShowDialog()
            If dlgResults = Windows.Forms.DialogResult.OK Then
                My.Settings.writePath = dialog.SelectedPath
                My.Settings.Save()
            End If
        End If

        If eventType = PRE_DISPLAY_POPUP Then
            If Not TypeOf (data) Is CIDRecord Then Return False
            Dim item As CIDRecord = data
            Dim objReader As System.IO.StreamWriter
            Try
                If item.IsInbound Then
                    Dim name As String = item.Name
                    Dim number As String = item.Phone.Replace("-", "")
                    If name.Length < 15 Then name = name.PadRight(15, " ")
                    If name.Length > 15 Then name = name.Substring(0, 15)
                    If number.Length < 10 Then number = number.PadRight(10, " ")
                    If number.Length > 10 Then number = number.Substring(0, 10)
                    objReader = New System.IO.StreamWriter(My.Settings.writePath + "\line" + item.Line.ToString + ".txt")
                    objReader.Write(number + name)
                    objReader.Close()
                End If
            Catch ex As Exception

            End Try
        End If
        Return False

    End Function
End Class