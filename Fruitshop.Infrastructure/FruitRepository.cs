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

    }
}
