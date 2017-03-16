' We didn't design this class at CallerID.Com, I found it somewhere on the internet.
' Works fine though.


Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class ELCBroadcaster
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
    Public nListenPort As Integer = 3520
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


retry:
        Dim mc2EndPoint As New IPEndPoint(IPAddress.Any, nListenPort)
        Try
            myClient.Bind(mc2EndPoint)
        Catch ex As Exception
            Exit Sub
            If socketThrown = False Then
                socketThrown = True
                waitFor(1000)
                If MsgBox("This tool cannot access the Network port: " + nListenPort.ToString + ", which is used to communicate with the Vertex. Please close any Caller ID application presently running to allow this program access to the port then click 'Retry'.", vbRetryCancel, "Error Code: 008-" + nListenPort.ToString) = vbRetry Then
                    GoTo retry
                Else
                    End
                End If
            End If
            

        End Try
        socketThrown = False
        _Info = System.Text.Encoding.UTF8.GetBytes(Me.BroadcastMessage)
        Dim EndPoint As New IPEndPoint(IPAddress.Parse(Me.NetIPAddress), Me.Port)
        Dim rcEndPoint As New IPEndPoint(IPAddress.Parse("255.255.255.255"), nListenPort)
        Try
            Debug.Write(Me.BroadcastMessage)
            myClient.SendTo(Me._Info, Me._Info.Length, System.Net.Sockets.SocketFlags.None, EndPoint)
            'Use a Success Event and raise it if things worked
            RaiseEvent MessageFailed()
        Catch ex As System.Net.Sockets.SocketException
            'Instead of using a return type, why not just create
            'a Failed Event?
            RaiseEvent MessageSent()
        End Try
        'Try
        'bytes = myClient.Receive(rcEndPoint)
        'sReceivedMessage = Encoding.Default.GetString(bytes)

        ' Dim ELink As New EthernetLinkDevice
        '  ELink.ImportData(sReceivedMessage)


        '   Form1.setTextBox(ELink)

        'Catch ex As Exception

        'End Try

        myClient.Close()
        'myclient2.Close()
    End Sub
#End Region
End Class


Public Class ELCUdpReceiverClass
    Public sReceivedMessage As String
    Public sReceivedMessageUTF7 As String
    Public bPause As Boolean = False
    Public Event DataReceived()
    Public nListenPort As Integer = 3520

    Sub UdpIdleReceive()

        Dim done As Boolean = False
        Dim udpClient As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)

        udpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)

        udpClient.EnableBroadcast = True

retry:
        Dim intEndPoint As New IPEndPoint(IPAddress.Any, nListenPort)

        Try
            udpClient.Bind(intEndPoint)
        Catch ex As Exception
            If socketThrown = False Then
                socketThrown = True
                waitFor(1000)

                nListenPort = 3521

                Dim result As DialogResult
                result = vbNull
                result = MsgBox("ELConfig cannot bind to UDP Port 3520. Another Caller ID application is bound to UDP Port 3520 creating this error.  Close this other application and run ELConfig again to retry or continue to use port 3521", 262144, "Warning")

                While (result = vbNull)
                    ' wait
                End While

            End If

        End Try
        socketThrown = False
        ELCForm1.Show()
        ELCForm1.Focus()

        sReceivedMessage = ""

        While Not done

            Dim receiveBytes(8100) As [Byte]
            Dim nByteCount As Integer

            nByteCount = udpClient.ReceiveFrom(receiveBytes, 0, 200, SocketFlags.None, intEndPoint)
            Try
                ' Below was commented out because of 192.168."43".90 causing issues x.x.43.x
                'sReceivedMessage = Encoding.UTF7.GetString(receiveBytes, 0, nByteCount)
                sReceivedMessage = Encoding.Default.GetString(receiveBytes, 0, nByteCount)
                sReceivedMessageUTF7 = Encoding.UTF7.GetString(receiveBytes, 0, nByteCount)

            Catch ex As Exception
            End Try

            If nByteCount > 20 Then
                RaiseEvent DataReceived()
            End If

        End While

    End Sub

End Class

