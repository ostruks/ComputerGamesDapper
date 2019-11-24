using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DAL.Models;

namespace DAL
{
    public class GenreRepository : IRepository<Genre>
    {
        string _connectionString = "Data Source=.;Initial Catalog=ComputerGames;Integrated Security=True;";
        public List<Genre> GetAll(int license)
        {
            List<Genre> genres = new List<Genre>();
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                genres = db.Query<Genre>(
                    "SELECT Id, Genre as Name FROM Genre").ToList();
            }
            return genres;
        }

        public Genre Get(int id)
        {
            Genre genre = null;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                genre = db.Query<Genre>("SELECT Id, Genre as Name FROM Genre WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return genre;
        }

        public Genre Create(Genre genre)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = $"INSERT INTO Genre (Genre, Description) VALUES(@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
                int genreId = db.Query<int>(sqlQuery, genre).FirstOrDefault();
                genre.Id = genreId;
            }
            return genre;
        }

        public void Update(Genre genre)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Genre SET Genre = @Name, Description = @Description WHERE Id = @Id";
                db.Execute(sqlQuery, genre);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Genre WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public void Delete(Genre genre)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Genre WHERE Id = @Id";
                db.Execute(sqlQuery, new { genre.Id });
            }
        }
    }
}
