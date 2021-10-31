using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1WebApi.Data;
using Assignment1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1WebApi.Controllers
{
    [Route("api/adults")]
    [ApiController]
    public class Adults : ControllerBase
    {
       

        private IServerData serverData;

        public Adults(IServerData serverData)
        {
            this.serverData = serverData;
        }

        [HttpGet]
        public async Task<ActionResult<Adult>> GetAdult([FromQuery] int fId, int aId)
        {

            try
            {
            
                Adult adult = await serverData.GetAdult(fId, aId);

                return Ok(adult);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostAdult([FromQuery] int fId, [FromBody] Adult adult)
        {
            try
            {

                serverData.AddNewAdult(fId,adult);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpPut]
        public async Task<ActionResult> UpdateAdult([FromQuery] int fId, [FromBody] Adult adult)
        {
            try
            {
                serverData.UpdateAdult(fId, adult);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
        
        [HttpDelete]
        public async Task<ActionResult> DeleteAdult([FromQuery] int fId, int aId)
        {
            try
            {
                serverData.RemoveAdult(fId, aId);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}