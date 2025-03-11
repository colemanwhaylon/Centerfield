namespace CenterfieldAPI.DTOs
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
