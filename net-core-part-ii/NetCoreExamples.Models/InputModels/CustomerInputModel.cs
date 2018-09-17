using System.ComponentModel.DataAnnotations;

namespace NetCoreExamples.Models.InputModels
{
    /// <summary>
    /// A customer input model
    /// </summary>
    public class CustomerInputModel
    {
        /// <summary>
        /// The name of the customer
        /// </summary>
        /// <value>Is required and should be a length between 3 and 100</value>
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        /// <summary>
        /// The ssn of the customer
        /// </summary>
        /// <value>Should be 10 characters long</value>
        [StringLength(10)]
        public string Ssn { get; set; }
        /// <summary>
        /// The email of the customer
        /// </summary>
        /// <value>A required valid email</value>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// The street address of the customer
        /// </summary>
        /// <value>Is required</value>
        [Required]
        public string StreetAddress { get; set; }
        /// <summary>
        /// The city of the customer
        /// </summary>
        /// <value>Is required</value>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// The country of the customer
        /// </summary>
        /// <value>Is required</value>
        [Required]
        public string Country { get; set; }
        /// <summary>
        /// The biography of the customer
        /// </summary>
        /// <value>Has a max length of 255 characters</value>
        [MaxLength(255)]
        public string Bio { get; set; }
    }
}