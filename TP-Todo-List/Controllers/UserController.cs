using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Todo_List.Data.Entities;
using TP_Todo_List.Data.Models;
using TP_Todo_List.Services.Interfaces;

namespace TP_Todo_List.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Address = userDto.Address
            };

            // Llama al método del servicio para crear el usuario
            int userId = _userService.CreateUser(user);

            // Retorna el UserId generado por la base de datos
            return Ok(userId);
        }


        [HttpGet("GetUsers")]

        public IActionResult GetAllUsers()
        {
            var res = _userService.GetAll();
            return Ok(res);
        }

        [HttpPut("UpdateUser/{UserId}")]
        public IActionResult UpdateUser([FromRoute] int UserId, [FromBody] UserDto userDto)
        {
            int updateUserId = _userService.UpdateUser(UserId, userDto);

            if (updateUserId == 0)
            {
                return NotFound($"Usuario con Id {UserId} no encontrado");
            }
            return Ok(updateUserId);
        }


        [HttpDelete("DeleteUser/{userId}")]
        public IActionResult DeleteUser([FromRoute] int userId)
        {
            _userService.DeleteUser(userId);
            return Ok();
        }
    }
}
