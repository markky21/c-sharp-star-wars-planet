using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.App;

interface IPlanetsStatisticAnalyzer
{
    void Analyze(IEnumerable<Planet> planets);
}