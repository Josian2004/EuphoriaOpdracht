namespace EuphoriaOpdracht.Enums;

public enum VehicleType
{
    Taxi,
    SmallVan,
    LargeVan,
}

public static class VehicleTypeMapper
{
    public static VehicleType MapToVehicleType(string vehicleType)
    {
        return vehicleType switch
        {
            "Taxi" => VehicleType.Taxi,
            "Klein busje" => VehicleType.SmallVan,
            "Grote bus" => VehicleType.LargeVan,
            _ => throw new ArgumentException($"Unknown vehicle type: {vehicleType}")
        };
    }
}