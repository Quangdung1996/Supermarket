namespace Application.Products.Queries;

public class GetProductQuery : IRequest<ProductDto>
{
    public int Id { get; set; }

    public GetProductQuery(int id)
    {
        Id = id;
    }
}

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Products
            .Where(x => x.Id == request.Id)
            .Include(inc => inc.Category)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity == null) return null;

        return _mapper.Map<ProductDto>(entity);
    }
}