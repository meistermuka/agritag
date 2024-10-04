namespace AgriTag.Dtos
{
    public class ProduceTypeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ProduceTypeDto(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
