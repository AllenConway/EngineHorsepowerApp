using Blazored.LocalStorage;
using EngineHorsepowerApp;
using EngineHorsepowerApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Note: There is no difference between scoped and singleton in Blazor WebAssmebly.
// Guidance from docs is to use scoped services as they will act the same between both hosting models.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IEngineHorsepowerService, EngineHorsepowerService>();
builder.Services.AddScoped<IEngineHorsepowerDataService, EngineHorsepowerLocalStorageService>();

await builder.Build().RunAsync();
