using Microsoft.AspNetCore.Mvc;
using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsApi.Service.Interfaces;

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
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            try
            {
                var accounts = await _productService.GetAll();

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
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

        [HttpGet("searchname")]
        public async Task<ActionResult<List<ProductDTO>>> SearchByName(string name)
        {
            try
            {
                var accounts = await _productService.GetAllByNameAsync(name);

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpGet("price")]
        public async Task<ActionResult<List<ProductDTO>>> SearchAbovePrice(int price)
        {
            try
            {
                var accounts = await _productService.GetAllAbovePriceAsync(price);

                return !accounts.Any()
                ? NotFound()
                : Ok(accounts);
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

        [HttpPut("{Id}")]
        public async Task<ActionResult<ProductDTO>> Put(int Id, ProductUpdateDTO product)
        {
            try
            {
                var accountToUpdate = await _productService.UpdateAsync(Id, product);

                if (accountToUpdate != null)
                {
                    return accountToUpdate;
                }
                else
                {
                    return NotFound($"Can't find account with Id {Id}");
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

