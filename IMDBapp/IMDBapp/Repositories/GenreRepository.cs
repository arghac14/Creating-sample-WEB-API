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
    public class GenreRepository : IGenreRepository
    {
        private readonly ConnectionString _connectionString;
        public GenreRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }
        public IEnumerable<Genre> Get()
        {
            string query = 
                @"SELECT * 
                FROM Genres";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.Query<Genre>(query);
            return res;
        }
        public Genre GetById(int id)
        {
            string query = 
                @"SELECT * 
                FROM Genres 
                WHERE Id = @Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<Genre>(query, new { Id = id });
            return res;
        }
        public void Post(Genre genre)
        {
            string query = 
                @"INSERT INTO 
                Genres (Name)
                VALUES(@Name)";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(query, new { @Name = genre.Name });
        }
        public void Put(int id, Genre genre)
        {
            string query = 
                @"UPDATE Genres 
                  SET Name=@Name
                  WHERE Id=@Id";
            
            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(query, new { @ID = id, @Name = genre.Name });
        }

        public void Delete(int id)
        {
            string query = 
                @"DELETE From 
                Genres 
                WHERE Id=@Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(query, new { @Id = id });
        }

        public IEnumerable<Genre> GetGenresByMovieId(int id)
        {
            string query = 
                @"SELECT 
                g.Id,
                g.Name 
                FROM 
                Genres g 
                INNER JOIN MovieGenresMapping mg 
                ON g.id=mg.GenreId 
                AND mg.MovieId=@Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.Query<Genre>(query, new { Id = id });
            return res;
            
        }
    }
}
