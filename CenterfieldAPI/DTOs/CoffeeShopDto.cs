namespace CenterfieldAPI.DTOs
{
    public record CoffeeShopDto
    (
        Guid Id,
        string Name,
        TimeOnly OpeningTime,
        TimeOnly ClosingTime,
        string? Location,
        decimal Rating,
        bool Is_Open
    );
}
