// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.AspNetCore.Builder;
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
    [NonParallelizable]
    public class MultiTenantExportLiveTests : RecordedTestBase<MultiTenantTestEnvironment>
    {
        private const string SourceName = "MultiTenantEndToEnd";
        private const string KeyAttribute = "microsoft.instrumentation_key";
        private const string EndpointAttribute = "microsoft.ingestion_endpoint";
        private const string RunAttribute = "multiTenantRunId";
        private const string RecordAttribute = "multiTenantRecordId";
        private const int FlushTimeoutMilliseconds = 60000;

        public MultiTenantExportLiveTests(bool isAsync) : base(isAsync) { }

        public override void GlobalTimeoutTearDown() { }

        [Test]
        [SyncOnly]
        public Task RoutesTracesAndLogsToTheirOwnResources() => VerifyExportAsync(simulateOutage: false);

        [Test]
        [SyncOnly]
        public Task ReplaysTracesAndLogsAfterOneEndpointRecovers() => VerifyExportAsync(simulateOutage: true);

        private async Task VerifyExportAsync(bool simulateOutage)
        {
            var resources = TestEnvironment.LoadResources();
            var queryClient = new LogsQueryClient(TestEnvironment.LogsEndpoint, TestEnvironment.Credential);
            using var exporterHttpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            await RunExportAsync(resources, simulateOutage, new HttpClientTransport(exporterHttpClient),
                (expected, runId, cancellationToken) => VerifyIngestionAsync(queryClient, resources, expected, runId, cancellationToken));
        }

        internal static async Task RunExportAsync(IReadOnlyList<TenantResource> resources, bool simulateOutage, HttpPipelineTransport innerTransport,
            Func<Dictionary<string, ExpectedTelemetry>, string, CancellationToken, Task> verifyIngestion)
        {
            Assert.That(AppContext.TryGetSwitch("Azure.Monitor.OpenTelemetry.EnableMultiTenantExport", out var enabled) && enabled, Is.True);
            var host = resources[0];
            var tenants = resources.Skip(1).ToArray();
            var runId = Guid.NewGuid().ToString("N");
            var storageRoot = Path.Combine(Path.GetTempPath(), SourceName, runId);
            Directory.CreateDirectory(storageRoot);
            TestContext.Out.WriteLine($"Multi-tenant run {runId}; outage={simulateOutage}; resources={resources.Count}");

            using var timeout = new CancellationTokenSource(TimeSpan.FromMinutes(35));
            using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
            var transport = new EndpointOutageTransport(innerTransport, simulateOutage ? tenants[0].Endpoint : null);
            using var activitySource = new ActivitySource(SourceName);
            var expected = new Dictionary<string, ExpectedTelemetry>();
            var builder = WebApplication.CreateBuilder();
            builder.Logging.ClearProviders();
            builder.Services.Configure<OpenTelemetryLoggerOptions>(options => options.IncludeScopes = true);
            builder.Services.AddOpenTelemetry()
                .WithTracing(tracing => tracing.AddSource(SourceName).AddAzureMonitorTraceExporter(Configure))
                .WithLogging(logging => logging.AddAzureMonitorLogExporter(Configure));

            void Configure(AzureMonitorExporterOptions options)
            {
                options.ConnectionString = host.ConnectionString;
                options.Credential = null;
                options.Transport = transport;
                options.StorageDirectory = storageRoot;
                options.DisableOfflineStorage = false;
                options.EnableLiveMetrics = false;
                options.EnableStandardMetrics = false;
                options.EnablePerformanceCounters = false;
                options.SamplingRatio = 1;
                options.TracesPerSecond = null;
                options.Retry.MaxRetries = 0;
            }

            try
            {
                using var app = builder.Build();
                app.Urls.Add("http://127.0.0.1:0");
                app.MapGet("/emit/{tenantIndex:int}", (int tenantIndex, ILoggerFactory loggerFactory) =>
                {
                    EmitTelemetry(activitySource, loggerFactory.CreateLogger(SourceName), tenants[tenantIndex], runId, expected);
                    return "Export queued";
                });
                await app.StartAsync(timeout.Token);

                var tracerProvider = app.Services.GetRequiredService<TracerProvider>();
                var loggerProvider = app.Services.GetRequiredService<LoggerProvider>();
                for (int sequence = 0; sequence < 3; sequence++)
                {
                    for (int tenantIndex = 0; tenantIndex < tenants.Length; tenantIndex++)
                    {
                        using var response = await httpClient.GetAsync($"{app.Urls.Single()}/emit/{tenantIndex}", timeout.Token);
                        Assert.That(response.IsSuccessStatusCode, Is.True);
                    }
                }

                Assert.That(tracerProvider.ForceFlush(FlushTimeoutMilliseconds), Is.True, "Trace batch flush failed.");
                Assert.That(loggerProvider.ForceFlush(FlushTimeoutMilliseconds), Is.True, "Log batch flush failed.");

                if (simulateOutage)
                {
                    Assert.That(transport.FailedRequests, Is.GreaterThan(0), "The selected endpoint must encounter the outage.");
                    await AssertStoredSignalsAsync(storageRoot, timeout.Token);

                    var healthyExpected = expected.Where(entry => entry.Value.Resource.Endpoint != tenants[0].Endpoint)
                        .ToDictionary(entry => entry.Key, entry => entry.Value);
                    await verifyIngestion(healthyExpected, runId, timeout.Token);
                    transport.Recover();
                }

                Assert.That(tracerProvider.Shutdown(FlushTimeoutMilliseconds), Is.True, "Trace shutdown/drain failed.");
                Assert.That(loggerProvider.Shutdown(FlushTimeoutMilliseconds), Is.True, "Log shutdown/drain failed.");
                await WaitForStorageDrainAsync(storageRoot, timeout.Token);
                await app.StopAsync(timeout.Token);

                Assert.That(GetStoredBlobs(storageRoot), Is.Empty, "Telemetry backlog remains after shutdown drain.");
                await verifyIngestion(expected, runId, timeout.Token);
            }
            finally
            {
                Directory.Delete(storageRoot, recursive: true);
            }
        }

        private static string[] GetStoredBlobs(string root) => Directory.GetFiles(root, "*", SearchOption.AllDirectories)
            .Where(path => Path.GetExtension(path) is ".blob" or ".lock").ToArray();

        private static async Task WaitForStorageDrainAsync(string root, CancellationToken cancellationToken)
        {
            var clock = Stopwatch.StartNew();
            while (GetStoredBlobs(root).Length != 0 && clock.Elapsed < TimeSpan.FromMinutes(7))
            {
                await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
            }
            Assert.That(GetStoredBlobs(root), Is.Empty, "Backlog remains after shutdown drain and lease-recovery retries.");
        }

        private static async Task AssertStoredSignalsAsync(string root, CancellationToken cancellationToken)
        {
            var types = new HashSet<string>();
            var expectedTypes = new[] { "RequestData", "RemoteDependencyData", "MessageData", "ExceptionData" };
            var clock = Stopwatch.StartNew();
            while (!expectedTypes.All(types.Contains) && clock.Elapsed < TimeSpan.FromSeconds(10))
            {
                foreach (var path in GetStoredBlobs(root))
                {
                    try
                    {
                        foreach (var line in File.ReadLines(path))
                        {
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                using var item = JsonDocument.Parse(line);
                                types.Add(item.RootElement.GetProperty("data").GetProperty("baseType").GetString()!);
                            }
                        }
                    }
                    catch (FileNotFoundException)
                    {
                    }
                }
                if (!expectedTypes.All(types.Contains))
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken);
                }
            }
            Assert.That(types, Is.SupersetOf(expectedTypes), "Both signals must be persisted during the outage, including leased blobs.");
        }

        private static void EmitTelemetry(ActivitySource source, ILogger logger, TenantResource tenant, string runId, Dictionary<string, ExpectedTelemetry> expected)
        {
            var requestId = Guid.NewGuid().ToString("N");
            using (var request = source.StartActivity("multi-tenant-request", ActivityKind.Server, default(ActivityContext)))
            {
                Assert.That(request, Is.Not.Null);
                var attributes = CreateAttributes(tenant, runId, requestId);
                foreach (var attribute in attributes)
                {
                    request!.SetTag(attribute.Key, attribute.Value);
                }

                expected.Add(requestId, new ExpectedTelemetry(tenant, "AppRequests", request!.TraceId.ToHexString(), request.ParentSpanId == default ? string.Empty : request.ParentSpanId.ToHexString()));
                using (var dependency = source.StartActivity("multi-tenant-dependency", ActivityKind.Client))
                {
                    Assert.That(dependency, Is.Not.Null);
                    var dependencyId = Guid.NewGuid().ToString("N");
                    foreach (var attribute in CreateAttributes(tenant, runId, dependencyId))
                    {
                        dependency!.SetTag(attribute.Key, attribute.Value);
                    }
                    expected.Add(dependencyId, new ExpectedTelemetry(tenant, "AppDependencies", request.TraceId.ToHexString(), request.SpanId.ToHexString()));
                }

                EmitLog(logger, tenant, runId, expected, request, exception: null);
                EmitLog(logger, tenant, runId, expected, request, new InvalidOperationException("Multi-tenant end-to-end exception"));
                using (logger.BeginScope(attributes))
                {
                    var scopeOnly = CreateAttributes(tenant, runId, Guid.NewGuid().ToString("N"));
                    scopeOnly.Remove(KeyAttribute);
                    scopeOnly.Remove(EndpointAttribute);
                    logger.Log(LogLevel.Information, default, scopeOnly, null, (_, _) => "Scope and Activity routing must not be inherited");
                }
            }

            var previousActivity = Activity.Current;
            try
            {
                Activity.Current = null;
                EmitLog(logger, tenant, runId, expected, activity: null, exception: null);
            }
            finally
            {
                Activity.Current = previousActivity;
            }

            foreach (var invalidRoute in new[] { "missing-key", "missing-endpoint", "missing-both", "invalid-endpoint", "non-string-key" })
            {
                var attributes = CreateAttributes(tenant, runId, Guid.NewGuid().ToString("N"));
                switch (invalidRoute)
                {
                    case "missing-key": attributes.Remove(KeyAttribute); break;
                    case "missing-endpoint": attributes.Remove(EndpointAttribute); break;
                    case "missing-both": attributes.Remove(KeyAttribute); attributes.Remove(EndpointAttribute); break;
                    case "invalid-endpoint": attributes[EndpointAttribute] = "http://localhost/"; break;
                    case "non-string-key": attributes[KeyAttribute] = 42; break;
                }

                using var invalidActivity = source.StartActivity("must-be-dropped", ActivityKind.Server);
                Assert.That(invalidActivity, Is.Not.Null);
                foreach (var attribute in attributes)
                {
                    invalidActivity!.SetTag(attribute.Key, attribute.Value);
                }
                logger.Log(LogLevel.Information, default, attributes, null, (_, _) => "Invalid route must be dropped");
            }
        }

        private static void EmitLog(ILogger logger, TenantResource tenant, string runId, Dictionary<string, ExpectedTelemetry> expected, Activity? activity, Exception? exception)
        {
            var recordId = Guid.NewGuid().ToString("N");
            logger.Log(exception == null ? LogLevel.Information : LogLevel.Error, default, CreateAttributes(tenant, runId, recordId), exception, (_, _) => "Multi-tenant end-to-end log");
            expected.Add(recordId, new ExpectedTelemetry(tenant, exception == null ? "AppTraces" : "AppExceptions", activity?.TraceId.ToHexString() ?? string.Empty, activity?.SpanId.ToHexString() ?? string.Empty));
        }

        private static Dictionary<string, object?> CreateAttributes(TenantResource tenant, string runId, string recordId) => new()
        {
            [KeyAttribute] = tenant.InstrumentationKey,
            [EndpointAttribute] = tenant.Endpoint.AbsoluteUri,
            [RunAttribute] = runId,
            [RecordAttribute] = recordId
        };

        private static async Task VerifyIngestionAsync(LogsQueryClient client, IReadOnlyList<TenantResource> resources, Dictionary<string, ExpectedTelemetry> expected, string runId, CancellationToken cancellationToken)
        {
            var query = $"union withsource=TelemetryTable AppRequests, AppDependencies, AppTraces, AppExceptions " +
                $"| where tostring(Properties.{RunAttribute}) == '{runId}' " +
                $"| project TelemetryTable, RecordId=tostring(Properties.{RecordAttribute}), ResourceId=_ResourceId, OperationId, ParentId";
            var clock = Stopwatch.StartNew();
            TimeSpan? completeSince = null;
            var seen = new HashSet<string>();
            while (clock.Elapsed < TimeSpan.FromMinutes(10))
            {
                seen.Clear();
                foreach (var workspaceId in resources.Select(resource => resource.WorkspaceId).Distinct(StringComparer.OrdinalIgnoreCase))
                {
                    var response = await client.QueryWorkspaceAsync(workspaceId, query, new LogsQueryTimeRange(TimeSpan.FromHours(1)), cancellationToken: cancellationToken);
                    Assert.That(response.Value.Status, Is.EqualTo(LogsQueryResultStatus.Success), "Partial queries cannot establish tenant isolation.");
                    foreach (var row in response.Value.Table.Rows)
                    {
                        var recordId = row.GetString("RecordId");
                        Assert.That(expected.TryGetValue(recordId, out var item), Is.True, $"Unexpected telemetry {recordId} in run {runId}: invalid routing, host fallback, or outage isolation failure.");
                        Assert.That(workspaceId, Is.EqualTo(item!.Resource.WorkspaceId).IgnoreCase, $"Wrong workspace for {recordId}.");
                        Assert.That(row.GetString("ResourceId"), Is.EqualTo(item.Resource.ResourceId).IgnoreCase, $"Cross-tenant delivery of {recordId}.");
                        Assert.That(row.GetString("TelemetryTable"), Is.EqualTo(item.Table));
                        Assert.That(row.GetString("OperationId") ?? string.Empty, Is.EqualTo(item.OperationId), $"Trace correlation mismatch for {recordId}.");
                        Assert.That(row.GetString("ParentId") ?? string.Empty, Is.EqualTo(item.ParentId), $"Parent correlation mismatch for {recordId}.");
                        seen.Add(recordId);
                    }
                }

                TestContext.Out.WriteLine($"Run {runId}: observed {seen.Count}/{expected.Count} expected records after {clock.Elapsed.TotalSeconds:F0}s.");
                if (seen.Count == expected.Count)
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

                await Task.Delay(TimeSpan.FromSeconds(30), cancellationToken);
            }

            Assert.Fail($"Ingestion timed out for run {runId}. Missing record IDs: {string.Join(", ", expected.Keys.Except(seen))}. Negative assertions require a one-minute observation window after complete ingestion.");
        }

        internal sealed class ExpectedTelemetry
        {
            internal ExpectedTelemetry(TenantResource resource, string table, string operationId, string parentId)
            {
                Resource = resource;
                Table = table;
                OperationId = operationId;
                ParentId = parentId;
            }

            internal TenantResource Resource { get; }
            internal string Table { get; }
            internal string OperationId { get; }
            internal string ParentId { get; }
        }
    }
}
#endif