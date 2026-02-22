using System.Net.Http.Json;
using DynamicTechShop.Client.Models;

namespace DynamicTechShop.Client.Services;

public class ProductService
{
    private readonly HttpClient _http;

    public ProductService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<ProductModel>> GetProductsAsync()
    {
        var items = await _http.GetFromJsonAsync<List<ProductModel>>("products.json");
        return items ?? new List<ProductModel>(); // Return  a new empty List<ProductModel> if items is null
    }


    public async Task<ProductModel?> GetByIdAsync(int id)
    {
        var items = await GetProductsAsync();
        return items.FirstOrDefault(x => x.Id == id); // Return the first product that matches the id, or null if not found
    }
}