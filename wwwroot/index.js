var tblStr = "";

function RenderCustomersTable() {
    $("#PageName").html("טבלת לקוחות")
    $.get("api/customers", function (data, status) {
        if (status == "success") {
            var customers = data;
            tblStr = "<table>";
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
    $("#PageName").html("טבלת הזמנות")
    $.get("/api/Orders", function (data, status) {
        if (status == "success") {
            var Orders = data;
            tblStr = "<table>";
            tblStr += "<tr><td>מספר הזמנה</td><td>מספר לקוח</td><td>מספר מוצר</td><td>תאריך הזמנה</td><td>תאריך לקיחה</td><td>תאריך שילוח</td><td>דמי הובלה</td><td>כתובת משלוח</td><td>עיר משלוח</td><td>קוד דואר</td></tr>";
            for (var i = 0; i < Orders.length; i++) {
                order = Orders[i];
                var OrderID = order.orderID;
                var CustomerID = order.customerID;
                var ProductID = order.productID;
                var OrderDate = order.orderDate;
                var OrderRequiredDate = order.orderRequiredDate;
                var ShippedDate = order.shippedDate;
                var Freight = order.freight;
                var ShippedAddress = order.shipAddress;
                var ShipTown = order.shipTown;
                var ShipPostalCode = order.shipPostalCode;
                tblStr += "<tr><td>" + OrderID + "</td><td>" + CustomerID + "</td><td>" + ProductID + "</td><td>" + OrderDate + "</td><td>" + OrderRequiredDate + "</td><td>" + ShippedDate + "</td><td>" + Freight + "</td><td>" + ShippedAddress + "</td><td>" + ShipTown + "</td><td>" + ShipPostalCode + "</td></tr>";
            }
            tblStr += "</table>";
            $("#ConteinerDiv").html(tblStr);
        }
    })
}
function RenderProductsTable() {
    $("#PageName").html("טבלת מוצרים קיימים")
    $.get("/api/Products", function (data, status) {
        if (status == "success") {
            var products = data;
            tblStr = "<table>";
            tblStr += "<tr><td>ProductID</td><td>ProductName</td><td>Price</td><td>UnitsInStock</td><td>UnitsInOrder</td><td>ReorderLevel</td><td>Discontinued</td></tr>"
            for (var i = 0; i < products.length; i++) {
                product = products[i];
                var productID = product.productID;
                var productName = product.productName;
                var price = product.price;
                var unitsInStock = product.unitsInStock;
                var unitsInOrder = product.unitsInOrder;
                var reorderLevel = product.reorderLevel;
                var discontinued = product.discontinued;

                tblStr += "<tr><td>" + productID + "</td><td>" + productName + "</td><td>" + price + "</td><td>" + unitsInStock + "</td><td>" + unitsInOrder + "</td><td>" + reorderLevel + "</td><td>" + discontinued + "</td></tr>";
            };
            tblStr += "</table>";
            $("#ConteinerDiv").html(tblStr);
        }
    })
}
function RenderAddTable() {
    $("#PageName").html("הוספת מוצר חדש");
    tblStr = "<table>";
    tblStr += "<tr><td>שם המוצר</td><td>מחיר</td><td>כמות זמינה</td><td>כמות בהזמנה</td><td>רמת הזמנה חוזרת</td></tr>";
    tblStr += "<tr><td><input id='ProductName' type='text' /></td><td><input id='Price' type='text' /></td><td><input id='UnitsInStock' type='text' /></td>";
    tblStr += "<td><input id='UnitsInOrder' type='text' /></td></tr>";
    tblStr += "<tr><td><button onclick='PostNewProduct()' id='AddNewProductBtn'>Add!</button></td></tr>";
    tblStr += "</table>";
    $("#ConteinerDiv").html(tblStr);
    
    
}
function PostNewProduct() {
    var testStr = "";
    testStr += $("#ProductName").val();
    testStr += "<br>";
    testStr += $("#Price").val();
    testStr += "<br>";
    testStr += $("#UnitsInStock").val();
    testStr += "<br>";
    testStr += $("#UnitsInOrder").val();
    $("#ConteinerDiv").html(testStr+ "added");
}
