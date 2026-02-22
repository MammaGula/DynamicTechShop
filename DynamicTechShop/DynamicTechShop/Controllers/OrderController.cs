using Azure.Core;
using DynamicTechShop.Data;
using DynamicTechShop.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace DynamicTechShop.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _db;

    public OrdersController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Create()
    {
        var order = new Order { CreatedAt = DateTime.UtcNow };
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return Ok(order);
    }
}


//1. The user opens the website https://localhost:xxxx

//2. The server(DynamicTechShop) sends the start page + static files.

//3. The browser loads the client(WASM) and begins interactive interaction.

//4. Products are read from products.json (static) → list/search is performed.

//5. The cart is stored in LocalStorage(in the browser).

//6. The checkout button is pressed → a POST request(/api/orders) is sent.

//7. The server receives the request via the controller → EF Core saves it to the SQL Server(Orders table).