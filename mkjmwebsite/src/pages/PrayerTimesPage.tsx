import { usePrayerTimes } from "../api/usePrayerTimes.ts";
import { PrayerTimesTable } from "../components/PrayerTimesTable.tsx";
import { useState } from "react";
import { YearAndMonthSelector } from "../components/YearAndMonthSelector.tsx";
import { getMonthOptions, getYearOptions } from "../utils/dateOptions.ts";

export function PrayerTimesPage() {
    const years = getYearOptions();
    const months = getMonthOptions();

    const [selectedYear, setSelectedYear] = useState(years[1]); // Default to the current year
    const [selectedMonth, setSelectedMonth] = useState(0); // Default to "All" months

    const data = usePrayerTimes(selectedYear, selectedMonth);
    return (
        <div style={{ padding: "2rem" }}>
            <YearAndMonthSelector
                years={years}
                months={months}
                selectedYear={selectedYear}
                selectedMonth={selectedMonth}
                onYearChange={setSelectedYear}
                onMonthChange={setSelectedMonth}
            />

            <div style={{ fontSize: "1.25rem", textAlign: "center" }}>
                {data === "Loading..." ? (
                    <div style={{ fontSize: "1rem", color: "#555", marginTop: "1rem" }}>
                        Loading...
                    </div>
                ) : typeof data === "string" ? (
                    <div>{data}</div>
                ) : (
                    <PrayerTimesTable data={data} />
                )}
            </div>
        </div>
    );
}
