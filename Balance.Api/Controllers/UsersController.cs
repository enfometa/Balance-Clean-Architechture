﻿using Balance.Application.Dtos;
using Balance.Application.Services;
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
        public async Task<ActionResult<bool>> CreateRide(UserDto userDto) 
        {
            try
            {
                await _userService.RegisterAsync(userDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            return Ok(true);
        }
    }
}
