using CenterfieldAPI.Features.CoffeeShops.CreateCoffeeShop;
using CenterfieldAPI.Features.CoffeeShops.GetCoffeeShops;

namespace CenterfieldAPI.Features.CoffeeShops
{
    public static class CoffeeShopsEndpoints
    {
        public static void MapCoffeeShops(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/coffeeshops");
            group.MapCreateCoffeeShop();
            group.MapGetCoffeeShops();
        }
    }
}
