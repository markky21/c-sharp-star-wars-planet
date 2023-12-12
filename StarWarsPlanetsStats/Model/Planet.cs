using StarWarsPlanetsStats.DTOs;
using StarWarsPlanetsStats.Utilities;

namespace StarWarsPlanetsStats.Model;

public readonly record struct Planet
{
    private Planet(string? name, int diameter, int? surfaceWater, long? population)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Diameter = diameter;
        SurfaceWater = surfaceWater;
        Population = population;
    }

    public string Name { get; }
    public int Diameter { get; }
    public int? SurfaceWater { get; }
    public long? Population { get; }

    public static explicit operator Planet(Result planetDto)
    {
        var name = planetDto.name;
        var diameter = int.Parse(planetDto.diameter);
        var surfaceWater = planetDto.surface_water.ParseToIntNullable();
        var population = planetDto.population.ParseToLongNullable();

        return new Planet(name, diameter, surfaceWater, population);
    }
}