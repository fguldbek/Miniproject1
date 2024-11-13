using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Miniproject1;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Sæt BaseAddress til din backend-API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7249") });

await builder.Build().RunAsync();

