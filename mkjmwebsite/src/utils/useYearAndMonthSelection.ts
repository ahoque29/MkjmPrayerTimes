import { getMonthOptions, getYearOptions } from "./dateOptions";
import { useState } from "react";
import type { YearAndMonthSelectorProps } from "../types/YearAndMonthSelectorProps.ts";

export function useYearAndMonthSelection(): YearAndMonthSelectorProps {
    const years = getYearOptions();
    const months = getMonthOptions();

    const [selectedYear, setSelectedYear] = useState(years[1]); // Default to the current year
    const [selectedMonth, setSelectedMonth] = useState(0); // Default to "All" months

    return {
        years,
        months,
        selectedYear,
        selectedMonth,
        onYearChange: setSelectedYear,
        onMonthChange: setSelectedMonth
    };
}
