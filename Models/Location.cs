namespace EuphoriaOpdracht.Models;

public class Location
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required double Lat { get; init; }
    public required double Lon { get; init; }
}