
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserRoleManagementApi.Data;
using UserRoleManagementApi.Models;
using UserRoleManagementApi.Services.Interfaces;

namespace UserRoleManagementApi.Services.Implementations
{
    public class PostService : IPostService
    {
        public Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post?> GetPostByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> CreatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<Post> UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePostAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
