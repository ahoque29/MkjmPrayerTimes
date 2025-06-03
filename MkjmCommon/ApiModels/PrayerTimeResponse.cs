namespace MkjmCommon.ApiModels;

public class PrayerTimeResponse
{
    public PrayerTimeQuery Query { get; init; }
    public IEnumerable<DailyPrayerTimes> Times { get; init; }
}