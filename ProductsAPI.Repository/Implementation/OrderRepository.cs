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
    public class OrderRepository : DataContextRepository<OrderModel>, IOrderRepository
    {
        public OrderRepository(DataContext context) : base(context)
        {
            
        }

        //public virtual async Task<List<OrderModel>> GetAllAsync(Expression<Func<OrderModel, bool>> predicate) => await _context.Set<OrderModel>()
        //    .Where(predicate)
        //    .Include(a => a.ProductOrders)
        //    .ThenInclude(ar => ar.Product)
        //    .ToListAsync();

        public override Task<List<OrderModel>> GetAllAsync(Expression<Func<OrderModel, bool>>?[] predicates = null,
                                         Func<IQueryable<OrderModel>, IQueryable<OrderModel>>? queryFunc = null,
                                         int? take = null,
                                         params Expression<Func<OrderModel, object?>>[] includes)
        {
            IQueryable<OrderModel> query = _context.Set<OrderModel>();

            query = query
                .Include(utilAcc => utilAcc.ProductOrders)
                    .ThenInclude(rua => rua.Product);

            if (predicates != null)
                query = predicates.Aggregate(query, (currentQuery, predicate) => currentQuery.Where(predicate));

            if (queryFunc != null)
                query = queryFunc(query);

            if (take is not null)
                query = query.Take(take.Value);

            return query.ToListAsync();
        }
    }

    
}
