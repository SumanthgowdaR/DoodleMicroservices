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
    public class LeadController : ControllerBase
    {
        private readonly ILeadRepo _lead;

        public LeadController(ILeadRepo lead)
        {
            _lead = lead;
        }


        [HttpPost]
        [ActionName("saveleadbycustomer")]
        

        public async Task<IActionResult> ContactbasedOnLead([FromBody] ContactAndLogs input)
        {
            try
            {
                var result = await _lead.ContactbasedOnLead(input);
                return Ok(result);
            }
            catch (Exception e)
            {
                return null;
                // return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [ActionName("currentstatusvalue")]


        public async Task<IActionResult> GetCurrentStatusValue(int? userId = null)
        {
            try
            {
                var result = await _lead.GetCurrentStatusValue(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return null;
                // return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [ActionName("leadsourcevalue")]


        public async Task<IActionResult> GetLeadSourceValue(int? userId = null)
        {
            try
            {
                var result = await _lead.GetLeadSourceValue(userId);
                return Ok(result);
            }
            catch (Exception e)
            {
                return null;
                // return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [ActionName("communicationlogs")]


        public async Task<IActionResult> GetCommunicationLogs(int? userId = null)
        {
            try
            {
                var result = await _lead.GetCommunicationLogs(userId);
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
