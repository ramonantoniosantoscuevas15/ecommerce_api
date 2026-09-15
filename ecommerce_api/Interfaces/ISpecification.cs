using System.Linq.Expressions;

namespace ecommerce_api.Interfaces
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
    }
}
