using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSmart
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID  { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderRequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string ShipAddress { get; set; }
        public string ShipTown { get; set; }
        public string ShipPostalCode { get; set; }
    }
}
