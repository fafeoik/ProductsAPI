using ProductsApi.DataAccess.Models;
using ProductsApi.Repository;
using System.Linq.Expressions;

namespace ProductsApi.Repository
{
    public interface IOrderRepository : IRepository<OrderModel>
    {
        Task<List<OrderModel>> GetAllAsync(Expression<Func<OrderModel, bool>>?[] predicates = null,
                                         int? take = null,
                                         int? skip = null,
                                         params Expression<Func<OrderModel, object?>>[] includes);

        Task<OrderModel?> GetByIdAsync(int Id);
    }
}