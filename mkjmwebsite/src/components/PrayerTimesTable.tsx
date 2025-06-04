import React from "react";
import type { PrayerTimeResponse } from "../types/prayerTimeTypes.ts";

interface PrayerTimesTableProps {
    data: PrayerTimeResponse;
}

export function PrayerTimesTable({ data }: PrayerTimesTableProps) {
    return (
        <table style={{ borderCollapse: "collapse", width: "100%" }}>
            <thead>
                <tr>
                    <th style={thStyle}>Day</th>
                    <th style={thStyle}>Month</th>
                    <th style={thStyle}>Fajr</th>
                    <th style={thStyle}>Iqamah</th>
                    <th style={thStyle}>Shourooq</th>
                    <th style={thStyle}>Dhuhr</th>
                    <th style={thStyle}>Iqamah</th>
                    <th style={thStyle}>Asr</th>
                    <th style={thStyle}>Iqamah</th>
                    <th style={thStyle}>Maghrib</th>
                    <th style={thStyle}>Iqamah</th>
                    <th style={thStyle}>Isha</th>
                    <th style={thStyle}>Iqamah</th>
                </tr>
            </thead>
            <tbody>
                {data.times.map(({ times, dayOfTheMonth, month }, i) => (
                    <tr key={i} style={i % 2 === 0 ? rowStyleEven : rowStyleOdd}>
                        <td style={tdStyle}>{dayOfTheMonth}</td>
                        <td style={tdStyle}>{month}</td>
                        <td style={tdStyle}>{times.fajr}</td>
                        <td style={tdStyle}>{times.fajrIqamah}</td>
                        <td style={tdStyle}>{times.sunrise}</td>
                        <td style={tdStyle}>{times.dhuhr}</td>
                        <td style={tdStyle}>{times.dhuhrIqamah}</td>
                        <td style={tdStyle}>{times.asr}</td>
                        <td style={tdStyle}>{times.asrIqamah}</td>
                        <td style={tdStyle}>{times.maghrib}</td>
                        <td style={tdStyle}>{times.maghribIqamah}</td>
                        <td style={tdStyle}>{times.isha}</td>
                        <td style={tdStyle}>{times.ishaIqamah}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}
const thStyle: React.CSSProperties = {
    border: "1px solid #ddd",
    padding: "8px",
    backgroundColor: "#f2f2f2",
    textAlign: "center"
};

const tdStyle: React.CSSProperties = {
    border: "1px solid #ddd",
    padding: "8px",
    textAlign: "center"
};

const rowStyleEven: React.CSSProperties = {
    backgroundColor: "white"
};

const rowStyleOdd: React.CSSProperties = {
    backgroundColor: "#fafafa"
};
