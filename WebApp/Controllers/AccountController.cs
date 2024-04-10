using Infrastructure.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers;

public class AccountController(AccountService accountService) : Controller
{
    private readonly AccountService _accountService = accountService;

    public IActionResult Details()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UpdateBasicInfo(AccountDetailsViewModel viewModel)
    {
        if (TryValidateModel(viewModel.BasicInfo!))
        {
            // uppdatera användaren och uppdatera databasen

            return RedirectToAction("Details");
        }
        else
        {
            return View("Details", viewModel);
        }

    }

    [HttpPost]
    public IActionResult UpdateAddressInfo(AccountDetailsViewModel viewModel)
    {
        if (TryValidateModel(viewModel.AddressInfo!))
        {
            // uppdatera användarens adress och uppdatera databasen

            return RedirectToAction("Details");
        }
        else
        {
            return View("Details", viewModel);
        }

    }




    [HttpPost]
    public async Task<IActionResult> ProfileImageUpload(IFormFile file)
    {
        var result = await _accountService.UploadUserProfileImageAsync(User, file);
        return RedirectToAction("Details", "Account");
    }
}
