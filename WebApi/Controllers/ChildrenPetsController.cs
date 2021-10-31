using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment1WebApi.Data;
using Assignment1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1WebApi.Controllers
{
    [Route("api/children/pets")]
    [ApiController]
    public class ChildrenPetsController : ControllerBase
    {
        private IServerData serverData;

        public ChildrenPetsController(IServerData serverData)
        {
            this.serverData = serverData;
        }

        [HttpGet]
        public async Task<ActionResult<Pet>> GetChildPet([FromQuery] int fId, int cId, int pId)
        {
            try
            {
                Pet pet = await serverData.GetChildPet(fId, cId, pId);

                return Ok(pet);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostChildPet([FromQuery] int fId, int cId, [FromBody] Pet pet)
        {
            try
            {
                serverData.AddNewChildPet(fId, cId, pet);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateChildrenPet([FromQuery] int fId, int cId, [FromBody] Pet pet)
        {
            try
            {
                serverData.UpdateChildPet(fId, cId, pet);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete]
        public async Task<ActionResult> DeletePet([FromQuery] int fId, int cId, int pId)
        {
            try
            {
                serverData.RemoveChildPet(fId, cId, pId);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}