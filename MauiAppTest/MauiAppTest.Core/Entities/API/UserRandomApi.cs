using System.Text.Json.Serialization;

namespace MauiAppTest.Core.Entities.API;

public class UserRandomApi
{
  [JsonPropertyName("gender")]
  public string? Gender { get; set; }

  [JsonPropertyName("email")]
  public string? Email { get; set; }

  [JsonPropertyName("cell")]
  public string? CellPhone { get; set; }

  [JsonPropertyName("nat")]
  public string? Nat { get; set; }

  [JsonPropertyName("name")]
  public NameApi Name { get; set; }

  [JsonPropertyName("location")]
  public LocationApi Location { get; set; }

  [JsonPropertyName("picture")]
  public PictureApi Picture { get; set; }
}