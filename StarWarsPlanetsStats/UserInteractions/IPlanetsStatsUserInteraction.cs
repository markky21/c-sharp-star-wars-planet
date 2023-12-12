using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.UserInteractions;

interface IPlanetsStatsUserInteraction
{
    string? ChooseStatisticsToBeShown(IEnumerable<string> propertiesThatCanBeChosen);
    void ShowMessage(string message);

    void Show(IEnumerable<Planet> planets);
}