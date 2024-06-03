using MauiAppTest.Core.Models;

namespace MauiAppTest.Services.Interfaces;

public interface IRandomUserService
{
     Task<List<UserModel>> GetUserRandomAsync(string countUser);

     Task<List<UserModel>> SetUserRandomAsync();
}
