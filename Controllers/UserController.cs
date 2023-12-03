using Microsoft.AspNetCore.Mvc;


namespace TigerPadG4.Controllers
{
    public class UserController : Controller
    {
        

        public IActionResult UserProfile()
        {
            return View("UserProfile");
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
