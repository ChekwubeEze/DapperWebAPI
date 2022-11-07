using Dapper;
using DapperWebApi.Interfaces;
using DapperWebApi.Models;
using Microsoft.Data.SqlClient;

namespace DapperWebApi.Services
{
    public class SuperHeroServices : ISuperHero
    {
        private readonly IConfiguration _configuration;
        private readonly string conn;

        public SuperHeroServices(IConfiguration configuration)
        {
            _configuration = configuration;
            conn = _configuration.GetSection("ConnectionStrings:SuperH").Value;
        }
        public string AddASuperHero(SuperHero superHero)
        {
            string message = string.Empty;
            using var connection = new SqlConnection(conn);
            int i = connection.Execute($"Insert Into SuperHero(Name, FirstName, LastName, Place) Values(@Name, @FirstName, @LastName, @Place)", superHero);
            if(i > 0)
            {
                message = "A Hero was successfully added";
            }
            else
            {
                message = "Error";
            }
            return message;
        }

        public string DeleteASuperHero(int id)
        {
            string message = string.Empty;
            using var connection = new SqlConnection(conn);
            int i = connection.Execute($"Delete From SuperHero Where Id = {id}");
            if(i > 0)
            {
                message = $"A Hero with ID {id} has been deleted from the database";
            }
            else
            {
                message="Error";
            }
            return message;
        }

        public List<SuperHero> GetAllSuperHeros()
        {
            using var connection = new SqlConnection(conn);
            var heros = connection.Query<SuperHero>("Select * From SuperHero");
            return heros.ToList();
        }

        public SuperHero GetASuperHeroById(int id)
        {
            using var connection = new SqlConnection(conn);
            var Hero = connection.QueryFirst<SuperHero>($"Select * From SuperHero Where Id = {id}");
            return Hero;
        }

        public string UpdateASuperHero(SuperHero superHero)
        {
            string message = string.Empty;
            using var connection = new SqlConnection(conn);
            int i = connection.Execute($"Update SuperHero Set Place = @Place Where Id = @Id", superHero);
            if(i > 0)
            {
                message = $"A Hero with ID   has changed location to ";
            }
            else
            {
                message = "Error";
            }
            return message;
        }
    }
}
