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

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDescending { get; private set; }

        public List<Expression<Func<T, object>>> Includes => throw new NotImplementedException();

        public List<string> IncludeStrings => throw new NotImplementedException();

        public bool IsDistinct => throw new NotImplementedException();

        public int Take => throw new NotImplementedException();

        public int Skip => throw new NotImplementedException();

        public bool IspagingEnabled => throw new NotImplementedException();

        public IQueryable<T> ApplyCriteria(IQueryable<T> query)
        {
            throw new NotImplementedException();
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }
    }
}
