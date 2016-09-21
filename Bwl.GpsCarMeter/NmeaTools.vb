Public Class GeoLocation
    Public Property Lon As Double
    Public Property Lat As Double
    Public Overrides Function ToString() As String
        Dim res = Lat.ToString().Replace(",", ".") + "," + Lon.ToString().Replace(",", ".")
        Return res
    End Function
End Class

Public Class GpsData
    Public Property FromGPS As Boolean
    Public Property FromGlonass As Boolean
    Public Property DateTimeUtc As Date
    Public Property DataValid As Boolean
    Public Property Location As New GeoLocation
    Public Property Satellites As Integer = -1
    Public Property Speed As Single
    Public Property HDOP As Single = -1

    Public Overrides Function ToString() As String
        Dim res = ""
        If FromGPS Then res += "GPS "
        If FromGlonass Then res += "GLONASS "
        If DataValid Then res += "DataValid " Else res += "DataNotValid "
        res += DateTimeUtc.ToString + " "
        res += Location.ToString
        res += ", Sats: " + Satellites.ToString
        Return res
    End Function
End Class

Public Class NmeaTools
    Private Shared Function DecodeNmeaCoordToDouble(coord As String) As Double
        Dim parts = coord.Split("."c)
        Dim result As Double = 0
        If parts.Length <> 2 Then Throw New Exception("Bad Coord Format")
        If IsNumeric(parts(0)) = False Then Throw New Exception("Bad Coord Format")
        If IsNumeric(parts(1)) = False Then Throw New Exception("Bad Coord Format")
        Select Case parts(0).Length
            Case 4
                Dim deg = parts(0).Substring(0, 2)
                Dim min = parts(0).Substring(2, 2)
                result += CDbl(deg)
                result += CDbl(min) / 60.0
            Case 5
                Dim deg = parts(0).Substring(0, 3)
                Dim min = parts(0).Substring(3, 2)
                result += CDbl(deg)
                result += CDbl(min) / 60.0
            Case Else
                Throw New Exception("Bad Coord Format")
        End Select
        result += CDbl("0," + parts(1)) / 60.0

        Return result
    End Function

    Public Shared Function GetLocation(gprmc As String) As GeoLocation
        Dim parts = gprmc.Split(","c)
        Dim latString = parts(3)
        Dim lonString = parts(5)
        Dim coord As New GeoLocation
        coord.Lat = DecodeNmeaCoordToDouble(latString)
        coord.Lon = DecodeNmeaCoordToDouble(lonString)
        Return coord
    End Function


    Public Shared Function DecodeGprmc(gprmc As String) As GpsData
        Dim parts = gprmc.Split(","c)
        Dim data As New GpsData
        Select Case parts(0)
            Case "$GPRMC" : data.FromGPS = True
            Case "$GLRMC" : data.FromGlonass = True
            Case "$GNRMC" : data.FromGPS = True : data.FromGlonass = True
            Case Else : Throw New Exception("Bad GPRMC string: " + gprmc)
        End Select
        Select Case parts(2)
            Case "A" : data.DataValid = True
            Case "V" : data.DataValid = False
            Case Else : Throw New Exception("Bad GPRMC string: " + gprmc)
        End Select
        Dim latString = parts(3)
        Dim lonString = parts(5)
        Dim speed = Val(parts(7)) * 1.852
        data.Speed = speed
        data.Location.Lat = DecodeNmeaCoordToDouble(latString)
        data.Location.Lon = DecodeNmeaCoordToDouble(lonString)
        Dim timeString = parts(1)
        Dim dateString = parts(9)
        data.DateTimeUtc = DecodeNmeaDateTime(timeString, dateString)
        Return data
    End Function

    Private Shared Function DecodeNmeaDateTime(timeString As String, dateString As String) As Date
        Dim timeparts = timeString.Split(".")
        If timeparts.Length <> 2 Then Throw New Exception("Bad timeString: " + timeString)
        If timeparts(0).Length <> 6 Then Throw New Exception("Bad timeString: " + timeString)

        Dim h = CInt(timeparts(0).Substring(0, 2))
        Dim m = CInt(timeparts(0).Substring(2, 2))
        Dim s = CInt(timeparts(0).Substring(4, 2))
        Dim ms = CInt(timeparts(1))

        If dateString IsNot Nothing Then
            Dim dateparts = dateString.Split(".")
            If dateparts.Length <> 1 Then Throw New Exception("Bad dateString: " + timeString)
            If dateparts(0).Length <> 6 Then Throw New Exception("Bad dateString: " + timeString)

            Dim day = CInt(dateparts(0).Substring(0, 2))
            Dim mounth = CInt(dateparts(0).Substring(2, 2))
            Dim year = 2000 + CInt(dateparts(0).Substring(4, 2))

            Dim result As New DateTime(year, mounth, day, h, m, s, ms, DateTimeKind.Utc)
            Return result
        Else
            Dim result As New DateTime(1970, 1, 1, h, m, s, ms, DateTimeKind.Utc)
            Return result
        End If
    End Function

    Public Shared Function DecodeGpgga(gpgga As String) As GpsData
        Dim parts = gpgga.Split(","c)
        Dim data As New GpsData
        Select Case parts(0)
            Case "$GPGGA" : data.FromGPS = True
            Case "$GLGGA" : data.FromGlonass = True
            Case "$GNGGA" : data.FromGPS = True : data.FromGlonass = True
            Case Else : Throw New Exception("Bad GPGGA string: " + gpgga)
        End Select
        Select Case parts(6)
            Case "0" : data.DataValid = False
            Case "1" : data.DataValid = True
            Case "2" : data.DataValid = True
            Case Else : Throw New Exception("Bad GPGGA string: " + gpgga)
        End Select
        Dim latString = parts(2)
        Dim lonString = parts(4)
        data.Location.Lat = DecodeNmeaCoordToDouble(latString)
        data.Location.Lon = DecodeNmeaCoordToDouble(lonString)
        data.Satellites = CInt(parts(7))
        data.HDOP = CSng(parts(8).Replace(".", ","))
        Dim timeString = parts(1)
        '  Dim dateString = parts(9)
        data.DateTimeUtc = DecodeNmeaDateTime(timeString, Nothing)
        Return data
    End Function
End Class
