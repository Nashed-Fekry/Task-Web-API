using Microsoft.AspNetCore.Mvc;
using Task.Core.DTO;
using Task.Core.Interfaces;
using Task.Core.Model;

namespace Task.Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder(OrderDTO orderDTO)
        {
            var addedOrder = await _orderService.AddOrderAsync(orderDTO);
            return CreatedAtAction(nameof(GetOrderById), new { id = addedOrder.Id }, addedOrder);
        }




    }
}
