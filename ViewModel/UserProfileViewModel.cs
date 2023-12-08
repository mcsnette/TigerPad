using System.ComponentModel.DataAnnotations;
using TigerPadG4.Data;

namespace TigerPadG4.ViewModel
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }


        [Display(Name = "Name")]
        [Required(ErrorMessage = "Username Required")]
        public string Name { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Username Required")]
        public string Username { get; set; }
        public string Bio { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Enter Program")]
        public CicsProgram CicsProgram { get; set; }
    }
}
