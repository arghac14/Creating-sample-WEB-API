using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDBapp.Test
{
    [Scope(Feature = "Genre Resource")]
    [Binding]
    public class GenreSteps : BaseSteps
    {
        public GenreSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => GenreMock.GenreRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            GenreMock.MockGet();
            GenreMock.MockGetById();
            GenreMock.MockAdd();
            GenreMock.MockUpdate();
            GenreMock.MockDelete();
        }
    }
}
