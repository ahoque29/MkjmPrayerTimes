import type { PrayerTimeResponse } from "../types/prayerTimeTypes.ts";

export function exportCsv(data: PrayerTimeResponse) {
    const headers = [
        "Date",
        "Fajr",
        "Iqamah",
        "Sunrise",
        "Dhuhr",
        "Iqamah",
        "Asr",
        "Iqamah",
        "Maghrib",
        "Iqamah",
        "Isha",
        "Iqamah"
    ];

    const rows = data.times.map(({ day, times }) => [
        day,
        times.fajr?.trim() || "",
        times.fajrIqamah?.trim() || "",
        times.sunrise?.trim() || "",
        times.dhuhr?.trim() || "",
        times.dhuhrIqamah?.trim() || "",
        times.asr?.trim() || "",
        times.asrIqamah?.trim() || "",
        times.maghrib?.trim() || "",
        times.maghribIqamah?.trim() || "",
        times.isha?.trim() || "",
        times.ishaIqamah?.trim() || ""
    ]);

    const csvContent = [headers, ...rows]
        .map(row => row.map(cell => `"${cell}"`).join(","))
        .join("\n");

    const blob = new Blob([csvContent], { type: "text/csv;charset=utf-8;" });
    const url = URL.createObjectURL(blob);

    const link = document.createElement("a");
    link.href = url;
    link.download = "PrayerTimes.csv";
    link.click();

    URL.revokeObjectURL(url);
}
