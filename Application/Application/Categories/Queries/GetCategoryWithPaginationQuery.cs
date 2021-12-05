namespace Application.Categories.Queries;

public class GetCategoryWithPaginationQuery : IRequest<PaginatedList<CategoryDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetCategoryWithPaginationHandler : IRequestHandler<GetCategoryWithPaginationQuery, PaginatedList<CategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCategoryWithPaginationHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CategoryDto>> Handle(GetCategoryWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Categories
                   .OrderBy(x => x.Name)
                   .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                   .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}