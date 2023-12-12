using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.UserInteractions;

class PlanetsStatsUserInteraction : IPlanetsStatsUserInteraction
{
    private readonly IUserInteraction _userInteraction;

    public PlanetsStatsUserInteraction(IUserInteraction userInteraction)
    {
        _userInteraction = userInteraction;
    }

    public string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen)
    {
        _userInteraction.ShowMessage(Environment.NewLine);
        _userInteraction.ShowMessage("The statistics of which property would you like to see?");
        foreach (var property in propertiesThatCanBeChosen)
        {
            _userInteraction.ShowMessage(property);
        }

        return _userInteraction.ReadFromUser();
    }

    public void ShowMessage(string message)
    {
        _userInteraction.ShowMessage(message);
    }

    public void Show(IEnumerable<Planet> planets)
    {
        TablePrinter.Print(planets);
    }
}

public static class TablePrinter
{
    public static void Print(IEnumerable<Planet> items)
    {
        var columnWidth = 15;
        var properties = typeof(Planet).GetProperties();

        foreach (var property in properties)
        {
            Console.Write($"{{0,-{columnWidth}}} |",property.Name);
        }
        Console.WriteLine();
        Console.WriteLine(new string('-', properties.Length * (columnWidth+1)));

        foreach (var item in items)
        {
            foreach (var property in properties)
            {
                Console.Write($"{{0,-{columnWidth}}} |",property.GetValue(item));
            }
            Console.WriteLine();
        }
    }
}

