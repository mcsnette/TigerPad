using Microsoft.AspNetCore.Mvc;
using TigerPadG4.Data;
using TigerPadG4.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TigerPadG4.ViewModel;

namespace TigerPadG4.Controllers
{
    public class SignUpController : Controller
    {
        private readonly UserContext _context;

        public SignUpController(UserContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        // LOGIN
        [HttpGet]
        public IActionResult UserLogin()
        {
            return View("UserLogin");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginInfo)
        {
            var user = await _context.UserProfiles.SingleOrDefaultAsync(u => u.Username == loginInfo.Username && u.Password == loginInfo.Password);

            if (user != null)
            {
                if (user.Access == false)
                {
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("UserHomepage", "User");
                }

                else
                {
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("AdminHomepage", "Admin");
                }
                
            }
            else
            {
                ModelState.AddModelError("", "Failed to Login");
                return View("UserLogin", loginInfo);
            }
        }

        // LOGOUT
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("UserLogin");
        }

        // REGISTER
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userEnteredData)
        {
            if (ModelState.IsValid)
            {
                UserClass newUser = new UserClass
                {
                    Username = userEnteredData.UserName,
                    Email = userEnteredData.Email,
                    Password = userEnteredData.Password,
                    Access = false
                };

                _context.UserProfiles.Add(newUser); // Ensure UserProfiles matches the DbSet name in your context
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString("UserId", newUser.Id.ToString());

                return RedirectToAction("UserLogin");
            }

            return View(userEnteredData);
        }

        public IActionResult AdminLogin()
        {
            return View();  
        }
    }
}
