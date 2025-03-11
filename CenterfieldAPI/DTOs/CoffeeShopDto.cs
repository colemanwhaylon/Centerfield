namespace CenterfieldAPI.DTOs
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
