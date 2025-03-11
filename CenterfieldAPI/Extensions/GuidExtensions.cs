namespace CenterfieldAPI.Extensions
{

    public static class GuidExtensions
    {
        /// <summary>
        /// Creates a NewSequentialGuid GUID which in the db allows for:
        /// Faster inserts (compared to random GUIDs)
        /// Less page splits (database pages stay ordered)
        /// Smaller index size, leading to better query performance
        /// </summary>
        public static Guid NewSequentialGuid(this Guid guid)
        {
            byte[] guidArray = Guid.NewGuid().ToByteArray();
            DateTime now = DateTime.UtcNow;
            long timestamp = now.Ticks;

            Array.Copy(BitConverter.GetBytes(timestamp), 0, guidArray, 0, 8);

            return guid = new Guid(guidArray);
        }
    }
}
