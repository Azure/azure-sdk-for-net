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

        [Fact]
        public async Task ProofOfConcept()
        {
            string testValue = Guid.NewGuid().ToString();

            // Arrange
            var client = this.factory.CreateClient();
            var request = new Uri(client.BaseAddress, $"api/home/{testValue}");

            // Act
            var response = await client.GetAsync(request);

            // Shutdown
            response.EnsureSuccessStatusCode();
            this.factory.ForceFlush();

            // Assert
            Assert.True(this.factory.TelemetryItems.Any(), "telemetry not captured");

            var item = this.factory.TelemetryItems.Single();
            var baseData = (Models.RequestData)item.Data.BaseData;
            Assert.True(baseData.Url.EndsWith(testValue), "it is expected that the recorded TelemetryItem matches the value of testValue.");
        }
    }
}
