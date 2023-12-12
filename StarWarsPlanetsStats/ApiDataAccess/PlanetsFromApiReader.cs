using System.Text.Json;
using StarWarsPlanetsStats.DTOs;
using StarWarsPlanetsStats.Model;
using StarWarsPlanetsStats.UserInteractions;

namespace StarWarsPlanetsStats.ApiDataAccess;

class PlanetsFromApiReader : IPlanetsReader
{
    private readonly IApiDataReader _apiDataReader;
    private readonly IApiDataReader _secondaryApiDataReader;
    private readonly IUserInteraction _userInteraction;


    public PlanetsFromApiReader(IApiDataReader apiDataReader, IApiDataReader secondaryApiDataReader,
        IUserInteraction userInteraction)
    {
        _apiDataReader = apiDataReader;
        _secondaryApiDataReader = secondaryApiDataReader;
        _userInteraction = userInteraction;
    }

    public async Task<IEnumerable<Planet>> Read()
    {
        string? json = null;
        try
        {
            json = await _apiDataReader.Read("https://swapi.dev/api/", "planets/");
        }
        catch (
            HttpRequestException ex)
        {
            _userInteraction.ShowMessage("API request failed. Using mock data." +
                                         "Exception message: " +
                                         ex.Message);
        }

        json ??= await _secondaryApiDataReader.Read("https://swapi.dev/api/", "planets/");


        var data = JsonSerializer.Deserialize<Root>(json);
        return ToPlanets(data).ToArray();
    }

    private static IEnumerable<Planet> ToPlanets(Root? data)
    {
        if (data is null)
        {
            throw new ArgumentNullException(nameof(data));
        }

        return data.results.Select(planetDto => (Planet)planetDto).ToList();
    }
}