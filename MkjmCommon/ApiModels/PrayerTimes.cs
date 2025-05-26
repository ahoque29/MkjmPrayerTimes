namespace MkjmCommon.ApiModels;

public class PrayerTimes
{
    public TimeOnly Fajr { get; set; }
    public TimeOnly Sunrise { get; set; }
    public TimeOnly Dhuhr { get; set; }
    public TimeOnly Asr { get; set; }
    public TimeOnly Maghrib { get; set; }
    public TimeOnly Isha { get; set; }
}