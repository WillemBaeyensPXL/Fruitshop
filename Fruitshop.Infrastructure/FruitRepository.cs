using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Fruitshop.Domain;
using Dapper;

namespace Fruitshop.Infrastructure
{
    public class FruitRepository
    {
        private const string CONNECTIONSTRING = "Server=.\\SQLEXPRESS;Database=FruitDb;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        public IEnumerable<Fruit> LoadAllFruits()
        {
            string query = "SELECT * FROM Fruits";

            using(SqlConnection sqlConnection = new SqlConnection(CONNECTIONSTRING))
            {
                return sqlConnection.Query<Fruit>(query);
            }
        }

        public bool Delete(int id)
        {
            string sql = "DELETE FROM Fruits WHERE Id = @Id";
            using (SqlConnection sqlConnection = new SqlConnection(CONNECTIONSTRING))
            {
                int rowsAffected = sqlConnection.Execute(sql, new { Id = id});
                return rowsAffected > 0;
            }
        }

        public void Add(Fruit fruit)
        {
            string sql = """
                INSERT INTO Fruits (Id, Name, Color, Season)
                VALUES(@id, @name, @color, @season)
                """;

            fruit.Id = GetNextId();

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTIONSTRING))
            {
                sqlConnection.Execute(sql, fruit);
            }
        }
        
        public void Update(Fruit fruit)
        {
            string sql = """
                UPDATE Fruits
                SET Name = @name, Color = @color, Season = @season
                WHERE Id = @id
                """;

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTIONSTRING))
            {
                sqlConnection.Execute(sql, new { name = fruit.Name, color = fruit.Color, season = fruit.Season, id = fruit.Id });
            }
        }

        private int GetNextId()
        {
            string sql = "SELECT MAX(Id) from Fruits";

            using (SqlConnection sqlConnection = new SqlConnection(CONNECTIONSTRING))
            {
                return sqlConnection.ExecuteScalar<int>(sql)+1;
            }
        }
    }
}
