using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiAppTest.Pages;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace MauiAppTest.ViewModels;

public partial class EntryUserViewModel : BaseViewModel
{
    [ObservableProperty]
    private string? _themeSelected;

    [ObservableProperty]
    private bool _isTheme;

    [ObservableProperty]
    private string? _userName;

    public EntryUserViewModel()
    {
        ThemeSelected = "Light";
    }

    [ICommand]
    public void ChangeTheme()
    {
        if (App.Current == null) return;

        if (IsTheme)
        {

            App.Current.UserAppTheme = AppTheme.Dark!;
            ThemeSelected = "Dark";
        }
        else
        {
            App.Current.UserAppTheme = AppTheme.Light!;
            ThemeSelected = "Light";
        }
    }

    [ICommand]
    public async Task Appearing()
    {
        await Execute(_dataBaseContextRealm.InitializeRealm);

        if (_dataBaseContextRealm.CurrentUser != null)
        {
            NavigateInitial();
        }
    }

    [ICommand]
    public async void Enter()
    {
        if (string.IsNullOrEmpty(UserName))
        {
            CancellationTokenSource cancellationTokenSource = new();
            await Toast.Make("Please enter a user name", ToastDuration.Short).Show(cancellationTokenSource.Token);
            return;
        }

        await _loadingService.Show();
        await LoginMongoService();
        NavigateInitial();

    }

    private void NavigateInitial()
    {
        if (App.Current == null) return;

        App.Current.MainPage = new AppShell();
    }

    public async Task LoginMongoService()
    {
        if (_dataBaseContextRealm.CurrentUser == null)
        {
            await _dataBaseContextRealm.RegisterAsync($"{UserName}@example.com", "123456");
        }

        await _dataBaseContextRealm.LoginAsync($"{UserName}@example.com", "123456");
    }
}

