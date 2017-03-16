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
    Public bPause As Boolean = False
    Public bTestMode As Boolean = False
    Private pLastPacket As String
    Public Event DataReceived(obj As Object)
    Public Event Log(ByVal LogMessage As String, ByVal iLogLevel As Integer)

    Sub UdpIdleReceive()

        Dim done As Boolean = False
        Dim udpClient As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim intEndPoint As New IPEndPoint(IPAddress.Any, 3520)

        '       Try
        udpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
        'udpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse, True)
        'Catch ex As Exception
        'MsgBox("Unable to bind to port 3520. Try turning off IPTest if it is on.", MsgBoxStyle.Information, Left(ex.ToString, 60) + "...")
        'End Try

        Try
            udpClient.Bind(intEndPoint)
        Catch ex As Exception
            MsgBox("ELPopup cannot bind to UDP Port 3520. Another Caller ID application is bound to UDP Port 3520 creating this error.  Close this other application and run ELPopup again. If necessary, use Windows 'Resource Monitor' to discover the Caller ID application.  In Resource Monitor, Select Tab  'Network', Window 'Listening Ports' , Sort on 'Port', and find UDP Port 3520.")
            Exit Sub
        End Try
        sReceivedMessage = ""
        While Not done

            Dim receiveBytes(255) As [Byte]
            Dim nByteCount As Integer
            Dim bValidMessage As Boolean = True
            Try
                nByteCount = udpClient.Receive(receiveBytes)

            Catch ex As Exception
                'If Not TypeOf (ex) Is System.Threading.ThreadAbortException Then MsgBox("Could not receive incoming packet" + vbCrLf + ex.ToString)
                If TypeOf (ex) Is System.Threading.ThreadAbortException Then udpClient.Close()
                Continue While
            End Try
            If bTestMode = False Then
                Try
                    sReceivedMessage = Encoding.Default.GetString(receiveBytes, 0, nByteCount)
                    If sReceivedMessage = pLastPacket Then bValidMessage = False
                    If Not Regex.Match(sReceivedMessage, "\^\^<U>.{6}<S>.{6}\$\$?\d{2,4}").Success Then bValidMessage = False
                    pLastPacket = sReceivedMessage
                    If sReceivedMessage.Length > 21 Then RaiseEvent Log("Inbound Packet: " + sReceivedMessage.Substring(21), 2)
                Catch ex As Exception

                End Try
            Else
                Try
                    'If InStr(Encoding.Default.GetString(receiveBytes, 0, nByteCount), "<S>") < 1 Then bValidMessage = False
                    If Not Regex.Match(Encoding.Default.GetString(receiveBytes, 0, nByteCount), "^^<U>.{6}<S>.{6}\$\d\d \w").Success Then bValidMessage = False
                    If bValidMessage Then sReceivedMessage = Encoding.Default.GetString(receiveBytes, 21, nByteCount - 21)

                Catch ex As Exception
                End Try
            End If

            If nByteCount > 24 Or bTestMode = True Then
                If bValidMessage Then RaiseEvent DataReceived(Me)
            End If

        End While
    End Sub

End Class

Public Class UdpReceiverClass2
    Public sReceivedMessage As String
    Public bPause As Boolean = False
    Public bTestMode As Boolean = False
    Private pLastPacket As String
    Public Event DataReceived(obj As Object)
    Public Event Log(ByVal LogMessage As String, ByVal iLogLevel As Integer)

    Sub UdpIdleReceive()

        Dim done As Boolean = False
        Dim udpClient As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
        Dim intEndPoint As New IPEndPoint(IPAddress.Any, 3521)

        '       Try
        udpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
        'udpClient.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ExclusiveAddressUse, True)
        'Catch ex As Exception
        'MsgBox("Unable to bind to port 3520. Try turning off IPTest if it is on.", MsgBoxStyle.Information, Left(ex.ToString, 60) + "...")
        'End Try

        Try
            udpClient.Bind(intEndPoint)
        Catch ex As Exception
            MsgBox("ELPopup could not bind to cannot bind to UDP Port 3521. Another Caller ID application is bound to UDP Port 3521 creating this error.  Close this other application and run ELPopup again. If necessary, use Window 'Resource Monitor' to discover the Caller ID application.  In Resource Monitor, Select Tab  'Network', Window 'Listening Ports' , Sort on 'Protocol', and find UDP Port 3521.")
            Exit Sub
        End Try
        sReceivedMessage = ""
        While Not done

            Dim receiveBytes(255) As [Byte]
            Dim nByteCount As Integer
            Dim bValidMessage As Boolean = True
            Try
                nByteCount = udpClient.Receive(receiveBytes)

            Catch ex As Exception
                'If Not TypeOf (ex) Is System.Threading.ThreadAbortException Then MsgBox("Could not receive incoming packet" + vbCrLf + ex.ToString)
                If TypeOf (ex) Is System.Threading.ThreadAbortException Then udpClient.Close()
                Continue While
            End Try
            If bTestMode = False Then
                Try
                    sReceivedMessage = Encoding.Default.GetString(receiveBytes, 0, nByteCount)
                    If sReceivedMessage = pLastPacket Then bValidMessage = False
                    If Not Regex.Match(sReceivedMessage, "\^\^<U>.{6}<S>.{6}\$\$?\d{2,4}").Success Then bValidMessage = False
                    pLastPacket = sReceivedMessage
                    If sReceivedMessage.Length > 21 Then RaiseEvent Log("Inbound Packet: " + sReceivedMessage.Substring(21), 2)
                Catch ex As Exception

                End Try
            Else
                Try
                    'If InStr(Encoding.Default.GetString(receiveBytes, 0, nByteCount), "<S>") < 1 Then bValidMessage = False
                    If Not Regex.Match(Encoding.Default.GetString(receiveBytes, 0, nByteCount), "^^<U>.{6}<S>.{6}\$\d\d \w").Success Then bValidMessage = False
                    If bValidMessage Then sReceivedMessage = Encoding.Default.GetString(receiveBytes, 21, nByteCount - 21)
                Catch ex As Exception
                End Try
            End If

            If nByteCount > 24 Or bTestMode = True Then
                If bValidMessage Then RaiseEvent DataReceived(Me)
            End If

        End While
    End Sub

End Class