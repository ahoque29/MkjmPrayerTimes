import { useEffect, useState } from "react";
import type { PrayerTimeResponse } from "../types/prayerTimeTypes.ts";

type PrayerTimesResult = {
    data: PrayerTimeResponse | null;
    isLoading: boolean;
    error: string | null;
};

export function usePrayerTimes(year: number, month: number): PrayerTimesResult {
    const [data, setData] = useState<PrayerTimeResponse | null>(null);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        setIsLoading(true);
        setError(null);

        fetch(`api/PrayerTime/mkjm?year=${year}&month=${month}`)
            .then(res => {
                if (!res.ok) throw new Error("Failed to fetch");
                return res.json();
            })
            .then(json => {
                setData(json);
                setIsLoading(false);
            })
            .catch(err => {
                setError(err.message);
                setIsLoading(false);
            });
    }, [year, month]);

    return { data, isLoading, error };
}
