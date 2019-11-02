using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Videofy.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Videofy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        /// AccountController Constructor.
        ///     Let's use the built-in UserManager service class IdentityUser.
        ///     This will handle the user authentication.
        /// *** we can use our custom model/class(Custom authentication properties) for UserManager to use,
        ///     but we can do that later. For now we use the built-in class - IdenttiyUser
        ///     
        public AccountController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        // Logout POST
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");   // Action, Controller
        }


        // Register GET: /<controller>/
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        // Register POST: /<controller>/
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) // check model object is valid
            {
                /// create a new IdentityUser object, 
                /// and copy the data (email and password) from the argument model object 
                /// 
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);   // Creates the new IdentityUser with the model data

                // Check if user was Created successfully
                if (result.Succeeded)
                {
                    // Sign In the User
                    await signInManager.SignInAsync(user, isPersistent: false);

                    // Redirect after Sign In
                    return RedirectToAction("Index", "Home");   // back to landing page
                }

                // If Create is NOT successful
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);    // Error description will show
                }
            }

            return View(model); // if NOT valid, Rerender register view and display the errors
        }


        // Login GET: /<controller>/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login POST: /<controller>/
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid) // check model object is valid
            {
                // SignIn With email and password
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);

                // Check if user was Created successfully
                if (result.Succeeded)
                {
                    // Redirect after Sign-In
                    return RedirectToAction("Index", "Home");   // back to landing page
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt"); // If Sign-in is NOT successful
            }

            return View(model); // if NOT valid, Rerender register view and display the errors
        }
    }
}
