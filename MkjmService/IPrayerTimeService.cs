using MkjmCommon.ApiModels;

namespace MkjmService;

public interface IPrayerTimeService
{
    Task<PrayerTimeResponse?>? GetPrayerTimesAsync(PrayerTimeQuery query);
}