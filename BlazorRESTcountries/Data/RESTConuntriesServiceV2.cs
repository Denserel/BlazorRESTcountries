using BlazorRESTcountries.Models;
using System.Text.Json;

namespace BlazorRESTcountries.Data;

public class RESTConuntriesServiceV2 : IRESTConuntriesServiceV2
{
    private readonly HttpClient _httpClient;

    public RESTConuntriesServiceV2(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<CountreyV2>> GetAllCountries()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "/v2/all");
        var response = await _httpClient.SendAsync(request);

        try
        {
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responsObject = await JsonSerializer.DeserializeAsync<CountreyV2[]>(responseStream);

            return responsObject.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return new List<CountreyV2>();
    }
}
