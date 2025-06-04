using MkjmCommon.ApiModels;

namespace MkjmService;

public interface IPrayerTimeService
{
    Task<PrayerTimeResponse?> GetPrayerTimesAsync(PrayerTimeQuery query);
    Task<PrayerTimeResponse?> GetMkjmPrayerTimeAsync(int year, int month = 0, int maghribIqamahOffset = 5);
}