﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Videofy.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Videofy.Controllers
{
    public class AccountController : Controller
    {
        /// UserManager class contains the api's needed to manage the User in the db.
        ///     e.g. create, delete or asign a role to this user etc.
        ///     
        /// SignInManager class contains the apis for the user to 
        ///     sign-in, log-off or signup etc.
        ///     
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        // GET: Login
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        // POST: Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)    // check if modelstate is valid or not
            {
                return View(loginViewModel);
            }

            // if user DOES exists.
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return Redirect(loginViewModel.ReturnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt"); // If Sign-in is NOT successful
            }
            //  If user DOES NOT exist.
            ModelState.AddModelError("", "Username/Password not found.");
            return View(loginViewModel);
        }


        // GET: Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                /// create a new IdentityUser object, 
                /// and copy the data from the argument's model object 
                /// 
                var user = new IdentityUser() { UserName = loginViewModel.UserName };
                var result = await _userManager.CreateAsync(user, loginViewModel.Password);

                if (result.Succeeded)
                {
                    // Sign In the User
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                /// If Create is NOT successful
                ///   display ALL error message and Required criteria for validation
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);    // Error description will show
                }
            }

            return View(loginViewModel);
        }


        // POST: Logout
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
