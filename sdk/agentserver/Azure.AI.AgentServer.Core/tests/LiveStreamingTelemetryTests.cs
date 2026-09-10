// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.OpenTelemetry.Exporter;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using NUnit.Framework;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Tests
{
    /// <summary>
    /// Live E2E test that runs a real Responses server (streaming SSE protocol),
    /// sends a request, and verifies traces arrive in Application Insights with
    /// correct parent-child hierarchy through the streaming pipeline.
    ///
    /// This specifically tests span parenting through the streaming pipeline — ensuring that
    /// handler-created spans are children of the ASP.NET Core request span even when
    /// events are streamed via SSE.
    ///
    /// Required environment variables (provisioned by test-resources.bicep):
    /// - AGENTSERVER_CONNECTION_STRING
    /// - AGENTSERVER_RESOURCE_ID (App Insights resource ID for querying)
    /// - Azure credentials (DefaultAzureCredential)
    ///
    /// Excluded from normal CI via [Category("Live")].
    /// </summary>
    [Category("Live")]
    [NonParallelizable]
    public class LiveStreamingTelemetryTests
    {
        // App Insights ingestion can take 2-5 minutes
        private static readonly TimeSpan s_maxIngestionWait = TimeSpan.FromMinutes(6);
        private static readonly TimeSpan s_pollInterval = TimeSpan.FromSeconds(30);

        private static AgentServerTestEnvironment TestEnvironment => s_lazyEnv.Value;
        private static readonly Lazy<AgentServerTestEnvironment> s_lazyEnv = new(() => new AgentServerTestEnvironment());

        /// <summary>
        /// Runs ResponsesServer.Run with a streaming handler, sends a real HTTP request,
        /// then verifies traces in App Insights have correct parent-child hierarchy
        /// through the SSE streaming pipeline.
        /// </summary>
        [Test]
        public async Task StreamingTracesAppearInAppInsightsWithCorrectHierarchy()
        {
            string uniqueMarker = Guid.NewGuid().ToString("N");
            StreamingTelemetryTestHandler.UniqueMarker = uniqueMarker;
            StreamingTelemetryTestHandler.CapturedTraceId = null;

            // ── Environment setup (same as a real deployed container) ──
            int port = Random.Shared.Next(20000, 20999);
            Environment.SetEnvironmentVariable("PORT", port.ToString());
            Environment.SetEnvironmentVariable(
                "APPLICATIONINSIGHTS_CONNECTION_STRING",
                TestEnvironment.ApplicationInsightsConnectionString);

            // FoundryEnvironment is a static class that caches env vars on first access.
            // We must call Reload() after setting env vars so the server picks up our
            // PORT and APPLICATIONINSIGHTS_CONNECTION_STRING values.
            FoundryEnvironment.Reload();

            try
            {
                // Start the server on a background thread — exactly as a user would
                // run `dotnet run` which calls ResponsesServer.Run<T>().
                Exception? serverError = null;
                var serverThread = new Thread(() =>
                {
                    try
                    {
                        ResponsesServer.Run<StreamingTelemetryTestHandler>(
                            configure: builder =>
                            {
                                builder.ConfigureTracing(tracing =>
                                    tracing.AddSource("AgentServer.Test.StreamingHandler"));
                            });
                    }
                    catch (Exception ex)
                    {
                        serverError = ex;
                    }
                })
                {
                    IsBackground = true,
                    Name = "ResponsesServer"
                };
                serverThread.Start();

                // Wait for server to start listening
                using var httpClient = new HttpClient();
                var startDeadline = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(30);
                bool serverReady = false;

                while (DateTimeOffset.UtcNow < startDeadline)
                {
                    if (serverError != null)
                    {
                        Assert.Fail($"Server failed to start: {serverError}");
                    }

                    try
                    {
                        using var probe = await httpClient.GetAsync($"http://localhost:{port}/readiness");
                        serverReady = true;
                        break;
                    }
                    catch (Exception) when (serverError == null)
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(500));
                    }
                }

                if (serverError != null)
                {
                    Assert.Fail($"Server failed to start: {serverError}");
                }

                Assert.That(serverReady, Is.True,
                    $"Server did not start within 30 seconds on port {port}");

                // ── Send a real HTTP request (streaming SSE) ──
                var requestBody = new StringContent(
                    JsonSerializer.Serialize(new { model = "test-streaming", stream = true }),
                    Encoding.UTF8,
                    "application/json");

                var response = await httpClient.PostAsync(
                    $"http://localhost:{port}/responses", requestBody);

                Assert.That((int)response.StatusCode, Is.LessThan(500),
                    "Responses endpoint should not return a server error");

                // Read the SSE stream to completion (ensures handler runs fully)
                var responseContent = await response.Content.ReadAsStringAsync();
                Assert.That(responseContent, Does.Contain("response.completed"),
                    "SSE stream should contain the response.completed event");

                Assert.That(StreamingTelemetryTestHandler.CapturedTraceId, Is.Not.Null,
                    "Handler should have captured a trace ID");
            }
            finally
            {
                Environment.SetEnvironmentVariable("PORT", null);
                Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
            }

            // Allow exporter flush
            await Task.Delay(TimeSpan.FromSeconds(5));

            // ── Query Application Insights ──
            var credential = new Azure.Identity.DefaultAzureCredential(
                new Azure.Identity.DefaultAzureCredentialOptions
                {
                    ExcludeInteractiveBrowserCredential = true,
                    TenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID"),
                });
            var logsClient = new LogsQueryClient(credential);
            var traceId = StreamingTelemetryTestHandler.CapturedTraceId!;
            var resourceId = new ResourceIdentifier(TestEnvironment.ApplicationInsightsResourceId);

            // Query for all spans in the trace
            string kql = $@"
                union requests, dependencies
                | where operation_Id == '{traceId}'
                | extend genAiOp = tostring(customDimensions['gen_ai.operation.name'])
                | project name, id, operation_ParentId, type, genAiOp
                | order by name asc";

            var deadline = DateTimeOffset.UtcNow + s_maxIngestionWait;

            while (DateTimeOffset.UtcNow < deadline)
            {
                await Task.Delay(s_pollInterval);

                var result = await logsClient.QueryResourceAsync(
                    resourceId,
                    kql,
                    new LogsQueryTimeRange(TimeSpan.FromMinutes(30)));

                var logsTable = result.Value.Table;

                // We expect at least 2 spans: HTTP request + HandleStreaming
                // (invoke_agent span was removed — framework spans parent under ASP.NET Core request)
                if (logsTable.Rows.Count >= 2)
                {
                    var rows = logsTable.Rows;
                    var columns = logsTable.Columns;

                    int nameIdx = columns.ToList().FindIndex(c => c.Name == "name");
                    int idIdx = columns.ToList().FindIndex(c => c.Name == "id");
                    int parentIdx = columns.ToList().FindIndex(c => c.Name == "operation_ParentId");
                    int genAiOpIdx = columns.ToList().FindIndex(c => c.Name == "genAiOp");

                    // HTTP request span (Server span from ASP.NET Core)
                    var requestRow = rows.FirstOrDefault(r =>
                        r[nameIdx]?.ToString()?.Contains("/responses") == true ||
                        r[nameIdx]?.ToString() == "POST /responses");

                    Assert.That(requestRow, Is.Not.Null,
                        "HTTP request span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => $"{r[nameIdx]} (genAiOp={r[genAiOpIdx]})"))}");

                    // HandleStreaming span — created inside handler during SSE streaming
                    var handlerRow = rows.FirstOrDefault(r =>
                        r[nameIdx]?.ToString() == "HandleStreaming");

                    Assert.That(handlerRow, Is.Not.Null,
                        "HandleStreaming child span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => r[nameIdx]?.ToString()))}");

                    // Verify HandleStreaming is a descendant of the request span.
                    // In the SSE streaming pipeline, there may be intermediate spans
                    // between the request and the handler, so we walk the parent chain.
                    var spanMap = rows.ToDictionary(
                        r => r[idIdx]?.ToString() ?? "",
                        r => r[parentIdx]?.ToString() ?? "");

                    string? current = handlerRow![parentIdx]?.ToString();
                    string requestId = requestRow![idIdx]?.ToString()!;
                    bool isDescendant = false;
                    int maxDepth = 10;
                    while (current != null && maxDepth-- > 0)
                    {
                        if (current == requestId)
                        {
                            isDescendant = true;
                            break;
                        }
                        spanMap.TryGetValue(current, out current);
                    }

                    Assert.That(isDescendant, Is.True,
                        "HandleStreaming should be a descendant of the HTTP request span. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => $"{r[nameIdx]}(id={r[idIdx]},parent={r[parentIdx]})"))}");

                    return;
                }
            }

            Assert.Fail($"Traces for operation_Id '{traceId}' did not appear in " +
                        $"App Insights within {s_maxIngestionWait.TotalMinutes} minutes. " +
                        "Expected at least 2 spans (HTTP request + HandleStreaming).");
        }

        /// <summary>
        /// Sends an HTTP request with an inbound <c>traceparent</c> header (simulating
        /// an upstream caller/orchestrator) to the streaming Responses endpoint, then
        /// verifies in App Insights that:
        /// 1. All spans share the caller's trace ID (W3C trace context propagation).
        /// 2. The handler's child span is a descendant of the caller's span through
        ///    the SSE streaming pipeline.
        ///
        /// This is the streaming equivalent of
        /// <c>HandlerChildSpan_ParentedUnderCaller_InAppInsights</c> from the Invocations tests.
        /// </summary>
        [Test]
        public async Task StreamingHandlerChildSpan_ParentedUnderCaller_InAppInsights()
        {
            string uniqueMarker = Guid.NewGuid().ToString("N");
            StreamingTelemetryTestHandler.UniqueMarker = uniqueMarker;
            StreamingTelemetryTestHandler.CapturedTraceId = null;

            // ── Environment setup ──
            int port = Random.Shared.Next(22000, 22999);
            Environment.SetEnvironmentVariable("PORT", port.ToString());
            Environment.SetEnvironmentVariable(
                "APPLICATIONINSIGHTS_CONNECTION_STRING",
                TestEnvironment.ApplicationInsightsConnectionString);

            FoundryEnvironment.Reload();

            // ── Set up a TracerProvider in the test process ──
            // This exports the caller span to App Insights so it appears in the
            // trace alongside the server-side spans, giving full end-to-end visibility.
            var callerSourceName = $"AgentServer.Test.StreamingCaller.{Guid.NewGuid():N}";
            using var callerSource = new ActivitySource(callerSourceName);
            using var callerTracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
                .AddSource(callerSourceName)
                .AddAzureMonitorTraceExporter(o =>
                    o.ConnectionString = TestEnvironment.ApplicationInsightsConnectionString)
                .Build();

            string? callerTraceId = null;
            string? callerSpanId = null;

            try
            {
                Exception? serverError = null;
                var serverThread = new Thread(() =>
                {
                    try
                    {
                        ResponsesServer.Run<StreamingTelemetryTestHandler>(
                            configure: builder =>
                            {
                                builder.ConfigureTracing(tracing =>
                                    tracing.AddSource("AgentServer.Test.StreamingHandler"));
                            });
                    }
                    catch (Exception ex)
                    {
                        serverError = ex;
                    }
                })
                {
                    IsBackground = true,
                    Name = "ResponsesServer-CallerTest"
                };
                serverThread.Start();

                // Wait for server to start listening
                using var httpClient = new HttpClient();
                var startDeadline = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(30);
                bool serverReady = false;

                while (DateTimeOffset.UtcNow < startDeadline)
                {
                    if (serverError != null)
                    {
                        Assert.Fail($"Server failed to start: {serverError}");
                    }

                    try
                    {
                        using var probe = await httpClient.GetAsync($"http://localhost:{port}/readiness");
                        serverReady = true;
                        break;
                    }
                    catch (Exception) when (serverError == null)
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(500));
                    }
                }

                if (serverError != null)
                {
                    Assert.Fail($"Server failed to start: {serverError}");
                }

                Assert.That(serverReady, Is.True,
                    $"Server did not start within 30 seconds on port {port}");

                // ── Send request under a caller span ──
                // Create a real span via ActivitySource so it gets exported to App Insights.
                // HttpClient's DiagnosticsHandler will create a child CLIENT span and
                // propagate the trace context via the traceparent header automatically.
                using var callerActivity = callerSource.StartActivity(
                    "CallerSpan", ActivityKind.Client);
                Assert.That(callerActivity, Is.Not.Null,
                    "Caller activity should be created (TracerProvider must sample it)");

                var callerTraceIdLocal = callerActivity!.TraceId.ToString();
                var callerSpanIdLocal = callerActivity.SpanId.ToString();
                callerTraceId = callerTraceIdLocal;
                callerSpanId = callerSpanIdLocal;

                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    $"http://localhost:{port}/responses")
                {
                    Content = new StringContent(
                        JsonSerializer.Serialize(new { model = "test-streaming", stream = true }),
                        Encoding.UTF8,
                        "application/json")
                };

                var response = await httpClient.SendAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();
                callerActivity.Stop();

                Assert.That((int)response.StatusCode, Is.LessThan(500),
                    "Responses endpoint should not return a server error");
                Assert.That(responseContent, Does.Contain("response.completed"),
                    "SSE stream should contain the response.completed event");

                // Verify the handler adopted the caller's trace ID
                Assert.That(StreamingTelemetryTestHandler.CapturedTraceId, Is.Not.Null,
                    "Handler should have captured a trace ID");
                Assert.That(StreamingTelemetryTestHandler.CapturedTraceId, Is.EqualTo(callerTraceIdLocal),
                    "Handler's trace ID should match the caller's traceparent trace ID");
            }
            finally
            {
                Environment.SetEnvironmentVariable("PORT", null);
                Environment.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", null);
            }

            // Allow exporter flush
            await Task.Delay(TimeSpan.FromSeconds(5));

            // ── Query Application Insights ──
            var credential = new Azure.Identity.DefaultAzureCredential(
                new Azure.Identity.DefaultAzureCredentialOptions
                {
                    ExcludeInteractiveBrowserCredential = true,
                    TenantId = Environment.GetEnvironmentVariable("AZURE_TENANT_ID"),
                });
            var logsClient = new LogsQueryClient(credential);
            var resourceId = new ResourceIdentifier(TestEnvironment.ApplicationInsightsResourceId);

            // Query for all spans matching the caller's trace ID
            string kql = $@"
                union requests, dependencies
                | where operation_Id == '{callerTraceId}'
                | project name, id, operation_ParentId, type
                | order by name asc";

            var deadline = DateTimeOffset.UtcNow + s_maxIngestionWait;

            while (DateTimeOffset.UtcNow < deadline)
            {
                await Task.Delay(s_pollInterval);

                var result = await logsClient.QueryResourceAsync(
                    resourceId,
                    kql,
                    new LogsQueryTimeRange(TimeSpan.FromMinutes(30)));

                var logsTable = result.Value.Table;

                // We expect at least 2 spans: HTTP request + HandleStreaming
                if (logsTable.Rows.Count >= 2)
                {
                    var rows = logsTable.Rows;
                    var columns = logsTable.Columns;

                    int nameIdx = columns.ToList().FindIndex(c => c.Name == "name");
                    int idIdx = columns.ToList().FindIndex(c => c.Name == "id");
                    int parentIdx = columns.ToList().FindIndex(c => c.Name == "operation_ParentId");

                    // 1. All spans share the caller's trace ID (verified by the KQL query filter)

                    // 2. HTTP request span (Server span from ASP.NET Core)
                    var requestRow = rows.FirstOrDefault(r =>
                        r[nameIdx]?.ToString()?.Contains("/responses") == true ||
                        r[nameIdx]?.ToString() == "POST /responses");

                    Assert.That(requestRow, Is.Not.Null,
                        "HTTP request span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => r[nameIdx]?.ToString()))}");

                    // 3. The request span's parent chain should trace back to the
                    //    caller's span ID. HttpClient may insert an intermediate client
                    //    span between the caller and the server, so we walk the chain.
                    var spanMap = rows.ToDictionary(
                        r => r[idIdx]?.ToString() ?? "",
                        r => r[parentIdx]?.ToString() ?? "");

                    string? current = requestRow![parentIdx]?.ToString();
                    bool requestTracesToCaller = current == callerSpanId;
                    int maxWalk = 10;
                    while (!requestTracesToCaller && current != null && maxWalk-- > 0)
                    {
                        if (current == callerSpanId)
                        {
                            requestTracesToCaller = true;
                            break;
                        }
                        spanMap.TryGetValue(current, out current);
                    }

                    Assert.That(requestTracesToCaller, Is.True,
                        "HTTP request span's parent chain should trace back to the caller's span ID. " +
                        $"Caller spanId: {callerSpanId}, request parentId: {requestRow[parentIdx]}. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => $"{r[nameIdx]}(id={r[idIdx]},parent={r[parentIdx]})"))}");

                    // 4. HandleStreaming span (created by the handler during SSE streaming)
                    var handlerRow = rows.FirstOrDefault(r =>
                        r[nameIdx]?.ToString() == "HandleStreaming");

                    Assert.That(handlerRow, Is.Not.Null,
                        "HandleStreaming child span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => r[nameIdx]?.ToString()))}");

                    // 5. HandleStreaming should be a descendant of the request span
                    //    (which is itself a child of the caller)
                    string requestId = requestRow[idIdx]?.ToString()!;
                    current = handlerRow![parentIdx]?.ToString();
                    bool isDescendant = false;
                    int maxDepth = 10;
                    while (current != null && maxDepth-- > 0)
                    {
                        if (current == requestId)
                        {
                            isDescendant = true;
                            break;
                        }
                        spanMap.TryGetValue(current, out current);
                    }

                    Assert.That(isDescendant, Is.True,
                        "HandleStreaming should be a descendant of the HTTP request span " +
                        "(which is parented under the caller). " +
                        $"Found spans: {string.Join(", ", rows.Select(r => $"{r[nameIdx]}(id={r[idIdx]},parent={r[parentIdx]})"))}");

                    return;
                }
            }

            Assert.Fail($"Traces for caller trace ID '{callerTraceId}' did not appear in " +
                        $"App Insights within {s_maxIngestionWait.TotalMinutes} minutes. " +
                        "Expected at least 2 spans (HTTP request + HandleStreaming).");
        }

        // ═══════════════════════════════════════════════════════════════════════
        // Test handler — streaming ResponseHandler that creates a child span
        // ═══════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Streaming handler that creates a child span during SSE event generation.
        /// This verifies that span parenting works through SSE streaming — the child span
        /// should be nested under the ASP.NET Core request span.
        /// </summary>
        public sealed class StreamingTelemetryTestHandler : ResponseHandler
        {
            internal static string? UniqueMarker { get; set; }
            internal static string? CapturedTraceId { get; set; }

            private static readonly ActivitySource s_activitySource = new("AgentServer.Test.StreamingHandler");

            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                // Capture trace ID from the current activity (set by ASP.NET Core request span)
                CapturedTraceId = Activity.Current?.TraceId.ToString();

                // Create a child span — this should be a child of the request span
                using var activity = s_activitySource.StartActivity("HandleStreaming");
                activity?.SetTag("test.marker", UniqueMarker);

                // Yield response.created
                var response = new ResponseObject(context.ResponseId, request.Model ?? "test-streaming");
                yield return new ResponseCreatedEvent(0, response);

                // Simulate async streaming work
                await Task.Yield();

                // Mark response as completed and yield response.completed
                response.Status = ResponseStatus.Completed;
                yield return new ResponseCompletedEvent(1, response);
            }
        }
    }
}

#endif
