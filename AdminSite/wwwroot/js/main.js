/** Toggle Buttons
 * We first load all elements of the class "Branch" into a variable.
 * Then we loop through the elements in branches, using  a for loop.
 * In that loop we add an event listerner "click" to each element.
 * On click, we toggle the css class "hidden", to show or hide the
 * ul element containing the leafs of the branch.
 */
var branches = document.getElementsByClassName("branch");

for (let i = 0; i < branches.length; i++) {
    let leaves = branches[i].getElementsByClassName('leaf');
    leaves[0].addEventListener('click', function () {
        let uls = branches[i].getElementsByTagName("ul");
        uls[0].classList.toggle("hidden");
    });
}

// get the formated time string
function getTime() {
    const now = new Date();
    const hours = now.getHours();
    const minutes = now.getMinutes();
    const seconds = now.getSeconds();

    return `${formatTime(hours)}:${formatTime(minutes)}:${formatTime(seconds)}`;

}

// updatesClock the clock
function updateClock() {
    const timeString = getTime();
    const clockElement = document.getElementById("clock");
    clockElement.textContent = timeString;
}

// format the time to make sure that single digits is shown with a 0 in front. 
function formatTime(time) {
    /** I might have used a ternary operator (short if operator) here instead of an if statement,
    * then the code would've looked like this:
    * return time < 10 ? "0" + time : time;
    */
    let TTime = time;
    if (time < 10) {
        TTime = "0" + time;
    }
    return TTime;
}

// Call the updateClock function every 1 second (1000 milliseconds)
setInterval(updateClock, 1000);

// Initial call to set the clock when the page loads
updateClock();