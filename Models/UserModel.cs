using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TigerPadG4.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }
    }
}
