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
        var baseUri = new Uri("https://moonsighting.ahmedbukhamsin.sa/time_json.php?");

        var queryparams = new Dictionary<string, string?>()
        {
            ["year"] = query.Year,
            ["tz"] = query.Timezone,
            ["lat"] = query.Latitude.ToString(CultureInfo.InvariantCulture),
            ["lon"] = query.Longitude.ToString(CultureInfo.InvariantCulture),
            ["method"] = query.Method,
            ["both"] = query.Both,
            ["time"] = query.Time
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

            var result = JsonSerializer.Deserialize<PrayerTimeResponse>(content,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            return result;
        }
        catch
        {
            return null;
        }
    }
}