using ProductsApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Repository
{
    public interface IProductRepository : IRepository<ProductModel>
    {
        Task<List<ProductModel>> GetAllAsync(Expression<Func<ProductModel, bool>> predicate);
    }
}
