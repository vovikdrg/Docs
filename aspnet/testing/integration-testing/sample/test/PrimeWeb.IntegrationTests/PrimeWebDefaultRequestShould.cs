using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PrimeWeb.IntegrationTests
{
    public class PrimeWebDefaultRequestShould
    {
        private TestServer _server;
        public PrimeWebDefaultRequestShould()
        {
            // Arrange
            _server = TestServer.Create(new Startup().Configure);
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _server.CreateClient().GetAsync("/");
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal("Hello World!",
                responseString);
        }
    }
}
