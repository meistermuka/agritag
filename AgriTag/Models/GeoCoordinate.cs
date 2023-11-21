using System.ComponentModel.DataAnnotations;

namespace AgriTag.Models
{
    public class GeoCoordinates
    {
        [Key]
        public Guid GeoCoordinatesId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
