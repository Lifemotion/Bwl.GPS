Imports Bwl.Framework
Imports Bwl.GpsCarMeter

Public Class CarMeter
    Inherits FormAppBase
    Private WithEvents _gps As IGpsSource

    Private _rate As Integer
    Private _gpsData As New GpsData
    Private _lastData As GpsData
    Private _recorder As New Recorder(AppBase.DataFolder, AppBase.RootLogger)
    Private _pointFixDistance As New DoubleSetting(_storage, "PointFixDist", 1.0)

    Private Sub _gps_GpsUpdate(data As GpsData, raw As String) Handles _gps.GpsUpdate
        _lastData = _gpsData
        _gpsData = data
        If _lastData Is Nothing Then _lastData = _gpsData

        _rate += 1
        _recorder.Write(data, raw)

        If _avgSpeed = "point1" Then
            Dim dist1 = GpsDistanse.GetDistance(_lastData.Location.ToString, tbPoint1.Text)
            Dim dist2 = GpsDistanse.GetDistance(_gpsData.Location.ToString, tbPoint1.Text)
            Dim diff = dist2 - dist1
            _logger.AddDebug(diff.ToString("0.00"))
            If diff > _pointFixDistance.Value Then
                _avgSpeedP1 = _gpsData
                _logger.AddMessage("Point 1 Captured, Avg Speed start")
                tbAvgSpeedTime1.Text = _gpsData.DateTimeUtc.ToString("HH:mm:ss:fff") + " " + _gpsData.Speed.ToString("0")
                _avgSpeed = "point2"
                _recorder.RecordStart("avgspeed")
            End If
        End If

        If _avgSpeed = "point0" Then
            '  Dim dist1 = GpsDistanse.GetDistance(_lastData.Location.ToString, tbPoint0.Text)
            Dim dist2 = GpsDistanse.GetDistance(_gpsData.Location.ToString, tbPoint0.Text)
            '   Dim diff = dist2 - dist1
            _logger.AddDebug(dist2.ToString("0.00"))
            If dist2 < _pointFixDistance.Value Then
                _avgSpeedP1 = _gpsData
                _logger.AddMessage("Point Speed Meashured, " + _gpsData.Speed.ToString("0.0") + " km/h")
                '       tbPoint0time.Text = _gpsData.DateTimeUtc.ToString("HH:mm:ss:fff") + " " + _gpsData.Speed.ToString("0")
                _avgSpeed = "done"
                Me.Invoke(Sub() tbPointSpeed.Text = "Speed " + _gpsData.Speed.ToString("0.0") + " km/h")
            End If
        End If

        If _avgSpeed = "point2" Then
            _avgSpeeds.Add(_gpsData.Speed)
            _logger.AddMessage(_gpsData.DateTimeUtc.ToString("HH:mm:ss:fff") + " " + _gpsData.Speed.ToString("0"))
            Dim dist1 = GpsDistanse.GetDistance(_lastData.Location.ToString, tbPoint2.Text)
            Dim dist2 = GpsDistanse.GetDistance(_gpsData.Location.ToString, tbPoint2.Text)
            Dim diff = dist2 - dist1
            _logger.AddDebug(diff.ToString("0.00"))
            If diff > _pointFixDistance.Value Then
                _avgSpeedP2 = _gpsData
                _logger.AddMessage("Point 2 Captured, Avg Speed Finished")
                tbAvgSpeedTime2.Text = _gpsData.DateTimeUtc.ToString("HH:mm:ss:fff") + " " + _gpsData.Speed.ToString("0")
                _avgSpeed = "done"
                _recorder.RecordStop()
                Dim dtime = (_avgSpeedP2.DateTimeUtc - _avgSpeedP1.DateTimeUtc).TotalHours
                Dim dist = GpsDistanse.GetDistance(_avgSpeedP1.Location.ToString, _avgSpeedP2.Location.ToString) / 1000.0
                Dim speed1 = dist / dtime

                Dim speed2 As Double
                Dim cnt As Integer
                For Each spd In _avgSpeeds
                    speed2 += spd
                    cnt += 1
                Next
                speed2 = speed2 / cnt
                _logger.AddMessage("Speed (distance/time) = " + speed1.ToString("0.0") + " km/h, dist: " +
                                   (dist * 1000).ToString("0") + " m, time: " +
                                   (_avgSpeedP2.DateTimeUtc - _avgSpeedP1.DateTimeUtc).TotalSeconds.ToString("0.00") + " s")

                _logger.AddMessage("Speed (gps averaging) = " + speed2.ToString("0.0") + " km/h")
                tbAvgSpeed.Text = "Speed " + speed1.ToString("0.0") + " km/h (d/t), " + speed2.ToString("0.0") + " km/h (gps)"
            End If
        End If
    End Sub

    Private Sub CarMeter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text += " " + Application.ProductVersion.ToString
        Try
            _gps = New GpsSource
            _gps.Open()
            _logger.AddMessage("GPS open")
        Catch ex As Exception
            _logger.AddError("GPS open error: " + ex.Message)
            _gps = New GpsEmulator
            _gps.Open()
        End Try
    End Sub

    Private Sub tRate_Tick(sender As Object, e As EventArgs) Handles tRate.Tick
        Dim rate = _rate
        _rate = 0
        tbGpsState.Text = "Rate: " + rate.ToString + ", Fix: " + _gpsData.DataValid.ToString
        If rate < 1 Or _gpsData.DataValid = False Then
            tbGpsState.BackColor = Color.Pink
            cbOk.Checked = False
        Else
            tbLocation.Text = _gpsData.Location.ToString
            If rate > 8 Then
                tbGpsState.BackColor = Color.LightGreen
                cbOk.Checked = True
            Else
                tbGpsState.BackColor = Color.LightYellow
                cbOk.Checked = False
            End If
        End If
    End Sub

    Private Sub tTime_Tick(sender As Object, e As EventArgs) Handles tTime.Tick
        tbTime.Text = _gpsData.DateTimeUtc.ToString("hh:mm:ss:f")
        tbSpeed.Text = _gpsData.Speed.ToString("0.0") + " km/h"

        If _recorder.Recording Then
            bRecord.Enabled = False
            bRecordStop.Enabled = True
            If cbAutostopRecordAt0.Checked Then
                If _gpsData.Speed < 1 Then _recorder.RecordStop()
            End If
            If cbAutostopRecordAt30.Checked Then
                If _gpsData.Speed < 29 Then _recorder.RecordStop()
            End If
            If cbAutostopRecordAt100.Checked Then
                If _gpsData.Speed > 110 Then _recorder.RecordStop()
            End If
        Else
            If cbAutostartRecord1.Checked Then
                If _gpsData.Speed > 2 And _gpsData.Speed < 10 Then _recorder.RecordStart("onmove1")
            End If
            If cbAutostartRecord30.Checked Then
                If _gpsData.Speed > 30 And _gpsData.Speed < 40 Then _recorder.RecordStart("onmove30")
            End If
            If cbAutostartRecord70.Checked Then
                If _gpsData.Speed < 70 And _gpsData.Speed > 60 Then _recorder.RecordStart("below70")
            End If
            bRecord.Enabled = True
            bRecordStop.Enabled = False
        End If
    End Sub

    Private Sub bRecord_Click(sender As Object, e As EventArgs) Handles bRecord.Click
        _recorder.RecordStart("manual")
    End Sub

    Private Sub bRecordStop_Click(sender As Object, e As EventArgs) Handles bRecordStop.Click
        _recorder.RecordStop()
    End Sub

    Private Sub bPoint1Set_Click(sender As Object, e As EventArgs) Handles bPoint1Set.Click
        tbPoint1.Text = tbLocation.Text
    End Sub

    Private Sub bPoint2Set_Click(sender As Object, e As EventArgs) Handles bPoint2Set.Click
        tbPoint2.Text = tbLocation.Text
    End Sub

    Private Sub tbPoint1_TextChanged(sender As Object, e As EventArgs) Handles tbPoint1.TextChanged, tbPoint2.TextChanged
        tbAverageSpeedInfo.Text = "Dist: " + GpsDistanse.GetDistance(tbPoint1.Text, tbPoint2.Text).ToString("0")
    End Sub

    Private _avgSpeed As String = "none"
    Private _avgSpeedP1 As GpsData
    Private _avgSpeedP2 As GpsData
    Private _avgSpeeds As New List(Of Integer)

    Private Sub bMeashureAverage_Click(sender As Object, e As EventArgs) Handles bMeashureAverage.Click
        tbAvgSpeedTime1.Text = ""
        tbAvgSpeedTime2.Text = ""
        tbAvgSpeed.Text = ""
        tbPoint0time.Text = ""
        tbPointSpeed.Text = ""
        _logger.AddMessage("Starting speed metering")
        _avgSpeed = "point1"
        _avgSpeeds.Clear()
    End Sub

    Private Sub bPoint0Set_Click(sender As Object, e As EventArgs) Handles bPoint0Set.Click
        tbPoint0.Text = tbLocation.Text
    End Sub

    Private Sub tbMeashurePoint_Click(sender As Object, e As EventArgs) Handles tbMeashurePoint.Click
        tbAvgSpeedTime1.Text = ""
        tbAvgSpeedTime2.Text = ""
        tbAvgSpeed.Text = ""
        tbPoint0time.Text = ""
        tbPointSpeed.Text = ""
        _avgSpeed = "point0"
    End Sub
End Class