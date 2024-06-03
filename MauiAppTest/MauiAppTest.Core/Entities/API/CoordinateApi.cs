using System.Text.Json.Serialization;

namespace MauiAppTest.Core.Entities.API;

public class CoordinateApi
{
    [JsonPropertyName("latitude")]
    public string Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string Longitude { get; set; }
}
