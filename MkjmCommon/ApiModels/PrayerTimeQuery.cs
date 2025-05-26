namespace MkjmCommon.ApiModels;

public class PrayerTimeQuery    
{
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    public string Timezone { get; set; }
    public string Method { get; set; }
    public string Year { get; set; }
    public string Both { get; set; }
    public string Time { get; set; }
}