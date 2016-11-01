Public Class Recorder
    Private _recordFile As IO.TextWriter
    Private _recordStartTime As DateTime
    Private _lastData As New GpsData
    Private _datafolder As String

    Public Sub New(datafolder As String)
        _datafolder = datafolder
    End Sub

    Public Sub RecordStart(prefix As String)
        Dim filename As String = Now.ToString("yyyy-MM-dd hh-mm-ss") + " " + prefix + ".csv"
        _recordStartTime = _lastData.DateTimeUtc
        SyncLock Me
            _recordFile = IO.File.CreateText(IO.Path.Combine(_datafolder, filename))
        End SyncLock
    End Sub

    Public Sub RecordStop()
        SyncLock Me
            _recordFile.Close()
            _recordFile = Nothing
        End SyncLock
    End Sub

    Public ReadOnly Property Recording As Boolean
        Get
            Return _recordFile IsNot Nothing
        End Get
    End Property

    Public Sub Write(data As GpsData)
        _lastData = data
        SyncLock Me
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
        End SyncLock
    End Sub
End Class
