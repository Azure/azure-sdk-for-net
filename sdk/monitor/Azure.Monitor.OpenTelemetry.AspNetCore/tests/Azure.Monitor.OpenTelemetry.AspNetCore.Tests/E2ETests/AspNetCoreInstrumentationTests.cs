// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using OpenTelemetry.Instrumentation.AspNetCore;
using OpenTelemetry.Instrumentation.SqlClient;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Xunit;
using Xunit.Abstractions;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    public class AspNetCoreInstrumentationTests
        : IClassFixture<WebApplicationFactory<AspNetCoreTestApp.Program>>, IDisposable
    {
        private readonly WebApplicationFactory<AspNetCoreTestApp.Program> _factory;
        private readonly TelemetryItemOutputHelper _telemetryOutput;

        public AspNetCoreInstrumentationTests(WebApplicationFactory<AspNetCoreTestApp.Program> factory, ITestOutputHelper output)
        {
            _factory = factory;
            _telemetryOutput = new TelemetryItemOutputHelper(output);
        }

        [Theory]
        [InlineData("/custom-endpoint", null, 200)]
        [InlineData("/custom-endpoint", "?key=value", 200)]
        [InlineData("/custom-endpoint", null, 500)]
        [InlineData("/exception-endpoint", null, 500, true)]
        [InlineData("/unknown-endpoint", null, 404)]
        public void AspNetCoreRequestsAreCapturedCorrectly(string path, string? queryString, int statusCode, bool shouldThrow = false)
        {
            // SETUP MOCK TRANSMITTER TO CAPTURE AZURE MONITOR TELEMETRY
            var testConnectionString = $"InstrumentationKey=unitTest-{nameof(AspNetCoreRequestsAreCapturedCorrectly)}";
            var telemetryItems = new List<TelemetryItem>();
            var mockTransmitter = new Exporter.Tests.CommonTestFramework.MockTransmitter(telemetryItems);
            // The TransmitterFactory is invoked by the Exporter during initialization to ensure that there's only one instance of a transmitter/connectionString shared by all Exporters.
            // Here we're setting that instance to use the MockTransmitter so this test can capture telemetry before it's sent to Azure Monitor.
            Exporter.Internals.TransmitterFactory.Instance.Set(connectionString: testConnectionString, transmitter: mockTransmitter);

            var activities = new List<Activity>();
            string expectedUrl;

            // SETUP WEBAPPLICATIONFACTORY WITH OPENTELEMETRY
            using (var client = _factory
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(serviceCollection =>
                    {
                        serviceCollection.AddOpenTelemetry()
                            .UseAzureMonitor(x =>
                            {
                                x.EnableLiveMetrics = false;
                                x.ConnectionString = testConnectionString;
                            })
                            .WithTracing(x => x.AddInMemoryExporter(activities))
                            // Custom resources must be added AFTER AzureMonitor to override the included ResourceDetectors.
                            .ConfigureResource(x => x.AddAttributes(SharedTestVars.TestResourceAttributes));

                        serviceCollection.Configure<AspNetCoreTraceInstrumentationOptions>(options =>
                        {
                            options.EnrichWithHttpRequest = (activity, request) => { activity.SetTag("enrichedOnStart", "request"); };
                            options.EnrichWithHttpResponse = (activity, response) => { activity.SetTag("enrichedOnStop", "response"); };
                            options.EnrichWithException = (activity, exception) => { activity.SetTag("enrichedOnException", "exception"); };
                        });
                    });

                    builder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("/custom-endpoint", async context =>
                            {
                                context.Response.StatusCode = statusCode;
                                await context.Response.WriteAsync("Hello!");
                            });

                            endpoints.MapGet("/exception-endpoint", context =>
                            {
                                context.Response.StatusCode = statusCode;
                                throw new Exception("test exception");
                            });
                        });
                    });
                })
                .CreateClient())
            {
                // Act
                string url = queryString is null
                    ? path
                    : path + queryString;

                expectedUrl = new Uri(client.BaseAddress!, url).AbsoluteUri;

                try
                {
                    using var response = client.GetAsync(url).Result;
                }
                catch
                {
                    // Ignore exceptions
                }
            }

            // SHUTDOWN
            var tracerProvider = _factory.Factories.Last().Services.GetRequiredService<TracerProvider>();
            tracerProvider.ForceFlush();

            WaitForActivityExport(activities);
            WaitForActivityExport(telemetryItems, x => x.Name == "Request");

            // ASSERT
            _telemetryOutput.Write(telemetryItems);
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Where(x => x.Name == "Request").Single();
            var activity = activities.Single();

            VerifyTelemetryItem(
                isSuccess: statusCode == 200,
                isException: shouldThrow,
                expectedUrl: expectedUrl,
                operationName: $"GET {path}",
                statusCode: statusCode.ToString(),
                telemetryItem: telemetryItem,
                activity: activity);
        }

        private void WaitForActivityExport<T>(List<T> traceTelemetryItems, Func<T, bool>? predicate = null)
        {
            var result = SpinWait.SpinUntil(
                condition: () =>
                {
                    Thread.Sleep(10);
                    return predicate is null
                        ? traceTelemetryItems.Any()
                        : traceTelemetryItems.Any(predicate);
                },
                timeout: TimeSpan.FromSeconds(10));

            Assert.True(result, $"{nameof(WaitForActivityExport)} failed.");
        }

        internal static void VerifyTelemetryItem(
            bool isSuccess,
            bool isException,
            string expectedUrl,
            string operationName,
            string statusCode,
            TelemetryItem telemetryItem,
            Activity activity)
        {
            // TELEMETRY ITEM
            Assert.Equal(6, telemetryItem.Tags.Count);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.operation.id" && kvp.Value == activity.TraceId.ToHexString());
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.operation.name" && kvp.Value == operationName);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.cloud.role" && kvp.Value == SharedTestVars.TestRoleName);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.cloud.roleInstance" && kvp.Value == SharedTestVars.TestServiceInstance);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.application.ver" && kvp.Value == SharedTestVars.TestServiceVersion);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.internal.sdkVersion");

            // TELEMETRY DATA
            var requestData = (RequestData)telemetryItem.Data.BaseData;

            Assert.Equal(operationName, requestData.Name);
            Assert.Equal(activity.SpanId.ToHexString(), requestData.Id);
            Assert.Equal(statusCode, requestData.ResponseCode);
            Assert.Null(requestData.Source);
            Assert.Equal(isSuccess, requestData.Success);
            Assert.Equal(expectedUrl, requestData.Url);

            var expectedPropertiesCount = isException ? 6 : 4;
            Assert.Equal(expectedPropertiesCount, requestData.Properties.Count);

            Assert.Contains(requestData.Properties, kvp => kvp.Key == "enrichedOnStart" && kvp.Value == "request");
            Assert.Contains(requestData.Properties, kvp => kvp.Key == "enrichedOnStop" && kvp.Value == "response");
            Assert.Contains(requestData.Properties, kvp => kvp.Key == "_MS.ProcessedByMetricExtractors" && kvp.Value == "(Name: X,Ver:'1.1')");
            Assert.Contains(requestData.Properties, kvp => kvp.Key == "network.protocol.version" && kvp.Value == "1.1");

            if (isException)
            {
                Assert.Contains(requestData.Properties, kvp => kvp.Key == "error.type" && kvp.Value == "System.Exception");
                Assert.Contains(requestData.Properties, kvp => kvp.Key == "enrichedOnException" && kvp.Value == "exception");
            }
        }

        public void Dispose()
        {
            // OpenTelemetry is registered on a nested Factory which is not disposed between test runs!
            // MUST explicitly dispose the nested Factory to avoid test conflicts.
            _factory.Factories.Last().Dispose();

            _factory.Dispose();
        }
    }
}
#endif
