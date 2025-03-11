using System.ComponentModel.DataAnnotations;

namespace CenterfieldAPI.Features.CoffeeShops.CreateCoffeeShop
{
    public partial record CreateCoffeeShopDto(string name, TimeOnly openingTime, TimeOnly closingTime)
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50)]
        public string Name { get; init; } = name;

        [Required(ErrorMessage = "OpeningTime is required.")]
        public TimeOnly OpeningTime { get; init; } = openingTime;

        [Required(ErrorMessage = "ClosingTime is required.")]
        public TimeOnly ClosingTime { get; init; } = closingTime;

        [StringLength(255)]
        public string? Location { get; set; }

        [Range(0.00f, 5.00f)]
        public decimal Rating { get; set; }

        //Calculated property
        public bool Is_Open
        {
            get
            {
                TimeOnly currentTime = TimeOnly.FromDateTime(DateTime.Now);

                // Check if current time is between opening and closing times
                return currentTime >= OpeningTime && currentTime <= ClosingTime;
            }
        }
    }
}
