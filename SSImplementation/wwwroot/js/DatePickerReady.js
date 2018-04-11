$(function () {
    var currentDate = new Date()
    $("#DateOfBooking").datepicker(currentDate, {
        minDate: currentDate
    });
});