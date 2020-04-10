using Ordering.Core.DTO;
using Ordering.Core.Interface;
using Ordering.DataContext.Context;
using Ordering.DataContext.Entities;
using System;
using System.Linq;

namespace Ordering.Services.Services
{
    public class OrderService : IOrderService
    {
        private OrderingContext _context;
        public void Create(OrderDto dto)
        {
            using (_context = new OrderingContext())
            {
                //count existing orders for the particular product
                //Todo: make call async
                int productOrderCount = _context.Orders.Where(x => x.ProductId == dto.ProductId).Count();

                _context.Orders.Add(new Order { ProductId = dto.ProductId, UserId = dto.UserId });

                if(productOrderCount > 4)
                {
                    Product popular = _context.Products.Where(x => x.Id == dto.ProductId).FirstOrDefault();
                    popular.IsPopular = true;
                }

                _context.SaveChanges();
            }
        }

        public OrderDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDto Update(OrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
