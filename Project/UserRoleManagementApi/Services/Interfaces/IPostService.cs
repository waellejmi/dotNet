

using System.Collections.Generic;
using System.Threading.Tasks;
using UserRoleManagementApi.Models;
namespace UserRoleManagementApi.Services.Interfaces

{
    public interface IPostService
    {
        // Define your methods here, for example:
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post?> GetPostByIdAsync(int id);
        Task<Post> CreatePostAsync(Post post);
        Task<Post> UpdatePostAsync(Post post);
        Task<bool> DeletePostAsync(int id);
    }
}
