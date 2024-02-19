using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class AppUser
    {
        public string UserName { get; set;}
        public string Password { get; set;}
        public string Email { get; set;}
    }
}
