using MauiAppTest.Core.Enums;
using Realms.Sync;

namespace MauiAppTest.Infrastructure.Repositories.Realm.Context;

public interface IDataBaseContextRealm
{
  User CurrentUser { get; set; }

  Task InitializeRealm();

  Realms.Realm GetRealm(TypeDataBase typeDataBase);

  Task RegisterAsync(string email, string password);

  Task LoginAsync(string email, string password);  
}
