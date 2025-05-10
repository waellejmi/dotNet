using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRoleManagementApi.Models;
using UserRoleManagementApi.Services.Interfaces;

namespace UserRoleManagementApi.Controllers
{
[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersWithRoles()
        {
            return Ok(await _userService.GetAllUsersWithRolesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserWithRoles(int id)
        {
            var user = await _userService.GetUserWithRolesAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpGet("with-posts")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsersWithPosts()
        {
            return Ok(await _userService.GetAllUsersWithPostsAsync());
        }

        [HttpGet("{id}/with-posts")]
        public async Task<ActionResult<User>> GetUserWithPosts(int id)
        {
            var user = await _userService.GetUserWithPostsAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            var created = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserWithRoles), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            await _userService.UpdateUserAsync(user);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            return success ? NoContent() : NotFound();
        }
    }

}
