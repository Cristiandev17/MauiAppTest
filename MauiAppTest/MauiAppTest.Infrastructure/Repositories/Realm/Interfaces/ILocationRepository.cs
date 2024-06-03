using MauiAppTest.Core.Entities.Realm;
using MauiAppTest.Core.Enums;

namespace MauiAppTest.Infrastructure.Repositories.Realm.Interfaces;

public interface ILocationRepository
{
  void InitilizeTypeDataBase(TypeDataBase parameter);

  void AddObject(LocationRealm obj);

  IQueryable<LocationRealm> GetAllObjects();

  void DeleteObject(LocationRealm obj);
}
