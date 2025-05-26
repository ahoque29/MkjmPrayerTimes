using System.Globalization;
using System.Text.Json.Serialization;

namespace MkjmCommon.ApiModels;

public class DailyPrayerTimes
{
    public string Day { get; set; }
    public PrayerTimes Times { get; set; }

    [JsonIgnore] public DateTime Date => Day == null ? DateTime.MaxValue : DateTime.ParseExact(Day[..6], "MMM dd", CultureInfo.InvariantCulture);
}