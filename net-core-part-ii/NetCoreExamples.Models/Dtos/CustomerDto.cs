namespace NetCoreExamples.Models.Dtos
{
    /// <summary>
    /// A DTO for customer
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// The id of the customer
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The name of the customer
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The social security number (kennitala) of the customer
        /// </summary>
        public string Ssn { get; set; }
        /// <summary>
        /// The email of the customer
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// The street address of the customer
        /// </summary>
        public string StreetAddress { get; set; }
        /// <summary>
        /// The city associated with the street address
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// The country associated with the city
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// An optional biography of the customer
        /// </summary>
        public string Bio { get; set; }
    }
}