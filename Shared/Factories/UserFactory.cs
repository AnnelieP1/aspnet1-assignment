using Shared.Entities;
using Shared.Models;
using System.Diagnostics;

namespace Shared.Factories;

public class UserFactory
{
    public static User Create(UserEntity entity)
    {
        try
        {
            return new User
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email!,
                ProfileImage = entity.ProfileImage,
                PhoneNumber = entity.PhoneNumber,
                Bio = entity.Bio,
                IsExternal = entity.IsExternal,

                AddressLine_1 = entity.Address?.AddressLine_1,
                AddressLine_2 = entity.Address?.AddressLine_2,
                PostalCode = entity.Address?.PostalCode,
                City = entity.Address?.City,
            };
        }
        catch (Exception ex) {  Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static UserEntity Create(string firstName, string lastName, string email)
    {
        try
        {
            return new UserEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email
            };
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public static IEnumerable<User> Create(List<UserEntity> list) 
    {
        var users = new List<User>();

        try
        {
            foreach (var user in list)
                users.Add(Create(user));
        }
        catch { }
        return users;
    
    
    }

}
