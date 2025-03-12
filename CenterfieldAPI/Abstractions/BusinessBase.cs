using System.ComponentModel.DataAnnotations;

namespace CenterfieldAPI.Abstractions
{

    // Abstract Base Class for Shared Properties
    public abstract class BusinessBase
    {
        // Default constructor for optional properties
        public BusinessBase() { Name = string.Empty; }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TimeOnly OpeningTime { get; set; }

        [Required]
        public TimeOnly ClosingTime { get; set; }

        public decimal? Rating { get; set; } // Optional

        public virtual bool IsOpen => false; // Override in derived classes if needed

        public override string ToString()
        {
            return $"{Name} ({OpeningTime} - {ClosingTime}) | Rating: {Rating ?? 0}";
        }
    }
}