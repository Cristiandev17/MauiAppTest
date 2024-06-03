using MauiAppTest.Core.Entities.API;
using MauiAppTest.Core.Entities.Realm;
using MauiAppTest.Core.Models;
using MongoDB.Bson;

namespace MauiAppTest.Core.Extensions;

public static class RealmEntityExtension
{
    public static UserRandomRealm? ToUserRealmObject<T>(this T parameter)
    {   
        if (parameter is UserModel usermodel)
        {
            return new UserRandomRealm
            {
                Id = ObjectId.Parse(usermodel.Id),
                Cell = usermodel.Cell,
                Email = usermodel.Email,
                Gender = usermodel.Gender,               
                Nat = usermodel.Nat,
                LastName = usermodel.LastName,
                Name = usermodel.Name
            };
        }

        if (parameter is UserRandomApi userRandom)
        {
            return new UserRandomRealm
            {
                Id = ObjectId.GenerateNewId(),
                Cell = userRandom.CellPhone,
                Email = userRandom.Email,
                Gender = userRandom.Gender,               
                Nat = userRandom.Nat,
                Name = userRandom.Name.FirstName,
                LastName = userRandom.Name.LastName,
                Picture = userRandom.Picture.Large,
            };
        }

        return null;        
    } 

    public static LocationRealm? ToLocationRealmObject<T>(this T parameter)
    {
        if (parameter is LocationApi location)
        {
            return new LocationRealm
            {
                Id = ObjectId.GenerateNewId(),
                City = location.City,
                Country = location.Country,
                Latitude = location.Coordinates.Latitude,
                Longitude = location.Coordinates.Longitude,
                // Postcode = location.Postcode,
                State = location.State,
            };
        }

        return null;
    } 

   

}
