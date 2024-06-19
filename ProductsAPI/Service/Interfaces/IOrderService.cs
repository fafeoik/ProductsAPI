using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsApi.Queries;

namespace ProductsApi.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDTO> GetByIdAsync(int id);
        Task<List<OrderDTO>> GetAllAsync(OrderQuery orderQuery);
        Task<bool> AddAsync(OrderPostDTO model);
        Task<OrderDTO> UpdateAsync(int Id, OrderDateDTO model);
        Task<bool> DeleteAsync(int Id);
    }
}
