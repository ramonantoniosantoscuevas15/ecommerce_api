using ecommerce_api.Entidades;

namespace ecommerce_api.Specifications
{
    public class BrandListSpecification: BaseSpecification<Product,string>
    {
        public BrandListSpecification()
        {
            AddSelect(b => b.Brand);
            ApplyDistinct();
        }
    }
}
