namespace EuphoriaOpdracht.Models;

public class Traveller
{
    public required string Name { get; init; }
    public bool HasWheelchair { get; init; } = false;
}