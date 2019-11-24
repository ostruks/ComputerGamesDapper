using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DAL.Models;

namespace DAL
{
    public class GameRepository : IRepository<Game>
    {
        string _connectionString = "Data Source=.;Initial Catalog=ComputerGames;Integrated Security=True;";

        public List<Game> GetAll(int license)
        {
            List<Game> games = new List<Game>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                games = license != 0 ? db.Query<Game>(
                    "SELECT g.Id, g.[Name], g.YearOfIssue, g.Genre_Id, g.Publisher_Id FROM Game g"
                    + " LEFT JOIN Publisher p ON p.Id = g.Publisher_Id"
                    + " WHERE p.License = @license", new { license }).ToList() : 
                    db.Query<Game>("SELECT * FROM Game").ToList();
            }
            return games;
        }

        public Game Get(int id)
        {
            Game game = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                game = db.Query<Game>("SELECT * FROM Game WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return game;
        }

        public Game Create(Game game)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Game (Name, YearOfIssue, Genre_Id, Publisher_Id) VALUES(@Name, @YearOfIssue, @Genre_Id, @Publisher_Id); SELECT CAST(SCOPE_IDENTITY() as int)";
                int gameId = db.Query<int>(sqlQuery, game).FirstOrDefault();
                game.Id = gameId;
            }
            return game;
        }

        public void Update(Game game)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Game SET Name = @Name, YearOfIssue = @YearOfIssue, Genre_Id = @Genre_Id, Publisher_Id = @Publisher_Id WHERE Id = @Id";
                db.Execute(sqlQuery, game);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Game WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public void Delete(Game game)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Game WHERE Id = @Id";
                db.Execute(sqlQuery, new { game.Id });
            }
        }
    }
}
