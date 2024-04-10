using Infrastructure.WebApp.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Entities;
using System.Security.Claims;

namespace Infrastructure.WebApp.Services;

public class AccountService(UserManager<UserEntity> userManager, IConfiguration configuration, ApplicationContext context)
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly ApplicationContext _context = context;

    public async Task<bool> UploadUserProfileImageAsync(ClaimsPrincipal userClaims, IFormFile file)
    {
        try
        {
            if (userClaims != null && file != null && file.Length != 0)
            {
                var user = await _userManager.GetUserAsync(userClaims);
                if (user != null)
                {
                    var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FilePath:ProfileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    user.ProfileImage = fileName;
                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    return true;
                }
            };
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        return false;

    }
}
