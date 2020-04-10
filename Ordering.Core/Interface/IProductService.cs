using Ordering.Core.DTO;
using System.Collections.Generic;

namespace Ordering.Core.Interface
{
    public interface IProductService : IBaseService<ProductDto>
    {
        List<ProductDto> Get();
    }
}
