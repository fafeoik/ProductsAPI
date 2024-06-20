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
            TypeAdapterConfig<List<OrderModel>, List<OrderGetDTO>>
                .NewConfig()
                .Map(dest => dest, src => src.Select(o => o.Adapt<OrderGetDTO>()));

            TypeAdapterConfig<OrderModel, OrderGetDTO>
            .NewConfig()
            .Map(dest => dest.Products, src => src.ProductOrders.Select(po => new ProductModel(po.Product)));

            TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());
        }
    }
}
