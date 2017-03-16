Imports PlugInInterface

Public Interface IMyPlugIn
    Function TestFunction(ByVal item As CIDRecord) As String
    Property MySetting() As String
End Interface