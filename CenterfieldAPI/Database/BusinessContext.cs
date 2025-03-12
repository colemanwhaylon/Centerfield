using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CenterfieldAPI.Database
{
    public class BusinessContext : DbContext
    {
        public DbSet<Business> Businesses => Set<Business>();
        public DbSet<BusinessType> BusinessTypes => Set<BusinessType>();
        public DbSet<Location> Locations => Set<Location>();

        public BusinessContext(DbContextOptions<BusinessContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<BusinessBase>()
            //    .UseTphMappingStrategy(); // Default TPH (single table)

            modelBuilder.Ignore<BusinessBase>(); // ✅ Ignore base class, so it's not mapped as an entity.


            var businessEntity = modelBuilder.Entity<Business>();

            businessEntity.HasKey(b => b.Id);

            businessEntity.Property(b => b.Name)
                .IsRequired();

            businessEntity.Property(b => b.OpeningTime)
                .IsRequired();

            businessEntity.Property(b => b.ClosingTime)
                .IsRequired();

            businessEntity.Property(b => b.Rating)
                .HasPrecision(3, 2)
                .IsRequired(false);

            businessEntity.HasOne(b => b.BusinessType)
                .WithMany()
                .HasForeignKey(b => b.BusinessTypeId)
                .IsRequired(false);

            businessEntity.HasOne(b => b.Location)
                .WithMany()
                .HasForeignKey(b => b.LocationId)
                .IsRequired(false);

            // Business Type Entity
            modelBuilder.Entity<BusinessType>()
                .HasKey(bt => bt.Id);

            modelBuilder.Entity<BusinessType>()
                .Property(bt => bt.Name)
                .IsRequired();

            modelBuilder.Entity<BusinessType>()
                .Property(bt => bt.Emoji)
                .IsRequired(false);

            // Location Entity
            modelBuilder.Entity<Location>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Location>()
                .Property(l => l.Latitude)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(l => l.Longitude)
                .IsRequired();
        }
    }

}