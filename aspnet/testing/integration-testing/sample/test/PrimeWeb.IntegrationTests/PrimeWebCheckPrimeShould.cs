using Microsoft.AspNet.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PrimeWeb.IntegrationTests
{
    public class PrimeWebCheckPrimeShould
    {
        private TestServer _server;
        public PrimeWebCheckPrimeShould()
        {
            // Arrange
            _server = TestServer.Create(new Startup().Configure);
        }

        private async Task<string> GetCheckPrimeResponseString(string querystring = "")
        {
            string request = "/checkprime";
            if(!String.IsNullOrEmpty(querystring))
            {
                request += "?" + querystring;
            }
            var response = await _server.CreateClient().GetAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        [Fact]
        public async Task ReturnInstructionsGivenEmptyQueryString()
        {
            // Act
            var responseString = await GetCheckPrimeResponseString();

            // Assert
            Assert.Equal("Pass in a number to check in the form /checkprime?5",
                responseString);
        }
        [Fact]
        public async Task ReturnPrimeGiven5()
        {
            // Act
            var responseString = await GetCheckPrimeResponseString("5");

            // Assert
            Assert.Equal("5 is prime!",
                responseString);
        }

        [Fact]
        public async Task ReturnNotPrimeGiven6()
        {
            // Act
            var responseString = await GetCheckPrimeResponseString("6");

            // Assert
            Assert.Equal("6 is NOT prime!",
                responseString);
        }
    }
}
