// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Trace;

#if NET
namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    [LiveOnly]
    [Explicit("Requires a fresh filtered Live test host.")]
    [Category("Manually")]
    [NonParallelizable]
    public class MultiTenantExportLiveTests : BaseLiveTest
    {
        private const string TestServerPort = "9998";
        private const string TestServerUrl = $"http://localhost:{TestServerPort}/";
        private const string SourceName = "MultiTenantLiveTests";
        private const string RunAttribute = "multiTenantRunId";
        private const string RecordAttribute = "multiTenantRecordId";

        public MultiTenantExportLiveTests(bool isAsync) : base(isAsync) { }

        [Test]
        [SyncOnly]
        public async Task RoutesTracesAndLogsAcrossResourcesAndEndpoints()
        {
            var resources = MultiTenantResource.Parse(TestEnvironment.MultiTenantResources);
            var runId = Guid.NewGuid().ToString("N");
            var expected = new Dictionary<string, (string WorkspaceId, string ResourceId, string Table)>();

            AppContext.SetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiTenantExport", true);

            // SETUP WEBAPPLICATION WITH OPENTELEMETRY
            using (var activitySource = new ActivitySource(SourceName))
            {
                var builder = WebApplication.CreateBuilder();
                builder.WebHost.UseUrls(TestServerUrl);
                builder.Logging.ClearProviders();
                builder.Services.AddOpenTelemetry()
                    .WithTracing(tracing => tracing.AddSource(SourceName).AddAzureMonitorTraceExporter(Configure))
                    .WithLogging(logging => logging.AddAzureMonitorLogExporter(Configure));

                void Configure(AzureMonitorExporterOptions options)
                {
                    options.ConnectionString = resources[0].ConnectionString;
                    options.EnableLiveMetrics = false;
                    options.SamplingRatio = 1;
                    options.TracesPerSecond = null;
                }

                using var app = builder.Build();
                app.MapGet("/", (ILoggerFactory loggerFactory) =>
                {
                    var logger = loggerFactory.CreateLogger(SourceName);
                    foreach (var resource in resources)
                    {
                        EmitTelemetry(activitySource, logger, resource, runId, expected);
                    }

                    return "Response from Test Server";
                });

                await app.StartAsync().ConfigureAwait(false);

                // ACT
                using var httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(TestServerUrl).ConfigureAwait(false);
                Assert.That(response, Is.EqualTo("Response from Test Server"), "The in-process test server did not return the expected response.");

                // SHUTDOWN
                var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
                var loggerProvider = app.Services.GetRequiredService<LoggerProvider>();
                tracerProvider.ForceFlush();
                tracerProvider.Shutdown();
                loggerProvider.ForceFlush();
                loggerProvider.Shutdown();
                await app.StopAsync().ConfigureAwait(false);
            }

            // ASSERT
            await VerifyIngestionAsync(resources, expected, runId);
        }

        private static Dictionary<string, object?> Attributes(MultiTenantResource resource, string runId, string recordId) => new()
        {
            ["microsoft.instrumentation_key"] = resource.InstrumentationKey,
            ["microsoft.ingestion_endpoint"] = resource.Endpoint.AbsoluteUri,
            [RunAttribute] = runId,
            [RecordAttribute] = recordId
        };

        private static void EmitTelemetry(ActivitySource source, ILogger logger, MultiTenantResource resource, string runId,
            Dictionary<string, (string WorkspaceId, string ResourceId, string Table)> expected)
        {
            var requestId = Guid.NewGuid().ToString("N");
            using var request = source.StartActivity("multi-tenant-request", ActivityKind.Server, default(ActivityContext));
            Assert.That(request, Is.Not.Null);
            foreach (var attribute in Attributes(resource, runId, requestId))
            {
                request!.SetTag(attribute.Key, attribute.Value);
            }
            expected.Add(requestId, (resource.WorkspaceId, resource.ResourceId, "AppRequests"));

            var dependencyId = Guid.NewGuid().ToString("N");
            using (var dependency = source.StartActivity("multi-tenant-dependency", ActivityKind.Client))
            {
                Assert.That(dependency, Is.Not.Null);
                foreach (var attribute in Attributes(resource, runId, dependencyId))
                {
                    dependency!.SetTag(attribute.Key, attribute.Value);
                }
                expected.Add(dependencyId, (resource.WorkspaceId, resource.ResourceId, "AppDependencies"));
            }

            foreach (var isException in new[] { false, true })
            {
                var recordId = Guid.NewGuid().ToString("N");
                logger.Log(isException ? LogLevel.Error : LogLevel.Information, default, Attributes(resource, runId, recordId),
                    isException ? new InvalidOperationException("Multi-tenant live test exception") : null,
                    (state, exception) => "Multi-tenant live test log");
                expected.Add(recordId, (resource.WorkspaceId, resource.ResourceId, isException ? "AppExceptions" : "AppTraces"));
            }
        }

        private async Task VerifyIngestionAsync(IReadOnlyList<MultiTenantResource> resources,
            Dictionary<string, (string WorkspaceId, string ResourceId, string Table)> expected, string runId)
        {
            var query = $"union withsource=TelemetryTable AppRequests, AppDependencies, AppTraces, AppExceptions " +
                $"| where tostring(Properties.{RunAttribute}) == '{runId}' " +
                $"| project TelemetryTable, RecordId=tostring(Properties.{RecordAttribute}), ResourceId=_ResourceId";

            for (var attempt = 1; attempt <= 20; attempt++)
            {
                var seen = new HashSet<string>();
                foreach (var workspaceId in resources.Select(resource => resource.WorkspaceId).Distinct(StringComparer.OrdinalIgnoreCase))
                {
                    var result = await QueryClient.QueryWorkspaceAsync(workspaceId, query, new LogsQueryTimeRange(TimeSpan.FromMinutes(30)));
                    Assert.That(result.Value.Status, Is.EqualTo(LogsQueryResultStatus.Success));
                    foreach (var row in result.Value.Table.Rows)
                    {
                        var recordId = row.GetString("RecordId");
                        Assert.That(expected.TryGetValue(recordId, out var item), Is.True, $"Unexpected record {recordId}.");
                        Assert.That(workspaceId, Is.EqualTo(item.WorkspaceId).IgnoreCase, $"Wrong workspace for {recordId}.");
                        Assert.That(row.GetString("ResourceId"), Is.EqualTo(item.ResourceId).IgnoreCase, $"Wrong resource for {recordId}.");
                        Assert.That(row.GetString("TelemetryTable"), Is.EqualTo(item.Table), $"Wrong signal for {recordId}.");
                        seen.Add(recordId);
                    }
                }

                if (seen.SetEquals(expected.Keys))
                {
                    return;
                }

                TestContext.Out.WriteLine($"Query attempt {attempt}/20 found {seen.Count}/{expected.Count} records.");
                await Task.Delay(TimeSpan.FromSeconds(30));
            }

            Assert.Fail($"Run {runId} did not ingest all expected records within ten minutes.");
        }
    }
}
#endif