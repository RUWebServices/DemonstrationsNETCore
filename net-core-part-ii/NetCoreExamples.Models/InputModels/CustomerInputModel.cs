using System.ComponentModel.DataAnnotations;

namespace NetCoreExamples.Models.InputModels
{
    public class CustomerInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Ssn { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [MaxLength(255)]
        public string Bio { get; set; }
    }
}