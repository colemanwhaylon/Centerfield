using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Entities;

namespace CenterfieldAPI.Behaviors
{
    internal class DefaultBusinessOpenStrategy : IBusinessOpenStrategy
    {
        public bool IsOpen(Business business)
        {
            return new TimeBasedBusinessOpenStrategy().IsOpen(business);
        }
    }
}