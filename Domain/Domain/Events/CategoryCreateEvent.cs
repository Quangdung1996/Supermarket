namespace Domain.Events;

public class CategoryCreateEvent : DomainEvent
{
    public Category Category { get; set; }

    public CategoryCreateEvent(Category category)
    {
        Category = category;
    }
}