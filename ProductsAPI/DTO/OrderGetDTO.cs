using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTO
{
    public class OrderGetDTO
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public List<ProductOrderlessDTO>? Products { get; set; }
    }
}
