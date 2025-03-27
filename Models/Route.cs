namespace EuphoriaOpdracht.Models;

public class Route
{
    public required List<Location> Locations { get; init; }
    public required TimeSpan Duration { get; init; }
    public required double DistanceInKm { get; init; }
    
    public override string ToString()
    {
        return $"Route: {string.Join(" -> ", Locations.Select(l => l.Name))} - {DistanceInKm} km - {Duration}";
    }
}