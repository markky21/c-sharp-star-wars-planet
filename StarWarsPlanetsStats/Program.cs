// See https://aka.ms/new-console-template for more information

using StarWarsPlanetsStats.ApiDataAccess;
using StarWarsPlanetsStats.App;
using StarWarsPlanetsStats.UserInteractions;

try
{
    var userInteraction = new ConsoleUserInteraction();
    var planetsStatsUserInteraction = new PlanetsStatsUserInteraction(userInteraction);

    var app = new StarWarsPlanetsStatsApp(
        new PlanetsFromApiReader(
            new ApiDataReader(),
            new MockStarWarsApiDataReader(),
            userInteraction
        ),
        new PlanetsStatisticAnalyzer(
            planetsStatsUserInteraction
        ),
        userInteraction,
        planetsStatsUserInteraction
    );
    await app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Exception message: " + ex.Message);
}