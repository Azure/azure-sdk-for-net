// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.AspNetCoreWebApp;
using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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

#if !NET461
        /// <summary>
        /// This test validates that when an app instrumented with the AzureMonitorExporter receives an HTTP request,
        /// A TelemetryItem is created matching that request.
        /// </summary>
        [Fact]
        public async Task VerifyRequestTelemetry()
        {
            string testValue = Guid.NewGuid().ToString();

            ConcurrentBag<TelemetryItem>? telemetryItems = null;

            // Arrange
            var client = this.factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureTestServices(services =>
                    {
                        services.AddOpenTelemetry().WithTracing(builder => builder
                            .AddAspNetCoreInstrumentation()
                            .AddAzureMonitorTraceExporterForTest(out telemetryItems));
                        ;
                    }))
                .CreateClient();

            // Act
            var request = new Uri(client.BaseAddress!, $"api/home/{testValue}");
            var response = await client.GetAsync(request);

            // Shutdown
            response.EnsureSuccessStatusCode();
            Assert.NotNull(telemetryItems);
            this.WaitForActivityExport(telemetryItems);

            // Assert
            Assert.True(telemetryItems.Any(), "test project did not capture telemetry");
            var telemetryItem = telemetryItems.Single();
            this.telemetryOutput.Write(telemetryItem);

            AssertRequestTelemetry(
                telemetryItem: telemetryItem,
                expectedResponseCode: "200",
                expectedUrl: request.AbsoluteUri);
        }
#endif
    }
}
