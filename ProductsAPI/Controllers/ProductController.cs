using Microsoft.AspNetCore.Mvc;
using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsApi.Service.Interfaces;
using ProductsAPI.Queries;

namespace ProductsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        private IOrderService _orderService;

        public ProductController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductGetDTO>>> GetAll([FromQuery] ProductQuery productQuery)
        {
            try
            {
                var accounts = await _productService.GetAllAsync(productQuery);

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetDTO>> GetProductById(int id)
        {
            try
            {
                var account = await _productService.GetByIdAsync(id);

                return account == null
                ? NotFound()
                : Ok(account);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductOrderlessDTO product)
        {
            try
            {
                return await _productService.AddAsync(product) ? Ok()
                : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductUpdateDTO>> Put(int id, ProductUpdateDTO product)
        {
            try
            {
                var accountToUpdate = await _productService.UpdateAsync(id, product);

                if (accountToUpdate != null)
                {
                    return accountToUpdate;
                }
                else
                {
                    return NotFound($"Can't find account with Id {id}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was a database failure: {ex.Message}");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                return await _productService.DeleteAsync(Id) ? Ok()
                : NotFound($"Can't find account with Id {Id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was a database failure: {ex.Message}");
            }
        }
    }
}

