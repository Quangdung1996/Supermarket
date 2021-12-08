using Application.Categories.Queries;

namespace Application.Products.Queries;

public class ProductDto : IMapFrom<Product>
{
    public int Id { get; set; }

    public int? CategoryId { get; set; }

    public string Name { get; set; }

    public int? Quantity { get; set; }

    public double? Price { get; set; }

    public CategoryDto? Category { get; set; }
}