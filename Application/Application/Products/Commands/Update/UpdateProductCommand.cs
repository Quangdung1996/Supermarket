using System.ComponentModel.DataAnnotations;

namespace Application.Products.Commands.Update;

public class UpdateProductCommand : IRequest<bool>
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
}

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        if (entity == null) return false;

        entity.Name = request.Name;
        entity.CategoryId = request.CategoryId;
        entity.Quantity = request.Quantity;
        entity.Price = request.Price;

        _context.Products.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}