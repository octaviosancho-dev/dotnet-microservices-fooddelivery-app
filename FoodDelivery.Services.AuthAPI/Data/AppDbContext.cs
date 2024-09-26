using FoodDelivery.Services.AuthAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodDelivery.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

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
    }
}
