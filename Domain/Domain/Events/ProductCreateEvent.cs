namespace Domain.Events;

public class ProductCreateEvent : DomainEvent
{
    public Product Product { get; set; }

    public ProductCreateEvent(Product product)
    {
        Product = product;
    }
}