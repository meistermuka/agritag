using System.ComponentModel.DataAnnotations;

namespace AgriTag.Models
{
    public class Location
    {
        [Key]
        public Guid LocationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; }
        public GeoCoordinates? GeoLocation { get; set; }
        public string PlusCode { get; set; } = string.Empty;

    }
}
