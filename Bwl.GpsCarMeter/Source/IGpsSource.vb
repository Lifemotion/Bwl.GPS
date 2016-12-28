Imports Bwl.GpsCarMeter

Public Interface IGpsSource
    Event GpsUpdate(data As GpsData, raw As String)
    Sub Open()
End Interface
