using System.Collections.Generic;

namespace UserRoleManagementApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
