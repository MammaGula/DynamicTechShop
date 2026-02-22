using Blazored.LocalStorage;
using DynamicTechShop.Client.Models;
using DynamicTechShop.Shared.Models;

namespace DynamicTechShop.Client.Services;

// This is the CartService for Blazor apps (WASM) —
// it stores and manages the user's shopping cart using Blazored.
// LocalStorage to save/load data in the browser's localStorage.

public class CartService
{
    private const string StorageKey = "dynamictechshop_cart";
    private readonly ILocalStorageService _localStorage;


    // The start list of items is empty, but it will be loaded from local storage when InitializeAsync is called.
    public List<ProductModel> Items { get; private set; } = new();

    public CartService(ILocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }

    public async Task InitializeAsync()
    {
        // Load items from local storage, or initialize with an empty list if not found
        Items = await _localStorage.GetItemAsync<List<ProductModel>>(StorageKey) ?? new();
    }


    // Keep items in local storage up to date whenever they are added or removed from the cart
    private ValueTask SaveAsync() => _localStorage.SetItemAsync(StorageKey, Items);


    // Add a product to the cart and save the updated cart to local storage
    public async Task AddAsync(ProductModel product)
    {
        Items.Add(product);
        await SaveAsync();
    }


    // Remove a product from the cart by its ID and save the updated cart to local storage
    public async Task RemoveAsync(int id)
    {
        var item = Items.FirstOrDefault(x => x.Id == id);
        if (item is null) return;

        Items.Remove(item);
        await SaveAsync();
    }

    public decimal Total => Items.Sum(x => x.Price);


    // Clear all items from the cart and save the empty cart to local storage
    public async Task ClearAsync()
    {
        Items.Clear();
        await SaveAsync();
    }
}













