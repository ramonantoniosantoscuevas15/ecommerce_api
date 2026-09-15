using ecommerce_api.Entidades;
using ecommerce_api.Interfaces;

namespace ecommerce_api.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> query, ISpecification<T> spec)
        {
            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            return query;
        }
    }
}
