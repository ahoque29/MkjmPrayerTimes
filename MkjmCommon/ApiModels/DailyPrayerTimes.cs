using System.Globalization;
using System.Text.Json.Serialization;

namespace MkjmCommon.ApiModels;

public class DailyPrayerTimes
{
    public string Day { get; set; }
    public PrayerTimes Times { get; set; }
    public int DayOfTheMonth { get; set; }
    public int Month { get; set; }

    public DateTime GetDate(int year)
    {
        if (string.IsNullOrEmpty(Day) || Day.Length < 6)
        {
            return DateTime.MaxValue; // Invalid date format
        }
        
        var monthString = Day[..6];
        var dateString = $"{monthString} {year}";

        if (!DateTime.TryParseExact(dateString, "MMM dd yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
        {
            return DateTime.MaxValue; // Invalid date format
        }

        return date;
    }
}