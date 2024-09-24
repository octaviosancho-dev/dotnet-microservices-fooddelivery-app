using FoodDelivery.Services.ShoppingCartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Services.ShoppingCartAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CartHeader> CartHeader { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
    }
}
