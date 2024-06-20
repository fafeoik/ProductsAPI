using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsApi.Queries;

namespace ProductsApi.Service.Interfaces
{
    public interface IOrderService
    {
        Task<OrderGetDTO> GetByIdAsync(int id);
        Task<List<OrderGetDTO>> GetAllAsync(OrderQuery orderQuery);
        Task<bool> AddAsync(OrderPostDTO order);
        Task<OrderGetDTO> UpdateAsync(int Id, OrderPutDTO order);
        Task<bool> DeleteAsync(int Id);
    }
}
