using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRoleManagementApi.Models;
using UserRoleManagementApi.Services.Interfaces;

namespace UserRoleManagementApi.Controllers

{

[Route("api/roles")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost("{userId}/assign/{roleId}")]
    public async Task<ActionResult<Role>> AssignRole(int userId, int roleId)
    {
        var role = await _roleService.AssignRoleToUserAsync(userId, roleId);
        return Ok(role);
    }

    [HttpPost]
    public async Task<ActionResult<Role>> CreateRole(Role role)
    {
        var created = await _roleService.CreateRoleAsync(role);
        return CreatedAtAction(nameof(GetRole), new { roleId = created.Id }, created);
    }

    [HttpGet("{roleId}")]
    public async Task<ActionResult<Role>> GetRole(int roleId)
    {
        var role = await _roleService.GetRoleAsync(roleId);
        return role == null ? NotFound() : Ok(role);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
    {
        return Ok(await _roleService.GetAllRolesAsync());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, Role role)
    {
        if (id != role.Id) return BadRequest();
        await _roleService.UpdateRoleAsync(role);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var success = await _roleService.DeleteRoleAsync(id);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{userId}/remove/{roleId}")]
    public async Task<IActionResult> RemoveRoleFromUser(int userId, int roleId)
    {
        var success = await _roleService.RemoveRoleFromUserAsync(userId, roleId);
        return success ? NoContent() : NotFound();
    }
}

}