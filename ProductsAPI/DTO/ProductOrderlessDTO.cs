using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTO
{
    public class ProductOrderlessDTO
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Цена должна быть больше 0.")]
        public int Price { get; set; }
    }
}
