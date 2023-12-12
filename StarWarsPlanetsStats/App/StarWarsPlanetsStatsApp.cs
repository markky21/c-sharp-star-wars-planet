using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.Model;
using StarWarsPlanetsStats.UserInteractions;

namespace StarWarsPlanetsStats.App;

class StarWarsPlanetsStatsApp
{
    private readonly IPlanetsReader _planetsReader;
    private readonly IPlanetsStatisticAnalyzer _planetsStatisticAnalyzer;
    private readonly IUserInteraction _userInteraction;
    private readonly IPlanetsStatsUserInteraction _planetsStatsUserInteraction;


    public StarWarsPlanetsStatsApp(
        IPlanetsReader planetsReader,
        IPlanetsStatisticAnalyzer planetsStatisticAnalyzer,
        IUserInteraction userInteraction,
        IPlanetsStatsUserInteraction planetsStatsUserInteraction)
    {
        _planetsReader = planetsReader;
        _planetsStatisticAnalyzer = planetsStatisticAnalyzer;
        _userInteraction = userInteraction;
        _planetsStatsUserInteraction = planetsStatsUserInteraction;
    }


    public async Task Run()
    {
        var planetsEnumerable = await _planetsReader.Read();
        var planets = planetsEnumerable as Planet[] ?? planetsEnumerable.ToArray();

        _planetsStatsUserInteraction.Show(planets);
        _userInteraction.ShowMessage();
        _planetsStatisticAnalyzer.Analyze(planets);
    }
}