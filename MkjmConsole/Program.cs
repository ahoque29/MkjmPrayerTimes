using MkjmService;

namespace MkjmConsole;

internal static class Program
{
    private static async Task Main()
    {
        var httpClient = new HttpClient();
        var prayerTimeService = new PrayerTimeService(httpClient);
        
        var prayerTimes = await prayerTimeService.GetMkjmPrayerTimeAsync(DateTime.UtcNow.Year);

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
        Console.WriteLine($"Fajr Iqamah: {firstPrayerTime.Times.FajrIqamah}");
        Console.WriteLine($"Sunrise: {firstPrayerTime.Times.Sunrise}");
        Console.WriteLine($"Dhuhr: {firstPrayerTime.Times.Dhuhr}");
        Console.WriteLine($"Dhuhr Iqamah: {firstPrayerTime.Times.DhuhrIqamah}");
        Console.WriteLine($"Asr: {firstPrayerTime.Times.Asr}");
        Console.WriteLine($"Asr Iqamah: {firstPrayerTime.Times.AsrIqamah}");
        Console.WriteLine($"Maghrib: {firstPrayerTime.Times.Maghrib}");
        Console.WriteLine($"Maghrib Iqamah: {firstPrayerTime.Times.MaghribIqamah}");
        Console.WriteLine($"Isha: {firstPrayerTime.Times.Isha}");
    }
}