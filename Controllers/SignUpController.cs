using Microsoft.AspNetCore.Mvc;

namespace TigerPadG4.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserLogin()
        {
            return View("UserLogin");
        }

        public IActionResult AdminLogin()
        {
            return View("AdminLogin");
        }
    }
}