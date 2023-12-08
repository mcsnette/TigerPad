// UserController.cs
using Microsoft.AspNetCore.Mvc;
using TigerPadG4.Models;
using System.Collections.Generic;

namespace LMagtakaITELEC.Controllers
{
    public class UserController : Controller
    {
        private static UserProfileModel userProfile = new UserProfileModel
        {
            Name = "John Doe",
            Username = "john_doe123",
            Bio = "Passionate about technology",
            CicsProgram = CicsProgram.IT
        };
        private static List<PostModel> _posts = new List<PostModel>(); // 

        [HttpGet]
        public IActionResult UserProfile()
        {
            return View(userProfile);
        }

        [HttpPost]
        public IActionResult SaveChanges(UserProfileModel updatedProfile)
        {
            if (ModelState.IsValid)
            {
                // Update the userProfile with the submitted data
                userProfile.Name = updatedProfile.Name;
                userProfile.Username = updatedProfile.Username;
                userProfile.Bio = updatedProfile.Bio;
                userProfile.CicsProgram = updatedProfile.CicsProgram;

                // Save changes (you may want to persist this data to a database)

                // Redirect back to the UserProfile page
                return RedirectToAction("UserProfile");
            }

            // If ModelState is not valid, return to the same UserProfile view with validation errors
            return View("UserProfile", userProfile);
        }

        public IActionResult EditUserProfile()
        {
            return View("EditUserProfile");
        }

        [HttpPost]
        public IActionResult UpdateUserProfile(UserProfileModel updatedProfile)
        {
            if (ModelState.IsValid)
            {
                // Update the userProfile with the submitted data
                userProfile.Name = updatedProfile.Name;
                userProfile.Username = updatedProfile.Username;
                userProfile.Bio = updatedProfile.Bio;
                userProfile.CicsProgram = updatedProfile.CicsProgram;

                // Save changes (you may want to persist this data to a database)

                // Redirect back to the UserProfile page
                return RedirectToAction("UserProfile");
            }

            // If ModelState is not valid, return to the same EditUserProfile view with validation errors
            return View("EditUserProfile", updatedProfile);
        }

        public IActionResult UserHomepage()
        {
            // Initialize the posts list if not already done
            if (_posts == null)
            {
                _posts = new List<PostModel>();
            }

            var posts = new List<PostModel>
    {
        new PostModel
        {
            ProfilePhoto = "~/images/profile-4.jpg",
            Name = "Makoy",
            Username = "@onyourmark",
            PostContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla varius elementum nisl? Vel ullamcorper eros auctor sed..."
        },
        // Add more posts as needed
    };

            // Add existing posts to the list
            _posts.AddRange(posts);

            return View(_posts);
        }
        [HttpPost]
        public IActionResult CreatePost(string postContent)
        {
            

            // Create a new post
            var newPost = new PostModel
            {
                Name ="Si Idol" ,
                Username= "Si Lodi",
                ProfilePhoto = "~/images/profile-3.jpg", // Replace with the actual path
                PostContent = postContent
            };

            // Add the new post to the list (replace with your actual logic to save to a database)
            _posts.Add(newPost);

            // For simplicity, let's assume success and return a status
            return Json(new { success = true });
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
