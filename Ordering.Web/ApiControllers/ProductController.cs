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
    public class ProductController : ApiController
    {

        readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<ProductDto> products;
            try
            {
                products = _productService.Get();

                if(products == null)
                {
                    return Content(HttpStatusCode.NotFound, "Products not found.");
                }
            }
            catch (Exception e)
            {
                //implement error logger
                return InternalServerError();
            }
            return Ok(products);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ProductDto product;
            try
            {
                product = _productService.Get(id);

                if (product == null)
                {
                    return Content(HttpStatusCode.NotFound, "Product not found.");
                }
            }
            catch (Exception e)
            {
                //implement error logger
                return InternalServerError();
            }
            return Ok(product);

        }
    }
}
