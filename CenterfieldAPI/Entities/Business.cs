using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Behaviors;

namespace CenterfieldAPI.Entities
{
    // Business Class Inheriting from BusinessBase
    public class Business : BusinessBase
    {
        private readonly IBusinessOpenStrategy _businessOpenStrategy;

        private Business()
        {
            _businessOpenStrategy = new DefaultBusinessOpenStrategy(); // Default strategy to prevent nulls
        }

        public Business(IBusinessOpenStrategy businessOpenStrategy)
        {
            _businessOpenStrategy = businessOpenStrategy;
        }

        public Business(string name, TimeOnly openingTime, TimeOnly closingTime, IBusinessOpenStrategy strategy)
        {
            Name = name;
            OpeningTime = openingTime;
            ClosingTime = closingTime;
            _businessOpenStrategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
        }

        public int? BusinessTypeId { get; set; }
        public BusinessType? BusinessType { get; set; }

        public int? LocationId { get; set; }
        public Location? Location { get; set; }

        // Use the strategy pattern for IsOpen logic
       
        public override bool IsOpen => _businessOpenStrategy?.IsOpen(this) ?? false;
    }
}