using MauiAppTest.Core.Entities.API;

namespace MauiAppTest.Infrastructure;

public interface IRandomUserRepository
{
  Task<List<UserRandomApi>> GetUserRandomAsync(string countUser);
}
