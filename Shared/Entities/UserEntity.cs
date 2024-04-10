using Microsoft.AspNetCore.Identity;

namespace Shared.Entities;

public class UserEntity : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? ProfileImage { get; set; } = "avatar.png";
    public string? Bio {  get; set; }
    public bool IsExternal { get; set; } = false;

    public int? AddressId { get; set; }
    public AddressEntity? Address {  get; set; }
}
