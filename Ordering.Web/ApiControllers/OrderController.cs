using Ordering.Core.DTO;
using Ordering.Core.Interface;
using Ordering.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ordering.Web.ApiControllers
{
    public class OrderController : ApiController
    {
        readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IHttpActionResult Create(OrderDto input)
        {
            try
            {
                if(input == null || input.ProductId <= 0 || input.UserId <= 0)
                {
                    return BadRequest();
                }

                _orderService.Create(input);
            }
            catch (Exception ex)
            {
                //log error
                return InternalServerError();
            }
            return Ok();
        }
    }
}
