using Microsoft.AspNetCore.Mvc;

namespace TigerPadG4.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminProfile()
        {
            return View("AdminProfile");
        }

        public IActionResult EditAdminProfile()
        {
            return View("EditAdminProfile");
        }

        public IActionResult AdminHomepage()
        {
            return View("AdminHomepage");
        }

        public IActionResult AdminInquiries()
        {
            return View("AdminInquiries");
        }

    }
}
