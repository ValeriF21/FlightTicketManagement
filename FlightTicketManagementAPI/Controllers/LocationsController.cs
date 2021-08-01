using FlightTicketManagementAPI.IServices;
using Location = FlightTicketManagementEntites.Location;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightTicketManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private ILocationService _oLocationService;

        static ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(LocationsController));
        public LocationsController(ILocationService oLocationService)
        {
            _oLocationService = oLocationService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Location> locations = _oLocationService.Gets();
                return Ok(locations);
            }
            catch(Exception ex)
            {
                log.Error("Error on GET of Locations: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{pCode}")]
        public IActionResult Get(string pCode)
        {
            try
            {
                Location response = _oLocationService.Get(pCode);
                return Ok(response);
            } catch(Exception ex)
            {
                log.Error("Error on GET by ID of Locations: " + ex.Message);
                return Problem(ex.Message);
            }
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Location oLocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _oLocationService.Save(oLocation);
                    //Extract substring of length 4 becasue the length in the DB is limited, return "location" by REST conventions.
                    string uri = "https://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + oLocation.Code.Substring(0, 4);
                    return Created(uri, oLocation);
                }
                log.Error("No content error on POST of Locations");
                return NoContent();
            } catch(Exception ex)
            {
                log.Error("Error on POST of Locations: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{pCode}")]
        public IActionResult Put(string pCode, [FromBody] Location oLocation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _oLocationService.Update(pCode, oLocation);
                    return StatusCode(204, "Location updated successfully");
                }
                log.Error("No content error on PUT of Locations");
                return NoContent();
            }
            catch(Exception ex)
            {
                log.Error("Error on PUT of Locations: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{pCode}")]
        public IActionResult Delete(string pCode)
        {
            try
            {
                _oLocationService.Delete(pCode);
                return StatusCode(204, "Location deleted successfully");
            }
            catch (Exception ex)
            {
                log.Error("Error on DELETE of Locations: " + ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
