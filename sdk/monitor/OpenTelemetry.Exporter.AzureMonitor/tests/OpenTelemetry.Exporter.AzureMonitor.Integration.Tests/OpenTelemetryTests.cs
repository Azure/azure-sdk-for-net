// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor.Integration.Tests
{
    public class OpenTelemetryTests : IClassFixture<OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup>>
    {
        private readonly OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup> factory;

        public OpenTelemetryTests(OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup> factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// This test validates that when an app instrumented with the AzureMonitorExporter receives an HTTP request,
        /// A TelemetryItem is created matching that request.
        /// </summary>
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
            Assert.True(this.factory.TelemetryItems.Any(), "test project did not capture telemetry");

            var item = this.factory.TelemetryItems.Single();
            var baseData = (Models.RequestData)item.Data.BaseData;
            Assert.True(baseData.Url.EndsWith(testValue), "it is expected that the recorded TelemetryItem matches the value of testValue.");
        }
    }
}
