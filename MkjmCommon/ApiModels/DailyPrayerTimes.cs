namespace MkjmCommon.ApiModels;

public class DailyPrayerTimes
{
    public DateOnly Day { get; set; }
    public PrayerTimes Times { get; set; }
}