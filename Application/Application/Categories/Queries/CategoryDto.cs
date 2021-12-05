using Application.Common.Mappings;

namespace Application.Categories.Queries;

public class CategoryDto : IMapFrom<Category>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}