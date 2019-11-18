using Dapper;
using Library;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GameRepo
{
    public class GenreRepository : IRepository<Genre>
    {
        string connectionString = "Data Source=.;Initial Catalog=ComputerGames;Integrated Security=True;";
        public List<Genre> GetAll(int license)
        {
            List<Genre> genres = new List<Genre>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                genres = db.Query<Genre>(
                    "SELECT Id, Genre as Name FROM Genre").ToList();
            }
            return genres;
        }

        public Genre Get(int id)
        {
            Genre genre = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                genre = db.Query<Genre>("SELECT Id, Genre as Name FROM Genre WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return genre;
        }

        public Genre Create(Genre genre)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $"INSERT INTO Genre (Genre, Description) VALUES(@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
                int genreId = db.Query<int>(sqlQuery, genre).FirstOrDefault();
                genre.Id = genreId;
            }
            return genre;
        }

        public void Update(Genre genre)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Genre SET Genre = @Name, Description = @Description WHERE Id = @Id";
                db.Execute(sqlQuery, genre);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Genre WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
