using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMDBapp.Models;
using IMDBapp.Models.Request;
using IMDBapp.Models.Response;
using Microsoft.Extensions.Options;
using Microsoft.Data.SqlClient;
using Dapper;

namespace IMDBapp.Repositories
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly ConnectionString _connectionString;
        public ProducerRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }
        public IEnumerable<Producer> Get()
        {
            string query = 
                @"SELECT * 
                FROM Producers";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.Query<Producer>(query);
            return res;
         
        }
        public Producer GetById(int id)
        {
            string query = 
                @"SELECT * 
                FROM Producers 
                WHERE Id = @Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<Producer>(query, new { Id = id });
            return res;
        }
        public void Post(Producer producer)
        {
            string query = 
                @"INSERT INTO 
                Producers (
                 Name
                ,Gender
                ,Bio
                ,DOB
                )
                VALUES(
                   @Name
                  ,@Gender
                  ,@Bio
                  ,@DOB
                );";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(query, new
                {
                    @Name = producer.Name,
                    @Gender = producer.Gender,
                    @Bio = producer.Bio,
                    @Dob = producer.DOB
                });
        }
        public void Put(int id, Producer producer)
        {
            string query = 
            @"UPDATE 
            Producers 
            SET Name=@Name
            WHERE Id=@Id";

             var connection = new SqlConnection(_connectionString.IMDBDB);
             connection.Execute(query, new { @ID = id, @Name = producer.Name });
        }
        public void Delete(int id)
        {
            string query = 
                @"DELETE From 
                Producers 
                WHERE Id=@Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(query, new { @Id = id });
        }
    }
}
