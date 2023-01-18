using BlazorRESTcountries;
using BlazorRESTcountries.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IRESTConuntriesServiceV2, RESTConuntriesServiceV2>(
    httpClient => httpClient.BaseAddress = new Uri(builder.Configuration["RESTCountriesAPI:URL"]));


await builder.Build().RunAsync();
