Imports Bwl.Framework

Public Class Recorder
    Private _recordFile As IO.TextWriter
    Private _recordFileRaw As IO.TextWriter
    Private _recordStartTime As DateTime
    Private _lastData As New GpsData
    Private _datafolder As String
    Private _logger As Logger

    Public Sub New(datafolder As String, logger As Logger)
        _datafolder = datafolder
        _logger = logger
    End Sub

    Public Sub RecordStart(prefix As String)
        Dim filename As String = Now.ToString("yyyy-MM-dd hh-mm-ss") + " " + prefix + ".gps.csv"
        Dim filenameRaw As String = Now.ToString("yyyy-MM-dd hh-mm-ss") + " " + prefix + ".gps.txt"
        _recordStartTime = _lastData.DateTimeUtc
        SyncLock Me
            _recordFile = IO.File.CreateText(IO.Path.Combine(_datafolder, filename))
            _recordFileRaw = IO.File.CreateText(IO.Path.Combine(_datafolder, filenameRaw))
        End SyncLock
        _max = 0
        _avg = 0
        _avgCnt = 0
        _logger.AddMessage("Record start: " + filename)
    End Sub

    Private _max As Single
    Private _avg As Single
    Private _avgCnt As Integer

    Public Sub RecordStop()
        SyncLock Me
            _recordFile.Close()
            _recordFileRaw.Close()
            _recordFile = Nothing
            _recordFileRaw = Nothing
        End SyncLock
        _logger.AddMessage("Record stop, max " + _max.ToString("0.0") + " avg " + (_avg / _avgCnt).ToString("0.0"))
    End Sub

    Public ReadOnly Property Recording As Boolean
        Get
            Return _recordFile IsNot Nothing
        End Get
    End Property

    Public Sub Write(data As GpsData, raw As String)
        _lastData = data
        SyncLock Me
            If _recordFile IsNot Nothing Then
                Try
                    Dim str = data.DateTimeUtc.ToString + ";" +
                              (data.DateTimeUtc - _recordStartTime).TotalSeconds.ToString("0.0") + ";" +
                              data.Speed.ToString("0.0") + ";" +
                              data.Location.ToString()
                    _recordFile.WriteLine(str)
                    _recordFileRaw.WriteLine(raw)
                Catch ex As Exception
                End Try
            End If
            If data.Speed > _max Then _max = data.Speed
            _avg += data.Speed
            _avgCnt += 1
        End SyncLock
    End Sub
End Class
