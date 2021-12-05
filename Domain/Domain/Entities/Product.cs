namespace Domain.Entities;

public class Product: AuditableEntity, IHasDomainEvent
{
    public int Id { get; set; }

    [Required]
    public int? CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int? Quantity { get; set; }

    [Required]
    public double? Price { get; set; }

    public Category? Category { get; set; }
    public List<DomainEvent> DomainEvents { get; set; } = new();
}