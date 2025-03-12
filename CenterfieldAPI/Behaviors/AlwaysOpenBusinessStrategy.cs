using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Entities;

namespace CenterfieldAPI.Behaviors
{
    public class AlwaysOpenBusinessStrategy : IBusinessOpenStrategy
    {
        public bool IsOpen(Business business) => true;

    }


}