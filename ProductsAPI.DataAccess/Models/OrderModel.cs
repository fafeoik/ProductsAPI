using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.DataAccess.Models
{
    public class OrderModel
    {
        public OrderModel() { }

        public OrderModel(OrderModel orderModel)
        {
            Id = orderModel.Id;
            Date = orderModel.Date;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        public virtual ICollection<ProductOrderModel> ProductOrders { get; set; } = new HashSet<ProductOrderModel>();
    }
}
