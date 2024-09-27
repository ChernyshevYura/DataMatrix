using DataMatrix.Models;
using DataMatrix.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace DataMatrix.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType<UserEntity>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetUsers(int page = 1, int pageSize = 30)
        {
            var users = await _userService.GetUsers(page, pageSize);
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType<UserEntity>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPut]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType<UserEntity>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        public async Task<IActionResult> UpdateUser(UserPayload userPayload)
        {
            var user = await _userService.UpdateUser(userPayload);
            return Ok(user);
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType<UserEntity>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        public async Task<IActionResult> CreateUser(UserPayload userPayload)
        {
            var user = await _userService.CreateUser(userPayload);
            return Ok(user);
        }

        [HttpDelete]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType<UserEntity>(StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUser(id);
            return Ok(user);
        }
    }
}
