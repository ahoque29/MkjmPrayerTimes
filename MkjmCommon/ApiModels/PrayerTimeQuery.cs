namespace MkjmCommon.ApiModels;

public class PrayerTimeQuery    
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Timezone { get; set; }
    public int Method { get; set; }
    public string Year { get; set; }
    public bool Both { get; set; }
    public bool Time { get; set; }
}