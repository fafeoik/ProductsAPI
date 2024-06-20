using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsApi.Repository;
using ProductsApi.Service.Interfaces;

namespace ProductsApi.Service
{
    public class ProductOrderService : IProductOrderService
    {
        private readonly IProductOrderRepository _productOrderRepository;

        public ProductOrderService(IProductOrderRepository productOrderRepository)
        {
            _productOrderRepository = productOrderRepository;
        }

        public async Task AddAsync(OrderPostDTO order, int orderId)
        {
            List<ProductOrderModel> models = new List<ProductOrderModel>();

            foreach (var id in order.ProductIds)
            {
                models.Add(new ProductOrderModel() { OrderId = orderId, ProductId = id });
            }

             await _productOrderRepository.AddAsync(models);
        }
    }
}
