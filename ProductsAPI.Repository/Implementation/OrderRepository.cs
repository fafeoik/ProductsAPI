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

        public override Task<List<OrderModel>> GetAllAsync(Expression<Func<OrderModel, bool>>?[] predicates = null,
                                         int? take = null,
                                         params Expression<Func<OrderModel, object?>>[] includes)
        {
            IQueryable<OrderModel> query = _context.Set<OrderModel>();

            query = query
                .Include(utilAcc => utilAcc.ProductOrders)
                    .ThenInclude(rua => rua.Product);

            if (predicates != null)
                query = predicates.Aggregate(query, (currentQuery, predicate) => currentQuery.Where(predicate));

            if (take is not null)
                query = query.Take(take.Value);

            return query.ToListAsync();
        }

        public override async Task<OrderModel?> GetByIdAsync(int Id)
        {
            IQueryable<OrderModel> query =_context.Set<OrderModel>();
            query = query
                .Include(utilAcc => utilAcc.ProductOrders)
                .ThenInclude(rua => rua.Product);

            return await query.SingleOrDefaultAsync(order => order.Id == Id);
        }
    }


}
