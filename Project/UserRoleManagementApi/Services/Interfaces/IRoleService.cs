using System.Collections.Generic;
using System.Threading.Tasks;
using UserRoleManagementApi.Models;

namespace UserRoleManagementApi.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Role> AssignRoleToUserAsync(int userId, int roleId);
        Task<Role> CreateRoleAsync(Role role);
        Task<Role?> GetRoleAsync(int roleId);
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(int roleId);
        Task<bool> RemoveRoleFromUserAsync(int userId, int roleId);
    }
}