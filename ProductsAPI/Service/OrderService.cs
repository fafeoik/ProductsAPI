using Mapster;
using ProductsApi.Repository;
using ProductsApi.Service.Interfaces;
using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using System;
using ProductsApi.Queries;
using System.Linq.Expressions;

namespace ProductsApi.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly IProductOrderService _productOrderService;

        public OrderService(IOrderRepository orderRepository, IProductService productService, IProductOrderService productOrderService)
        {
            _orderRepository = orderRepository;
            _productService = productService;
            _productOrderService = productOrderService;
        }

        public async Task<OrderDTO> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order.Adapt<OrderDTO>();
        }

        public async Task<List<OrderDTO>> GetAllAsync(OrderQuery orderQuery)
        {
            var predicates = new List<Expression<Func<OrderModel, bool>>>();

            if (orderQuery.Date != null)
            {
                DateOnly date;

                bool isParsed = DateOnly.TryParse(orderQuery.Date, out date);

                if (!isParsed)
                {
                    
                }

                predicates.Add(order => order.Date == date);
            }

            var orders = await _orderRepository.GetAllAsync(predicates.ToArray());

            return orders.Adapt<List<OrderDTO>>();
        }

        public async Task<bool> AddAsync(OrderPostDTO orderDTO)
        {
            var orderModel = orderDTO.Adapt<OrderModel>();
            var createdId = await _orderRepository.AddAsync(orderModel);

            if (orderDTO.ProductIds != null && createdId > 0)
            {
                await _productOrderService.AddAsync(orderDTO);
                return true;
            }

            return false;
        }

        public async Task<OrderDTO> UpdateAsync(int Id, OrderDateDTO model)
        {
            var accountToUpdate = await _orderRepository.GetByIdAsync(Id);

            if (accountToUpdate != null)
            {
                accountToUpdate.Date = DateOnly.Parse(model.Date);
                await _orderRepository.Update(accountToUpdate);
            }
            return accountToUpdate.Adapt<OrderDTO>();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var accountToDelete = await _orderRepository.GetByIdAsync(Id);
            return await _orderRepository.DeleteAsync(accountToDelete);
        }
    }
}
