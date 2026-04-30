// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER

using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Invocations;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using OpenTelemetry.Trace;

namespace Azure.AI.AgentServer.Core.Tests
{
    /// <summary>
    /// Live E2E test that runs a real Invocations server — identical to the
    /// HelloWorld BYO sample — sends a real HTTP request, stops the server,
    /// then queries Application Insights to verify traces arrived with
    /// correct parent-child hierarchy.
    ///
    /// Required environment variables (provisioned by test-resources.bicep):
    /// - AGENTSERVER_CONNECTION_STRING (or CONNECTION_STRING)
    /// - AGENTSERVER_RESOURCE_ID (or RESOURCE_ID — App Insights resource ID for querying)
    /// - Azure credentials (DefaultAzureCredential via test framework)
    ///
    /// Excluded from normal CI via [Category("Live")].
    /// </summary>
    [Category("Live")]
    [NonParallelizable]
    public class LiveTelemetryTests
    {
        // App Insights ingestion can take 2-5 minutes
        private static readonly TimeSpan s_maxIngestionWait = TimeSpan.FromMinutes(6);
        private static readonly TimeSpan s_pollInterval = TimeSpan.FromSeconds(30);

        private static AgentServerTestEnvironment TestEnvironment => s_lazyEnv.Value;
        private static readonly Lazy<AgentServerTestEnvironment> s_lazyEnv = new(() => new AgentServerTestEnvironment());

        /// <summary>
        /// Runs InvocationsServer.Run exactly like the HelloWorld BYO sample,
        /// sends a real HTTP request, then verifies traces in App Insights.
        /// </summary>
        [Test]
        public async Task TracesAppearInAppInsightsWithCorrectHierarchy()
        {
            string uniqueMarker = Guid.NewGuid().ToString("N");
            TelemetryTestHandler.UniqueMarker = uniqueMarker;
            TelemetryTestHandler.CapturedTraceId = null;

            // ── Environment setup (same as a real deployed container) ──
            int port = Random.Shared.Next(9000, 9999);
            Environment.SetEnvironmentVariable("PORT", port.ToString());
            Environment.SetEnvironmentVariable(
                "APPLICATIONINSIGHTS_CONNECTION_STRING",
                TestEnvironment.ApplicationInsightsConnectionString);

            try
            {
                // Start the server on a background thread — exactly as a user would
                // run `dotnet run` which calls InvocationsServer.Run<T>().
                // InvocationsServer.Run blocks forever, so we run it on a thread.
                Exception? serverError = null;
                var serverThread = new Thread(() =>
                {
                    try
                    {
                        InvocationsServer.Run<TelemetryTestHandler>(
                            configure: builder =>
                            {
                                // Register the handler's custom ActivitySource so its spans
                                // are exported — this is the pattern real developers use to
                                // add their own tracing alongside the built-in agent spans.
                                builder.ConfigureTracing(tracing =>
                                    tracing.AddSource("AgentServer.Test.Handler"));
                            });
                    }
                    catch (Exception ex)
                    {
                        serverError = ex;
                    }
                })
                {
                    IsBackground = true,
                    Name = "InvocationsServer"
                };
                serverThread.Start();

                // Wait for server to start listening — poll until it accepts connections
                using var httpClient = new HttpClient();
                var startDeadline = DateTimeOffset.UtcNow + TimeSpan.FromSeconds(30);
                bool serverReady = false;

                while (DateTimeOffset.UtcNow < startDeadline)
                {
                    if (serverError != null)
                    {
                        Assert.Fail($"Server failed to start: {serverError.Message}");
                    }

                    try
                    {
                        using var probe = await httpClient.GetAsync($"http://localhost:{port}/health");
                        serverReady = true;
                        break;
                    }
                    catch (HttpRequestException)
                    {
                        await Task.Delay(TimeSpan.FromMilliseconds(500));
                    }
                }

                Assert.That(serverReady, Is.True, "Server did not start within 30 seconds");

                // ── Send a real HTTP request ──
                var requestBody = new StringContent(
                    JsonSerializer.Serialize(new { message = "Hello from test" }),
                    Encoding.UTF8,
                    "application/json");

                var response = await httpClient.PostAsync(
                    $"http://localhost:{port}/invocations", requestBody);

                Assert.That((int)response.StatusCode, Is.LessThan(500),
                    "Invocation endpoint should not return a server error");
                Assert.That(TelemetryTestHandler.CapturedTraceId, Is.Not.Null,
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
                    ExcludeInteractiveBrowserCredential = true
                });
            var logsClient = new LogsQueryClient(credential);
            var traceId = TelemetryTestHandler.CapturedTraceId!;
            var resourceId = new ResourceIdentifier(TestEnvironment.ApplicationInsightsResourceId);

            // Query for all spans in the trace — requests table has Server spans,
            // dependencies table has Internal/Client spans.
            string kql = $@"
                union requests, dependencies
                | where operation_Id == '{traceId}'
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

                // We expect at least 3 spans: HTTP request, invoke_agent, HandleInvocation
                // (plus possibly outgoing HTTP dependency from in-process HttpClient)
                if (logsTable.Rows.Count >= 3)
                {
                    var rows = logsTable.Rows;
                    var columns = logsTable.Columns;

                    int nameIdx = columns.ToList().FindIndex(c => c.Name == "name");
                    int idIdx = columns.ToList().FindIndex(c => c.Name == "id");
                    int parentIdx = columns.ToList().FindIndex(c => c.Name == "operation_ParentId");

                    // invoke_agent span (Server span from InvocationsActivitySource)
                    var invokeAgentRow = rows.FirstOrDefault(r =>
                        r[nameIdx]?.ToString() == "invoke_agent");

                    Assert.That(invokeAgentRow, Is.Not.Null,
                        "invoke_agent span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => r[nameIdx]?.ToString()))}");

                    // HandleInvocation span (child of invoke_agent)
                    var handlerRow = rows.FirstOrDefault(r =>
                        r[nameIdx]?.ToString() == "HandleInvocation");

                    Assert.That(handlerRow, Is.Not.Null,
                        "HandleInvocation child span not found in App Insights. " +
                        $"Found spans: {string.Join(", ", rows.Select(r => r[nameIdx]?.ToString()))}");

                    // Verify parent-child: HandleInvocation's parent == invoke_agent's id
                    Assert.That(handlerRow![parentIdx]?.ToString(),
                        Is.EqualTo(invokeAgentRow![idIdx]?.ToString()),
                        "HandleInvocation should be a child of invoke_agent");

                    return;
                }
            }

            Assert.Fail($"Traces for operation_Id '{traceId}' did not appear in " +
                        $"App Insights within {s_maxIngestionWait.TotalMinutes} minutes. " +
                        "Expected at least 3 spans (HTTP request + invoke_agent + HandleInvocation).");
        }

        // ═══════════════════════════════════════════════════════════════════════
        // Test handler — same structure as HelloWorldHandler from the sample
        // ═══════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Minimal handler that captures the trace ID and returns a simple SSE response.
        /// Same structure as HelloWorldHandler but without a real model call.
        /// </summary>
        public sealed class TelemetryTestHandler(ILogger<TelemetryTestHandler> logger) : InvocationHandler
        {
            internal static string? UniqueMarker { get; set; }
            internal static string? CapturedTraceId { get; set; }

            private static readonly ActivitySource s_activitySource = new("AgentServer.Test.Handler");

            public override async Task HandleAsync(
                HttpRequest request,
                HttpResponse response,
                InvocationContext context,
                CancellationToken cancellationToken)
            {
                CapturedTraceId = Activity.Current?.TraceId.ToString();

                logger.LogInformation(
                    "Processing invocation {InvocationId} (session {SessionId}), marker={Marker}",
                    context.InvocationId, context.SessionId, UniqueMarker);

                // Simulate agent work — child span like a model call
                using var activity = s_activitySource.StartActivity("HandleInvocation");
                activity?.SetTag("test.marker", UniqueMarker);

                // Return SSE response — same format as HelloWorldHandler
                response.ContentType = "text/event-stream";
                response.Headers.CacheControl = "no-cache";

                var doneEvent = JsonSerializer.Serialize(new
                {
                    type = "done",
                    invocation_id = context.InvocationId,
                    session_id = context.SessionId,
                    full_text = "Hello from test handler!",
                });
                await response.WriteAsync($"data: {doneEvent}\n\n", cancellationToken);
                await response.Body.FlushAsync(cancellationToken);
            }
        }
    }
}

#endif
