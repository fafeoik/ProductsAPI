using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;

namespace ProductsApi.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetByIdAsync(int id);
        Task<List<ProductDTO>> GetAll();
        Task<List<ProductDTO>> GetAllAbovePriceAsync(int price);
        Task<List<ProductDTO>> GetAllByNameAsync(string name);
        Task<bool> AddAsync(ProductOrderlessDTO model);
        Task AddRangeAsync(List<ProductModel> models);
        Task<ProductDTO> UpdateAsync(int Id, ProductUpdateDTO model);
        Task<bool> DeleteAsync(int Id);
    }
}
