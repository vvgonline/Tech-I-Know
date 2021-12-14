import { getCurrentYear } from "./getCurrentYear";

export function showCurrentyear() {
    //show current year
    let currentYearContainer = document.getElementById('currentYear') as HTMLElement;
    currentYearContainer.innerHTML = getCurrentYear();
}