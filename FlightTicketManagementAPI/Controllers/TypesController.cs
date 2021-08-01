using FlightTicketManagementAPI.IServices;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Type = FlightTicketManagementEntites.Type;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightTicketManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private ITypeService _oTypeService;

        static ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(TypesController));

        public TypesController(ITypeService oTypeService)
        {
            _oTypeService = oTypeService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Type> Types =  _oTypeService.Gets();
                return Ok(Types);
            }
            catch(Exception ex)
            {
                log.Error("Error on GET of Types: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Type response = _oTypeService.Get(id);
                return Ok(response);
            } catch(Exception ex)
            {
                log.Error("Error on GET by ID of Types: " + ex.Message);
                return Problem(ex.Message);
            }
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Type oType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string id =_oTypeService.Save(oType);
                    //Extract substring of length 4 becasue the length in the DB is limited, return "Type" by REST conventions.
                    string uri = "https://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + id;
                    return Created(uri, oType);
                }
                log.Error("No content error at POST of types");
                return NoContent();
            } catch(Exception ex)
            {
                log.Error("Error on POST of Types: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Type oType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _oTypeService.Update(id, oType);
                    return StatusCode(204, "Type updated successfully");
                }
                log.Error("No content error at PUT of types");
                return NoContent();
            }
            catch(Exception ex)
            {
                log.Error("Error on PUT of Types: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _oTypeService.Delete(id);
                return StatusCode(204, "Type deleted successfully");
            }
            catch (Exception ex)
            {
                log.Error("Error on DELETE of Types: " + ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
