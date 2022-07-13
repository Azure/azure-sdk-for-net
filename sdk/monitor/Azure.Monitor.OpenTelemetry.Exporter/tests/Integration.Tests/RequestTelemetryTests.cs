// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Models;

using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests
{
    public class RequestTelemetryTests : IClassFixture<OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup>>
    {
        private readonly OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup> factory;
        private readonly ITestOutputHelper output;
        private readonly TelemetryItemOutputHelper telemetryOutput;

        public RequestTelemetryTests(OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup> factory, ITestOutputHelper output)
        {
            this.factory = factory;
            this.output = output;
            this.telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        /// <summary>
        /// This test validates that when an app instrumented with the AzureMonitorExporter receives an HTTP request,
        /// A TelemetryItem is created matching that request.
        /// </summary>
        [Fact]
        public async Task VerifyRequestTelemetry()
        {
            string testValue = Guid.NewGuid().ToString();

            // Arrange
            var client = this.factory.CreateClient();

            // Act
            var request = new Uri(client.BaseAddress, $"api/home/{testValue}");
            var response = await client.GetAsync(request);

            // Shutdown
            response.EnsureSuccessStatusCode();
            this.factory.WaitForActivityExport();

            // Assert
            Assert.True(this.factory.TelemetryItems.Any(), "test project did not capture telemetry");
            var telemetryItem = this.factory.TelemetryItems.Single();
            telemetryOutput.Write(telemetryItem);

            Assert.Equal("Request", telemetryItem.Name);

            Assert.Contains("ai.operation.id", telemetryItem.Tags.Keys);
            Assert.Contains("ai.user.userAgent", telemetryItem.Tags.Keys);
            Assert.Contains("ai.operation.name", telemetryItem.Tags.Keys);
            Assert.Contains("ai.location.ip", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.role", telemetryItem.Tags.Keys);
            Assert.Contains("ai.cloud.roleInstance", telemetryItem.Tags.Keys);
            Assert.Contains("ai.internal.sdkVersion", telemetryItem.Tags.Keys);

            Assert.Equal(nameof(RequestData), telemetryItem.Data.BaseType);
            var requestData = (RequestData)telemetryItem.Data.BaseData;
            Assert.Equal("200", requestData.ResponseCode);
            Assert.Equal(request.AbsoluteUri, requestData.Url);
        }
    }
}
