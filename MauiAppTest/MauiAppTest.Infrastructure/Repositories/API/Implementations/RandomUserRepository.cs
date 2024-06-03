
using MauiAppTest.Core;
using MauiAppTest.Core.Entities.API;
using RestSharp;
namespace MauiAppTest.Infrastructure;

public class RandomUserRepository : IRandomUserRepository
{

  public async Task<List<UserRandomApi>> GetUserRandomAsync(string countUser)
  {
    var client = new RestClient();
    var rest = await client.GetJsonAsync<RootApiResponse>($"https://randomuser.me/api/?results={countUser}");
    return rest?.Results?.ToList() ?? new List<UserRandomApi>();
  }
}
