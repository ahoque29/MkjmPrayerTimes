using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using MkjmCommon.ApiModels;

namespace MkjmService;

public class PrayerTimeService : IPrayerTimeService
{
    private readonly HttpClient _httpClient = new();

    public async Task<PrayerTimeResponse?> GetPrayerTimesAsync(PrayerTimeQuery query)
    {
        var baseUri = new Uri("https://moonsighting.ahmedbukhasim.sa/time_json.php");

        var queryparams = new Dictionary<string, string?>()
        {
            ["year"] = query.Year,
            ["tz"] = query.Timezone,
            ["lat"] = query.Latitude.ToString(CultureInfo.InvariantCulture),
            ["lon"] = query.Longitude.ToString(CultureInfo.InvariantCulture),
            ["method"] = query.Method.ToString(),
            ["both"] = query.Both ? "1" : "0",
            ["time"] = query.Time ? "1" : "0"
        };

        var queryUrl = QueryHelpers.AddQueryString(baseUri.ToString(), queryparams);

        try
        {
            var response = await _httpClient.GetAsync(queryUrl);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var result = JsonSerializer.Deserialize<PrayerTimeResponse>(content, options);
            return result;
        }
        catch
        {
            return null;
        }
    }
}