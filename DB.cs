using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace BeSmart
{
    public class DB
    {
        private static string CONN_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = BeSmartDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //-------------CUSTOMERS-------------//
        //-----------------------------------//
        //-----------------------------------//
        //-------------GET CUSTOMERS LIST----//
        public static List<Customer> GetCustomers()
        {
            string fN, lN, address, city, postalCode, phone, fax;
            int ID;
            List<Customer> customers = new List<Customer>();
            using (SqlConnection conn = new SqlConnection(DB.CONN_STRING))
            using (SqlCommand cmd = new SqlCommand(@"SELECT * FROM Customers", conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr.IsDBNull(0) == true || dr.GetInt32(0).ToString().Length < 1) throw new Exception("Illigal ID");
                    else ID = dr.GetInt32(0);
                    if (dr.IsDBNull(1) == true || dr.GetString(1).Length <= 1) throw new Exception("illigal first name");
                    else fN = dr.GetString(1);
                    if (dr.IsDBNull(2) == true || dr.GetString(2).Length <= 1) throw new Exception("illigal last name");
                    lN = dr.GetString(2);
                    if (dr.IsDBNull(3) == true || dr.GetString(3).Length <= 3) throw new Exception("illigal address");
                    else address = dr.GetString(3);
                    if (dr.IsDBNull(4) == true) throw new Exception("illigal city");
                    else city = dr.GetString(4);
                    if (dr.IsDBNull(5) == true || dr.GetString(5).Length <= 4) postalCode = "  ";
                    else postalCode = dr.GetString(5);
                    if (dr.IsDBNull(6) == true) throw new Exception("phone needed");
                    phone = dr.GetString(6);
                    if (dr.IsDBNull(7) == true) fax = "no fax";
                    else fax = dr.GetString(7);
                    Customer customer = new Customer()
                    {
                        CustomerID = ID,
                        CustomerFirstName = fN,
                        CustomerLastName = lN,
                        Address = address,
                        City = city,
                        PostalCode = postalCode,
                        Phone = phone,
                        Fax = fax
                    };
                    customers.Add(customer);
                }
            }
            return customers;
        }
        //------------PRODUCTS---------------//
        //-----------------------------------//
        //-----------------------------------//
        //-----------GET PRODUCTS LIST-------//
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            int productID;
            string productName;
            decimal price;
            Int16 unitsInStock, unitsInOrder, reorderLevel;
            bool discontinued;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    productID = dr.IsDBNull(0) ? throw new Exception("illigal ID") : dr.GetInt32(0);
                    productName = dr.IsDBNull(1) ? throw new Exception("Product name is missing!") : dr.GetString(1);
                    price = dr.IsDBNull(2) ? throw new Exception("null price, cant get free stuff here :)") : dr.GetDecimal(2);
                    unitsInStock = dr.IsDBNull(3) ? throw new Exception("null units in stock") : dr.GetInt16(3);
                    unitsInOrder = dr.IsDBNull(4) ? (Int16)0 : dr.GetInt16(4);
                    reorderLevel = dr.IsDBNull(5) ? (Int16)0 : dr.GetInt16(5);
                    discontinued = dr.IsDBNull(6) ? false : dr.GetBoolean(6);
                    Product product = new Product()
                    {
                        ProductID = productID,
                        ProductName = productName,
                        Price = price,
                        UnitsInStock = unitsInStock,
                        UnitsInOrder = unitsInOrder,
                        ReorderLevel = reorderLevel,
                        Discontinued = discontinued
                    };
                    products.Add(product);
                }
            }

            return products;
        }
        //------------ORDERS-----------------//
        //-----------------------------------//
        //-----------------------------------//
        //---------GET ORDERS LIST-----------//
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            int orderID, customerID, productID;
            DateTime orderDate, orderRequiredDate, shippedDate;
            decimal freight;
            string shipAddress, shipTown, shipPostalcode;
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            using (SqlCommand cmd = new SqlCommand("Select * FROM Orders", conn))
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    orderID = dr.IsDBNull(0) ? throw new Exception("null OrderID") : dr.GetInt32(0);
                    customerID = dr.IsDBNull(1) ? throw new Exception("null customerID") : dr.GetInt32(1);
                    productID = dr.IsDBNull(2) ? throw new Exception("null ProductID") : dr.GetInt32(2);
                    orderDate = dr.IsDBNull(3) ? throw new Exception("null orderDate") : dr.GetDateTime(3);
                    orderRequiredDate = dr.IsDBNull(4) ? throw new Exception("null OrderRequiredDate") : dr.GetDateTime(4);
                    shippedDate = dr.IsDBNull(5) ? throw new Exception("null ShippedDate") : dr.GetDateTime(5);
                    freight = dr.IsDBNull(6) ? (decimal)0 : dr.GetDecimal(6);
                    shipAddress = dr.IsDBNull(7) ? "no address" : dr.GetString(7);
                    shipTown = dr.IsDBNull(8) ? "no ShipTown" : dr.GetString(8);
                    shipPostalcode = dr.IsDBNull(9) ? "no postalCode!" : dr.GetString(9);
                    Order order = new Order()
                    {
                        OrderID = orderID,
                        CustomerID = customerID,
                        ProductID = productID,
                        OrderDate = orderDate,
                        OrderRequiredDate = orderRequiredDate,
                        ShippedDate = shippedDate,
                        Freight = freight,
                        ShipAddress = shipAddress,
                        ShipTown = shipTown,
                        ShipPostalCode = shipPostalcode
                    };
                    orders.Add(order);
                }
            }

            return orders;
        }
    }
}
