using DynamicTechShop.Client.Pages;
using DynamicTechShop.Components;

var builder = WebApplication.CreateBuilder(args);

// Register shared client services used by prerendered components.
// CartService is safe to register because it handles missing ILocalStorageService during prerender.
builder.Services.AddScoped<DynamicTechShop.Client.Services.CartService>();

// Register HttpClient for server-side prerendering (base address is the current server).
// This allows components that inject HttpClient to be prerendered without errors.
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:5001/") // Update port if different
});

// Register ProductService for prerendered components that need product data.
builder.Services.AddScoped<DynamicTechShop.Client.Services.ProductService>();



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

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DynamicTechShop.Client._Imports).Assembly);

app.Run();
