Imports Bwl.Framework
Imports Bwl.GpsCarMeter

Public Class CarMeter
    Inherits FormAppBase
    Private WithEvents _gps As New GpsSource

    Private _rate As Integer
    Private _lastData As New GpsData
    Private _recordFile As IO.TextWriter
    Private _recordStartTime As DateTime

    Private Sub _gps_GpsUpdate(data As GpsData) Handles _gps.GpsUpdate
        _rate += 1
        _lastData = data
        If _recordFile IsNot Nothing Then
            Try
                Dim str = data.DateTimeUtc.ToString + ";" +
        (data.DateTimeUtc - _recordStartTime).TotalSeconds.ToString("0.0") + ";" +
        data.Speed.ToString("0.0") + ";" +
                data.Location.ToString()
                _recordFile.WriteLine(str)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub CarMeter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _gps.Open()
            _logger.AddMessage("GPS open")
        Catch ex As Exception
            _logger.AddError(ex.Message)
        End Try
    End Sub

    Private Sub tRate_Tick(sender As Object, e As EventArgs) Handles tRate.Tick
        Dim rate = _rate
        _rate = 0
        TextBox1.Text = rate.ToString + ", Valid: " + _lastData.DataValid.ToString
        If rate < 2 Then
            TextBox1.BackColor = Color.Pink
        Else
            TextBox3.Text = _lastData.Location.ToString
            TextBox4.Text = _lastData.Speed.ToString("0.0") + " km/h"

            If rate > 8 Then
                TextBox1.BackColor = Color.LightGreen
            Else
                TextBox1.BackColor = Color.LightYellow
            End If
        End If
    End Sub

    Private Sub tTime_Tick(sender As Object, e As EventArgs) Handles tTime.Tick
        TextBox2.Text = _lastData.DateTimeUtc.ToString("hh:mm:ss:f")
    End Sub

    Private Sub bRecord_Click(sender As Object, e As EventArgs) Handles bRecord.Click
        Dim filename As String = Now.ToString("yyyy-MM-dd hh-mm-ss") + ".csv"
        _recordStartTime = _lastData.DateTimeUtc
        _recordFile = IO.File.CreateText(IO.Path.Combine(AppBase.DataFolder, filename))
        bRecord.Enabled = False
        bRecordStop.Enabled = True
    End Sub

    Private Sub bRecordStop_Click(sender As Object, e As EventArgs) Handles bRecordStop.Click
        _recordFile.Close()
        _recordFile = Nothing
        bRecord.Enabled = True
        bRecordStop.Enabled = False
    End Sub
End Class