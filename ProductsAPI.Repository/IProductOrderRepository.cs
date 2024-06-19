using ProductsApi.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.Repository
{
    public interface IProductOrderRepository
    {
        Task AddAsync(List<ProductOrderModel> models);
    }
}
