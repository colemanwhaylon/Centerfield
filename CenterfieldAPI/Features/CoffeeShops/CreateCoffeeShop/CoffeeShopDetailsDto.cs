namespace CenterfieldAPI.Features.CoffeeShops.CreateCoffeeShop
{
    public record CoffeeShopDetailsDto
      (
          Guid Id,
          string Name,
          TimeOnly OpeningTime,
          TimeOnly ClosingTime,
          string? Location,
          decimal Rating
      );

}
