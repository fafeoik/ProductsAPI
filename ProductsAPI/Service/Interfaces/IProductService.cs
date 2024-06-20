using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsAPI.Queries;

namespace ProductsApi.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductGetDTO> GetByIdAsync(int id);
        Task<List<ProductGetDTO>> GetAllAsync(ProductQuery productQuery);
        Task<bool> AddAsync(ProductDTO model);
        Task AddRangeAsync(List<ProductModel> models);
        Task<ProductDTO> UpdateAsync(int Id, ProductDTO model);
        Task<bool> DeleteAsync(int Id);
    }
}
