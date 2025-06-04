namespace MkjmCommon.ApiModels;

public class PrayerTimeResponse
{
    public PrayerTimeQuery Query { get; init; }
    public DailyPrayerTimes[] Times { get; init; }
}