using Ordering.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Core.Interface
{
    public interface IUserService : IBaseService<UserDto>
    {
        UserDto GetByEmail(string email);
    }
}
