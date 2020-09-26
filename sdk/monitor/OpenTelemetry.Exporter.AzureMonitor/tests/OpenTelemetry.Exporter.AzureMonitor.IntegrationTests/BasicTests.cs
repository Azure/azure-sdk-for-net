// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.IntegrationTests
{
    /// <summary>
    /// These tests are to verify that the IntegrationTests work (i.e. Tests app can talk to WebApp).
    /// </summary>
    public class BasicTests : IClassFixture<WebApplicationFactory<WebApp.Startup>>
    {
        private readonly WebApplicationFactory<WebApp.Startup> factory;

        public BasicTests(WebApplicationFactory<WebApp.Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData(HttpStatusCode.OK)]
        [InlineData(HttpStatusCode.BadRequest)]
        public async Task VerifyRequest(HttpStatusCode httpStatusCode)
        {
            // Arrange
            var client = this.factory.CreateClient();
            var request = new Uri(client.BaseAddress, $"api/statuscode/{(int)httpStatusCode}");

            // Act
            var response = await client.GetAsync(request);

            // Assert
            Assert.Equal(httpStatusCode, response.StatusCode);
        }

        [Fact]
        public void ProofOfConcept()
        {
            Assert.True(true);

            //services.AddOpenTelemetryTracing((builder) => builder
            //            .AddAspNetCoreInstrumentation()
            //            .AddHttpClientInstrumentation()
            //            .AddConsoleExporter());
        }
    }
}
