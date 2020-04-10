using Ordering.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Interface
{
    public interface IBaseService<T>  where T : BaseDto
    {
        void Create(T dto);
        T Update(T dto);
        T Get(int id);
    }
}
