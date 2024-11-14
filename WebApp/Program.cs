using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Miniproject1;
using Miniproject1.Service;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<ILoginService, LoginServiceClientSide>();

// Sæt BaseAddress til din backend-API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7249") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ILoginService, LoginServiceClientSide>();
await builder.Build().RunAsync();

