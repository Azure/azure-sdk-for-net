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
    /// This specifically tests the SseResult span parenting fix — ensuring that
    /// handler-created spans are children of the invoke_agent span even when
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

                // We expect at least 3 spans: HTTP request, invoke_agent, HandleStreaming
                if (logsTable.Rows.Count >= 3)
                {
                    var rows = logsTable.Rows;
                    var columns = logsTable.Columns;

                    int nameIdx = columns.ToList().FindIndex(c => c.Name == "name");
                    int idIdx = columns.ToList().FindIndex(c => c.Name == "id");
                    int parentIdx = columns.ToList().FindIndex(c => c.Name == "operation_ParentId");
                    int genAiOpIdx = columns.ToList().FindIndex(c => c.Name == "genAiOp");

                    // invoke_agent span — identified by gen_ai.operation.name custom dimension
                    var invokeAgentRow = rows.FirstOrDefault(r =>
                        r[genAiOpIdx]?.ToString() == "invoke_agent");

                    Assert.That(invokeAgentRow, Is.Not.Null,
                        "invoke_agent span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => $"{r[nameIdx]} (genAiOp={r[genAiOpIdx]})"))}");

                    // HandleStreaming span (child of invoke_agent — created inside handler during SSE streaming)
                    var handlerRow = rows.FirstOrDefault(r =>
                        r[nameIdx]?.ToString() == "HandleStreaming");

                    Assert.That(handlerRow, Is.Not.Null,
                        "HandleStreaming child span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => r[nameIdx]?.ToString()))}");

                    // Verify parent-child: HandleStreaming's parent == invoke_agent's id
                    // This confirms the SseResult span parenting fix is working — that
                    // Activity.Current is restored before iterating handler events.
                    Assert.That(handlerRow![parentIdx]?.ToString(),
                        Is.EqualTo(invokeAgentRow![idIdx]?.ToString()),
                        "HandleStreaming should be a child of invoke_agent. " +
                        "If this fails, the SseResult Activity.Current fix is not propagating correctly.");

                    return;
                }
            }

            Assert.Fail($"Traces for operation_Id '{traceId}' did not appear in " +
                        $"App Insights within {s_maxIngestionWait.TotalMinutes} minutes. " +
                        "Expected at least 3 spans (HTTP request + invoke_agent + HandleStreaming).");
        }

        // ═══════════════════════════════════════════════════════════════════════
        // Test handler — streaming ResponseHandler that creates a child span
        // ═══════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Streaming handler that creates a child span during SSE event generation.
        /// This verifies that the SseResult span parenting fix works — the child span
        /// should be nested under invoke_agent, not under the HTTP request.
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
                // Capture trace ID from the current activity (set by invoke_agent span)
                CapturedTraceId = Activity.Current?.TraceId.ToString();

                // Create a child span — this should be a child of invoke_agent
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
