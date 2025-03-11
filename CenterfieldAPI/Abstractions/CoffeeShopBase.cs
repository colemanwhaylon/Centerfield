namespace CenterfieldAPI.Abstractions
{
    using System;
    using CenterfieldAPI.Extensions;

    public abstract class CoffeeShopBase
    {
        protected CoffeeShopBase() { }
        protected CoffeeShopBase(string name, TimeOnly openingTime, TimeOnly closingTime)
        {
            this.Id = Id.NewSequentialGuid();
            Name = "Unnamed CoffeeShop" ;
            OpeningTime = TimeOnly.MinValue;
            ClosingTime = TimeOnly.MinValue;
        }

        public abstract Guid Id { get; set; } 
        public abstract string Name { get; init; }
        public abstract TimeOnly OpeningTime { get; init; }
        public abstract TimeOnly ClosingTime { get; init; }
        public virtual string? Location { get; set; }
        public virtual decimal Rating { get; set; } = 0.0m;
    }
}
