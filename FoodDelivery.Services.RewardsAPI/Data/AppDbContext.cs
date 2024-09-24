using FoodDelivery.Services.RewardsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDelivery.Services.RewardsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Rewards> Rewards { get; set; }
    }
}
