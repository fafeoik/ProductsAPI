using ProductsApi.DTO;

namespace ProductsApi.Service.Interfaces
{
    public interface IProductOrderService
    {
        Task AddAsync(OrderPostDTO orders);
    }
}
