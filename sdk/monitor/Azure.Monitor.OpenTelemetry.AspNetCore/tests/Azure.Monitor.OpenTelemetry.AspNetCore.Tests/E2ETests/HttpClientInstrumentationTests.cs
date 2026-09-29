// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Monitor.OpenTelemetry.Exporter.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry.Instrumentation.Http;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Tests;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests.E2ETests
{
    [Collection("InstrumentationLibraries")]
    public class HttpClientInstrumentationTests
    {
#if NET8_0_OR_GREATER
        [Theory]
        [InlineData("default", false)]
        [InlineData("one", false)]
        [InlineData("one", true)]
        [InlineData("all", false)]
        [InlineData("all", true)]
        [InlineData("drop", false)]
        [InlineData("drop", true)]
        [InlineData("customize", false)]
        [InlineData("customize", true)]
        public void HttpClientMetricsRespectCustomerViews(string configuration, bool configureBeforeDistro)
        {
            var connectionString = $"InstrumentationKey=unitTest-{nameof(HttpClientMetricsRespectCustomerViews)}-{configuration}-{configureBeforeDistro}";
            Exporter.Internals.TransmitterFactory.Instance.Set(connectionString,
                new Exporter.Tests.CommonTestFramework.MockTransmitter(new List<TelemetryItem>()));
            var services = new ServiceCollection();
            var exportedMetrics = new List<Metric>();
            Action<MeterProviderBuilder> configureMetrics = metrics => metrics.AddView(instrument =>
            {
                if (instrument.Meter.Name != "System.Net.Http")
                {
                    return null;
                }

                if (configuration == "all" || (configuration == "one" && instrument.Name == "http.client.open_connections"))
                {
                    return new MetricStreamConfiguration();
                }

                if (instrument.Name == "http.client.request.duration")
                {
                    if (configuration == "drop")
                    {
                        return MetricStreamConfiguration.Drop;
                    }

                    if (configuration == "customize")
                    {
                        return new ExplicitBucketHistogramConfiguration
                        {
                            Name = "custom.duration",
                            Boundaries = new[] { 0.05, 0.5 },
                            TagKeys = new[] { "kept" },
                        };
                    }
                }

                return null;
            });

            if (configureBeforeDistro)
            {
                services.ConfigureOpenTelemetryMeterProvider(configureMetrics);
            }

            services.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = connectionString;
                    options.EnableLiveMetrics = false;
                })
                .WithMetrics(metrics => metrics
                    .SetResourceBuilder(ResourceBuilder.CreateEmpty())
                    .AddMeter("HttpClientMetrics.Tests", "System.Net.NameResolution")
                    .AddInMemoryExporter(exportedMetrics));

            if (!configureBeforeDistro)
            {
                services.ConfigureOpenTelemetryMeterProvider(configureMetrics);
            }

            using var serviceProvider = services.BuildServiceProvider();
            var meterProvider = serviceProvider.GetRequiredService<MeterProvider>();
            using var meter = new Meter("System.Net.Http", "HttpClientMetrics.Tests");
            meter.CreateHistogram<double>("http.client.request.duration", "s").Record(
                0.1, new KeyValuePair<string, object?>("kept", "value"), new KeyValuePair<string, object?>("removed", "value"));
            foreach (var name in new[]
            {
                "http.client.active_requests",
                "http.client.open_connections",
                "http.client.connection.duration",
                "http.client.request.time_in_queue",
                "http.client.future_metric",
            })
            {
                if (name == "http.client.active_requests" || name == "http.client.open_connections")
                {
                    meter.CreateUpDownCounter<long>(name).Add(1);
                }
                else
                {
                    meter.CreateHistogram<double>(name).Record(1);
                }
            }

            using var customMeter = new Meter("HttpClientMetrics.Tests");
            using var serverMeter = new Meter("Microsoft.AspNetCore.Hosting", "HttpClientMetrics.Tests");
            using var dnsMeter = new Meter("System.Net.NameResolution", "HttpClientMetrics.Tests");
            customMeter.CreateCounter<long>("http.client.open_connections").Add(1);
            serverMeter.CreateUpDownCounter<long>("http.server.active_requests").Add(1);
            dnsMeter.CreateHistogram<double>("dns.lookup.duration").Record(0.1);

            meterProvider.ForceFlush();

            // Meter version isolates this test's synthetic instruments from any real System.Net.Http meter in the process.
            var httpMetrics = exportedMetrics.Where(metric => metric.MeterName == meter.Name && metric.MeterVersion == meter.Version).ToList();
            Assert.Equal(configuration == "all" ? 6 : configuration == "one" ? 2 : configuration == "drop" ? 0 : 1, httpMetrics.Count);
            if (configuration != "drop")
            {
                var durationMetric = Assert.Single(httpMetrics, metric => metric.Name == (configuration == "customize" ? "custom.duration" : "http.client.request.duration"));
                Assert.Equal("s", durationMetric.Unit);
                foreach (ref readonly var point in durationMetric.GetMetricPoints())
                {
                    Assert.Equal(1, point.GetHistogramCount());
                    Assert.Equal(0.1, point.GetHistogramSum());
                    if (configuration == "customize")
                    {
                        Assert.Equal(1, point.Tags.Count);
                        var bounds = new List<double>();
                        foreach (var bucket in point.GetHistogramBuckets())
                        {
                            bounds.Add(bucket.ExplicitBound);
                        }

                        Assert.Equal(new[] { 0.05, 0.5, double.PositiveInfinity }, bounds);
                    }
                }
            }

            Assert.Contains(exportedMetrics, metric => metric.MeterName == customMeter.Name);
            Assert.Contains(exportedMetrics, metric => metric.MeterName == serverMeter.Name);
            Assert.Contains(exportedMetrics, metric => metric.MeterName == dnsMeter.Name);
        }

        [Fact]
        public async Task HttpClientMetricsCollectOnlyRequestDurationFromRealRequests()
        {
            using var testHttpServer = TestHttpServer.RunServer(
                action: (ctx) =>
                {
                    ctx.Response.StatusCode = 200;
                    ctx.Response.OutputStream.Close();
                },
                host: out var host,
                port: out var port);

            var testConnectionString = $"InstrumentationKey=unitTest-{nameof(HttpClientMetricsCollectOnlyRequestDurationFromRealRequests)}";
            Exporter.Internals.TransmitterFactory.Instance.Set(testConnectionString,
                new Exporter.Tests.CommonTestFramework.MockTransmitter(new List<TelemetryItem>()));

            var exportedMetrics = new List<Metric>();
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddOpenTelemetry()
                .UseAzureMonitor(x =>
                {
                    x.ConnectionString = testConnectionString;
                    x.EnableLiveMetrics = false;
                })
                .WithMetrics(x => x
                    .SetResourceBuilder(ResourceBuilder.CreateEmpty())
                    .AddInMemoryExporter(exportedMetrics));

            using var serviceProvider = serviceCollection.BuildServiceProvider();
            var meterProvider = serviceProvider.GetRequiredService<MeterProvider>();

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"http://{host}:{port}/probe");
            }

            meterProvider.ForceFlush();

            // Catches the distro's instrument name drifting from the name the runtime actually emits.
            Assert.Equal(
                new[] { "http.client.request.duration" },
                exportedMetrics.Where(metric => metric.MeterName == "System.Net.Http").Select(metric => metric.Name).Distinct().ToArray());
        }
#endif

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
                .UseAzureMonitor(x =>
                {
                    x.ConnectionString = testConnectionString;
                    x.SamplingRatio = 1.0f; // Ensure 100% sampling for tests
                    x.TracesPerSecond = null; // Disable rate limited sampler
                })
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
