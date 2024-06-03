using MauiAppTest.Core;
using MauiAppTest.Core.Enums;
using MauiAppTest.Infrastructure.Repositories.Realm.Context;
using MauiAppTest.Infrastructure.Repositories.Realm.Interfaces;

namespace MauiAppTest.Infrastructure.Repositories.Realm.Implementations;

public class UserRepository : IUserRepository
{
    private Realms.Realm _realm;
    private readonly IDataBaseContextRealm _dataBaseContextRealm;

    public UserRepository(IDataBaseContextRealm dataBaseContextRealm)
    {
        this._dataBaseContextRealm = dataBaseContextRealm;
    }

    public void InitilizeTypeDataBase(TypeDataBase parameter)
    {
        switch (parameter)
        {
            case TypeDataBase.Local:
                _realm = _dataBaseContextRealm.GetRealm(TypeDataBase.Local);
                break;
            case TypeDataBase.Remote:             
                _realm = _dataBaseContextRealm.GetRealm(TypeDataBase.Remote);
                break;
        }         
    }

     public void AddObject(UserRandomRealm obj)
    {
        _realm.Write(() =>
        {
            _realm.Add(obj);
        });
    }

    // Read
    public IQueryable<UserRandomRealm> GetAllObjects()
    {
        return _realm.All<UserRandomRealm>();
    }

    // Delete
    public void DeleteObject(UserRandomRealm obj)
    {
        _realm.Write(() =>
        {
            _realm.Remove(obj);
        });
    }
}
