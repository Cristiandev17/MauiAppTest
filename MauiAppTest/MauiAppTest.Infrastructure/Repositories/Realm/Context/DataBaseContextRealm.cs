using MauiAppTest.Core.Enums;
using Realms.Sync;

namespace MauiAppTest.Infrastructure.Repositories.Realm.Context;

public class DataBaseContextRealm : IDataBaseContextRealm
{
    private static App app;

    public User CurrentUser { get; set; }

    public Task InitializeRealm()
    {
        var appConfiguration = new AppConfiguration("application-0-yzueedy")
        {
            BaseUri = new Uri("https://services.cloud.mongodb.com")
        };

        app = App.Create(appConfiguration);
        AssigneUser();
        return Task.CompletedTask;
    }

    public Realms.Realm GetRealm(TypeDataBase typeDataBase)
    {
        return typeDataBase switch
        {
            TypeDataBase.Local => Realms.Realm.GetInstance(),
            TypeDataBase.Remote => Realms.Realm.GetInstance(new FlexibleSyncConfiguration(CurrentUser)),
            _ => throw new NotImplementedException()
        };
    }

    public async Task RegisterAsync(string email, string password)
    {
        await app.EmailPasswordAuth.RegisterUserAsync(email, password);
    }

    public async Task LoginAsync(string email, string password)
    {
        await app.LogInAsync(Credentials.EmailPassword(email, password));
        AssigneUser();
        //This will populate the initial set of subscriptions the first time the realm is opened
        var realm = GetRealm(TypeDataBase.Remote);
        await realm.Subscriptions.WaitForSynchronizationAsync();
    }

    private void AssigneUser()
    {
        if (app.CurrentUser != null)
        {
            CurrentUser = app.CurrentUser;
        }
    }
}