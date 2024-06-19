using Microsoft.EntityFrameworkCore;
using ProductsApi.DataAccess;
using ProductsApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Repository.Implementation
{
    public class ProductOrderRepository : IProductOrderRepository
    {
        protected readonly DataContext _context;
        public ProductOrderRepository(DataContext dbContext) => _context = dbContext;

        public async Task AddAsync(List<ProductOrderModel> models)
        {
             await _context.Set<ProductOrderModel>().AddRangeAsync(models);
            _ = await _context.SaveChangesAsync();
        }
    }
}
