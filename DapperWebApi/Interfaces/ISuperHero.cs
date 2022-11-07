using DapperWebApi.Models;

namespace DapperWebApi.Interfaces
{
    public interface ISuperHero
    {
        SuperHero GetASuperHeroById(int id);
        List<SuperHero> GetAllSuperHeros();
        string DeleteASuperHero(int id);
        string AddASuperHero(SuperHero superHero);
        string UpdateASuperHero(SuperHero superHero);
    }
}
