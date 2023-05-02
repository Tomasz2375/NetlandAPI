using Microsoft.AspNetCore.Mvc;
using NetlandAPI.Entity;
using NetlandAPI.Services;

namespace NetlandAPI.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(ICsvService csvService, IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrder()
        {
            var orders = _orderService.GetOrder();
            return Ok(orders);

        }
    }
}
