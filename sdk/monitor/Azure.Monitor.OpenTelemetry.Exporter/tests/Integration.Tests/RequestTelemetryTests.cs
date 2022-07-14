// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.AspNetCoreWebApp;
using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework;

using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;

using OpenTelemetry;
using OpenTelemetry.Trace;

using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests
{
    public class RequestTelemetryTests : WebApplicationTestsBase
    {
        public RequestTelemetryTests(WebApplicationFactory<Startup> factory, ITestOutputHelper output) : base(factory, output)
        {
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
            var transmitter = new MockTransmitter();
            var activityProcessor = new SimpleActivityExportProcessor(new AzureMonitorTraceExporter(transmitter));
            var client = this.factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureTestServices(services =>
                    {
                        services.AddOpenTelemetryTracing((builder) => builder
                            .AddAspNetCoreInstrumentation()
                            .AddProcessor(activityProcessor));
                    }))
                .CreateClient();

            // Act
            var request = new Uri(client.BaseAddress, $"api/home/{testValue}");
            var response = await client.GetAsync(request);

            // Shutdown
            response.EnsureSuccessStatusCode();
            this.WaitForActivityExport(transmitter.TelemetryItems);

            // Assert
            Assert.True(transmitter.TelemetryItems.Any(), "test project did not capture telemetry");
            var telemetryItem = transmitter.TelemetryItems.Single();
            this.telemetryOutput.Write(telemetryItem);

            AssertRequestTelemetry(
                telemetryItem: telemetryItem,
                expectedResponseCode: "200",
                expectedUrl: request.AbsoluteUri);
        }
    }
}
