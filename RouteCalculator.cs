using EuphoriaOpdracht.Models;
using MoreLinq;
using MoreLinq.Extensions;

namespace EuphoriaOpdracht;

public class RouteCalculator(List<List<double>> distances, List<List<double>> durations)
{
    private readonly List<List<double>> _distances = distances;
    private readonly List<List<double>> _durations = durations;

    public Route FindShortestRoute(Location home, List<Location> locations)
    {
        List<Route> possibleRoutes = [];
        
        // I have used the MoreLinq library to get all permutations of the locations,
        // which means all possible combinations of the locations. Which is !amountOfLocations, or in this case !9 = 362880.
        IEnumerable<IList<Location>> permutations = PermutationsExtension.Permutations(locations);
        
        foreach (IList<Location> permutation in permutations)
        {
            List<Location> possibleLocations = permutation.ToList();
            possibleLocations.Insert(0, home);
            possibleLocations.Add(home);
            possibleRoutes.Add(CalculateRoute(possibleLocations.ToList()));
        }
        
        possibleRoutes.Sort((a, b) => a.DistanceInKm.CompareTo(b.DistanceInKm));
        return possibleRoutes.First();
    }

    private Route CalculateRoute(List<Location> locations)
    {
        double distance = 0;
        double duration = 0;
        for (int i = 0; i < locations.Count - 2; i++)
        {
            distance += _distances[locations[i].Id - 1][locations[i + 1].Id - 1];
            duration += _durations[locations[i].Id - 1][locations[i + 1].Id - 1];
        }
        return new Route()
        {
            Locations = locations,
            DistanceInKm = distance,
            Duration = TimeSpan.FromMinutes(duration)
        };
        
    }
}