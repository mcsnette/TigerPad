using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TigerPadG4.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Display(Name = "Username")]
        public string RegUsername { get; set; }

        [Display(Name = "Password")]
        public string RegPassword { get; set; }

        [Display(Name = "Email")]
        public string RegEmail { get; set; }

        [Display(Name = "Access")]
        public bool RegAccess { get; set; }
    }
}
