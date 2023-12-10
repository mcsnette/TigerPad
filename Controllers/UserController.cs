// UserController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TigerPadG4.Data;
using TigerPadG4.Models;
using TigerPadG4.ViewModel;
using System.Collections.Generic;

namespace TigerPadG4.Controllers
{
    public class UserController : Controller
    {
        //START HERE


        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
  

        [HttpGet]
        public IActionResult UserProfile()
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
                if (userProfile.Username == updatedProfile.Username)
                {
                    // Redirect back to the UserProfile page
                    return RedirectToAction("UserProfile");
                }


                // Update the userProfile with the submitted data
                userProfile.Name = updatedProfile.Name;
                userProfile.Username = updatedProfile.Username;
                userProfile.Bio = updatedProfile.Bio;
                userProfile.CicsProgram = updatedProfile.CicsProgram;

                if(_context.Users.Any(u => u.Username == userProfile.Username) )
                {
                   

                    ModelState.AddModelError("UserName", "Username already exists. Please choose a different one.");
                    return View("EditUserProfile", userProfile);
                }


                currentUser.Username = updatedProfile.Username;

                // Save changes (you may want to persist this data to a database)
                _context.SaveChanges();
                // Redirect back to the UserProfile page
                return RedirectToAction("UserProfile");
            }

            _context.SaveChanges();
            // If ModelState is not valid, return to the same UserProfile view with validation errors
            return View("UserProfile", userProfile);
        }

        public IActionResult EditUserProfile()
        {
            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            return View("EditUserProfile", userProfile);
        }


        public IActionResult UserHomepage()
        {
            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            var userPosts = _context.Posts;

            QOTD qotd = _context.qotd.OrderByDescending(q => q.Id).FirstOrDefault();



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


        public IActionResult UserInquiries()
        {

            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            var userPosts = _context.Posts;

            QOTD qotd = _context.qotd.OrderByDescending(q => q.Id).FirstOrDefault();

            var viewModel = new UserHomepageViewModel
            {
                UserPosts = userPosts,
                UserProfile = userProfile,
                QOTD = qotd
            };

            return View(viewModel);

        
        }


        [HttpPost]
        public IActionResult CreatePost(string postContent)
        {
            string userId = HttpContext.Session.GetString("UserId");
            UserClass currentUser = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            UserProfile userProfile = _context.Profiles.FirstOrDefault(profile => profile.Id == currentUser.Id);

            // Create a new post
            var newPost = new UserPosts
            {
                Name = userProfile.Name,
                Username = userProfile.Username,
                /*ProfilePhoto = "~/images/profile-3.jpg", // Replace with the actual path*/
                PostContent = postContent,
                IsInquiry = false
                
            };

            // Add the new post to the list (replace with your actual logic to save to a database)
            _context.Posts.Add(newPost);
            _context.SaveChangesAsync();

            // For simplicity, let's assume success and return a status
            return Json(new { success = true });
        }





    }
}
