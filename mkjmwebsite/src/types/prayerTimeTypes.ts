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

export type DailyPrayerTimes = {
    day: string;
    times: PrayerTimes;
    dayOfTheMonth: number;
    month: number;
};

export type PrayerTimeResponse = {
    query: Record<string, string>;
    times: DailyPrayerTimes[];
};
