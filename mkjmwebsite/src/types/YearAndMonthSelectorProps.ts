export type YearAndMonthSelectorProps = {
    years: number[];
    months: { value: number; label: string }[];
    selectedYear: number;
    selectedMonth: number;
    onYearChange: (year: number) => void;
    onMonthChange: (month: number) => void;
};
