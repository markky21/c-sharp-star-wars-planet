using StarWarsPlanetsStats.Model;

namespace StarWarsPlanetsStats.ApiDataAccess;

interface IPlanetsReader
{
    Task<IEnumerable<Planet>> Read();
}