using FlightTicketManagementAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FlightTicketManagementEntites;
using FlightTicketManagementEntities;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightTicketManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private IFlightService _oFlightService;

        static ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(FlightsController));

        public FlightsController(IFlightService oFlightService)
        {
            _oFlightService = oFlightService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Regular> Flights =  _oFlightService.Gets();
                return Ok(Flights);
            }
            catch(Exception ex)
            {
                log.Error("Error on Get of Flights: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                FullFlight response = _oFlightService.Get(id);
                return Ok(response);
            } catch(Exception ex)
            {
                log.Error("Error on Get by ID of Flights: " + ex.Message);
                return Problem(ex.Message);
            }
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Regular oFlight)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string id =_oFlightService.Save(oFlight);
                    //Extract substring of length 4 becasue the length in the DB is limited, return "Flight" by REST conventions.
                    string uri = "https://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + id;
                    return Created(uri, oFlight);
                }
                return NoContent();
            } catch(Exception ex)
            {
                log.Error("Error on POST of Flights: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Flight oFlight)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _oFlightService.Update(id, oFlight);
                    return StatusCode(204, "Flight updated successfully");
                }
                log.Error("No content error on PUT of flights");
                return NoContent();
            }
            catch(Exception ex)
            {
                log.Error("Error on PUT of Flights: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _oFlightService.Delete(id);
                return StatusCode(204, "Flight deleted successfully");
            }
            catch (Exception ex)
            {
                log.Error("Error on DELETE of Flights: " + ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
