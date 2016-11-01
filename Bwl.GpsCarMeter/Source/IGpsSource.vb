Imports Bwl.GpsCarMeter

Public Interface IGpsSource
    Event GpsUpdate(data As GpsData)
    Sub Open()
End Interface
