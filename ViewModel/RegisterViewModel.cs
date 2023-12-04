using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TigerPadG4.ViewModel
{
    public class RegisterViewModel 
    {
        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Username Required")]
        public string? UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Username Required")]
        public string? Password { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Username Required")]
        public string? Email { get; set; }
    }
}
