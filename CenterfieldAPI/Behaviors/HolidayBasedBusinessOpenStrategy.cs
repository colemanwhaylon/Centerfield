using CenterfieldAPI.Abstractions;
using CenterfieldAPI.Entities;

namespace CenterfieldAPI.Behaviors
{
    public class HolidayBasedBusinessOpenStrategy : IBusinessOpenStrategy
    {
        private readonly List<DateTime> _holidays;

        public HolidayBasedBusinessOpenStrategy(List<DateTime> holidays)
        {
            _holidays = holidays;
        }

        public bool IsOpen(Business business)
        {
            if (_holidays.Contains(DateTime.Now.Date))
                return false; // Closed on holidays

            var timeStrategy = new TimeBasedBusinessOpenStrategy();
            return timeStrategy.IsOpen(business);
        }
    }


}