﻿Module Module1

    Public socketThrown As Boolean = False
    Public ProgramClosed As Boolean = False

    ' Loops for a specificied period of time (milliseconds)
    Public Sub waitFor(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            If ProgramClosed And ELCForm1.Visible = False Then End
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub
End Module
