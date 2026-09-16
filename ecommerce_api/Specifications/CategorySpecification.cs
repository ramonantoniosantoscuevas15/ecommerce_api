using ecommerce_api.Entidades;

namespace ecommerce_api.Specifications
{
    public class CategorySpecification:BaseSpecification<Categorie>
    {
        public CategorySpecification(string? name) : base(
            n => (string.IsNullOrWhiteSpace(name) || n.Name == name))
        {

        }
    }
}
