# ✨ DynamicTechShop

A cute, modern, and professional e-commerce demo built with .NET 10 and Blazor WebAssembly 💖 DynamicTechShop lets users browse products, search by name or category, view product details, manage a shopping cart, and place orders through a clean API-backed checkout flow.

## Features 🌸

- Product catalog with card-based browsing
- Live search across product names and categories
- Product details view
- Shopping cart with local storage persistence
- Checkout flow with order confirmation
- Server API for order creation
- SQL Server integration through Entity Framework Core
- Responsive UI with a Blazor-first user experience

## Tech Stack 🛠️

- .NET 10
- Blazor WebAssembly
- ASP.NET Core Razor Components
- Entity Framework Core
- SQL Server
- Blazored.LocalStorage

## Solution Structure 🧩

- `DynamicTechShop/` - Server host, API controllers, and app composition
- `DynamicTechShop.Client/` - Blazor WebAssembly client UI and services
- `DynamicTechShop.shared/` - Shared models used by both client and server

## Getting Started 🚀

### Prerequisites ✅

- .NET 10 SDK
- SQL Server
- Visual Studio 2026 or another compatible .NET IDE/editor

### Configuration 🔧

1. Update the connection string in `DynamicTechShop/appsettings.json` if needed.
2. Make sure SQL Server is running and accessible.
3. Restore packages and build the solution.

### Run the application 🎀

Before running the app, update the database first.

#### PowerShell

From the solution root:

```powershell
dotnet ef database update --project DynamicTechShop\DynamicTechShop.csproj --startup-project DynamicTechShop\DynamicTechShop.csproj
dotnet run --project DynamicTechShop\DynamicTechShop.csproj
```

#### NuGet Package Manager Console

Open **Tools > NuGet Package Manager > Package Manager Console** in Visual Studio, then run:

```powershell
Update-Database
```

After the database is updated, run the app from Visual Studio or use:

```powershell
dotnet run --project DynamicTechShop\DynamicTechShop.csproj
```

Then open the app in your browser and start shopping.

## User Flow 💫

1. Open the website.
2. Browse products on the catalog page.
3. Search products by name or category.
4. Open a product for more details.
5. Add items to the cart.
6. Review the cart and proceed to checkout.
7. Place the order and see the confirmation screen.

## Notes 🌷

- Cart data is stored in browser local storage.
- Orders are created through the `/api/orders` endpoint.
- The app is designed to work well with Blazor WebAssembly and server-side prerendering.

## Future Improvements 🌟

- Add user authentication and account management
- Save orders to a full order history page
- Add product filtering and sorting options
- Improve admin tools for managing products and orders
- Add tests for client and server features

