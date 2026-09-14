// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
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
using static Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.MultiTenantTelemetry;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests
{
    [LiveOnly]
    [Explicit("Requires a fresh filtered host with MONITOR_MULTI_TENANT_LIVE=true.")]
    [Category("Manually")]
    [NonParallelizable]
    public class MultiTenantExportLiveTests : BaseLiveTest
    {
        private const string TestServerPort = "9998";
        private const string TestServerUrl = $"http://localhost:{TestServerPort}/";
        private const string SourceName = "MultiTenantLiveTests";
        private const string RunAttribute = "multiTenantRunId";
        private const string RecordAttribute = "multiTenantRecordId";
        private const int FlushTimeoutMilliseconds = 60000;
        private readonly IReadOnlyList<MultiTenantResource> _resources;

        public MultiTenantExportLiveTests(bool isAsync) : base(isAsync, usesMultiTenantExport: true)
        {
            _resources = MultiTenantResource.Parse(TestEnvironment.MultiTenantResources);
        }

        [Test]
        [SyncOnly]
        public async Task RoutesTracesAndLogsAcrossResourcesAndEndpoints()
        {
            var resources = _resources;
            var runId = Guid.NewGuid().ToString("N");
            var expected = new Dictionary<string, Record>();
            TestContext.Out.WriteLine($"Multi-tenant run {runId}: {resources.Count} destinations, {resources.Select(resource => resource.Endpoint).Distinct().Count()} endpoints.");

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
                    options.Credential = null;
                    options.DisableOfflineStorage = true;
                    options.EnableLiveMetrics = false;
                    options.EnableStandardMetrics = false;
                    options.EnablePerformanceCounters = false;
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
                using var httpClient = new System.Net.Http.HttpClient();
                var response = await httpClient.GetStringAsync(TestServerUrl).ConfigureAwait(false);
                Assert.That(response, Is.EqualTo("Response from Test Server"), "The in-process test server did not return the expected response.");

                // SHUTDOWN
                var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
                var loggerProvider = app.Services.GetRequiredService<LoggerProvider>();
                Assert.That(tracerProvider.ForceFlush(FlushTimeoutMilliseconds), Is.True, "Trace flush failed.");
                Assert.That(loggerProvider.ForceFlush(FlushTimeoutMilliseconds), Is.True, "Log flush failed.");
                Assert.That(tracerProvider.Shutdown(FlushTimeoutMilliseconds), Is.True, "Trace shutdown failed.");
                Assert.That(loggerProvider.Shutdown(FlushTimeoutMilliseconds), Is.True, "Log shutdown failed.");
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

        private static void EmitTelemetry(ActivitySource source, ILogger logger, MultiTenantResource resource, string runId, Dictionary<string, Record> expected)
        {
            var requestId = Guid.NewGuid().ToString("N");
            using var request = source.StartActivity("multi-tenant-request", ActivityKind.Server, default(ActivityContext));
            Assert.That(request, Is.Not.Null);
            foreach (var attribute in Attributes(resource, runId, requestId))
            {
                request!.SetTag(attribute.Key, attribute.Value);
            }
            expected.Add(requestId, new Record(requestId, resource.WorkspaceId, resource.ResourceId, "AppRequests", request!.TraceId.ToHexString(),
                request.ParentSpanId == default ? string.Empty : request.ParentSpanId.ToHexString()));

            var dependencyId = Guid.NewGuid().ToString("N");
            using (var dependency = source.StartActivity("multi-tenant-dependency", ActivityKind.Client))
            {
                Assert.That(dependency, Is.Not.Null);
                foreach (var attribute in Attributes(resource, runId, dependencyId))
                {
                    dependency!.SetTag(attribute.Key, attribute.Value);
                }
                expected.Add(dependencyId, new Record(dependencyId, resource.WorkspaceId, resource.ResourceId, "AppDependencies", request.TraceId.ToHexString(), request.SpanId.ToHexString()));
            }

            foreach (var isException in new[] { false, true })
            {
                var recordId = Guid.NewGuid().ToString("N");
                logger.Log(isException ? LogLevel.Error : LogLevel.Information, default, Attributes(resource, runId, recordId),
                    isException ? new InvalidOperationException("Multi-tenant live test exception") : null,
                    (state, exception) => "Multi-tenant live test log");
                expected.Add(recordId, new Record(recordId, resource.WorkspaceId, resource.ResourceId, isException ? "AppExceptions" : "AppTraces", request.TraceId.ToHexString(), request.SpanId.ToHexString()));
            }
        }

        private async Task VerifyIngestionAsync(IReadOnlyList<MultiTenantResource> resources, Dictionary<string, Record> expected, string runId)
        {
            var query = $"union withsource=TelemetryTable AppRequests, AppDependencies, AppTraces, AppExceptions " +
                $"| where tostring(Properties.{RunAttribute}) == '{runId}' " +
                $"| project TelemetryTable, RecordId=tostring(Properties.{RecordAttribute}), ResourceId=_ResourceId, OperationId, ParentId";
            using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(12));
            var clock = Stopwatch.StartNew();
            TimeSpan? completeSince = null;
            var seen = new HashSet<string>();
            while (clock.Elapsed < TimeSpan.FromMinutes(10))
            {
                seen.Clear();
                foreach (var workspaceId in resources.Select(resource => resource.WorkspaceId).Distinct(StringComparer.OrdinalIgnoreCase))
                {
                    var response = await QueryClient.QueryWorkspaceAsync(workspaceId, query, new LogsQueryTimeRange(TimeSpan.FromHours(1)), cancellationToken: timeout.Token);
                    Assert.That(response.Value.Status, Is.EqualTo(LogsQueryResultStatus.Success), $"Partial query for run {runId} in workspace {workspaceId}.");
                    var rows = response.Value.Table.Rows.Select(row => new Record(row.GetString("RecordId"), workspaceId,
                        row.GetString("ResourceId"), row.GetString("TelemetryTable"), row.GetString("OperationId") ?? string.Empty, row.GetString("ParentId") ?? string.Empty));
                    seen.UnionWith(ValidateQuery(expected, rows, response.Value.Status));
                }

                TestContext.Out.WriteLine($"Run {runId}: {seen.Count}/{expected.Count} records after {clock.Elapsed.TotalSeconds:F0}s. Missing: {string.Join(", ", expected.Keys.Except(seen))}");
                if (seen.SetEquals(expected.Keys))
                {
                    completeSince ??= clock.Elapsed;
                    if (clock.Elapsed - completeSince.Value >= TimeSpan.FromMinutes(1))
                    {
                        return;
                    }
                }
                else
                {
                    completeSince = null;
                }
                await Task.Delay(TimeSpan.FromSeconds(30), timeout.Token);
            }

            Assert.Fail($"Run {runId} did not establish complete ingestion and a one-minute observation window within ten minutes. Missing: {string.Join(", ", expected.Keys.Except(seen))}");
        }
    }
}
#endif