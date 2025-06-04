using System.Globalization;
using System.Text.Json;
using Microsoft.AspNetCore.WebUtilities;
using MkjmCommon.ApiModels;

namespace MkjmService;

public class PrayerTimeService : IPrayerTimeService
{
    private readonly HttpClient _httpClient;

    public PrayerTimeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PrayerTimeResponse?> GetPrayerTimesAsync(PrayerTimeQuery query)
    {
        var baseUri = new Uri("https://moonsighting.ahmedbukhamsin.sa/time_json.php?");

        var queryParams = new Dictionary<string, string?>
        {
            ["year"] = query.Year,
            ["tz"] = query.Timezone,
            ["lat"] = query.Latitude.ToString(CultureInfo.InvariantCulture),
            ["lon"] = query.Longitude.ToString(CultureInfo.InvariantCulture),
            ["method"] = query.Method,
            ["both"] = query.Both,
            ["time"] = query.Time
        };

        var queryUrl = QueryHelpers.AddQueryString(baseUri.ToString(), queryParams);

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

            return TrimAllTimes(result);
        }
        catch
        {
            return null;
        }
    }

    public async Task<PrayerTimeResponse?> GetMkjmPrayerTimeAsync(int year, int month = 0, int maghribIqamahOffset = 5)
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
            if (maghribIqamahOffset > 0)
            {
                PopulateMaghribIqamah(maghribIqamahOffset, results);
            }

            return results;
        }

        var filteredTimes = results.Times.Where(t => t.GetDate(year).Month == month).ToArray();

        var filteredResponse = new PrayerTimeResponse
        {
            Query = results.Query,
            Times = filteredTimes
        };

        if (maghribIqamahOffset > 0)
        {
            PopulateMaghribIqamah(maghribIqamahOffset, filteredResponse);
        }

        return filteredResponse;
    }

    private static void PopulateMaghribIqamah(int maghribIqamahOffset, PrayerTimeResponse results)
    {
        foreach (var time in results.Times)
        {
            if (time?.Times == null || string.IsNullOrEmpty(time.Times.Maghrib))
            {
                continue;
            }

            if (TimeSpan.TryParse(time.Times.Maghrib, out var maghribTime))
            {
                time.Times.MaghribIqamah =
                    maghribTime.Add(TimeSpan.FromMinutes(maghribIqamahOffset)).ToString(@"hh\:mm");
            }
        }
    }

    private static PrayerTimeResponse? TrimAllTimes(PrayerTimeResponse? response)
    {
        if (response is null)
        {
            return response;
        }
        
        foreach (var day in response.Times)
        {
            var prayerTimes = day.Times;
            if (prayerTimes == null)
            {
                continue;
            }
            
            prayerTimes.Fajr = prayerTimes.Fajr?.Trim();
            prayerTimes.Sunrise = prayerTimes.Sunrise?.Trim();
            prayerTimes.Dhuhr = prayerTimes.Dhuhr?.Trim();
            prayerTimes.Asr = prayerTimes.Asr?.Trim();
            prayerTimes.Maghrib = prayerTimes.Maghrib?.Trim();
            prayerTimes.Isha = prayerTimes.Isha?.Trim();
        }
        
        return response;
    }
}