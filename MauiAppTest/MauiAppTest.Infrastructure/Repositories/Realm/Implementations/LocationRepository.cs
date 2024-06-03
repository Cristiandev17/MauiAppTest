using MauiAppTest.Core.Entities.Realm;
using MauiAppTest.Core.Enums;
using MauiAppTest.Infrastructure.Repositories.Realm.Context;
using MauiAppTest.Infrastructure.Repositories.Realm.Interfaces;

namespace MauiAppTest.Infrastructure.Repositories.Realm.Implementations;

public class LocationRepository : ILocationRepository
{
    private Realms.Realm _realm;
    private readonly IDataBaseContextRealm _dataBaseContextRealm;

    public LocationRepository(IDataBaseContextRealm dataBaseContextRealm)
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

    public void AddObject(LocationRealm obj)
    {
        _realm.Write(() =>
       {
           _realm.Add(obj);
       });
    }

    public void DeleteObject(LocationRealm obj)
    {
        _realm.Write(() =>
       {
           _realm.Remove(obj);
       });
    }

    public IQueryable<LocationRealm> GetAllObjects()
    {
        return _realm.All<LocationRealm>();
    }

   
}
