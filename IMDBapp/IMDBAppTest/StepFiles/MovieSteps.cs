using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDBapp.Test
{
    [Scope(Feature = "Movie Resource")]
    [Binding]
    public class MovieSteps : BaseSteps
    {
        public MovieSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => MovieMock.MovieRepoMock.Object);
                    services.AddScoped(service => ActorMock.ActorRepoMock.Object);
                    services.AddScoped(service => GenreMock.GenreRepoMock.Object);
                    services.AddScoped(service => ProducerMock.ProducerRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            MovieMock.MockGet();
            MovieMock.MockGetById();
            MovieMock.MockAdd();
            MovieMock.MockUpdate();
            MovieMock.MockDelete();
            ActorMock.GetActorByMovieId();
            ProducerMock.GetProducerByMovieId();
            GenreMock.GetGenreByMovieId();

        }
    }
}
