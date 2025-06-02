import { useEffect, useState } from "react";
import type { PrayerTimeResponse } from "../types/prayerTimeTypes.ts";

export function usePrayerTimes(): PrayerTimeResponse | string {
    const [data, setData] = useState<PrayerTimeResponse | string>("Loading...");

    useEffect(() => {
        fetch("api/PrayerTime/mkjm?year=2026&month=1")
            .then(res => {
                if (!res.ok) {
                    throw new Error("Failed to fetch");
                }
                return res.json();
            })
            .then(json => setData(json))
            .catch(err => setData("Error: " + err.message));
    }, []);

    return data;
}
