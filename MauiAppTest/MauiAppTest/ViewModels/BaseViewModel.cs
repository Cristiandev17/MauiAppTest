using System.Reflection.Metadata.Ecma335;
using MauiAppTest.Infrastructure.Repositories.Realm.Context;
using MauiAppTest.Services.Interfaces;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace MauiAppTest.ViewModels;

public class BaseViewModel : ObservableObject
{
    public ILoadingService _loadingService { get; set; }
    public IDataBaseContextRealm _dataBaseContextRealm { get; set; }

    public BaseViewModel()
    {
        _loadingService = Startup.ServicesProvider.GetService<ILoadingService>();
        _dataBaseContextRealm = Startup.ServicesProvider.GetService<IDataBaseContextRealm>();
    }

    public async Task Execute(Func<Task> action, string  message = "")
    {
        if (string.IsNullOrEmpty(message))
        {
            await _loadingService.Show();
        }
        else
        {
            await _loadingService.Show(message);
        }
        
        await action(); // Pass the Task object as an argument
        await _loadingService.Hide();
    }
}
