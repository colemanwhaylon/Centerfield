using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Entities;

namespace CenterfieldAPI.Behaviors
{
    public class TimeBasedBusinessOpenStrategy : IBusinessOpenStrategy
    {
        public bool IsOpen(Business business)
        {
            var currentTime = TimeOnly.FromDateTime(DateTime.UtcNow);
            return currentTime >= business.OpeningTime && currentTime <= business.ClosingTime;
        }
    }
}