using Ordering.Core.DTO;
using Ordering.Core.Interface;
using Ordering.Services.Services;
using System;
using System.Net;
using System.Web.Http;

namespace Ordering.Web.ApiControllers
{
    public class UserController : ApiController
    {
        readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("api/user/{email}")]
        public IHttpActionResult Get([FromUri]string email)
        {
            UserDto user;
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return Content(HttpStatusCode.BadRequest, "Please provide valid email.");
                }
                user = _userService.GetByEmail(email);
                if(user == null || user.Id <= 0)
                {
                    return Content(HttpStatusCode.NotFound, "User not found.");
                }
            }
            catch (Exception ex)
            {
                //log error
                return InternalServerError();
            }
            return Ok(user);
        }

    }
}
