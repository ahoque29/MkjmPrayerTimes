import { usePrayerTimes } from "../api/usePrayerTimes.ts";
import { PrayerTimesTable } from "../components/PrayerTimesTable.tsx";
import { YearAndMonthSelector } from "../components/YearAndMonthSelector.tsx";
import { useYearAndMonthSelection } from "../utils/useYearAndMonthSelection.ts";

export function PrayerTimesPage() {
    const yearAndMonthsProps = useYearAndMonthSelection();
    const { selectedYear, selectedMonth } = yearAndMonthsProps;
    const { data, isLoading, error } = usePrayerTimes(selectedYear, selectedMonth);

    return (
        <div style={{ padding: "2rem" }}>
            <YearAndMonthSelector {...yearAndMonthsProps} />
            <div style={{ fontSize: "1.25rem", textAlign: "center" }}>
                {isLoading ? (
                    <div style={{ fontSize: "1rem", color: "#555", marginTop: "1rem" }}>
                        Loading...
                    </div>
                ) : error ? (
                    <div style={{ color: "red" }}>{error}</div>
                ) : data ? (
                    <PrayerTimesTable data={data} />
                ) : null}
            </div>{" "}
        </div>
    );
}
