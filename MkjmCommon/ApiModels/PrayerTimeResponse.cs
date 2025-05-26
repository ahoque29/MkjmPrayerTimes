namespace MkjmCommon.ApiModels;

public class PrayerTimeResponse
{
    public PrayerTimeQuery Query { get; set; }
    public IEnumerable<DailyPrayerTimes> Times { get; set; }
}