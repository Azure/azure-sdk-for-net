// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Metrics;
using OpenTelemetry.Trace;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    [LiveOnly]
    [Explicit("Requires a fresh filtered Live test host.")]
    public class MultiEndpointRoutingLiveTests : BaseLiveTest
    {
        private const string TestServerPort = "9998";
        private const string TestServerUrl = $"http://localhost:{TestServerPort}/";
        private const string TestLogCategoryName = "MultiEndpointRoutingLiveTests";
        private const string TestLogMessage = "Multi-endpoint routing live test log";
        private const string RecordAttribute = "multiEndpointRecordId";

        public MultiEndpointRoutingLiveTests(bool isAsync) : base(isAsync) { }

        [Test]
        [SyncOnly]
        public async Task RoutesTracesAndLogsAcrossResourcesAndEndpoints()
        {
            var resources = MultiEndpointResource.Parse(TestEnvironment.MultiEndpointResources);
            var runId = Guid.NewGuid().ToString("N");

            AppContext.SetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiEndpointRouting", true);

            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Services.AddOpenTelemetry()
                .UseAzureMonitor(options =>
                {
                    options.ConnectionString = resources[0].ConnectionString;
                    options.EnableLiveMetrics = false;
                    options.TracesPerSecond = null;
                    options.SamplingRatio = 1.0F;
                });

            using var app = builder.Build();
            app.MapGet("/{destination:int}", (int destination, ILoggerFactory loggerFactory) =>
            {
                var resource = resources[destination];
                var requestId = $"{runId}-request-{destination}";
                foreach (var attribute in Attributes(resource, requestId))
                {
                    Activity.Current!.SetTag(attribute.Key, attribute.Value);
                }

                var logId = $"{runId}-log-{destination}";
                loggerFactory.CreateLogger(TestLogCategoryName).Log(
                    LogLevel.Information,
                    default,
                    Attributes(resource, logId),
                    null,
                    (state, exception) => TestLogMessage);

                return "Response from Test Server";
            });

            _ = app.RunAsync(TestServerUrl);

            // ACT
            using var httpClient = new HttpClient();
            for (var destination = 0; destination < resources.Count; destination++)
            {
                var response = await httpClient.GetStringAsync($"{TestServerUrl}{destination}").ConfigureAwait(false);
                Assert.True(response.Equals("Response from Test Server"), "If this assert fails, the in-process test server is not running.");
            }

            // SHUTDOWN
            var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
            tracerProvider.ForceFlush();
            tracerProvider.Shutdown();

            var meterProvider = app.Services.GetRequiredService<MeterProvider>();
            meterProvider.ForceFlush();
            meterProvider.Shutdown();

            await app.StopAsync(); // shutdown to prevent collecting the log queries.

            // ASSERT
            await VerifyTelemetry(resources, runId);
        }

        private static Dictionary<string, object?> Attributes(MultiEndpointResource resource, string recordId) => new()
        {
            ["microsoft.instrumentation_key"] = resource.InstrumentationKey,
            ["microsoft.ingestion_endpoint"] = resource.Endpoint.AbsoluteUri,
            [RecordAttribute] = recordId
        };

        private async Task VerifyTelemetry(IReadOnlyList<MultiEndpointResource> resources, string runId)
        {
            for (var destination = 0; destination < resources.Count; destination++)
            {
                var resource = resources[destination];
                await VerifyRecord(resource, "AppRequests", $"{runId}-request-{destination}");
                await VerifyRecord(resource, "AppTraces", $"{runId}-log-{destination}");
            }
        }

        private async Task VerifyRecord(MultiEndpointResource resource, string table, string recordId)
        {
            var query = $"{table} | where tostring(Properties.{RecordAttribute}) == '{recordId}' | project ResourceId=_ResourceId";
            var result = await QueryClient.QueryTelemetryAsync(resource.WorkspaceId, recordId, query);
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Rows.Count, Is.EqualTo(1));
            Assert.That(result.Rows[0].GetString("ResourceId"), Is.EqualTo(resource.ResourceId).IgnoreCase);
        }
    }
}
#endif