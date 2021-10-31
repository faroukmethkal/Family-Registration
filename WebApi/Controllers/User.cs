using System;
using System.Threading.Tasks;
using Assignment1WebApi.Data;
using Assignment1WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1WebApi.Controllers
{
    [ApiController]
    public class Users : ControllerBase
    {
        private IServerData serverDate;

        public Users(IServerData serverDate)
        {
            this.serverDate = serverDate;
        }
        

        [HttpPost]
        [Route("api/users/register")]

        public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
        {
            try
            {
                User user1 = await serverDate.RegisterNewUser(user);
                return Ok(user1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("api/users/login")]

        public async Task<ActionResult<User>> Login([FromBody] User user)
        {
            try
            {
                User user1 = await serverDate.ValidateUser(user.Username, user.Password);
                return Ok(user1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
               return StatusCode(500, e.Message);
            }
        }


    }
}