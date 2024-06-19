using Microsoft.EntityFrameworkCore;
using ProductsApi.DataAccess;
using ProductsApi.MappingConfigurations;
using ProductsApi.Repository;
using ProductsApi.Repository.Implementation;
using ProductsApi.Service;
using ProductsApi.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.RegisterMapsterConfiguration();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{ options.UseSqlite(builder.Configuration.GetConnectionString("ShopRepo"), b => b.MigrationsAssembly("ProductsAPI.DataAccess")); });

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductOrderRepository, ProductOrderRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductOrderService, ProductOrderService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
