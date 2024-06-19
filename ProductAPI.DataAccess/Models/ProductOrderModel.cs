using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.DataAccess.Models
{
    public class ProductOrderModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int OrderId { get; set; }
        public OrderModel Order { get; set; }
    }
}
