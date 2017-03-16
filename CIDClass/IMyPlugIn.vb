Public Interface IMyPlugIn
    Function PluginName() As String
    Function PluginDiscription() As String

    Function EventFunction(ByVal eventType As Integer, Optional ByVal data As Object = Nothing) As Object
    
End Interface