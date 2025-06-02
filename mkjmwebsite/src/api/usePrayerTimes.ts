import { useEffect, useState } from "react";
import type { PrayerTimeResponse } from "../types/prayerTimeTypes.ts";

export function usePrayerTimes(year: number, month: number): PrayerTimeResponse | string {
    const [data, setData] = useState<PrayerTimeResponse | string>("Loading...");

    useEffect(() => {
        setData("Loading...");
        fetch(`api/PrayerTime/mkjm?year=${year}&month=${month}`)
            .then(res => {
                if (!res.ok) {
                    throw new Error("Failed to fetch");
                }
                return res.json();
            })
            .then(json => setData(json))
            .catch(err => setData("Error: " + err.message));
    }, [year, month]);

    return data;
}
