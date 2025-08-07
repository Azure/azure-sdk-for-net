// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Instrumentation.Http;
using OpenTelemetry.Resources;
using OpenTelemetry.Tests;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    [Collection("InstrumentationLibraries")]
    public class HttpClientInstrumentationTests
    {
        [Theory]
        [InlineData(null, 200)]
        [InlineData("?key=value", 200)]
        [InlineData(null, 500)]
        [InlineData(null, 0, true)]
        public async Task HttpRequestsAreCapturedCorrectly(string? queryString, int expectedStatusCode, bool shouldThrowException = false)
        {
            using var testHttpServer = TestHttpServer.RunServer(
                action: (ctx) =>
                {
                    ctx.Response.StatusCode = expectedStatusCode;
                    ctx.Response.OutputStream.Close();
                },
                host: out var host,
                port: out var port);

            if (shouldThrowException)
            {
                host = "fakehost"; // fake hostname that will not resolve DNS and should be reported as an error span.
            }
            var baseAddress = $"http://{host}:{port}";

            // SETUP MOCK TRANSMITTER TO CAPTURE AZURE MONITOR TELEMETRY
            var testConnectionString = $"InstrumentationKey=unitTest-{nameof(HttpRequestsAreCapturedCorrectly)}";
            var telemetryItems = new List<TelemetryItem>();
            var mockTransmitter = new Exporter.Tests.CommonTestFramework.MockTransmitter(telemetryItems);
            // The TransmitterFactory is invoked by the Exporter during initialization to ensure that there's only one instance of a transmitter/connectionString shared by all Exporters.
            // Here we're setting that instance to use the MockTransmitter so this test can capture telemetry before it's sent to Azure Monitor.
            Exporter.Internals.TransmitterFactory.Instance.Set(connectionString: testConnectionString, transmitter: mockTransmitter);

            // SETUP OPENTELEMETRY WITH AZURE MONITOR DISTRO
            var activities = new List<Activity>();
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(x => x.ConnectionString = testConnectionString)
                .WithTracing(x => x.AddInMemoryExporter(activities))
                // Custom resources must be added AFTER AzureMonitor to override the included ResourceDetectors.
                .ConfigureResource(x => x.AddAttributes(SharedTestVars.TestResourceAttributes));
            serviceCollection.Configure<HttpClientTraceInstrumentationOptions>(options =>
            {
#if NETFRAMEWORK
                options.EnrichWithHttpWebRequest = (activity, httpWebRequest) => { activity.SetTag("enrichedWithHttpWebRequest", "yes"); };
                options.EnrichWithHttpWebResponse = (activity, httpWebResponse) => { activity.SetTag("enrichedWithHttpWebResponse", "yes"); };
#else
                options.EnrichWithHttpRequestMessage = (activity, httpRequestMessage) => { activity.SetTag("enrichedWithHttpRequestMessage", "yes"); };
                options.EnrichWithHttpResponseMessage = (activity, httpResponseMessage) => { activity.SetTag("enrichedWithHttpResponseMessage", "yes"); };
#endif
                // options.RecordException = true; TODO: THIS SHOULD GENERATE AN EXCEPTION TELEMETRY ITEM
                options.EnrichWithException = (activity, exception) => { activity.SetTag("enrichedOnException", "yes"); };
            });
            using var serviceProvider = serviceCollection.BuildServiceProvider();

            await StartHostedServicesAsync(serviceProvider);

            // We must resolve the TracerProvider here to ensure that it is initialized.
            // In a normal app, the OpenTelemetry.Extensions.Hosting package would handle this.
            var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();

            // ACT
            string path = "/custom-endpoint";
            string url = queryString is null
                    ? path
                    : path + queryString;

            string expectedQueryString = queryString is null
                    ? string.Empty
#if NET9_0_OR_GREATER //Starting with .NET 9, HttpClient library performs redaction by default
                    : "?*";
#else  // For all older frameworks, the Instrumentation Library performs redaction by default
                    : queryString;
#endif

            string urlForValidation = path + expectedQueryString;

            var httpclient = new HttpClient();

            try
            {
                await httpclient.GetAsync(baseAddress + url);
            }
            catch
            {
                // Do nothing
            }

            // SHUTDOWN
            tracerProvider.ForceFlush();
            tracerProvider.Shutdown();

            // ASSERT
            WaitForActivityExport(telemetryItems, x => x.Name == "RemoteDependency");
            var activity = activities.Single();
            Assert.True(telemetryItems.Any(), "Unit test failed to collect telemetry.");
            var telemetryItem = telemetryItems.Where(x => x.Name == "RemoteDependency").Single();

            VerifyTelemetryItem(
                isSuccessfulRequest: expectedStatusCode == 200,
                hasException: shouldThrowException,
                expectedUrl: urlForValidation,
                operationName: $"GET {path}",
                expectedData: baseAddress + path + expectedQueryString,
                expectedTarget: $"{host}:{port}",
                statusCode: expectedStatusCode.ToString(),
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
                timeout: TimeSpan.FromSeconds(20));

            Assert.True(result, $"{nameof(WaitForActivityExport)} failed.");
        }

        internal static void VerifyTelemetryItem(
            bool isSuccessfulRequest,
            bool hasException,
            string expectedUrl,
            string operationName,
            string statusCode,
            string expectedData,
            string expectedTarget,
            TelemetryItem telemetryItem,
            Activity activity)
        {
            // TELEMETRY ITEM
            Assert.Equal(5, telemetryItem.Tags.Count);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.operation.id" && kvp.Value == activity.TraceId.ToHexString());
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.cloud.role" && kvp.Value == SharedTestVars.TestRoleName);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.cloud.roleInstance" && kvp.Value == SharedTestVars.TestServiceInstance);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.application.ver" && kvp.Value == SharedTestVars.TestServiceVersion);
            Assert.Contains(telemetryItem.Tags, kvp => kvp.Key == "ai.internal.sdkVersion");

            // TELEMETRY DATA
            var remoteDependencyData = (RemoteDependencyData)telemetryItem.Data.BaseData;

            Assert.Equal(operationName, remoteDependencyData.Name);
            Assert.Equal(activity.SpanId.ToHexString(), remoteDependencyData.Id);
            Assert.Equal(expectedData, remoteDependencyData.Data);
            Assert.Equal(statusCode, remoteDependencyData.ResultCode);
            Assert.Equal(expectedTarget, remoteDependencyData.Target);
            Assert.Equal("Http", remoteDependencyData.Type);
            Assert.Equal(isSuccessfulRequest, remoteDependencyData.Success);

            var expectedPropertiesCount = (!isSuccessfulRequest && !hasException) ? 5 : 4;

            Assert.Equal(expectedPropertiesCount, remoteDependencyData.Properties.Count);

#if NETFRAMEWORK
            Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "enrichedWithHttpWebRequest" && kvp.Value == "yes");

            if (!hasException)
            {
                Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "enrichedWithHttpWebResponse" && kvp.Value == "yes");
            }
#else
            Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "enrichedWithHttpRequestMessage" && kvp.Value == "yes");

            if (!hasException)
            {
                Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "enrichedWithHttpResponseMessage" && kvp.Value == "yes");
            }
#endif

            Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "_MS.ProcessedByMetricExtractors" && kvp.Value == "(Name: X,Ver:'1.1')");

            if (isSuccessfulRequest)
            {
                Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "network.protocol.version" && kvp.Value == "1.1");
            }

            if (!isSuccessfulRequest && !hasException)
            {
                Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "error.type" && kvp.Value == statusCode);
            }

            if (hasException)
            {
                Assert.Contains(remoteDependencyData.Properties, kvp => kvp.Key == "enrichedOnException" && kvp.Value == "yes");
            }
        }

        private static async Task StartHostedServicesAsync(ServiceProvider serviceProvider)
        {
            var hostedServices = serviceProvider.GetServices<IHostedService>();
            foreach (var hostedService in hostedServices)
            {
                await hostedService.StartAsync(CancellationToken.None);
            }
        }
    }
}
