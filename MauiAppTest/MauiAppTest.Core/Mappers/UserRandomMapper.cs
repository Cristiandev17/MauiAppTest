
using MauiAppTest.Core.Models;

namespace MauiAppTest.Core.Mappers;

public class UserRandomMapper
{
    public static Task<List<UserModel>> MapListUserModel(List<UserRandomRealm> userslocal)
    {
        List<UserModel> users = new();
        foreach (var item in userslocal)
        {
            users.Add(new UserModel
            {
                Cell = item.Cell,
                Email = item.Email,
                Gender = item.Gender,
                Nat = item.Nat,
                Id = item.Id.ToString(),
                Name = item.Name,
                LastName = item.LastName                  
            });
        }

        return Task.FromResult(users);
    }
}
