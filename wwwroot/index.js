
$(function () {
    $("#CustomerBtn").click(function () {
        $.get("api/customers", function (data) {
            $("#ConteinerDiv").html(data);
            
            

        })
    });
    $("#OrderBtn").click(function () {
        $("#ConteinerDiv").html("Order");
    });
    $("#ProductBtn").click(function () {
        $("#ConteinerDiv").html("Product");
    });
})

