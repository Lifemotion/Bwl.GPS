Public Class GpsSource
    Implements IGpsSource
    Private _port As New IO.Ports.SerialPort
    Private _thread As New Threading.Thread(AddressOf ReadThread)

    Public Event GpsUpdate(data As GpsData, raw As String) Implements IGpsSource.GpsUpdate

    Private Sub ReadThread()
        Do
            Try
                If _port.IsOpen Then
                    Dim line = _port.ReadLine()
                    If line.StartsWith("$GPRMC,") Then
                        Dim data = NmeaTools.DecodeGprmc(line)
                        RaiseEvent GpsUpdate(data, line)
                    End If
                End If
            Catch ex As Exception
            End Try
            Threading.Thread.Sleep(1)
        Loop
    End Sub

    Public Sub New()
        _thread.IsBackground = True
        _thread.Start()
    End Sub

    Public Sub Open() Implements IGpsSource.Open
        _port.BaudRate = 38400
        _port.PortName = IO.Ports.SerialPort.GetPortNames(0)
        _port.Open()
    End Sub
End Class
