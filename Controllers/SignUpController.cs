using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TigerPadG4.Data;
using TigerPadG4.ViewModel;

namespace TigerPadG4.Controllers
{
    public class SignUpController : Controller
    {


            private readonly SignInManager<UserClass> _signInManager;
            private readonly UserManager<UserClass> _userManager;


            public SignUpController(SignInManager<UserClass> signInManager, UserManager<UserClass> userManager)
            {
                _signInManager = signInManager;
                _userManager = userManager;
            }


         public IActionResult Index()
            {
                return View();
            }


            //LOGIN

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View("UserLogin");
        }

        [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel loginInfo)

            
            {

            UserClass newUser = new();

                var result = await _signInManager.PasswordSignInAsync(loginInfo.Email,
                                                                      loginInfo.Password,
                                                                      false,
                                                                      false);
                if (result.Succeeded)
                {
                    if (newUser.Access == true)
                        {
                         return RedirectToAction("Index", "User");
                }

                    else if (newUser.Access == false)
                {
                    return RedirectToAction("Index", "Admin");
                }
                   
                }
                else
                {
                    ModelState.AddModelError("", "Failed to Login");
                }

                return View("Index", loginInfo);
            }

        //LOGOUT
        public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "SignUp");
            }




         //REGISTER
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
                UserClass newUser = new()
                {
                    UserName = userEnteredData.UserName,
                    Email = userEnteredData.Email,
                    Access = false
                };

                    var result = await _userManager.CreateAsync(newUser, userEnteredData.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("UserLogin", "SignUp" );
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }


                }

                return View(userEnteredData);
            }


        public IActionResult AdminLogin()
        {
            return View();
        }
        }

        




    }
