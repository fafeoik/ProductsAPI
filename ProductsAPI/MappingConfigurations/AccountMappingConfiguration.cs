using Mapster;
using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ProductsApi.MappingConfigurations
{
    public static class AccountMappingConfiguration
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<List<ProductModel>, List<ProductDTO>>
                .NewConfig()
                .Map(dest => dest, src => src.Select(p => p.Adapt<ProductDTO>()));

            TypeAdapterConfig<List<OrderModel>, List<OrderDTO>>
                .NewConfig()
                .Map(dest => dest, src => src.Select(o => o.Adapt<OrderDTO>()));

            TypeAdapterConfig<ProductModel, ProductDTO>
            .NewConfig()
            .Map(dest => dest.Orders, src => src.ProductOrders.Select(po => new OrderModel(po.Order)));

            TypeAdapterConfig<OrderModel, OrderDTO>
            .NewConfig()
            .Map(dest => dest.Products, src => src.ProductOrders.Select(po => new ProductModel(po.Product)));

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
