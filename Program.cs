using BlazorApp;
using BlazorApp.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Configure HttpClient to use the API base URL from appsettings.json
builder.Services.AddScoped(sp => {
    var config = sp.GetRequiredService<IConfiguration>();
    var apiBaseUrl = config["ApiBaseUrl"] ?? throw new InvalidOperationException("ApiBaseUrl not configured in wwwroot/appsettings.json");
    return new HttpClient { BaseAddress = new Uri(apiBaseUrl) };
});

// Register the custom service for fetching data
builder.Services.AddScoped<IPortfolioClientService, PortfolioClientService>();

await builder.Build().RunAsync();
