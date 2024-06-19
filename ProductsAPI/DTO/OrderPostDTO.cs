using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTO
{
    public class OrderPostDTO
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public List<int>? ProductIds { get; set; }
    }
}
