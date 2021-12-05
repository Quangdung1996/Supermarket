using System.ComponentModel.DataAnnotations;

namespace Application.Categories.Commands.Create;

public class CreateCategoryCommand : IRequest<int>
{
    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public List<int> ProductId { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new Category
        {
            Name = request.Name,
            Description = request.Description,
        };

        entity.DomainEvents.Add(new CategoryCreateEvent(entity));
        _context.Categories.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}