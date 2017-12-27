Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Broadcaster
#Region "Delegates"
    Delegate Sub MessageSuccess()
    Delegate Sub MessageFailure()
#End Region

#Region "Private Fields"
    Private _NetIPAddress As String
    Private _Port As Int16
    Private _BroadcastMessage As String
    Private myClient As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
    Private _Info As Byte()
    'Points to MessageSuccess()
    Public Event MessageSent As MessageSuccess
    'Points to MessageFailure
    Public Event MessageFailed As MessageFailure
#End Region

#Region "Properties"
    Public Property NetIPAddress() As String
        Get
            Return _NetIPAddress
        End Get
        Set(ByVal Value As String)
            _NetIPAddress = Value
        End Set
    End Property

    Public Property Port() As Int16
        Get
            Return _Port
        End Get
        Set(ByVal Value As Int16)
            _Port = Value
        End Set
    End Property
    Public Property BroadcastMessage() As String
        Get
            Return _BroadcastMessage
        End Get
        Set(ByVal Value As String)
            _BroadcastMessage = Value
        End Set
    End Property
#End Region

#Region "Methods"
    'If this constructor is used, all you need to do is call SendMessage
    Public Sub New(ByVal IP_Address As String, ByVal PortNumber As Int16, ByVal Msg As String)
        Me.NetIPAddress = IP_Address
        Me.Port = PortNumber
        Me.BroadcastMessage = Msg
    End Sub
    'If this constructor is used, make sure you set the BroadcastMessage
    Public Sub New(ByVal IP_Address As String, ByVal PortNumber As Int16)
        Me.NetIPAddress = IP_Address
        Me.Port = PortNumber
    End Sub

    Public Sub SendMessage()
        'To make this more robust, I should probably check
        'that there is in fact a message and respond accordingly..
        'but it's Sunday night so forgive me.

        myClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
        myClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, True)
        Dim mc2EndPoint As New IPEndPoint(IPAddress.Any, 0)
        myClient.Bind(mc2EndPoint)

        _Info = System.Text.Encoding.UTF8.GetBytes(Me.BroadcastMessage)
        Dim EndPoint As New IPEndPoint(IPAddress.Parse(Me.NetIPAddress), Me.Port)
        Dim rcEndPoint As New IPEndPoint(IPAddress.Parse("255.255.255.255"), 0)
        Try
            myClient.SendTo(Me._Info, Me._Info.Length, System.Net.Sockets.SocketFlags.None, EndPoint)
            'Use a Success Event and raise it if things worked
            RaiseEvent MessageFailed()
        Catch ex As System.Net.Sockets.SocketException
            'Instead of using a return type, why not just create
            'a Failed Event?
            RaiseEvent MessageSent()
        End Try
        
        myClient.Close()
        'myclient2.Close()
    End Sub
#End Region
End Class


Public Class UdpReceiverClass

    Public sReceivedMessage As String
    Public sReceivedMessageUTF7 As String
    Public bPause As Boolean = False
    Public bTestMode As Boolean = False
    Private pLastPacket As String
    Public Event DataReceived(ByVal obj As Object)
    Public Event Log(ByVal LogMessage As String, ByVal iLogLevel As Integer)
    Public Event EndReceiving()
    Public nListenPorts() As Integer = {3520, 3521, 3522, 3523, 3524, 3525, 3526, 3527, 3528, 3529, 3530}
    Public boundPort As Integer
    Public keepListeninging As Boolean = True

    Sub UdpIdleReceive()


        Dim done As Boolean = False
        Dim udpClient As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

        udpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
        udpClient.EnableBroadcast = True

        Dim bound As Boolean = False
        Dim socketThrown As Boolean = False
        Dim intEndPoint As New IPEndPoint(IPAddress.Any, 3520)

        Dim procList() As Process = Process.GetProcessesByName("portrepeater")
        Dim usingPortRepeater As Boolean = procList.Length > 0

        If usingPortRepeater Then

            While (Not bound)

                For Each port In nListenPorts

                    Try

                        intEndPoint = New IPEndPoint(IPAddress.Any, port)
                        udpClient.Bind(intEndPoint)
                        bound = True
                        boundPort = port
                        Exit For

                    Catch ex As Exception

                        Continue For

                    End Try

                Next

            End While

        Else

            Try

                intEndPoint = New IPEndPoint(IPAddress.Any, 3520)
                udpClient.Bind(intEndPoint)
                bound = True
                boundPort = 3520

            Catch ex As Exception

                bound = False

            End Try

        End If

        If Not bound Then

            socketThrown = True
            waitFor(1000)

            Dim proc As ProcessStartInfo = New ProcessStartInfo("cmd.exe")
            Dim pr As Process
            proc.CreateNoWindow = True
            proc.UseShellExecute = False
            proc.RedirectStandardInput = True
            proc.RedirectStandardOutput = True
            pr = Process.Start(proc)
            pr.StandardInput.WriteLine("netstat -a -n -o")
            pr.StandardInput.Close()
            Dim readIn As String = pr.StandardOutput.ReadToEnd()
            pr.StandardOutput.Close()

            Dim portMatcher As String = "(UDP)(.*)0.0.0.0:3520(\s*)(\*\:\*)(\s*)([\d]{1,8})"

            Dim pMatch As MatchCollection = Regex.Matches(readIn, portMatcher)

            Dim programName As String = "none"

            Dim thisProgramPID = Integer.Parse(Process.GetCurrentProcess().Id.ToString)
            Dim foundpId As Integer = 0
            If (pMatch.Count > 0) Then

                For Each m As Match In pMatch
                    Dim pid As Integer = Integer.Parse(m.Groups(6).Value)

                    If pid = thisProgramPID Then
                        Continue For
                    End If

                    foundpId = pid

                Next

                programName = Process.GetProcessById(foundpId).ProcessName

            Else

                programName = "failed"

            End If

            If programName = "failed" Then

                MsgBox("Netstat command failed. Another program other than ELConfig may be bound to ELConfig UDP port.")

            End If

            If Not programName.ToLower() = "idle" And Not programName.ToLower() = "portrepeater" And Not programName = "failed" Then

                Dim result As DialogResult
                result = vbNull

                If (programName = "none") Then

                    result = MsgBox("ELPopup cannot bind to UDP Port 3520.  Another program may be already bound to this port.  Close any other application that uses Caller ID and relaunch the ELPopup." + Environment.NewLine + Environment.NewLine +
                                "Windows Resource Monitor can be used to discover the application bound to UDP 3520.  Within Resource Monitor, select the Network tab.  View the Listening Ports window." + Environment.NewLine + Environment.NewLine +
                                "Select 'Ok' to continue (program may be unstable) or 'Cancel' to quit.", MsgBoxStyle.OkCancel, "Failed to Launch")

                    If (result = DialogResult.Cancel) Then Environment.Exit(0)

                Else

                    result = MsgBox("ELPopup cannot bind to UDP Port 3520.  Another program has already bound itself to this port.  Close any other application that uses Caller ID and relaunch the ELPopup" + Environment.NewLine + Environment.NewLine +
                                    "This program has found that the application named '" + programName + "' is bound to Port UDP 3520.", 262144, "Failed to Launch")

                    Environment.Exit(0)

                End If

            End If

        End If

        sReceivedMessage = ""
        udpClient.ReceiveTimeout = 200
        While Not done AndAlso keepListeninging

            Dim receiveBytes(8100) As [Byte]
            Dim nByteCount As Integer

            Try
                nByteCount = udpClient.ReceiveFrom(receiveBytes, 0, 200, SocketFlags.None, intEndPoint)

                ' Below was commented out because of 192.168."43".90 causing issues x.x.43.x
                'sReceivedMessage = Encoding.UTF7.GetString(receiveBytes, 0, nByteCount)
                sReceivedMessage = Encoding.Default.GetString(receiveBytes, 0, nByteCount)
                sReceivedMessageUTF7 = Encoding.UTF7.GetString(receiveBytes, 0, nByteCount)

            Catch ex As Exception
                Console.WriteLine(ex.ToString())
                Continue While
            End Try

            If nByteCount > 20 Then
                RaiseEvent DataReceived(Me)
            End If

        End While

        udpClient.Close()

        RaiseEvent EndReceiving()


    End Sub

    Sub StopListening()

        keepListeninging = False

    End Sub

End Class