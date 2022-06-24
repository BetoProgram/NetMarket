using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {

        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderByAsc { get; private set; }
        public Expression<Func<T, object>> OrderByDesc { get; private set; }

        protected void AddIncludes(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }

        protected void AddOrderByAsc(Expression<Func<T, object>> orderByExpessionAsc)
        {
            OrderByAsc = orderByExpessionAsc;
        }

        protected void AddOrderByDesc(Expression<Func<T, object>> orderByExpessionDesc)
        {
            OrderByDesc = orderByExpessionDesc;
        }
    }
}
