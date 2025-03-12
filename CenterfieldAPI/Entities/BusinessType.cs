using System.ComponentModel.DataAnnotations;

namespace CenterfieldAPI.Entities
{
    // Business Type Model (e.g., "Coffee Shop", "Bookstore")
    public class BusinessType
    {
        [Required(ErrorMessage ="Id is required.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string? Emoji { get; set; } // Optional Unicode emoji
    }
}