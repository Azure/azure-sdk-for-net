// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Trace;

using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.Exporter.Integration.Tests
{
    public class RequestTelemetryTests : WebApplicationTestsBase
    {
        private const string TestServerUrl = "http://localhost:9997/";

        public RequestTelemetryTests(ITestOutputHelper output) : base(output)
        {
        }

#if !NET462
        /// <summary>
        /// This test validates that when an app instrumented with the AzureMonitorExporter receives an HTTP request,
        /// A TelemetryItem is created matching that request.
        /// </summary>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public async Task VerifyRequestTelemetry(bool testNewSemanticConventions)
        {
            string testValue = Guid.NewGuid().ToString();

            List<TelemetryItem>? telemetryItems = null;

            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            var builder = WebApplication.CreateBuilder();

            if (testNewSemanticConventions)
            {
                //Environment.SetEnvironmentVariable("OTEL_SEMCONV_STABILITY_OPT_IN", "HTTP");

                builder.Configuration.AddInMemoryCollection(new[] { new KeyValuePair<string, string?>("OTEL_SEMCONV_STABILITY_OPT_IN", "HTTP") });
            }

            builder.Services.AddOpenTelemetry()
                .WithTracing(builder => builder
                    .AddAspNetCoreInstrumentation()
                    .AddAzureMonitorTraceExporterForTest(out telemetryItems));

            var app = builder.Build();
            app.MapGet("/", () =>
            {
                return "Response from Test Server";
            });

            _ = app.RunAsync(TestServerUrl);

            // ACT
            using var httpClient = new HttpClient();
            var res = await httpClient.GetStringAsync(TestServerUrl).ConfigureAwait(false);
            Assert.True(res.Equals("Response from Test Server"), "If this assert fails, the in-process test server is not running.");

            // Shutdown
            //response.EnsureSuccessStatusCode();
            Assert.NotNull(telemetryItems);
            this.WaitForActivityExport(telemetryItems);

            // Assert
            Assert.True(telemetryItems.Any(), "test project did not capture telemetry");
            var telemetryItem = telemetryItems.Last()!;
            this.telemetryOutput.Write(telemetryItem);

            AssertRequestTelemetry(
                telemetryItem: telemetryItem,
                expectedResponseCode: "200",
                expectedUrl: TestServerUrl,
                isNewSemConv: testNewSemanticConventions);
        }
#endif
    }
}
