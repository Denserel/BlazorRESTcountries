using BlazorRESTcountries.Models;

namespace BlazorRESTcountries.Data;

public interface IRESTConuntriesServiceV2
{
    Task<List<CountryV2>> GetAllCountries();
    Task<CountryV2> GetCountryByAlphaCode(string alphaCode);
}
