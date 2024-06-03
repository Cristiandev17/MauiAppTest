using System.Text.Json.Serialization;
using MauiAppTest.Core.Entities.API;

namespace MauiAppTest.Core;

public class RootApiResponse
{
  [JsonPropertyName("results")]
  public List<UserRandomApi>? Results { get; set; }
}
