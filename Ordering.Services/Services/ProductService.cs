using System;
using System.Collections.Generic;
using System.Linq;
using Ordering.Core.DTO;
using Ordering.Core.Interface;
using Ordering.DataContext.Context;
using Ordering.DataContext.Entities;

namespace Ordering.Services.Services
{
    public class ProductService : IProductService
    {
        private OrderingContext _context;
        public void Create(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        public ProductDto Get(int id)
        {
            ProductDto dto = null;
            using (_context = new OrderingContext())
            {
                Product entity = _context.Products.Where(x => x.Id == id).FirstOrDefault();
                if(entity != null)
                {
                    dto = MapEntityToDto(entity);
                }
            }
            return dto;
        }

        public List<ProductDto> Get()
        {
            List<ProductDto> data = new List<ProductDto>();
            using (_context = new OrderingContext())
            {
                List<Product> entities = _context.Products.ToList();
                if(entities != null)
                {
                    foreach (Product item in entities)
                    {
                        data.Add(MapEntityToDto(item));
                    }
                }
            }
            return data;
        }

        public ProductDto Update(ProductDto dto)
        {
            throw new NotImplementedException();
        }

        private ProductDto MapEntityToDto(Product entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                IsPopular = entity.IsPopular,
                Name = entity.Name,
                Price = entity.Price
            };
        }
    }
}
