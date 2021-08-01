using FlightTicketManagementAPI.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using FlightTicketManagementEntites;
using log4net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightTicketManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemarksController : ControllerBase
    {
        private IRemarkService _oRemarkService;

        static ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(RemarksController));

        public RemarksController(IRemarkService oRemarkService)
        {
            _oRemarkService = oRemarkService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Remark> Remarks =  _oRemarkService.Gets();
                return Ok(Remarks);
            }
            catch(Exception ex)
            {
                log.Error("Error on GET of Remarks: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Remark response = _oRemarkService.Get(id);
                return Ok(response);
            } catch(Exception ex)
            {
                log.Error("Error on GET by ID of Remarks: " + ex.Message);
                return Problem(ex.Message);
            }
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] Remark oRemark)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string id =_oRemarkService.Save(oRemark);
                    //Extract substring of length 4 becasue the length in the DB is limited, return "Remark" by REST conventions.
                    string uri = "https://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + id;
                    return Created(uri, oRemark);
                }
                log.Error("No content error on POST of Remarks");
                return NoContent();
            } catch(Exception ex)
            {
                log.Error("Error on POST of Remarks: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Remark oRemark)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _oRemarkService.Update(id, oRemark);
                    return StatusCode(204, "Remark updated successfully");
                }
                log.Error("No content error on PUT of Remarks");
                return NoContent();
            }
            catch(Exception ex)
            {
                log.Error("Error on PUT of Remarks: " + ex.Message);
                return Problem(ex.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _oRemarkService.Delete(id);
                return StatusCode(204, "Remark deleted successfully");
            }
            catch (Exception ex)
            {
                log.Error("Error on DELETE of Remarks: " + ex.Message);
                return Problem(ex.Message);
            }
        }
    }
}
