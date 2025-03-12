using CenterfieldAPI.Entities;

namespace CenterfieldAPI.Abstractions
{
    public interface IBusinessOpenStrategy
    {
        bool IsOpen(Business business);
    }
}