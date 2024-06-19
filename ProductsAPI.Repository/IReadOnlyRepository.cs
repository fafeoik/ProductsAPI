using ProductsApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Repository
{
    public interface IReadOnlyRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>?[] predicates = null,
                                         Func<IQueryable<T>, IQueryable<T>>? queryFunc = null,
                                         int? take = null,
                                         params Expression<Func<T, object?>>[] includes);
        Task<T?> GetByIdAsync(int Id);
    }
}
