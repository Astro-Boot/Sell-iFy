using Sellify.Domain;

namespace Sellify.Application.Specification.Products;

public class ProductSpecificationParams : SpecificationParams
{
    public int? CategoryId { get; set; }

    public decimal? PrecioMax { get; set; }

    public decimal? PrecioMin { get; set; }

    public int? Rating { get; set; }

    public ProductStatus? Status { get; set; }
}