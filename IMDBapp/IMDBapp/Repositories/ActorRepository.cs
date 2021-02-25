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
    public class ActorRepository : IActorRepository
    {
        private readonly ConnectionString _connectionString;
        public ActorRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Actor> Get()
        {
            string query = 
                @" SELECT * 
                FROM Actors";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.Query<Actor>(query);
            return res;
        }

        public Actor GetById(int id)
        {
            string query = 
                @"SELECT * 
                FROM Actors 
                WHERE Id = @Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.QuerySingle<Actor>(query, new { Id = id });
            return res;
        }

        public void Post(Actor actor)
        {
            string query = 
                @"INSERT INTO 
                 Actors (
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
                    @Name = actor.Name,
                    @Gender = actor.Gender,
                    @Bio = actor.Bio,
                    @Dob = actor.DOB
                });
        }

        public void Put(int id, Actor actor)
        {
            string query = 
            @"UPDATE Actors
            SET
                Name=@Name,
                DOB=@DOB,
                Bio=@Bio,
                Gender=@Gender
            WHERE Actors.Id=@id";

           var connection = new SqlConnection(_connectionString.IMDBDB);
           connection.Execute(query, new
                {
                    id,
                    actor.Name,
                    actor.DOB,
                    actor.Bio,
                    actor.Gender
                });
        }

        public void Delete(int id)
        {
            string sql = @"
            DELETE from 
            Actors 
            WHERE Id=@Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            connection.Execute(sql, new { @Id = id });
            
        }
        public IEnumerable<Actor> GetActorsByMovieId(int id)
        {
            string query = 
            @"SELECT 
            a.Id,
            a.Name,
            a.Gender,
            a.Bio,
            a.DOB 
            FROM Actors a 
            INNER JOIN MovieActorsMapping mp 
            ON a.id=mp.ActorId 
            WHERE mp.MovieId=@Id";

            var connection = new SqlConnection(_connectionString.IMDBDB);
            var res = connection.Query<Actor>(query, new { @Id = id });
            return res; 
        }
    }
}
