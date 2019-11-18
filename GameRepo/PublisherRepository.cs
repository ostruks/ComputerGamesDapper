using Dapper;
using Library;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace GameRepo
{
    public class PublisherRepository : IRepository<Publisher>
    {
        string connectionString = "Data Source=.;Initial Catalog=ComputerGames;Integrated Security=True;";
        public List<Publisher> GetAll(int license)
        {
            List<Publisher> genres = new List<Publisher>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                genres = db.Query<Publisher>(
                    "SELECT * FROM Publisher").ToList();
            }
            return genres;
        }

        public Publisher Get(int id)
        {
            Publisher publisher = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                publisher = db.Query<Publisher>("SELECT * FROM Publisher WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return publisher;
        }

        public Publisher Create(Publisher publisher)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Publisher (Name, License) VALUES(@Name, @License); SELECT CAST(SCOPE_IDENTITY() as int)";
                int publisherId = db.Query<int>(sqlQuery, publisher).FirstOrDefault();
                publisher.Id = publisherId;
            }
            return publisher;
        }

        public void Update(Publisher publisher)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Publisher SET Name = @Name WHERE Id = @Id";
                db.Execute(sqlQuery, publisher);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Publisher WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
