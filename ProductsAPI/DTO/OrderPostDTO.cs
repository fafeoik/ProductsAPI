using System.ComponentModel.DataAnnotations;

namespace ProductsApi.DTO
{
    public class OrderPostDTO
    {
        public List<int>? ProductIds { get; set; }
    }
}
