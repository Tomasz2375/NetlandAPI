﻿using Microsoft.AspNetCore.Mvc;
using NetlandAPI.Entity;
using NetlandAPI.Models;
using NetlandAPI.Services;

namespace NetlandAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(ICsvService csvService, 
            IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("/searchOrders")]
        public ActionResult<IEnumerable<Order>> GetOrder
            ([FromQuery] SearchPhrasesDto dto)
        {
            var orders = _orderService.GetOrder(dto);
            return Ok(orders);
        }
    }
}
