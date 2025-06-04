import type { YearAndMonthSelectorProps } from "../types/YearAndMonthSelectorProps.ts";

export function YearAndMonthSelector({
    years,
    months,
    selectedYear,
    selectedMonth,
    onYearChange,
    onMonthChange
}: YearAndMonthSelectorProps) {
    return (
        <div style={{ marginBottom: "1rem" }}>
            <label>
                Year:{" "}
                <select value={selectedYear} onChange={e => onYearChange(Number(e.target.value))}>
                    {years.map(y => (
                        <option key={y} value={y}>
                            {y}
                        </option>
                    ))}
                </select>
            </label>

            <label style={{ marginLeft: "1rem" }}>
                Month:{" "}
                <select value={selectedMonth} onChange={e => onMonthChange(Number(e.target.value))}>
                    {months.map(m => (
                        <option key={m.value} value={m.value}>
                            {m.label}
                        </option>
                    ))}
                </select>
            </label>
        </div>
    );
}
