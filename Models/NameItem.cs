namespace REST.Models
{
    public class NameItem
    {
        public required Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
    }
}
