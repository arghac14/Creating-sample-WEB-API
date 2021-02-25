using System;
using System.Net;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.Threading.Tasks;

namespace IMDBapp.Test
{
    [Binding]
    public class BaseSteps
    {
        protected WebApplicationFactory<TestStartup> Factory;
        protected HttpClient Client { get; set; }
        protected HttpResponseMessage Response { get; set; }

        public BaseSteps(WebApplicationFactory<TestStartup> baseFactory)
        {
            // instance of webapplication factory provided through Dependency Injection
            Factory = baseFactory;
        }
            
        [Given(@"I am a client")]
        public void GivenIAmAClient()
        {
            // Create a test client using the factory instance
            Client = Factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                // The base address of the test server 
                BaseAddress = new Uri($"http://localhost/")
            });
        }
        
        [When(@"I make GET Request '(.*)'")]
        public virtual async Task WhenIMakeGETRequest(string resourceEndpoint)
        {
            // use the client created to make the GET request
            var uri = new Uri(resourceEndpoint, UriKind.Relative);

            ///Assigning the reponse to the global variable '_response' to be validated in the next steps
            Response = await Client.GetAsync(uri);
        }
        
        [Then(@"response code must be '(.*)'")]
        public void ThenResponseCodeMustBe(int statusCode)
        {
            var expectedStatusCode = (HttpStatusCode)statusCode;
            Assert.Equal(expectedStatusCode, Response.StatusCode);
        }
        
        [Then(@"response data must look like '(.*)'")]
        public void ThenResponseDataMustLookLike(string data)
        {
            var responseData = Response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Assert.Equal(data, responseData);
        }

        [When(@"I make POST request to '(.*)' with data '(.*)'")]
        public virtual async Task WhenIMakePOSTRequestToWithData(string resourceEndPoint,
            string postDataJson)
        {
            var uri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(postDataJson, Encoding.UTF8, "application/json");
            Response = await Client.PostAsync(uri, content);
        }

        [When(@"I make PUT Request '(.*)' with data '(.*)'")]
        public virtual async Task WhenIMakePUTRequestWithData(string resourceEndPoint,
            string putDataJson)
        {

            var uri = new Uri(resourceEndPoint, UriKind.Relative);
            var content = new StringContent(putDataJson, Encoding.UTF8, "application/json");
            Response = await Client.PutAsync(uri, content);
        }

        [When(@"I make Delete Request '(.*)'")]
        public virtual async Task WhenIMakeDeleteRequest(string resourceEndPoint)
        {
            var uri = new Uri(resourceEndPoint, UriKind.Relative);
            Response = await Client.DeleteAsync(uri);
        }
    }
}
