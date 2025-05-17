using System.Collections.Generic;
using System.Threading.Tasks;
using UserRoleManagementApi.Models;

namespace UserRoleManagementApi.Services.Interfaces
{
   public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersWithRolesAsync();
    Task<User?> GetUserWithRolesAsync(int userId);
    Task<IEnumerable<User>> GetAllUsersWithPostsAsync();
    Task<User?> GetUserWithPostsAsync(int userId);
    Task<User> CreateUserAsync(User user);
    Task<User> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(int userId);
}

}
