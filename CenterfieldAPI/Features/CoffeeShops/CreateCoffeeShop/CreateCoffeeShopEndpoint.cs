using CenterfieldAPI.Database;
using CenterfieldAPI.Entities;
using CenterfieldAPI.Extensions;
using CenterfieldAPI.Features.CoffeeShops.Constants;

namespace CenterfieldAPI.Features.CoffeeShops.CreateCoffeeShop
{
    public static class CreateCoffeeShopEndpoint
    {
        public static void MapCreateCoffeeShop(this IEndpointRouteBuilder app)
        {
            app.MapPost("/", (CreateCoffeeShopDto coffeeShopDto, CoffeeShopContext dbContext) =>
            {
                var coffeeShop = new CoffeeShop
                {
                    Id = new Guid().NewSequentialGuid(),
                    Name = coffeeShopDto.Name,
                    OpeningTime = coffeeShopDto.OpeningTime,
                    ClosingTime = coffeeShopDto.ClosingTime,
                    Location = coffeeShopDto.Location,
                    Rating = coffeeShopDto.Rating,
                };

                dbContext.CoffeeShops.Add(coffeeShop);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(EndpointNames.GetCoffeeShops,
                    new { id = coffeeShop.Id },
                    new CoffeeShopDetailsDto(
                        coffeeShop.Id,
                        coffeeShop.Name,
                        coffeeShop.OpeningTime,
                        coffeeShop.ClosingTime,
                        coffeeShop.Location,
                        coffeeShop.Rating
                    ));
            });
        }
    }
}
