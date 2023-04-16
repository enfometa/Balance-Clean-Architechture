using Balance.Application.Dtos;
using Balance.Application.Services;
using Balance.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Balance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : AppBaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Signup")]
        public async Task<ActionResult<bool>> Signup(UserDto userDto) 
        {
            try
            {
                await _userService.RegisterAsync(userDto);
            }
            catch (UserAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            

            return Ok(true);
        }
    }
}
