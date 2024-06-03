using MongoDB.Bson;
using Realms;

namespace MauiAppTest.Core;

public class UserRandomRealm : RealmObject
{

    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId? Id { get; set; }

    [MapTo("gender")]
    public string? Gender { get; set; }

    [MapTo("email")]
    public string? Email { get; set; }

    [MapTo("phone")]
    public string? Phone { get; set; }

    [MapTo("cell")]
    public string? Cell { get; set; }

    [MapTo("nat")]
    public string? Nat { get; set; }

    [MapTo("name")]
    public string? Name { get; set; }

    [MapTo("lastName")]
    public string? LastName { get; set; }

    [MapTo("picture")]
    public string? Picture { get; set; }
}
