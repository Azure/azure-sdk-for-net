// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.IntegrationTests
{
    public class OpenTelemetryTests : IClassFixture<OpenTelemetryWebApplicationFactory<WebApp.Startup>>
    {
        private readonly OpenTelemetryWebApplicationFactory<WebApp.Startup> factory;

        public OpenTelemetryTests(OpenTelemetryWebApplicationFactory<WebApp.Startup> factory)
        {
            this.factory = factory;
        }

        [SkippableFact]
        public async Task ProofOfConcept()
        {
            string testNumber = "123456";

            // Arrange
            var client = this.factory.CreateClient();
            var request = new Uri(client.BaseAddress, $"api/home/{testNumber}");

            // Act
            var response = await client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();

            Assert.True(this.factory.TelemetryItems.Any(), "telemetry not captured");

            // TODO: EVALUATE TELEMETRY ITEMS
            Skip.If(true, "work in progress.");
        }
    }
}
