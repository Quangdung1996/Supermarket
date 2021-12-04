namespace Domain.Entities;

public class Category : AuditableEntity, IHasDomainEvent
{
    public int CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    // navigation property for ef core
    public List<Product>? Products { get; set; }
    public List<DomainEvent> DomainEvents { get; set; } = new ();
}