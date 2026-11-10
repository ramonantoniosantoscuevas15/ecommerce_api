using ecommerce_api.Entidades;

namespace ecommerce_api.Specifications
{
    public class TypeListSpecification : BaseSpecification<Product, string>
    {
        public TypeListSpecification()
        {
            AddSelect(t => t.Type);
            ApplyDistinct();
        }
    }
}
