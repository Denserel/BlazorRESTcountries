using BlazorRESTcountries.Models;

namespace BlazorRESTcountries.Data;

public interface IRESTConuntriesServiceV2
{
    Task<List<CountreyV2>> GetAllCountries();
}
