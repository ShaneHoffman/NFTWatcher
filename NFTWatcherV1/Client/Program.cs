global using NFTWatcherV1.Shared;
global using NFTWatcherV1.Client.Services.GenieService;
global using NFTWatcherV1.Client.Services.BrowserService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NFTWatcherV1.Client;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IGenieService, GenieService>();
builder.Services.AddScoped<IBrowserServcie, BrowserService>();

await builder.Build().RunAsync();
