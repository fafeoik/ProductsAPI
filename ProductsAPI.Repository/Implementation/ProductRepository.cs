using Microsoft.EntityFrameworkCore;
using ProductsApi.DataAccess;
using ProductsApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Repository.Implementation
{
    public class ProductRepository : DataContextRepository<ProductModel>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context)
        {
            
        }

        public override Task<List<ProductModel>> GetAllAsync(Expression<Func<ProductModel, bool>>?[] predicates = null,
                                         int? take = null,
                                         int? skip = null,
                                         params Expression<Func<ProductModel, object?>>[] includes)
        {
            IQueryable<ProductModel> query = _context.Set<ProductModel>();

            if (predicates != null)
                query = predicates.Aggregate(query, (currentQuery, predicate) => currentQuery.Where(predicate));

            if (skip != null)
                query = query.Skip(skip.Value);

            if (take != null)
                query = query.Take(take.Value);

            return query.ToListAsync();
        }
    }
}
