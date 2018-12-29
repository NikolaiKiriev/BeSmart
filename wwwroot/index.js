var tblStr = "<table>";
$(function () {
    $("#CustomerBtn").click(RenderCustomersTable())
});
$("#OrderBtn").click(function () {
    $("#ConteinerDiv").html("Order");
});
$("#ProductBtn").click(function () {
    $("#ConteinerDiv").html("Product");
});


function RenderCustomersTable() {
    $.get("api/customers", function (data, status) {
        if (status == "success") {
            var customers = data;
            tblStr += "<tr><th>ID</th><th>FirstName</th><th>LastName</th><th>Address</th><th>City</th><th>PostalCode</th><th>Phone</th><th>Fax</th></tr>";
            for (var i = 0; i < customers.length; i++) {
                customer = customers[i];
                var CustomerID = customer.customerID;
                var CustomerFirstName = customer.customerFirstName;
                var CustomerLastName = customer.customerLastName;
                var Address = customer.address;
                var City = customer.city;
                var PostalCode = customer.postalCode;
                var Phone = customer.phone;
                var Fax = customer.fax;
                tblStr += "<tr><td>" + CustomerID + "</td><td>" + CustomerFirstName + "</td><td>" + CustomerLastName + "</td><td>" + Address + "</td><td>" + City + "</td><td>" + PostalCode + "</td><td>" + Phone + "</td><td>" + Fax + "</td></tr>"
            }
            tblStr += "</table>";
            $("#ConteinerDiv").html(tblStr);
        }
        else {
            $("#ConteinerDiv").html("ERR");
        }
    })
}

function RenderOrdersTable() {
    $.get("/api/Orders", function (data, status) {
        if (status == "success") {
            var Orders = data;
            tblStr += "<tr><td>ID</td><td>CustomerID</td><td>ProductID</td><td>OrderDate</td><td>OrderRequiredDate</td><td>ShippedDate</td><td>Freight</td><td>ShipAddress</td><td>ShipTown</td><td>ShipPostalCode</td></tr>";
            for (var i = 0; i < Orders.length; i++) {
                order = Orders[i];
                var OrderID = order.orderID;
                var CustomerID = order.customerID;
                var ProductID = order.productID;
                var OrderDate = order.orderDate;
                var OrderRequiredDate = order.orderRequiredDate;
                var ShippedDate = order.shippedDate;
                var Freight = order.freight;
                var ShippedAddress = order.shippedAddress;
                var ShipTown = order.shipTown;
                var ShipPostalCode = order.shipPostalCode;
                tblStr += "<tr><td>" + OrderID + "</td><td>" + CustomerID + "</td><td>" + ProductID + "</td><td>"+OrderDate+"</td><td>"+OrderRequiredDate+"</td><td>"+ShippedDate+"</td><td>"+Freight+"</td><td>"+ShippedAddress+"</td><td>"+ShipTown+"</td><td>"+ShipPostalCode+"</td></tr>";
            }
        }
    })
}