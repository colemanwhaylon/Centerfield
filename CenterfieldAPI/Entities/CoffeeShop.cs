using CenterfieldAPI.Abstractions;

namespace CenterfieldAPI.Entities
{
    using System;

    public class CoffeeShop : CoffeeShopBase
    {
        public CoffeeShop()
        {
            this.Name = "No Name Set";
            this.Location = null;
            this.Rating = 0.0m;
        }
        public CoffeeShop(string name, TimeOnly openingTime, TimeOnly closingTime)
             : base(name, openingTime, closingTime)

        {
            this.Name = name;
            this.OpeningTime = openingTime;
            this.ClosingTime = closingTime;
            this.Location = null;
            this.Rating = 0.0m;
        }
        public override Guid Id { get; set; }
        public override string Name { get; init; }
        public override TimeOnly OpeningTime { get; init; }
        public override TimeOnly ClosingTime { get; init; }
        public override string? Location { get; set; }
        public override decimal Rating { get; set; } = 0.0m;
    }


}
