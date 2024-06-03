using System.Text.Json.Serialization;

namespace MauiAppTest.Core.Entities.API;

public class LocationApi
{    
    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    // [JsonPropertyName("postcode")]
    // public int Postcode { get; set; }

    [JsonPropertyName("coordinates")]
    public CoordinateApi Coordinates { get; set; }    

}
