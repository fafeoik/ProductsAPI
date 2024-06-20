using Mapster;
using ProductsApi.Repository;
using ProductsApi.Service.Interfaces;
using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using System;
using ProductsAPI.Queries;
using ProductsApi.Queries;
using ProductsApi.Repository.Implementation;
using System.Linq.Expressions;

namespace ProductsApi.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var account = await _productRepository.GetByIdAsync(id);
            return account.Adapt<ProductDTO>();
        }

        public async Task<List<ProductDTO>> GetAllAsync(ProductQuery productQuery)
        {
            var predicates = new List<Expression<Func<ProductModel, bool>>>();

            if (productQuery.Name != null)
                predicates.Add(product => product.Name == productQuery.Name);

            if (productQuery.AbovePrice != null && productQuery.BelowPrice != null)
                predicates.Add(product => product.Price >= productQuery.AbovePrice && product.Price <= productQuery.BelowPrice);

            if (productQuery.BelowPrice != null)
                predicates.Add(product => product.Price <= productQuery.BelowPrice);

            if (productQuery.AbovePrice != null)
                predicates.Add(product => product.Price >= productQuery.AbovePrice);

            var products = await _productRepository.GetAllAsync(predicates.ToArray());

            return products.Adapt<List<ProductDTO>>();
        }

        public async Task<bool> AddAsync(ProductOrderlessDTO product)
        {
            var model = product.Adapt<ProductModel>();
            var createdId = await _productRepository.AddAsync(model);
            
            if (createdId > 0)
            {
                return true;
            }

            return false;
        }

        public async Task AddRangeAsync(List<ProductModel> models)
        {
            foreach (var model in models)
            {
                _ = await _productRepository.AddAsync(model);
            }
        }

        public async Task<ProductDTO> UpdateAsync(int Id, ProductUpdateDTO model)
        {
            var accountToUpdate = await _productRepository.GetByIdAsync(Id);

            if (accountToUpdate != null)
            {
                accountToUpdate.Name = model.Name;
                accountToUpdate.Price = model.Price;
                await _productRepository.Update(accountToUpdate);
            }
            return accountToUpdate.Adapt<ProductDTO>();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var accountToDelete = await _productRepository.GetByIdAsync(Id);
            return await _productRepository.DeleteAsync(accountToDelete);
        }
    }
}
