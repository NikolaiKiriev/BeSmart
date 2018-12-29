using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeSmart
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Int16 UnitsInStock { get; set; }
        public Int16 UnitsInOrder { get; set; }
        public Int16 ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

    }
}
