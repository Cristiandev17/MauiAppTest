using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiAppTest.Core.Enums;
using MauiAppTest.Core.Extensions;
using MauiAppTest.Core.Models;
using MauiAppTest.Infrastructure.Repositories.Realm.Interfaces;
using MauiAppTest.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiAppTest.ViewModels;

public partial class ListUserViewModel : BaseViewModel
{
    private readonly IRandomUserService _randomUserService;
    private readonly IUserRepository _userRepository;

    [ObservableProperty]
    private List<UserModel>? _users;

    public ListUserViewModel()
    {
        _randomUserService = Startup.ServicesProvider.GetService<IRandomUserService>();
        _userRepository = Startup.ServicesProvider.GetService<IUserRepository>();
    }

    [ICommand]
    public async Task Appearing()
    {
        try
        {
            var users = await _randomUserService.GetUserRandomAsync("10");
            if (!users.IsNullOrEmptyList())
            {
                Users = users;
            }

            await _loadingService.Hide();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }

    [ICommand]
    public async Task SyncDataWithMongoDB()
    {
        try
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await Toast.Make("No internet connection", ToastDuration.Short).Show();
            }
            else
            {
                await Execute(AddUsersToMongoDB, "Sincronizando....");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
        }
    }

    private Task AddUsersToMongoDB()
    {
        try
        {
            var item = Users?[0];
            _userRepository.InitilizeTypeDataBase(TypeDataBase.Remote);
            var user = item.ToUserRealmObject();
            _userRepository?.AddObject(user);
            return Task.CompletedTask;
        }
        catch (System.Exception ex)
        {

            throw;
        }


    }
}
