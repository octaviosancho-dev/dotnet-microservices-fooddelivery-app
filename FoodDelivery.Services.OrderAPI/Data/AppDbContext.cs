using FoodDelivery.Services.OrderAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodDelivery.Services.OrderAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
                v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(), // Convertir a UTC antes de guardar
                v => DateTime.SpecifyKind(v, DateTimeKind.Utc) // Asegurar que se lea como UTC
            );

            // Para todas las entidades que tienen propiedades DateTime
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Busca todas las propiedades de tipo DateTime
                var dateTimeProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime));

                foreach (var property in dateTimeProperties)
                {
                    // Configura la conversión de cada propiedad DateTime a UTC
                    modelBuilder.Entity(entityType.Name)
                        .Property(property.Name)
                        .HasConversion(dateTimeConverter);
                }
            }
        }

        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
