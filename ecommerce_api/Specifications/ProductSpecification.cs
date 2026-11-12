using ecommerce_api.Entidades;

namespace ecommerce_api.Specifications
{
    public class ProductSpecification : BaseSpecification<Product>
    {
        public ProductSpecification(ProductSpecParams specParams): base(p => 
        (string.IsNullOrEmpty(specParams.Search) || p.Name.ToLower().Contains(specParams.Search)) &&
        (specParams.Brand.Count == 0 || specParams.Brand.Contains(p.Brand)) &&
        (specParams.Type.Count == 0 || specParams.Type.Contains(p.Type))
        )
        {
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);
            switch (specParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }

        }
    }
}
