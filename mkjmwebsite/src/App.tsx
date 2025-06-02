import { PrayerTimesPage } from "./pages/PrayerTimesPage.tsx";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<PrayerTimesPage />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;
