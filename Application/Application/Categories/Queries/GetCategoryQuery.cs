namespace Application.Categories.Queries;

public class GetCategoryQuery : IRequest<CategoryDto?>
{
    public int Id { get; }

    public GetCategoryQuery(int id)
    {
        Id = id;
    }
}

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto?>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryDto?> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (category == null) return null;
        return _mapper.Map<CategoryDto>(category);
    }
}