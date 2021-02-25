using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.Extensions.DependencyInjection;
using IMDBapp;

namespace IMDBapp.Test
{
    [Scope(Feature = "Actor Resource")]
    [Binding]
    public class ActorSteps : BaseSteps
    {
        public ActorSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => ActorMock.ActorRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ActorMock.MockGet();
            ActorMock.MockGetById();
            ActorMock.MockAdd();
            ActorMock.MockUpdate();
            ActorMock.MockDelete();
        }
    }
}
