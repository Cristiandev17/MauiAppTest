using System.Text.Json.Serialization;

namespace MauiAppTest.Core.Entities.API;

public class NameApi
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("first")]
    public string FirstName { get; set; }

    [JsonPropertyName("last")]
    public string LastName { get; set; }
}
