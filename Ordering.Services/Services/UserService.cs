using System;
using System.Linq;
using Ordering.Core.DTO;
using Ordering.Core.Interface;
using Ordering.DataContext.Context;
using Ordering.DataContext.Entities;

namespace Ordering.Services.Services
{
    public class UserService : IUserService
    {
        private OrderingContext _context;
        public void Create(UserDto dto)
        {
            throw new NotImplementedException();
        }

        public UserDto Get(int id)
        {
            UserDto dto = null;
            using (_context = new OrderingContext())
            {
                User entity = _context.Users.Where(x => x.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    dto = MapEntityToDto(entity);
                }
            }
            return dto;
        }

        public UserDto GetByEmail(string email)
        {
            UserDto dto = null;
            using (_context = new OrderingContext())
            {
                User entity = _context.Users.Where(x => x.Email == email).FirstOrDefault();
                if (entity != null)
                {
                    dto = MapEntityToDto(entity);
                }
            }
            return dto;
        }

        public UserDto Update(UserDto dto)
        {
            throw new NotImplementedException();
        }

        private UserDto MapEntityToDto(User entity)
        {
            return new UserDto
            {
                Id = entity.Id,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Password = entity.Password,
                Role = entity.Role
            };
        }
    }
}
