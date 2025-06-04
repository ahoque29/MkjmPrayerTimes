export type PrayerTimes = {
    fajr: string;
    fajrIqamah?: string;
    sunrise: string;
    dhuhr: string;
    dhuhrIqamah?: string;
    asr: string;
    asrIqamah?: string;
    maghrib: string;
    maghribIqamah?: string;
    isha: string;
    ishaIqamah?: string;
};

export type DayAndTimes = {
    day: string;
    times: PrayerTimes;
};

export type PrayerTimeResponse = {
    query: Record<string, string>;
    times: DayAndTimes[];
};
