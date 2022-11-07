using DapperWebApi.Interfaces;
using DapperWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHero _superHero;

        public SuperHeroController(ISuperHero superHero)
        {
            _superHero = superHero;
        }
        [HttpGet("Get-All-SuperHeros")]
        public List<SuperHero> GetAllSuperHeros()
        {
            List<SuperHero> superheros = new List<SuperHero>();
            superheros = _superHero.GetAllSuperHeros();
            return superheros;
        }
        [HttpGet("Get-A-Hero")]
        public SuperHero GetAGero([FromQuery]int id)
        {
            SuperHero hero = new SuperHero();
            hero = _superHero.GetASuperHeroById( id);
            return hero;
        }
        [HttpPost("Add-A-Hero")]
        public string AddASuperHero([FromQuery]SuperHero superHero)
        {
           string message = _superHero.AddASuperHero(superHero);
            return message;
        }
        [HttpDelete("Delete-Hero")]
        public string Delete([FromQuery] int id)
        {
            string message = _superHero.DeleteASuperHero(id);
            return message;
        }
        [HttpPut("Update-Hero")]
        public string UpdateASuperHero([FromQuery]SuperHero superHero)
        {
            string message = _superHero.UpdateASuperHero(superHero);
            return message; 
        }
    }
}
