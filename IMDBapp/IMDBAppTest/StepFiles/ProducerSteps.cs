using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TechTalk.SpecFlow;

namespace IMDBapp.Test
{
    [Scope(Feature = "Producer Resource")]
    [Binding]
    public class ProducerSteps : BaseSteps
    {
        public ProducerSteps(CustomWebApplicationFactory<TestStartup> factory)
            : base(factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped(service => ProducerMock.ProducerRepoMock.Object);
                });
            }))
        {
        }

        [BeforeScenario]
        public static void Mocks()
        {
            ProducerMock.MockGet();
            ProducerMock.MockGetById();
            ProducerMock.MockAdd();
            ProducerMock.MockUpdate();
            ProducerMock.MockDelete();
        }
    }
}
