using ProductsApi.DataAccess.Models;
using ProductsApi.Repository;
using System.Linq.Expressions;

namespace ProductsApi.Repository
{
    public interface IOrderRepository : IRepository<OrderModel>
    {
        Task<List<OrderModel>> GetAllAsync(Expression<Func<OrderModel, bool>>?[] predicates = null,
                                         Func<IQueryable<OrderModel>, IQueryable<OrderModel>>? queryFunc = null,
                                         int? take = null,
                                         params Expression<Func<OrderModel, object?>>[] includes);
    }
}