using Microsoft.AspNetCore.Mvc;
using TigerPadG4.Services;

namespace TigerPadG4.Controllers
{
    public class UserController : Controller
    {
        private readonly UserProfileService _userProfileService;

        public UserController(UserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfile(int id)
        {
            var userProfile = _userProfileService.GetUserProfile(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }

        public IActionResult EditUserProfile()
        {
            return View("EditUserProfile");
        }

        public IActionResult UserHomepage()
        {
            return View("UserHomepage");
        }

        public IActionResult UserInquiries()
        {
            return View("UserInquiries");
        }

        public IActionResult UserBookmarks()
        {
            return View("UserBookmarks");
        }
    }
}
