using System.ComponentModel.DataAnnotations;

namespace RentAWorld.Models.InputModels
{
    public class RentalInputModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal AskingPrice { get; set; }
        public bool? Available { get; set; }
        [MinLength(3)]
        [MaxLength(255)]
        public string Address { get; set; }
        [MinLength(3)]
        [MaxLength(255)]
        public string City { get; set; }
    }
}