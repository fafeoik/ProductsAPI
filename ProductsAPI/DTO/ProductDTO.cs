using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public List<OrderDTO>? Orders { get; set; }
    }
}
