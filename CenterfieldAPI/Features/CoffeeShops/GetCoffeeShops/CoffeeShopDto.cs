namespace CenterfieldAPI.Features.CoffeeShops.GetCoffeeShops
{
    public record CoffeeShopDto
    (
        string Name,
        TimeOnly OpeningTime,
        TimeOnly ClosingTime,
        string? Location,
        decimal Rating,
        bool Is_Open
    );
}
