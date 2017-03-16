Module Module1

    Public socketThrown As Boolean = False

    ' Loops for a specificied period of time (milliseconds)
    Public Sub waitFor(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub
End Module
