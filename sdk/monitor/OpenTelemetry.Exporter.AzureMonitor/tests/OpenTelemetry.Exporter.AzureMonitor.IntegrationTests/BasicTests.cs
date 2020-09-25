// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.Testing;

using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.IntegrationTests
{
    public class BasicTests : IClassFixture<WebApplicationFactory<WebApp.Startup>>
    {
        private readonly WebApplicationFactory<WebApp.Startup> factory;

        public BasicTests(WebApplicationFactory<WebApp.Startup> factory)
        {
            this.factory = factory;
        }

        [Fact]
        public async Task VerifyRequestSuccess()
        {
            // Arrange
            var client = this.factory.CreateClient();
            var request = new Uri(client.BaseAddress, "api/values");

            // Act
            var response = await client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.True(true);
        }

        [Fact]
        public async Task VerifyRequestFail()
        {
            // Arrange
            var client = this.factory.CreateClient();
            var request = new Uri(client.BaseAddress, "api/fail");

            // Act
            var response = await client.GetAsync(request);

            // Assert
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }
    }
}
