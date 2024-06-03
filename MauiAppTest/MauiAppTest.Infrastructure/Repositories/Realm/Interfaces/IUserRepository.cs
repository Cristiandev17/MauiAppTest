using MauiAppTest.Core;
using MauiAppTest.Core.Enums;

namespace MauiAppTest.Infrastructure.Repositories.Realm.Interfaces;

public interface IUserRepository
{
    void InitilizeTypeDataBase(TypeDataBase parameter);
    
    void AddObject(UserRandomRealm obj);

    IQueryable<UserRandomRealm> GetAllObjects();

    void DeleteObject(UserRandomRealm obj);

}
