using DynamicTechShop.Client.Pages;
using DynamicTechShop.Components;
using DynamicTechShop.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// EF Core + SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Register shared client services used by prerendered components.
// CartService is safe to register because it handles missing ILocalStorageService during prerender.
builder.Services.AddScoped<DynamicTechShop.Client.Services.CartService>();

// Register HttpClient for server-side prerendering.
// BaseAddress is set to a relative URL so it works during prerender.
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost") });

// Register ProductService for prerendered components that need product data.
builder.Services.AddScoped<DynamicTechShop.Client.Services.ProductService>();

// Add controllers to the DI container so API endpoints work
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

// Adds antiforgery token validation to all non-GET requests.
// This is important for security, especially for the API endpoints that modify data.
app.UseAntiforgery(); 

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DynamicTechShop.Client._Imports).Assembly);

// Map API controllers so endpoints like /api/orders work
app.MapControllers();

app.Run();








