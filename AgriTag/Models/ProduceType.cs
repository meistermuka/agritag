using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AgriTag.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class ProduceType
    {
        [Key]
        public Guid ProduceTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
