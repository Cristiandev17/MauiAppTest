using MongoDB.Bson;
using Realms;

namespace MauiAppTest.Core.Entities.Realm;

public class LocationRealm : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId? Id { get; set; }

    [MapTo("city")]
    public string City { get; set; }

    [MapTo("state")]
    public string State { get; set; }

    [MapTo("country")]
    public string Country { get; set; }

    [MapTo("postcode")]
    public int Postcode { get; set; }

    [MapTo("latitude")]
    public string Latitude { get; set; }

    [MapTo("longitude")]
    public string Longitude { get; set; }

    [MapTo("userId")]
    public ObjectId? UserId { get; set; }
}
