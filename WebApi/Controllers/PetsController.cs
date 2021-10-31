using System;
using System.Threading.Tasks;
using Assignment1WebApi.Data;
using Assignment1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1WebApi.Controllers
{
    [Route("api/pets")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IServerData serverData;

        public PetsController(IServerData serverData)
        {
            this.serverData = serverData;
        }

        [HttpGet]
        public async Task<ActionResult<Pet>> GetPet([FromQuery] int fId, int pId)
        {
            try
            {
                Pet pet = await serverData.GetPet(fId, pId);
                return Ok(pet);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostPet([FromQuery] int fId, [FromBody] Pet pet)
        {
            try
            {
                serverData.AddNewPet(fId, pet);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePet([FromQuery] int fId, [FromBody] Pet pet)
        {
            try
            {
                serverData.UpdatePet(fId, pet);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePet([FromQuery] int fId, int pId)
        {
            try
            {
                serverData.RemovePet(fId, pId);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}