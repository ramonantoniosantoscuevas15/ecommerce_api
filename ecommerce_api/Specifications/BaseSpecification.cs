using ecommerce_api.Interfaces;
using System.Linq.Expressions;

namespace ecommerce_api.Specifications
{
    public class BaseSpecification<T>(Expression<Func<T, bool>>? criteria) : ISpecification<T>
    {
        protected BaseSpecification() : this(null)
        {

        }


        public Expression<Func<T, bool>>? Criteria => criteria;
    }
}
