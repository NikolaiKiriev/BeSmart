using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BeSmart;


namespace BeSmart.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        [HttpGet]        
        public List<Customer> GetCustomers()
        {
            return DB.GetCustomers();
        }
        
    }
}