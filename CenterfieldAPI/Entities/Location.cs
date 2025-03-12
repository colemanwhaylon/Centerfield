using System.ComponentModel.DataAnnotations;

namespace CenterfieldAPI.Entities
{
    // Stores latitude/longitude for mapping support
    public class Location
    {
        [Required(ErrorMessage ="Id is required.")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Latitude is required.")]
        public double Latitude { get; set; }
        [Required(ErrorMessage = "Longitude is required.")]
        public double Longitude { get; set; }
    }
}