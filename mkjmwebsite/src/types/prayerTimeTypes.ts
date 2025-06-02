export type PrayerTimes = {
    fajr: string;
    sunrise: string;
    dhuhr: string;
    asr: string;
    maghrib: string;
    isha: string;
};

export type DayAndTimes = {
    day: string;
    times: PrayerTimes;
};

export type PrayerTimeResponse = {
    query: Record<string, string>;
    times: DayAndTimes[];
};
