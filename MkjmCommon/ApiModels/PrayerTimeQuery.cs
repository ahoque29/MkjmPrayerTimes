namespace MkjmCommon.ApiModels;

public class PrayerTimeQuery    
{
    public string Latitude { get; init; }
    public string Longitude { get; init; }
    public string Timezone { get; init; }
    public string Method { get; init; }
    public string Year { get; init; }
    public string Both { get; init; }
    public string Time { get; init; }
}