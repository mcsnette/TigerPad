// UserController.cs
using Microsoft.AspNetCore.Mvc;
using TigerPadG4.Models;

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
