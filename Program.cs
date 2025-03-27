// See https://aka.ms/new-console-template for more information

using EuphoriaOpdracht;
using EuphoriaOpdracht.Models;
using OfficeOpenXml;

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
const string path = "casus.xlsx";

List<Location> locations = ExcelParser.GetLocations(path);
List<Traveller> travellers = ExcelParser.GetTravellers(path);
List<Vehicle> vehicles = ExcelParser.GetVehicles(path);
List<List<double>> distances = ExcelParser.GetDistanceTable(path, locations.Count);
List<List<double>> times = ExcelParser.GetTimeTable(path, locations.Count);

RouteCalculator routeCalculator = new RouteCalculator(distances, times);

Route shortestRoute = routeCalculator.FindShortestRoute(locations.First(), locations.Skip(1).ToList());

Console.WriteLine(shortestRoute);
Console.ReadLine();
