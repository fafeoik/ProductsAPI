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
        
        public virtual async Task<List<ProductModel>> GetAllAsync(Expression<Func<ProductModel, bool>> predicate) => await _context.Set<ProductModel>()
            .Where(predicate)
            .Include(a => a.ProductOrders)
            .ThenInclude(ar => ar.Order)
            .ToListAsync();
    }
}
