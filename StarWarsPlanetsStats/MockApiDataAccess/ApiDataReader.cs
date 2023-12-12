namespace StarWarsPlanetsStats.ApiDataAccess;

public class ApiDataReader : IApiDataReader
{
    public async Task<string> Read(string baseAddress, string requestAddress)
    {
        using var httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri(baseAddress);
        HttpResponseMessage response = await httpClient.GetAsync(requestAddress);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}