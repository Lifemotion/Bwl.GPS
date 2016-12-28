Imports Bwl.GpsCarMeter

Public Class GpsEmulator
    Implements IGpsSource

    Public Event GpsUpdate(data As GpsData, raw As String) Implements IGpsSource.GpsUpdate
    Private map1 As New PointF(59.0883, 37.9075)
    Private map2 As New PointF(59.0796, 37.9287)
    Private point As PointF = map2
    Private lastPoint As PointF = map2
    Private graph As Graphics

    Public Sub Open() Implements IGpsSource.Open
        Me.Show()
    End Sub

    Private Sub pbMap_MouseDown(sender As Object, e As MouseEventArgs) Handles pbMap.MouseDown, pbMap.MouseMove
        If MouseButtons = MouseButtons.Left Then
            Dim my = e.X / pbMap.Width
            Dim mx = e.Y / pbMap.Height
            point.X = map1.X + (map2.X - map1.X) * mx
            point.Y = map1.Y + (map2.Y - map1.Y) * my
            graph.DrawEllipse(Pens.Red, e.X, e.Y, 2, 2)
        End If
        If MouseButtons = MouseButtons.Right Then
            pbMap.Refresh()
        End If
    End Sub

    Private Sub GpsEmulator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        graph = pbMap.CreateGraphics
    End Sub

    Private Sub tGps_Tick(sender As Object, e As EventArgs) Handles tGps.Tick
        Dim diff = Math.Sqrt((point.X - lastPoint.X) ^ 2 + (point.Y - lastPoint.Y) ^ 2)
        Dim gps As New GpsData
        gps.DataValid = True
        gps.DateTimeUtc = Now.ToUniversalTime
        gps.FromGPS = True
        gps.Location.Lat = point.X
        gps.Location.Lon = point.Y
        gps.Speed = diff * 100000
        'Dim position As String = "4807.038,N,01131.000,E"
        Dim position As String = (gps.Location.Lat * 100).ToString("0000.000") + ",N," + (gps.Location.Lon * 100).ToString("00000.000") + ",E"
        Dim rmc = "$GPRMC," + gps.DateTimeUtc.ToString("HHmmss.fff") + ",A," + position + ",000.0,000.0," + gps.DateTimeUtc.ToString("ddMMyy") + ",003.1,W*6A"
        RaiseEvent GpsUpdate(gps, rmc)
        lastPoint = point
    End Sub
End Class