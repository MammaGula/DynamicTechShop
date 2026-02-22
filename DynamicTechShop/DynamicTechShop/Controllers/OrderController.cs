using DynamicTechShop.Data;
using DynamicTechShop.Shared.Models;
using Microsoft.AspNetCore.Mvc;

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