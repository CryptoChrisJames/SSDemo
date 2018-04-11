$(function () {

    $("#BookingTime2").change(function () {
        
        var t1 = $("#BookingTime1").val()
        var t2 = $("#BookingTime2").val()
        var ttotal = (t2 - t1) / 100
        if (ttotal <= 0) {
            $("#TotalPrice").html("<h2>The times you chose are not compatible.")
            $("#ConfirmBooking").remove();
        }

        else {
            var TotalPrice = ttotal * PricePerHour
            $("#FinalCost").val(TotalPrice)
            $("#AmountofTimeBooked").val(ttotal)
            $("#StudioBooked").val(StudioObject)
            $("#ProfileMakingReservation").val(ProfileObject)
            $("#TotalPrice").html("<h1>Price To Book: $" + TotalPrice)
            debugger;
            $("#SubmitButton").html("<input type='submit' value='Book This Time!' id='ConfirmBooking' class='btn btn-default'/>")
        }
    })
    
});