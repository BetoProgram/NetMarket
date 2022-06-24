using CORE.Entities;
using CORE.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUSSINESLOGIC.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            if (spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }

            if(spec.OrderByAsc is not null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderByAsc);
            }

            if (spec.OrderByDesc is not null)
            {
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDesc);
            }

            inputQuery = spec.Includes.Aggregate(inputQuery, (c, include) => c.Include(include));

            return inputQuery;
        }
    }
}
