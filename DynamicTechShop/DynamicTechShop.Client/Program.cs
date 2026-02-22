using Blazored.LocalStorage;
using DynamicTechShop.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// WebAssembly DI container for Services used by client-side components.
// HttpClient base address = same origin (https://localhost:xxxx/)
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CartService>();

await builder.Build().RunAsync();