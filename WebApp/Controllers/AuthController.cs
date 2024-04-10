using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Factories;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;

    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }


    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (!await _userManager.Users.AnyAsync(x => x.Email == model.Email))
            {
                var userEntity = UserFactory.Create(model.FirstName, model.LastName, model.Email);

                var result = await _userManager.CreateAsync(userEntity, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Auth");
                }
                else
                {
                    ViewData["StatusMessage"] = "Something went wrong! Please try again.";
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User with the same email address already exists.";
            }

        }

        return View(model);
    }


    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/"; 
        return View();
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel model, string returnUrl)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return LocalRedirect(returnUrl);
                }
            }
        }
        ViewData["StatusMessage"] = "Incorrect email or password";
        ViewData["ReturnUrl"] = returnUrl;

        return View(model);
    }


    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }
}
