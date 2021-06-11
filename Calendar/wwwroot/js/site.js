document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridWeek',
        headerToolbar: {
            left: 'prev,next today',
            center: 'title',
            right: 'dayGridMonth,timeGridWeek,timeGridDay'
        },
        events: [
            {
                title: "Test event",
                start: "2021-06-11"
            },
        ],
    });
    
    calendar.render();
});

calendar.addEvent({
    title: "Test event 3",
    start: "2021-06-12T13:00",
    end: "2021-06-12T16:00",
    allDay: false,

});