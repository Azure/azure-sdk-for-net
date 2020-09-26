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

            // TODO: HOW TO REMOVE THE WAIT?
            Task.Delay(5000).Wait();

            // I'M TRYING TO CALL SHUTDOWN TO GUARENTEE THAT THE EXPORTER IS FLUSHED WITHOUT NEEDING A WAIT.
            //this.factory.AzureMonitorTraceExporter.Shutdown();

            Assert.True(this.factory.TelemetryItems.Any(), "telemetry not captured");

            var item = this.factory.TelemetryItems.Single();
            var baseData = (Models.RequestData)item.Data.BaseData;
            Assert.True(baseData.Url.EndsWith(testNumber), "it is expected that the recorded TelemetryItem matches the value of testNumber.");

            Skip.If(true, "work in progress.");
        }
    }
}
