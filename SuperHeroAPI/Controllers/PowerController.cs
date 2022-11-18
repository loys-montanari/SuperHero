using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PowerController : Controller
    {

            private static List<Powers> powers = new List<Powers>
        {
            new Powers{
                    Id =1,
                    Description = "Laser Negro",
                    Type = "Laser",
                    PowerLevel =(decimal)0.34,
                    },

            new Powers{
                    Id =2,
                    Description = "Super Rico",
                    Type = "Resources",
                    PowerLevel =(decimal)0.9,
                    }

        };


            [HttpGet]
            public async Task<ActionResult<List<Powers>>> Get()
            {
                return Ok(powers);
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<Powers>> Get(int id)
            {
                var power = powers.Find(x => x.Id == id);
                if (power == null)
                    return BadRequest("Power not found.");
                return Ok(power);
            }


            [HttpPost]
            public async Task<ActionResult<List<Powers>>> AddPower(Powers power)
            {
                powers.Add(power);
                return Ok(powers);
            }


            [HttpPut]
            public async Task<ActionResult<List<Powers>>> UpdatePower(Powers powerrequest)
            {

            if (powerrequest.PowerLevel > 1)
                return BadRequest("Desculpe, você não pode fazer isso");
                var power = powers.Find(x => x.Id == powerrequest.Id);
                if (power == null)
                    return BadRequest("Power not found.");
                power.Id = powerrequest.Id;
                power.Description = powerrequest.Description;
                power.Type = powerrequest.Type;

                power.PowerLevel = powerrequest.PowerLevel;
                return Ok(powers);
            }



        [HttpDelete("{idpower}")]
        public async Task<ActionResult<List<Powers>>> DeletePower(int idpower)
        {
            var power = powers.Find(x => x.Id == idpower);
            if (power == null)
                return BadRequest("Power not found.");

            powers.Remove(power);

            return Ok(powers);

        }


    }



}
