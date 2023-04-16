using Balance.Api.Attributes;
using Balance.Api.Helpers;
using Balance.Application.Dtos;
using Balance.Application.Services;
using Balance.Core.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Balance.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : AppBaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public int UserId { get { return (int)UserAuthHelper.GetUserId(HttpContext); } }

        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("Signup")]
        [ServiceFilter(typeof(RequestLoggerFilterAttribute))]
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

        [HttpPost("Authenticate")]
        [ServiceFilter(typeof(RequestLoggerFilterAttribute))]
        public async Task<ActionResult<bool>> Authenticate(UserCredentialsDto userCredentialsDto)
        {
            AuthTokenDto token = null;
            try
            {
                var user = await _userService.AuthenticateAsync(userCredentialsDto.Username, userCredentialsDto.Password);
                if (user != null)
                {
                    token = await _authService.GetToken(user);
                }
            }
            catch (InvalidCredentailsException ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(token);
        }

        [HttpGet("auth/balance")]
        [Authorize]
        public async Task<ActionResult<bool>> Balance()
        {
            var user = await _userService.GetUser(UserId);


            return Ok(new { user.Balance });
        }
    }
}
