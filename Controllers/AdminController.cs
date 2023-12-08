using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TigerPadG4.Data;
using TigerPadG4.ViewModel;

namespace TigerPadG4.Controllers
{
    public class AdminController : Controller
    {
        //START HERE



        private readonly UserContext _context;

        public AdminController(UserContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AdminProfile()
        {

            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            if (currentUser != null)
            {
                return View(userProfile);
            }

            return View(_context.Profiles);

        }

        [HttpPost]
        public IActionResult SaveChanges(UserProfile updatedProfile)
        {
            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);


            if (ModelState.IsValid)
            {
                // Update the userProfile with the submitted data
                userProfile.Name = updatedProfile.Name;
                userProfile.Username = updatedProfile.Username;
                userProfile.Bio = updatedProfile.Bio;
                userProfile.CicsProgram = updatedProfile.CicsProgram;

                // Save changes (you may want to persist this data to a database)
                _context.SaveChanges();
                // Redirect back to the UserProfile page
                return RedirectToAction("AdminProfile");
            }

            _context.SaveChanges();
            // If ModelState is not valid, return to the same UserProfile view with validation errors
            return View("UserProfile", userProfile);
        }

        public IActionResult EditAdminProfile()
        {

            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            return View("EditAdminProfile", userProfile);
       
        }

        public IActionResult AdminHomepage()
        {

            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            QOTD qotd = _context.qotd.OrderByDescending(q => q.Id).FirstOrDefault();

            var userPosts = _context.Posts;

            var viewModel = new UserHomepageViewModel
            {
                UserPosts = userPosts,
                UserProfile = userProfile,
                QOTD = qotd
            };

            return View(viewModel);


        }

        public IActionResult AdminInquiries()
        {
            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            QOTD qotd = _context.qotd.OrderByDescending(q => q.Id).FirstOrDefault();

            var userPosts = _context.Posts;

            var viewModel = new UserHomepageViewModel
            {
                UserPosts = userPosts,
                UserProfile = userProfile,
                QOTD = qotd
            };

            return View(viewModel);


        }

        [HttpGet]
        public IActionResult qotd()
        {
            return View(_context.qotd);
        }

        [HttpPost]
        public IActionResult qotd(String str)
        {
            QOTD qotd = new QOTD()
            {
                QuoteOftheDay = str
            };

            _context.qotd.Add(qotd);
            _context.SaveChanges();

            return Json(new { success = true });
        }


        [HttpPost]
        public IActionResult DeletePost(int postId)
        {
            // Retrieve the post from the database
            var postToDelete = _context.Posts.Find(postId);

            if (postToDelete != null)
            {
                // Remove the post and save changes
                _context.Posts.Remove(postToDelete);
                _context.SaveChanges();
                return Json(new { success = true });
            }

            // If postToDelete is null, return an error
            return Json(new { success = false, error = "Post not found." });
        }
    }
}
