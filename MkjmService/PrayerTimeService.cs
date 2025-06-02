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

    public async Task<PrayerTimeResponse?> GetMkjmPrayerTimeAsync(int year, int month = 0)
    {
        var query = new PrayerTimeQuery
        {
            Latitude = "51.992135", // Milton Keynes Jamee Masjid Latitude
            Longitude = "-0.734272", // Milton Keynes Jamee Masjid Longitude
            Timezone = "Europe/London", // Milton Keynes Timezone
            Method = "0", // Hanafi General
            Year = year.ToString(),
            Both = "0", // Only one asr time
            Time = "0" // 24-hour format
        };

        var results = await GetPrayerTimesAsync(query);

        if (results?.Times == null || !results.Times.Any())
        {
            return null;
        }

        if (month == 0)
        {
            return results;
        }

        var filteredTimes = results.Times.Where(t => t.GetDate(year).Month == month);

        var filteredResponse = new PrayerTimeResponse
        {
            Query = results.Query,
            Times = filteredTimes
        };

        return filteredResponse;
    }
}