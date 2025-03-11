using CenterfieldAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CenterfieldAPI.Database;

public class CoffeeShopContext(DbContextOptions<CoffeeShopContext> options)
    : DbContext(options)
{
    public DbSet<CoffeeShop> CoffeeShops => Set<CoffeeShop>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var entity = modelBuilder.Entity<CoffeeShop>();

        // Ensure CoffeeShop inherits from CoffeeShopBase
        // entity.HasBaseType<CoffeeShopBase>();

        // Configure Primary Key (Id) - No auto-generation
        entity.HasKey(c => c.Id);

        entity.Property(c => c.Id)
              .IsRequired()
              .ValueGeneratedNever(); // EF won't generate it

        // Configure Name (Required)
        entity.Property(c => c.Name)
              .IsRequired();

        // Configure OpeningTime and ClosingTime
        entity.Property(c => c.OpeningTime)
              .IsRequired();

        entity.Property(c => c.ClosingTime)
              .IsRequired();

        // Configure Location (Optional)
        entity.Property(c => c.Location)
              .HasMaxLength(255)
              .IsRequired(false); // Nullable

        // Configure Rating (Optional)
        entity.Property(c => c.Rating)
              .HasPrecision(3, 2); // Example: 4.75
    }

}
