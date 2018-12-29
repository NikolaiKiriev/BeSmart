using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSmart
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        /*
        public Customer(int CustomerID , string CustomerFristName, string CustomerLastName, string Address, string City, string PostalCode, string Phone, string Fax)
        {

            this.CustomerID = CustomerID;
            //this.CustomerFirstName = CustomerFirstName;
            this.CustomerLastName = CustomerLastName;
            this.Address = Address;
            this.City = City;
            this.PostalCode = PostalCode;
            this.Phone = Phone;
            this.Fax = Fax;
        }
        public Customer(string CustomerFristName, string CustomerLastName, string Address, string City, string PostalCode, string Phone, string Fax)
        {
            //this.CustomerFirstName = CustomerFirstName;
            this.CustomerLastName = CustomerLastName;
            this.Address = Address;
            this.City = City;
            this.PostalCode = PostalCode;
            this.Phone = Phone;
            this.Fax = Fax;
        }
        */
    }
}
