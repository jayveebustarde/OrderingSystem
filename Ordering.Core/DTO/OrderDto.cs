using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.DTO
{
    public class OrderDto : BaseDto
    {
        public int ProductId { get; set; }
        public int UserId { get; set; }

        public UserDto User { get; set; }
        public ProductDto Product { get; set; }
    }
}
