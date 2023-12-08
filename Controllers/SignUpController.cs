using Microsoft.AspNetCore.Mvc;
using TigerPadG4.Data;
using TigerPadG4.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TigerPadG4.ViewModel;
using System.Text.RegularExpressions;

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

                if (_context.UserProfiles.Any(u => u.Username == userEnteredData.UserName))
                {
                    ModelState.AddModelError("UserName", "Username already exists. Please choose a different one.");
                    return View("Index", userEnteredData);
                }

                // Validate password requirements
                if (!IsPasswordValid(userEnteredData.Password))
                {
                    ModelState.AddModelError("Password", "Password must contain at least one uppercase letter, one lowercase letter, one digit, and have a minimum length of 8 characters.");
                    return View("Index", userEnteredData);
                }



                _context.UserProfiles.Add(newUser); // Ensure UserProfiles matches the DbSet name in your context
                await _context.SaveChangesAsync();

                


                HttpContext.Session.SetString("UserId", newUser.Id.ToString());

                return RedirectToAction("UserLogin");
            }

            return View(userEnteredData);
        }

        private bool IsPasswordValid(string password)
        {
            // Add your custom password validation logic here
            // For example, you can use regular expressions or other methods to enforce password requirements

            // Example using regular expression:
            // Requires at least one uppercase letter, one lowercase letter, one digit, and minimum length of 8 characters
            var passwordRegex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
            return passwordRegex.IsMatch(password);
        }

        public IActionResult AdminLogin()
        {
            return View();  
        }
    }
}
