using EuphoriaOpdracht.Enums;

namespace EuphoriaOpdracht.Models;

public class Vehicle
{
    public required VehicleType Type { get; init; }
    public required int PersonCapacity { get; init; }
    public required int WheelchairCapacity { get; init; }
}