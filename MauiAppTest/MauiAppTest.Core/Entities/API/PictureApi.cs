using System.Text.Json.Serialization;

namespace MauiAppTest.Core.Entities.API;

public class PictureApi
{
    [JsonPropertyName("large")]
    public string Large { get; set; }

    [JsonPropertyName("medium")]
    public string Medium { get; set; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }
}
