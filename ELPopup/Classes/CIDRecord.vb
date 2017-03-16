Imports System.Text.RegularExpressions
Public Class CIDRecord
    Public Name As String
    Public Phone As String
    Public Duration As Integer
    Public Line As Integer
    Public CallStart As Boolean 'I think 'start' is a bad name for a public variable
    Public Checksum As Boolean
    Public CallTime As DateTime
    Public DetailType As String
    Public Rings As Integer
    Public RingType As String
    Public UnitID As String
    Public SerialNumber As String
    Private Inbound As Boolean 'use .IsInbound to find out
    Private Limited As Boolean
    Private detail As Boolean

    Public Sub New(Optional ByVal recordText As String = "", Optional ByVal timeSource As Integer = 0)
        '0 is from box, 1 is from the computer's local time
        If Not recordText = "" Then ImportCallRecord(recordText)
    End Sub
    Public Function IsFullRecord() As Boolean
        If Limited = False Then Return True Else Return False
    End Function
    Public Function IsDetailed() As Boolean ' need to work on this one
        If detail Then Return True Else Return False
    End Function
    Public Function IsStandard() As Boolean
        If detail Then Return False Else Return True
    End Function
    Public Function IsOutbound() As Boolean
        If Inbound = True Then Return False Else Return True
    End Function
    Public Function IsInbound() As Boolean
        If Inbound = True Then Return True Else Return False
    End Function
    Public Function IsStartRecord() As Boolean
        If CallStart = True Then Return True Else Return False
    End Function
    Public Function IsEndRecord() As Boolean
        If CallStart = True Then Return False Else Return True
    End Function
    Public Function IsGoodChecksum() As Boolean
        If Checksum Then Return True Else Return False
    End Function
    Public Function IsAMTime() As Boolean
        If CallTime.Hour > 11 Then Return False Else Return True
    End Function
    Public Sub ImportCallRecord(ByVal CallRecord As String)
        Dim sSubSet As String
        Dim ix As Integer
        Dim CallMatch As System.Text.RegularExpressions.Match

        'Find out the UnitID and serial number, if any
        If InStr(CallRecord, "^^<U>") > 0 Then
            ix = InStr(CallRecord, "^^<U>") - 1
            sSubSet = CallRecord.Substring(ix, 11) ' the size of the whole string(11)
            UnitID = CIDFunctions.UID_Decoder(Right(sSubSet, 6))
            CallRecord = CallRecord.Remove(ix, 11)
        End If
        If InStr(CallRecord, "<S>") > 0 Then
            ix = InStr(CallRecord, "<S>") - 1
            sSubSet = CallRecord.Substring(ix, 9)
            SerialNumber = CIDFunctions.UID_Decoder(Right(sSubSet, 6))
            CallRecord = CallRecord.Remove(ix, 9)
        End If
        ' instead of requireing the full 'packet' of data, you can just send the callerid record
        ' we'll remove everything before the first $ and then you can use this sub for
        ' serial data as well as packet information.
        ix = InStr(CallRecord, "$")
        CallRecord = CallRecord.Remove(0, ix)

        If Not Regex.Match(CallRecord, "\d\d \w").Success Then
            Exit Sub
        End If
        'we are now (theoretically) left with just the WC output.
        'Replace any $'s with nothings
        CallRecord = CallRecord.Replace("$", "")

        CallMatch = Regex.Match(CallRecord, ".*(\d\d) ([IO]) ([ES]) (\d{4}) ([GB]) (.)(\d) (\d\d/\d\d \d\d:\d\d [AP]M) (.{8,15})(.*)")
        '                                       |      |      |      |       |    |   |            |                      |      |
        '                                   01 Line #  |      |      |       |    | 07 Ring#       |                      |    10 Name
        '                               02 Inbound/outbound   |   04 Duration| 06 Ring Type        |                 09 Phone Number
        '                                               03 Start/End recrod  |          08 Date of call start
        '                                                                05 Good/Bad record checksum
        If CallMatch.Success Then ' it's a full record.
            detail = False
            Limited = False
            Line = Val(CallMatch.Groups.Item(1).Value)
            If CallMatch.Groups.Item(3).Value = "S" Then CallStart = True Else CallStart = False
            If CallMatch.Groups.Item(2).Value = "I" Then Inbound = True Else Inbound = False
            DetailType = CallMatch.Groups.Item(2).Value
            Duration = Val(CallMatch.Groups.Item(4).Value)
            If CallMatch.Groups.Item(5).Value = "G" Then Checksum = True Else Checksum = False
            RingType = CallMatch.Groups.Item(6).Value
            Rings = Val(CallMatch.Groups.Item(7).Value)
            Try
                CallTime = Date.ParseExact(CallMatch.Groups.Item(8).Value, "MM/dd hh:mm tt", System.Globalization.DateTimeFormatInfo.CurrentInfo)
            Catch ex As Exception
                CallTime = My.Computer.Clock.LocalTime
            End Try
            Phone = CallMatch.Groups.Item(9).Value.Trim(" ")
            Name = CallMatch.Groups.Item(10).Value.Replace(vbCr, "").Trim(" ") ' Sometimes carrage returns sneak in the serial port door.
        End If

        CallMatch = Regex.Match(CallRecord, ".*(\d\d) ([NFR]) {13}(\d\d/\d\d \d\d:\d\d:\d\d)")
        If CallMatch.Success Then ' it's a detail record.
            detail = True
            Limited = False
            DetailType = CallMatch.Groups.Item(2).Value
            Line = Val(CallMatch.Groups.Item(1).Value)
            Try
                CallTime = Date.ParseExact(CallMatch.Groups.Item(3).Value, "MM/dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.CurrentInfo)
            Catch ex As Exception
                CallTime = My.Computer.Clock.LocalTime
            End Try
        End If


        ''is it a full record? or just on/off hook stuff.
        'If CallRecord.Length > 32 Then detail = False Else detail = True
        'CallRecord = CallRecord.PadRight(61, " ")
        '' ok, Is it 'limited' or 'normal'? Normal records always have an I or an O as the 4th charicter
        '' (or 3rd charicter if you count the first one as the zero'th one...
        '' so we'll use that to figure out how to pull apart the rest of the string.
        'If CallRecord.Substring(3, 1) = " " Then Limited = True Else Limited = False

        'If Limited = False Then
        '    Line = Val(CallRecord.Substring(0, 2))
        '    DetailType = CallRecord.Substring(3, 1)
        '    Debug.Print(CallRecord)

        '    If detail = True Then
        '        Try
        '            CallTime = Date.ParseExact(CallRecord.Substring(17, 14), "MM/dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.CurrentInfo)
        '        Catch ex As Exception
        '            CallTime = My.Computer.Clock.LocalTime
        '        End Try
        '    Else

        '        If CallRecord.Substring(5, 1) = "S" Then CallStart = True Else CallStart = False
        '        If CallRecord.Substring(3, 1) = "I" Then Inbound = True Else Inbound = False
        '        Duration = Val(CallRecord.Substring(7, 4))
        '        If CallRecord.Substring(12, 1) = "G" Then Checksum = True Else Checksum = False
        '        RingType = CallRecord.Substring(14, 1)
        '        Rings = Val(CallRecord.Substring(15, 1))
        '        Try
        '            CallTime = Date.ParseExact(CallRecord.Substring(17, 14), "MM/dd hh:mm tt", System.Globalization.DateTimeFormatInfo.CurrentInfo)
        '        Catch ex As Exception
        '            CallTime = My.Computer.Clock.LocalTime
        '        End Try
        '        'I have no idea what the last part means. It seems to satisfy VB.NET so whatever...
        '        Phone = CallRecord.Substring(32, 14).Trim(" ")
        '        Name = CallRecord.Substring(46, 15).Trim(" ")

        '    End If
        'Else
        '    Line = Val(CallRecord.Substring(0, 2))
        '    Try
        '        CallTime = Date.ParseExact(CallRecord.Substring(7, 18), "MM/dd     hh:mm tt", System.Globalization.DateTimeFormatInfo.CurrentInfo)
        '        'Seriously...System.globalWHAT? anyway, noticed the extra spaces between MM/dd and hh:mm
        '    Catch ex As Exception
        '        CallTime = My.Computer.Clock.LocalTime ' use local time if the box dosn't provide one.
        '    End Try
        '    Phone = CallRecord.Substring(26, 14).Trim(" ")
        '    If CallRecord.Substring(45, 1) = "I" Then Inbound = True Else Inbound = False
        '    Name = CallRecord.Substring(47, 15).Trim(" ")

        'End If
        ''Alright, that should do it...

    End Sub
End Class

Public Class EthernetLinkDevice
    Public Serial As String
    Public UnitID As String
    Public DestIP As String
    Public IntIP As String
    Public DestMac As String
    Public IntMac As String
    Public IntPort As String
    Public DestPort As String

    Public Sub ImportData(ByVal sData As String)
        Dim ix As Integer
        ix = InStr(sData, "$")
        sData = sData.Substring(ix)
        'Serial
        Serial = IDX_extractor("S", sData, 6)
        'UnitID
        UnitID = IDX_extractor("U", sData, 6)
        'DestIP
        DestIP = IPFromHex(IDX_extractor("D", sData, 4))
        'IntIP
        IntIP = IPFromHex(IDX_extractor("I", sData, 4))
        'DestMac
        DestMac = IDX_extractor("C", sData, 6)
        'IntMac
        IntMac = IDX_extractor("M", sData, 6)
        'DestPort
        DestPort = Str(Convert.ToInt32(IDX_extractor("P", sData, 2), 16))
        'IntPort
        IntPort = Str(Convert.ToInt32(IDX_extractor("T", sData, 2), 16))

    End Sub
    Private Function IDX_extractor(ByVal sLetter As String, ByVal sData As String, ByVal nLength As Integer)
        Dim ix As Integer
        ix = InStr(sData, "<" + sLetter.ToUpper + ">")
        sData = sData.Substring(ix + 2, nLength)
        Return CIDFunctions.UID_Decoder(sData)
    End Function
End Class
Module CIDFunctions
    Private rNumber As New Random
    Public Function FakeRecordGenerator() As String
        Dim nLine As Integer = 0
        Dim cInbout As String = "I"
        Dim cStartEnd As String = "S"
        Dim nDuration As Integer = 0
        Dim sDate As String = "01/20"
        Dim sTime As String = "12:00"
        Dim sAMPM As String = "AM"
        Dim sPhoneNumber As String
        Dim sName As String
        Dim sCallerID As String

        nLine = Math.Floor(rNumber.NextDouble * 8) + 1
        nDuration = Math.Floor(rNumber.NextDouble * 300)
        sTime = (Math.Floor(rNumber.NextDouble * 12) + 1).ToString.PadLeft(2, "0") + ":" + _
            (Math.Floor(rNumber.NextDouble * 60)).ToString.PadLeft(2, "0")
        sPhoneNumber = (Math.Floor(rNumber.NextDouble * 500) + 200).ToString + "-" + _
            (Math.Floor(rNumber.NextDouble * 500) + 200).ToString + "-" + _
            (Math.Floor(rNumber.NextDouble * 8000) + 1000).ToString + "  "
        sName = FakeNameGenerator()
        If sName.Length > 15 Then
            sName = sName.Substring(0, 15)
        End If
        sCallerID = "0" + nLine.ToString + " I S " + nDuration.ToString.PadLeft(4, "0") + " G A2 01/25 " + _
        sTime + " AM " + sPhoneNumber + " " + sName.PadRight(15, " ")
        Return sCallerID
    End Function

    Private Function FakeNameGenerator() As String
        Dim lFirstNames As New List(Of String)
        Dim lLastNames As New List(Of String)
        lFirstNames.Add("Agnes")
        lFirstNames.Add("Artie")
        lFirstNames.Add("Benjamin")
        lFirstNames.Add("Doug")
        lFirstNames.Add("Gary")
        lFirstNames.Add("Bernice")
        lFirstNames.Add("Brandine")
        lFirstNames.Add("Cecil")
        lFirstNames.Add("Charlie")
        lFirstNames.Add("Cookie")
        lFirstNames.Add("Constance")
        lFirstNames.Add("Dave")
        lFirstNames.Add("Jasper")
        lFirstNames.Add("Jebediah")
        lFirstNames.Add("Lindsey")
        lFirstNames.Add("Luigi")
        lFirstNames.Add("Manjula")
        lFirstNames.Add("Marvin")
        lFirstNames.Add("Ruth")
        lFirstNames.Add("Sanjay")
        lFirstNames.Add("Homer")
        lFirstNames.Add("Marjorie")
        lFirstNames.Add("Bart")
        lFirstNames.Add("Lisa")
        lFirstNames.Add("Margaret")
        lFirstNames.Add("Ned")
        lFirstNames.Add("Maude")
        lFirstNames.Add("Rod")
        lFirstNames.Add("Todd")
        lFirstNames.Add("Kirk")
        lFirstNames.Add("Luann")
        lFirstNames.Add("Milhouse")
        lFirstNames.Add("Apu")
        lFirstNames.Add("Manjula")
        lFirstNames.Add("Clancy")
        lFirstNames.Add("Ralph")
        lFirstNames.Add("Timothy")
        lFirstNames.Add("Helen")
        lFirstNames.Add("Nelson")
        lFirstNames.Add("Cletus")
        lFirstNames.Add("Montgomery")
        lFirstNames.Add("Waylon")
        lFirstNames.Add("Lenny")
        lFirstNames.Add("Carl")
        lFirstNames.Add("Mindy")
        lFirstNames.Add("Karl")
        lFirstNames.Add("Seymour")
        lFirstNames.Add("Gary")
        lFirstNames.Add("Edna")
        lFirstNames.Add("Willie")
        lFirstNames.Add("Otto")
        lFirstNames.Add("Lou")
        lFirstNames.Add("Eddie")
        lFirstNames.Add("Snake")
        lFirstNames.Add("Robert")
        lFirstNames.Add("Hank")
        lFirstNames.Add("Anthony")
        lFirstNames.Add("Joey")
        lFirstNames.Add("Moe")
        lFirstNames.Add("Gil")
        lFirstNames.Add("Kent")
        lFirstNames.Add("Troy")
        lFirstNames.Add("Jasper")
        lFirstNames.Add("Eleanor")

        lLastNames.Add("Simpson")
        lLastNames.Add("Powell")
        lLastNames.Add("Bouvier")
        lLastNames.Add("Flanders")
        lLastNames.Add("Van Houten")
        lLastNames.Add("Nahasapeemapetilon")
        lLastNames.Add("Wiggum")
        lLastNames.Add("Hibbert")
        lLastNames.Add("Prince")
        lLastNames.Add("Lovejoy")
        lLastNames.Add("Muntz")
        lLastNames.Add("Spuckler")
        lLastNames.Add("Burns")
        lLastNames.Add("Smithers")
        lLastNames.Add("Leonald")
        lLastNames.Add("Carlson")
        lLastNames.Add("Simmons")
        lLastNames.Add("Grimes")
        lLastNames.Add("Quimby")
        lLastNames.Add("Skinner")
        lLastNames.Add("Tamzarian")
        lLastNames.Add("Chalmers")
        lLastNames.Add("Krabapple")
        lLastNames.Add("Hoover")
        lLastNames.Add("Pommelhorst")
        lLastNames.Add("Mann")
        lLastNames.Add("Jones")
        lLastNames.Add("Starbeam")
        lLastNames.Add("Zzyzwicz")
        lLastNames.Add("Banner")
        lLastNames.Add("Snider")
        lLastNames.Add("Harm")
        lLastNames.Add("Jailbird")
        lLastNames.Add("Terwilliger")
        lLastNames.Add("Botkowski")
        lLastNames.Add("Scorpio") ' Hank Scorpio is the best character ever.
        lLastNames.Add("Lanley")
        lLastNames.Add("Di Maggio")
        lLastNames.Add("D'Amico")
        lLastNames.Add("Risotto")
        lLastNames.Add("McCallister")
        lLastNames.Add("Duff")
        lLastNames.Add("Costington")
        lLastNames.Add("Hutz")
        lLastNames.Add("Gunderson")
        lLastNames.Add("Frink")
        lLastNames.Add("Moleman")
        lLastNames.Add("Naegle")
        lLastNames.Add("Kwan")
        lLastNames.Add("Brokman")
        lLastNames.Add("Pye")
        lLastNames.Add("Ziff")
        lLastNames.Add("McClure")
        lLastNames.Add("Wolfcastle")
        lLastNames.Add("Szyslak")
        lLastNames.Add("Gumble")
        lLastNames.Add("Riviera")
        lLastNames.Add("Beardley")
        lLastNames.Add("Gerald")
        lLastNames.Add("Abernathy")
        lLastNames.Add("Glick")
        lLastNames.Add("Allbright")
        ' The names are from "The Simpons". I know 'Nahasapeemapetilon' is too long for a 
        ' CallerID stream in itself, but if I left it out, I'd be a raceist. Thank you, come again.
        Return lFirstNames(Math.Floor(rNumber.NextDouble * lFirstNames.Count)) + " " + lLastNames(Math.Floor(rNumber.NextDouble * lLastNames.Count))
    End Function

    Public Function UID_Decoder(ByVal UnitID As String)
        ' The two Id's (Unit ID and Serial Number) come in as kinda compresed data
        ' to save space on the network chip. If you read the network packet directly
        ' in hex, then it reads normally. This function just turns it back into hex.
        Dim sDecoded As String = ""
        Dim caDecoded As Char()
        Dim nNumeric As Integer
        'If UnitID.Length <> 6 Then Return 0

        caDecoded = UnitID.ToCharArray
        For Each cBit As Char In caDecoded
            nNumeric = Asc(cBit)
            sDecoded = sDecoded + Hex(nNumeric).PadLeft(2, "0")
        Next
        Return sDecoded
    End Function

    Public Function SerialNumberGenerator(ByVal nBuild As Integer, ByVal nVersion As Integer, Optional ByVal nSeries As Integer = 0) ' Not for the public
        Dim sDate As String = ""
        Dim sSerial As String = nVersion.ToString.PadLeft(2, "0")
        sSerial += nSeries.ToString.PadLeft(2, "0")
        sDate += Right(Date.Now.Year.ToString, 2)
        sDate += Date.Now.Month.ToString.PadLeft(2, "0")
        sDate += Date.Now.Day.ToString.PadLeft(2, "0")
        sSerial += sDate + nBuild.ToString.PadLeft(2, "0")

        Return sSerial
    End Function

    Public Function HexFromIP(ByVal sIP As String)
        ' This will return a 2 digit string
        Dim aIP As String()
        Dim sHexCode As String = ""
        aIP = sIP.Split(".")

        For Each IPOct As String In aIP
            sHexCode += Hex(Val(IPOct)).PadLeft(2, "0")
        Next

        Return sHexCode
    End Function
    Public Function IPFromHex(ByVal sHex As String)
        Dim sSubHex As String
        Dim sIP As String = ""
        Do While sHex.Length > 1
            sSubHex = Left(sHex, 2)
            sIP += Str(Convert.ToInt32(sSubHex, 16)).Trim(" ")
            sHex = Right(sHex, sHex.Length - 2)
            If sHex.Length > 0 Then sIP += "."
        Loop
        Return sIP
    End Function
End Module
