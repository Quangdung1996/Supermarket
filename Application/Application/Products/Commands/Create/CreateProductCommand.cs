using System.ComponentModel.DataAnnotations;

namespace Application.Products.Commands.Create;

public class CreateProductCommand : IRequest<int>

{
    [Required]
    public int? CategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public int? Quantity { get; set; }

    [Required]
    public double? Price { get; set; }
}

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = new Product
        {
            Name = request.Name,
            CategoryId = request.CategoryId,
            Quantity = request.Quantity,
            Price = request.Price,
        };

        entity.DomainEvents.Add(new ProductCreateEvent(entity));
        _context.Products.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}