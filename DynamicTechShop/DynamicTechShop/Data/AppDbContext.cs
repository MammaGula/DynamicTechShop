using DynamicTechShop.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DynamicTechShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Order> Orders => Set<Order>();
}