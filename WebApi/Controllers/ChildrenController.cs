using System;
using System.Threading.Tasks;
using Assignment1WebApi.Data;
using Assignment1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1WebApi.Controllers
{
    [Route("api/children")]
    [ApiController]
    public class ChildrenController : ControllerBase
    {
        private IServerData _serverData;

        public ChildrenController(IServerData serverData)
        {
            _serverData = serverData;
        }

        [HttpGet]
        public async Task<ActionResult<Child>> GetChild([FromQuery] int fId, int id)
        {
            try
            {
                Child child = await _serverData.GetChild(fId, id);

                return Ok(child);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostChild([FromQuery] int fId, [FromBody] Child child)
        {
            try
            {
                _serverData.AdNewChild(fId, child);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutChild([FromQuery] int fId, [FromBody] Child child)
        {
            try
            {
                _serverData.UpdateChild(fId, child);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteChild([FromQuery] int fId, int cId)
        {
            try
            {
                _serverData.RemoveChild(fId, cId);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}