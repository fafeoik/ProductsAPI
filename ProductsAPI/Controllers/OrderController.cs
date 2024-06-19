using Microsoft.AspNetCore.Mvc;
using ProductsApi.DataAccess.Models;
using ProductsApi.DTO;
using ProductsApi.Queries;
using ProductsApi.Service.Interfaces;

namespace ProductsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetAll([FromQuery] OrderQuery orderQuery)
        {
            try
            {
                var accounts = await _orderService.GetAllAsync(orderQuery);

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
        public async Task<ActionResult<OrderDTO>> GetById(int id)
        {
            try
            {
                var account = await _orderService.GetByIdAsync(id);

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
        public async Task<IActionResult> Post(OrderPostDTO model)
        {
            try
            {
                return await _orderService.AddAsync(model) ? Ok()
                : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a database failure");
            }
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<OrderDTO>> Put(int Id, OrderDateDTO model)
        {
            try
            {
                var accountToUpdate = await _orderService.UpdateAsync(Id, model);

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
                return await _orderService.DeleteAsync(Id) ? Ok()
                : NotFound($"Can't find account with Id {Id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"There was a database failure: {ex.Message}");
            }
        }
    }
}

