import { usePrayerTimes } from "../api/usePrayerTimes.ts";
import { PrayerTimesTable } from "../components/PrayerTimesTable.tsx";
import { useState } from "react";

function getYearOptions(): number[] {
    const currentYear = new Date().getFullYear();
    const startYear = currentYear - 1; // Start from the previous year
    const endYear = currentYear + 10; // Up to 10 years in the future
    const years = [];

    for (let year = startYear; year <= endYear; year++) {
        years.push(year);
    }

    return years;
}

function getMonthOptions(): { value: number; label: string }[] {
    return [
        { value: 0, label: "All" },
        { value: 1, label: "January" },
        { value: 2, label: "February" },
        { value: 3, label: "March" },
        { value: 4, label: "April" },
        { value: 5, label: "May" },
        { value: 6, label: "June" },
        { value: 7, label: "July" },
        { value: 8, label: "August" },
        { value: 9, label: "September" },
        { value: 10, label: "October" },
        { value: 11, label: "November" },
        { value: 12, label: "December" }
    ];
}

export function PrayerTimesPage() {
    const years = getYearOptions();
    const months = getMonthOptions();

    const [selectedYear, setSelectedYear] = useState(years[1]); // Default to the current year
    const [selectedMonth, setSelectedMonth] = useState(0); // Default to "All" months

    const data = usePrayerTimes(selectedYear, selectedMonth);
    return (
        <div style={{ padding: "2rem" }}>
            <div style={{ marginBottom: "1rem" }}>
                <label>
                    Year:{" "}
                    <select
                        value={selectedYear}
                        onChange={e => setSelectedYear(Number(e.target.value))}
                    >
                        {years.map(y => (
                            <option key={y} value={y}>
                                {y}
                            </option>
                        ))}
                    </select>
                </label>

                <label style={{ marginLeft: "1rem" }}>
                    Month:{" "}
                    <select
                        value={selectedMonth}
                        onChange={e => setSelectedMonth(Number(e.target.value))}
                    >
                        {months.map(m => (
                            <option key={m.value} value={m.value}>
                                {m.label}
                            </option>
                        ))}
                    </select>
                </label>
            </div>

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
