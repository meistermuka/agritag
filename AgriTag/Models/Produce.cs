namespace AgriTag.Models
{
    public class Produce
    {
        public Guid ProduceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProduceTypeId { get; set; }
        public ProduceType ProduceType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
