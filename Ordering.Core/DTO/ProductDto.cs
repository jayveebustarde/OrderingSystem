using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.DTO
{
    public class ProductDto: BaseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public bool IsPopular { get; set; }
    }
}
