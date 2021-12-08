namespace Application.Products.Commands.Delete;

public class DeleteProductCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeleteProductCommand(int id)
    {
        Id = id;
    }
}

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteProductCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null) return false;
        _context.Products.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}