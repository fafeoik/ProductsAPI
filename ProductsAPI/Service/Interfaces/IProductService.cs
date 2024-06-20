using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsAPI.Queries;

namespace ProductsApi.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductGetDTO> GetByIdAsync(int id);
        Task<List<ProductGetDTO>> GetAllAsync(ProductQuery productQuery);
        Task<bool> AddAsync(ProductOrderlessDTO model);
        Task AddRangeAsync(List<ProductModel> models);
        Task<ProductUpdateDTO> UpdateAsync(int Id, ProductUpdateDTO model);
        Task<bool> DeleteAsync(int Id);
    }
}
