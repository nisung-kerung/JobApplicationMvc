using System.ComponentModel.DataAnnotations;

namespace JobApplicationMVC.Models
{
    public class JobApplication
    {
        [Key]
        public required string Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string City { get; set; }

        [Range(17, 99)]
        public int Age { get; set; }

        [Required]
        public required string Gender { get; set; }

        [Required]
        public required string Position { get; set; }

        [Range(0, 100)]
        public float Experience { get; set; }

        [Required]
        public required string Education { get; set; }

        public string Level =>
            Experience < 2 ? "Fresher" :
            Experience < 5 ? "Junior" :
            Experience < 10 ? "Mid-level" : "Senior";
    }
}
