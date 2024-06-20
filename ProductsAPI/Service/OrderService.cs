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

        public async Task<OrderGetDTO> GetByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            return order.Adapt<OrderGetDTO>();
        }

        public async Task<List<OrderGetDTO>> GetAllAsync(OrderQuery orderQuery)
        {
            var predicates = new List<Expression<Func<OrderModel, bool>>>();

            if (orderQuery.Date != null)
            {
                if (!DateOnly.TryParse(orderQuery.Date, out DateOnly date))
                    throw new ArgumentException(nameof(orderQuery.Date));

                predicates.Add(order => order.Date == date);
            }
               
            var orders = await _orderRepository.GetAllAsync(predicates.ToArray());

            return orders.Adapt<List<OrderGetDTO>>();
        }

        public async Task<bool> AddAsync(OrderPostDTO orderDTO)
        {
            var orderModel = orderDTO.Adapt<OrderModel>();
            orderModel.Date = DateOnly.FromDateTime(DateTime.Now);

            var createdId = await _orderRepository.AddAsync(orderModel);

            if (orderDTO.ProductIds != null && createdId > 0)
            {
                await _productOrderService.AddAsync(orderDTO, createdId);
                return true;
            }

            return false;
        }

        public async Task<OrderGetDTO> UpdateAsync(int Id, OrderPutDTO order)
        {
            var orderToUpdate = await _orderRepository.GetByIdAsync(Id);

            if (orderToUpdate != null)
            {
                orderToUpdate.Date = DateOnly.Parse(order.Date);
                await _orderRepository.Update(orderToUpdate);
            }

            return orderToUpdate.Adapt<OrderGetDTO>();
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var accountToDelete = await _orderRepository.GetByIdAsync(Id);
            return await _orderRepository.DeleteAsync(accountToDelete);
        }
    }
}
