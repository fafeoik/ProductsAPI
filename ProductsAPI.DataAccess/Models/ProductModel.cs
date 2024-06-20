using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApi.DataAccess.Models
{
    public class ProductModel
    {
        public ProductModel() { }
        public ProductModel(ProductModel productModel)
        {
            Id = productModel.Id;
            Name = productModel.Name;
            Price = productModel.Price;
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Цена должна быть больше 0.")]
        public int? Price { get; set; }
        public virtual ICollection<ProductOrderModel> ProductOrders { get; set; } = new HashSet<ProductOrderModel>();
    }
}
