import { usePrayerTimes } from "../api/usePrayerTimes.ts";
import { PrayerTimesTable } from "../components/PrayerTimesTable.tsx";

export function PrayerTimesPage() {
    const data = usePrayerTimes();

    return (
        <div style={{ padding: "2rem", fontSize: "1.5rem" }}>
            {typeof data === "string" ? data : <PrayerTimesTable data={data} />}
        </div>
    );
}
