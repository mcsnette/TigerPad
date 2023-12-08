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
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == loginInfo.Username && u.Password == loginInfo.Password);

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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
                return RedirectToAction("UserLogin", "SignUp");
            
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
                    Access = true
                  
                };


                UserProfile newProfile = new UserProfile
                {

                    Name = userEnteredData.UserName,
                    Username = userEnteredData.UserName,
                    Bio = "Welcome to my Bio!!!",
                    CicsProgram = CicsProgram.IT

                };


                if (_context.Users.Any(u => u.Username == userEnteredData.UserName))
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

                    

                _context.Users.Add(newUser); // Ensure UserProfiles matches the DbSet name in your context
                _context.Profiles.Add(newProfile);
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
