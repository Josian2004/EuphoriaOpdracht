using EuphoriaOpdracht.Enums;
using EuphoriaOpdracht.Models;
using OfficeOpenXml;

namespace EuphoriaOpdracht;

public static class ExcelParser
{
    public static List<Location> GetLocations(string path)
    {
        List<Location> locations = [];
        
        ExcelPackage package = new(new FileInfo(path));
        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        
        Dictionary<int, int> headerCell = FindHeaderCell(worksheet, "Locaties");
        int row = headerCell.First().Key + 1;
        int col = headerCell.First().Value;

        while (!string.IsNullOrEmpty(worksheet.Cells[row, col].Text))
        {
            locations.Add(new Location()
            {
                Id = int.Parse(worksheet.Cells[row, col - 1].Text),
                Name = worksheet.Cells[row, col].Text,
                Lat = double.Parse(worksheet.Cells[row, col + 1].Text),
                Lon = double.Parse(worksheet.Cells[row, col + 2].Text)
            });
            row++;
        }
        
        return locations;
    }

    public static List<Traveller> GetTravellers(string path)
    {
        List<Traveller> travellers = [];
        
        ExcelPackage package = new(new FileInfo(path));
        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        
        Dictionary<int, int> headerCell = FindHeaderCell(worksheet, "Reizigers");
        int row = headerCell.First().Key + 1;
        int col = headerCell.First().Value;
        
        while (!string.IsNullOrEmpty(worksheet.Cells[row, col].Text))
        {
            travellers.Add(new Traveller()
            {
                Name = worksheet.Cells[row, col].Text,
                HasWheelchair = worksheet.Cells[row, col + 1].Text == "Ja"
            });
            row++;
        }
        
        return travellers;
    }

    public static List<Vehicle> GetVehicles(string path)
    {
        List<Vehicle> vehicles = [];
        
        ExcelPackage package = new(new FileInfo(path));
        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        
        Dictionary<int, int> headerCell = FindHeaderCell(worksheet, "Voertuigen");
        int row = headerCell.First().Key + 1;
        int col = headerCell.First().Value;
        
        while (!string.IsNullOrEmpty(worksheet.Cells[row, col].Text))
        {
            vehicles.Add(new Vehicle()
            {
                Type = VehicleTypeMapper.MapToVehicleType(worksheet.Cells[row, col + 1].Text),
                PersonCapacity = int.Parse(worksheet.Cells[row, col + 2].Text),
                WheelchairCapacity = int.Parse(worksheet.Cells[row, col + 3].Text)
            });
            row++;
        }
        
        return vehicles;
    }
    
    public static List<List<double>> GetDistanceTable(string path, int amountOfLocations)
    {
        return GetTable(path, "Afstand in Km", amountOfLocations);
    }
    
    public static List<List<double>> GetTimeTable(string path, int amountOfLocations)
    {
        return GetTable(path, "Reistijd in sec.", amountOfLocations);
    }

    private static List<List<double>> GetTable(string path, string headerName, int amountOfLocations)
    {
        List<List<double>> table = [];
        
        ExcelPackage package = new(new FileInfo(path));
        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
        
        Dictionary<int, int> headerCell = FindHeaderCell(worksheet, headerName);
        int row = headerCell.First().Key + 2;
        int col = headerCell.First().Value + 1;
        
        for (int i = 0; i < amountOfLocations; i++)
        {
            List<double> rows = [];
            for (int j = 0; j < amountOfLocations; j++)
            {
                rows.Add(double.Parse(worksheet.Cells[row + i, col + j].Text));
            }
            table.Add(rows);
        }
        
        return table;
    }
    
    private static Dictionary<int, int> FindHeaderCell(ExcelWorksheet worksheet, string header)
    {
        int maxRows = worksheet.Dimension.Rows;
        for (int row = 1; row <= maxRows; row++)
        {
            for (int col = 1; col <= worksheet.Dimension.Columns; col++)
            {
                if (worksheet.Cells[row, col].Text == header)
                    return new Dictionary<int, int>() { { row, col } };
            }
        }
        throw new Exception($"Could not find header row {header}");
    }
}