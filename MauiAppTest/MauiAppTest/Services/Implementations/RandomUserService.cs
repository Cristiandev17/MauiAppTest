

using MauiAppTest.Core.Enums;
using MauiAppTest.Core.Extensions;
using MauiAppTest.Core.Mappers;
using MauiAppTest.Core.Models;
using MauiAppTest.Infrastructure;
using MauiAppTest.Infrastructure.Repositories.Realm.Interfaces;
using MauiAppTest.Services.Interfaces;

namespace MauiAppTest.Services.Implementations;

public class RandomUserService : IRandomUserService
{
  private readonly IRandomUserRepository _randomUserRepository;
  private readonly IUserRepository _userRepository;
  private readonly ILocationRepository _locationRepository;

  public RandomUserService(IRandomUserRepository randomUserRepository, IUserRepository userRepository, ILocationRepository locationRepository)
  {
    _randomUserRepository = randomUserRepository;
    _userRepository = userRepository;
    _locationRepository = locationRepository;
  }

  public async Task<List<UserModel>> GetUserRandomAsync(string countUser)
  {
    try
    {
      var users = await _randomUserRepository.GetUserRandomAsync(countUser);

    if (!users.Any())
    {
      return new List<UserModel>();
    }

    foreach (var item in users)
    {
      var userRealm = item.ToUserRealmObject();
      if (userRealm != null)
      {
        _userRepository.InitilizeTypeDataBase(TypeDataBase.Local);
        _userRepository.AddObject(userRealm);
      }

      if (item.Location != null)
      {
        var locationRealm = item.Location.ToLocationRealmObject();
        if (locationRealm != null)
        {
          _locationRepository.InitilizeTypeDataBase(TypeDataBase.Local);
          _locationRepository.AddObject(locationRealm);
        }
      }
    }

    return await SetUserRandomAsync();
    }
    catch (System.Exception ex)
    {
      return new List<UserModel>();      
    }
    
    
  }

  public Task<List<UserModel>> SetUserRandomAsync()
  {
    var userslocal = _userRepository.GetAllObjects();
    return UserRandomMapper.MapListUserModel(userslocal.ToList());
  }
}
