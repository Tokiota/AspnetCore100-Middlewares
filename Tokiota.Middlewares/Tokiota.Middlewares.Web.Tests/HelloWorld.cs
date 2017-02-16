namespace Tokiota.Middlewares.Web.Tests
{
    using System.Net.Http;
    using Xunit;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;
    using Middewares.Web;

    public class HelloWorld
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public HelloWorld()
        {
            _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task TestHelloWorldMiddlewareWorks()
        {
            // Act
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            // Assert
            Assert.True(responseString.Contains("Hello World!"));
        }
    }
}
