using MkjmCommon.ApiModels;
using MkjmService;

namespace MkjmConsole;

internal static class Program
{
    private static async Task Main()
    {
        var prayerTimeService = new PrayerTimeService();

        var query = new PrayerTimeQuery
        {
            Latitude = "51.992135", // Milton Keynes Jamee Masjid
            Longitude = "-0.734272", // Milton Keynes Jamee Masjid
            Timezone = "Europe/London",
            Method = "0", // Hanafi General
            Year = "2026",
            Both = "0",
            Time = "1"
        };

        var prayerTimes = await prayerTimeService.GetPrayerTimesAsync(query);

        if (prayerTimes == null)
        {
            Console.WriteLine("Failed to retrieve prayer times.");
            return;
        }

        Console.WriteLine($"Latitude: {prayerTimes.Query.Latitude}");
        Console.WriteLine($"Longitude: {prayerTimes.Query.Longitude}");
        Console.WriteLine($"Timezone: {prayerTimes.Query.Timezone}");
        Console.WriteLine($"Method: {prayerTimes.Query.Method}");
        Console.WriteLine($"Year: {prayerTimes.Query.Year}");
        Console.WriteLine($"Both: {prayerTimes.Query.Both}");
        Console.WriteLine($"Time: {prayerTimes.Query.Time}");

        var firstPrayerTime = prayerTimes.Times.FirstOrDefault();

        if (firstPrayerTime == null)
        {
            Console.WriteLine("No prayer times available.");
            return;
        }

        Console.WriteLine($"Day: {firstPrayerTime.Day}");
        Console.WriteLine($"Fajr: {firstPrayerTime.Times.Fajr}");
        Console.WriteLine($"Sunrise: {firstPrayerTime.Times.Sunrise}");
        Console.WriteLine($"Dhuhr: {firstPrayerTime.Times.Dhuhr}");
        Console.WriteLine($"Asr: {firstPrayerTime.Times.Asr}");
        Console.WriteLine($"Maghrib: {firstPrayerTime.Times.Maghrib}");
        Console.WriteLine($"Isha: {firstPrayerTime.Times.Isha}");
    }
}