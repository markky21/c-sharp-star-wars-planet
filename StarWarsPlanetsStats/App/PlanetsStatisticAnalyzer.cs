using StarWarsPlanetsStats.Model;
using StarWarsPlanetsStats.UserInteractions;

namespace StarWarsPlanetsStats.App;

class PlanetsStatisticAnalyzer : IPlanetsStatisticAnalyzer
{
    private readonly IPlanetsStatsUserInteraction _planetsStatsUserInteraction;

    private readonly Dictionary<string, (string propertyName, string propertyValue, Func<Planet, long?> selector)>
        _statistics =
            new()
            {
                ["1"] = ("diameter", "kilometers", p => p.Diameter),
                ["2"] = ("surface water", "%", p => p.SurfaceWater),
                ["3"] = ("population", "inhabitants", p => p.Population)
            };

    public PlanetsStatisticAnalyzer(IPlanetsStatsUserInteraction planetsStatsUserInteraction)
    {
        _planetsStatsUserInteraction = planetsStatsUserInteraction;
    }

    public void Analyze(IEnumerable<Planet> planets)
    {
        var userChoice = _planetsStatsUserInteraction.ChooseStatisticsToBeShown(_statistics.Select(s =>
            ($"{s.Key}. {s.Value.propertyName}")));
        if (userChoice is null || !_statistics.ContainsKey(userChoice))
        {
            _planetsStatsUserInteraction.ShowMessage("Invalid input");
            return;
        }

        var (propertyName, propertyValue, selector) = _statistics[userChoice];
        ShowStatistics(planets, (propertyName, propertyValue), selector);
    }

    private void ShowStatistics(
        IEnumerable<Planet> planets,
        (string name, string value) propertyNames,
        Func<Planet, long?> selector)
    {
        var enumerable = planets as Planet[] ?? planets.ToArray();
        ShowStatistic("Max", enumerable.MaxBy(selector), propertyNames);
        ShowStatistic("Min", enumerable.MinBy(selector), propertyNames);
    }

    private void ShowStatistic(string category, Planet planet, (string name, string value) propertyNames)
    {
        _planetsStatsUserInteraction.ShowMessage(
            $"The planet with the {category} {propertyNames.name} is {planet.Name} with {planet.Population} {propertyNames.value}.");
    }
}