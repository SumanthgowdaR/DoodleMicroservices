using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Customer.Api.Interfaces;
using Doodle.Infrastructure.SharedModels;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("{v:apiVersion}/[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customer;

        public CustomerController(ICustomer customer)
        {
            _customer = customer;
        }


        [HttpPost]
        [ActionName("savecustomer")]

        
        public async Task<IActionResult> Customers([FromBody] Contact input)
        {
            try
            {
                var result = await _customer.Customers(input);
                return Ok(result);
            }
            catch (Exception e)
            {
                return null;
               // return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [ActionName("updatecustomer")]


        public async Task<IActionResult> UpdateCustomers([FromQuery] int userId, int leadId )
        {
            try
            {
                var result = await _customer.UpdateCustomers(userId, leadId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return null;
                // return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
