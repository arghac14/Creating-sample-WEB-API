using System;
using System.Data;
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
    public class MovieRepository : IMovieRepository
    {

        private readonly ConnectionString _connectionString;
        public MovieRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Movie> Get()
        {
            string query = 
                @"SELECT *
                FROM Movies";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.Query<Movie>(query);
            return res;
        }

        public Movie GetById(int id)
        {
            string query =
                @"SELECT * 
                FROM Movies 
                WHERE Id = @Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<Movie>(query, new { Id = id });
            return res;
        }

        public void Post(Movie movie, List<int> actor, List<int> genre)
        {
            var connection = new SqlConnection(_connectionString.IMDBDB);
            var procedure = @"usp_insertMovie";
            var values = new {
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Poster = movie.Poster,
                ProducerId = movie.ProducerId,
                Actors = string.Join(",", actor),
                Genres = string.Join(",", genre)
            };
            connection.Execute(procedure, values, commandType: CommandType.StoredProcedure);
        }

        public void Put(int id, Movie movie, List<int> actor, List<int> genre)
        {    
            var connection = new SqlConnection(_connectionString.IMDBDB);
            var procedure = @"usp_updateMovie";
            var values = new
            {
                Id = id,
                Name = movie.Name,
                YearOfRelease = movie.YearOfRelease,
                Plot = movie.Plot,
                Poster = movie.Poster,
                ProducerId = movie.ProducerId,
                Actors = string.Join(",", actor),
                Genres = string.Join(",", genre)
            };
            connection.Execute(procedure, values, commandType: CommandType.StoredProcedure);
        }

        public void Delete(int id)
        {
            string query = 
                @"DELETE
                FROM MovieActorsMapping
                WHERE MovieId = @id
                DELETE
                FROM MovieGenresMapping
                WHERE MovieId = @id
                DELETE
                FROM Movies
                WHERE Id = @id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(query, new { Id = id });
        }

    }
}
