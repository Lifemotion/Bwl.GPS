Imports System.Device.Location

Public Class GpsDistanse
    Public Shared Function GetDistance(lat1 As Double, lon1 As Double, lat2 As Double, lon2 As Double)
        Dim point1 As New GeoCoordinate(lat1, lon1)
        Dim point2 As New GeoCoordinate(lat2, lon2)
        Dim dist = GetDistance(point1, point2)
        Return dist
    End Function

    Public Shared Function GetDistance(point1 As String, point2 As String) As Double
        Dim dist = GetDistance(New GeoLocation(point1), New GeoLocation(point2))
        Return dist
    End Function

    Public Shared Function GetDistance(point1l As GeoLocation, point2l As GeoLocation) As Double
        Dim point1 As New GeoCoordinate(point1l.Lat, point1l.Lon)
        Dim point2 As New GeoCoordinate(point2l.Lat, point2l.Lon)
        Dim dist = GetDistance(point1, point2)
        Return dist
    End Function

    Public Shared Function GetDistance(point1 As GeoCoordinate, point2 As GeoCoordinate) As Double
        Dim dist = point1.GetDistanceTo(point2)
        Return dist
    End Function
End Class
