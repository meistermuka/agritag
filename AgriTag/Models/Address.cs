using System.ComponentModel.DataAnnotations;

namespace AgriTag.Models
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
