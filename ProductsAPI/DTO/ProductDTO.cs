using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTO
{
    public class ProductGetDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
    }
}
