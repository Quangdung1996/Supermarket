using System.ComponentModel.DataAnnotations;

namespace Application.Categories.Commands.Update;

public class UpdateCategoryCommand : IRequest<bool>
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public List<int> ProductId { get; set; }
}

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Categories.FirstOrDefaultAsync(x=>x.Id == request.Id,cancellationToken);
        if (entity == null) return false;

        entity.Name = request.Name;
        entity.Description = request.Description;

        _context.Categories.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
