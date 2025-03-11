using Bogus;
using CenterfieldAPI.Entities;
using CenterfieldAPI.Extensions;
using Microsoft.EntityFrameworkCore;


namespace CenterfieldAPI.Database
{
    public static class DatabaseExtensions
    {
        public static void InitializeDb(this WebApplication app)
        {
            app.MigrateDb();
            app.SeedDb();
        }

        private static void MigrateDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            CoffeeShopContext dbContext = scope.ServiceProvider
                                               .GetRequiredService<CoffeeShopContext>();
            dbContext.Database.Migrate();
        }

        private static void SeedDb(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            CoffeeShopContext dbContext =
                scope.ServiceProvider
                     .GetRequiredService<CoffeeShopContext>();

            if (!dbContext.CoffeeShops.Any())
            {
                dbContext.CoffeeShops.AddRange(GetCoffeeShops());
                dbContext.SaveChanges();
            }
        }

        private static IEnumerable<CoffeeShop> GetCoffeeShops()
        {
            //Use Bogus to set the randomizer seed if
            //you wish to generate repeatable data sets.
            Randomizer.Seed = new Random(8675309);

            var coffeeShopFaker = new Faker<CoffeeShop>()
                .StrictMode(true)
                .RuleFor(o => o.Id, f => f.Random.Guid().NewSequentialGuid())
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.OpeningTime, f => f.Date.BetweenTimeOnly(new TimeOnly(8, 0, 0), new TimeOnly(10, 0, 0)))
                .RuleFor(o => o.ClosingTime, f => f.Date.BetweenTimeOnly(new TimeOnly(20, 0, 0), new TimeOnly(0, 0, 0)))
                .RuleFor(o => o.Location, f => f.Address.FullAddress())
                .RuleFor(o => o.Rating, f => f.Random.Decimal(0.0m, 5.0m));

            var list = coffeeShopFaker.GenerateBetween(1000, 2000);
            return list;
        }
    }
}