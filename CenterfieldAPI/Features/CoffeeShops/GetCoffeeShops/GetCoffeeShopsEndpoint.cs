using CenterfieldAPI.Database;
using CenterfieldAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CenterfieldAPI.Features.CoffeeShops.GetCoffeeShops
{
    public static class GetCoffeeShopsEndpoint
    {
        public static void MapGetCoffeeShops(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", (CoffeeShopContext dbContext) =>
            {
                dbContext.CoffeeShops
                     .Select(coffeeShop => new CoffeeShopDto(
                         coffeeShop.Name,
                         coffeeShop.OpeningTime,
                         coffeeShop.ClosingTime,
                         coffeeShop.Location,
                         coffeeShop.Rating,
                         IsCoffeeShopOpen(coffeeShop)
                         ))
                     .AsNoTracking();
            });
        }

        private static bool IsCoffeeShopOpen(CoffeeShop coffeeShop)
        {
            TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);
            // Check if current time is between opening and closing times
            return currentTime >= coffeeShop.OpeningTime && currentTime <= coffeeShop.ClosingTime;
        }
    }
}
