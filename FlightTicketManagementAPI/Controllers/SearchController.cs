using FlightTicketManagementEntites;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FlightTicketManagementAPI.Services;
using FlightTicketManagementAPI.IServices;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightTicketManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ISearchService _oSearchService;

        static ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(SearchController));

        public SearchController(ISearchService oSearchService)
        {
            _oSearchService = oSearchService;
        }

        // GET: api/<SearchController>
        [HttpGet]
        public IActionResult Get(int? pType_ID = null, float? pBase_Price = null, DateTime? pStarting_Departure = null, DateTime? pDestination_Departure = null)
        {
            try
            {
                pStarting_Departure = pStarting_Departure ?? null;
                pDestination_Departure = pDestination_Departure ?? null;

                List<Flight> Flights = _oSearchService.Gets(pType_ID, pBase_Price, pStarting_Departure, pDestination_Departure);
                return Ok(Flights);
            }
            catch (Exception ex)
            {
                log.Error("Error on search controller (GET): " + ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
