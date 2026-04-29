// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if NET8_0_OR_GREATER

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests
{
    /// <summary>
    /// Live E2E tests that boot a real <see cref="AgentHost"/> with the Core
    /// telemetry pipeline (<c>AddAgentHostTelemetry</c>), send HTTP requests,
    /// and query Application Insights via Log Analytics to verify that spans
    /// are exported with correct parent-child hierarchy.
    /// </summary>
    /// <remarks>
    /// These tests require:
    /// - APPLICATIONINSIGHTS_CONNECTION_STRING (for trace export via Microsoft OpenTelemetry distro)
    /// - WORKSPACE_ID (Log Analytics workspace for querying)
    /// - Azure credentials (DefaultAzureCredential via test framework)
    ///
    /// Provisioned by test-resources.bicep. Excluded from normal CI via [Category("Live")].
    /// </remarks>
    [Category("Live")]
    public class LiveTelemetryTests : RecordedTestBase<AgentServerTestEnvironment>
    {
        // ActivitySource used inside test handlers to simulate framework child spans
        private static readonly ActivitySource s_frameworkSource = new("Experimental.Microsoft.Agents.AI.Test");

        // App Insights ingestion can take 2-5 minutes
        private static readonly TimeSpan s_maxIngestionWait = TimeSpan.FromMinutes(6);
        private static readonly TimeSpan s_pollInterval = TimeSpan.FromSeconds(30);

        public LiveTelemetryTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Boots an <see cref="AgentHost"/> with the real telemetry pipeline, sends an
        /// HTTP request whose handler creates a child span (simulating framework work),
        /// and verifies the ASP.NET Core request span -> framework child span hierarchy
        /// appears in Application Insights.
        /// </summary>
        [RecordedTest]
        public async Task TracesShowCorrectParentChildHierarchy()
        {
            string uniqueMarker = Guid.NewGuid().ToString("N");
            string? capturedTraceId = null;

            // Boot AgentHost with APPLICATIONINSIGHTS_CONNECTION_STRING set so the
            // Microsoft OpenTelemetry distro exports to the real App Insights resource.
            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();

            // Inject the connection string so the distro auto-exports to App Insights
            builder.WebApplicationBuilder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["APPLICATIONINSIGHTS_CONNECTION_STRING"] = TestEnvironment.ApplicationInsightsConnectionString
            });

            // Register a custom ActivitySource so we can create framework child spans
            builder.ConfigureTracing(tracing =>
            {
                tracing.AddSource(s_frameworkSource.Name);
            });

            // Register a protocol endpoint that creates a child span
            builder.RegisterProtocol("TestProtocol", endpoints =>
            {
                endpoints.MapGet("/test-trace", async (HttpContext ctx) =>
                {
                    // Capture the ASP.NET Core trace ID (parent span is auto-created by ASP.NET)
                    capturedTraceId = Activity.Current?.TraceId.ToHexString();
                    Activity.Current?.SetTag("test.marker", uniqueMarker);

                    // Create child span simulating agent framework work
                    using var frameworkSpan = s_frameworkSource.StartActivity(
                        "AgentFramework.ExecuteTool",
                        ActivityKind.Internal,
                        Activity.Current!.Context);

                    frameworkSpan?.SetTag("test.marker", uniqueMarker);
                    frameworkSpan?.SetTag("gen_ai.operation.name", "execute_tool");

                    await Task.Delay(50); // Simulate work
                    return Results.Ok("done");
                });
            });

            var app = builder.Build();
            await app.App.StartAsync();

            try
            {
                // Send request - this triggers the ASP.NET Core span + our child span
                var client = app.App.GetTestClient();
                var response = await client.GetAsync("/test-trace");
                Assert.That(response.IsSuccessStatusCode, Is.True, "Test endpoint should return 200");
                Assert.That(capturedTraceId, Is.Not.Null, "Should have captured a trace ID");
            }
            finally
            {
                // Stop the host to flush the telemetry pipeline
                await app.App.StopAsync();
            }

            // Wait briefly for flush to complete before querying
            await Task.Delay(TimeSpan.FromSeconds(5));

            // Query App Insights to verify the spans arrived with correct hierarchy
            var logsClient = new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()));

            string kql = $@"
                union requests, dependencies
                | where operation_Id == '{capturedTraceId}'
                | where customDimensions['test.marker'] == '{uniqueMarker}'
                | project operation_Id, id, operation_ParentId, name, timestamp
                | order by timestamp asc";

            LogsQueryResult? queryResult = null;
            var stopwatch = Stopwatch.StartNew();
            bool dataFound = false;

            while (stopwatch.Elapsed < s_maxIngestionWait)
            {
                try
                {
                    var queryResponse = await logsClient.QueryWorkspaceAsync(
                        TestEnvironment.WorkspaceId,
                        kql,
                        new LogsQueryTimeRange(TimeSpan.FromMinutes(30)),
                        new LogsQueryOptions { AllowPartialErrors = true });

                    queryResult = queryResponse.Value;

                    if (queryResult.Table.Rows.Count >= 2)
                    {
                        dataFound = true;
                        break;
                    }
                }
                catch (RequestFailedException)
                {
                    // Transient query failures, retry
                }

                await Task.Delay(s_pollInterval);
            }

            Assert.That(dataFound, Is.True,
                $"Expected at least 2 trace entries within {s_maxIngestionWait.TotalMinutes} minutes. TraceId: {capturedTraceId}");

            var rows = queryResult!.Table.Rows;
            var columns = queryResult.Table.Columns;

            int idIndex = GetColumnIndex(columns, "id");
            int parentIdIndex = GetColumnIndex(columns, "operation_ParentId");
            int nameIndex = GetColumnIndex(columns, "name");

            // Find the ASP.NET Core request span (GET /test-trace)
            var requestRow = rows.FirstOrDefault(r =>
                r[nameIndex]?.ToString()?.Contains("/test-trace") == true ||
                r[nameIndex]?.ToString()?.StartsWith("GET") == true);
            Assert.That(requestRow, Is.Not.Null,
                "ASP.NET Core request span for '/test-trace' not found in App Insights");

            // Find child span (AgentFramework.ExecuteTool)
            var childRow = rows.FirstOrDefault(r =>
                r[nameIndex]?.ToString() == "AgentFramework.ExecuteTool");
            Assert.That(childRow, Is.Not.Null,
                "Child span 'AgentFramework.ExecuteTool' not found in App Insights");

            // Verify parent-child relationship: child's parentId == request span's id
            string actualChildParentId = childRow![parentIdIndex]?.ToString() ?? "";
            string actualParentId = requestRow![idIndex]?.ToString() ?? "";

            Assert.That(actualChildParentId, Is.EqualTo(actualParentId),
                "Framework child span's operation_ParentId should equal ASP.NET request span's id");

            // Verify they share the same operation_Id (trace ID)
            int operationIdIndex = GetColumnIndex(columns, "operation_Id");
            Assert.That(childRow[operationIdIndex]?.ToString(),
                Is.EqualTo(requestRow[operationIdIndex]?.ToString()),
                "Both spans should share the same operation_Id (trace ID)");
        }

        /// <summary>
        /// Boots an <see cref="AgentHost"/>, sends an HTTP request whose handler creates
        /// a 3-level span hierarchy (ASP.NET -> Framework -> Tool), and verifies all three
        /// levels appear correctly in Application Insights.
        /// </summary>
        [RecordedTest]
        public async Task MultiLevelHierarchyPreservedInAppInsights()
        {
            string uniqueMarker = Guid.NewGuid().ToString("N");
            string? capturedTraceId = null;

            var builder = AgentHost.CreateBuilder();
            builder.WebApplicationBuilder.WebHost.UseTestServer();

            builder.WebApplicationBuilder.Configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["APPLICATIONINSIGHTS_CONNECTION_STRING"] = TestEnvironment.ApplicationInsightsConnectionString
            });

            builder.ConfigureTracing(tracing =>
            {
                tracing.AddSource(s_frameworkSource.Name);
            });

            builder.RegisterProtocol("TestProtocol", endpoints =>
            {
                endpoints.MapGet("/test-multi-level", async (HttpContext ctx) =>
                {
                    capturedTraceId = Activity.Current?.TraceId.ToHexString();
                    Activity.Current?.SetTag("test.marker", uniqueMarker);

                    // Level 2: Framework span (child of ASP.NET request span)
                    using var frameworkSpan = s_frameworkSource.StartActivity(
                        "Framework.Process",
                        ActivityKind.Internal,
                        Activity.Current!.Context);

                    frameworkSpan?.SetTag("test.marker", uniqueMarker);

                    // Level 3: Tool span (child of framework span)
                    using var toolSpan = s_frameworkSource.StartActivity(
                        "Tool.Execute",
                        ActivityKind.Internal,
                        frameworkSpan!.Context);

                    toolSpan?.SetTag("test.marker", uniqueMarker);

                    await Task.Delay(50); // Simulate work
                    return Results.Ok("done");
                });
            });

            var app = builder.Build();
            await app.App.StartAsync();

            try
            {
                var client = app.App.GetTestClient();
                var response = await client.GetAsync("/test-multi-level");
                Assert.That(response.IsSuccessStatusCode, Is.True);
                Assert.That(capturedTraceId, Is.Not.Null);
            }
            finally
            {
                await app.App.StopAsync();
            }

            await Task.Delay(TimeSpan.FromSeconds(5));

            // Query and verify 3-level hierarchy
            var logsClient = new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()));

            string kql = $@"
                union requests, dependencies
                | where operation_Id == '{capturedTraceId}'
                | where customDimensions['test.marker'] == '{uniqueMarker}'
                | project operation_Id, id, operation_ParentId, name, timestamp
                | order by timestamp asc";

            LogsQueryResult? queryResult = null;
            var stopwatch = Stopwatch.StartNew();
            bool dataFound = false;

            while (stopwatch.Elapsed < s_maxIngestionWait)
            {
                try
                {
                    var queryResponse = await logsClient.QueryWorkspaceAsync(
                        TestEnvironment.WorkspaceId,
                        kql,
                        new LogsQueryTimeRange(TimeSpan.FromMinutes(30)),
                        new LogsQueryOptions { AllowPartialErrors = true });

                    queryResult = queryResponse.Value;

                    if (queryResult.Table.Rows.Count >= 3)
                    {
                        dataFound = true;
                        break;
                    }
                }
                catch (RequestFailedException)
                {
                    // Transient, retry
                }

                await Task.Delay(s_pollInterval);
            }

            Assert.That(dataFound, Is.True,
                $"Expected 3 trace entries within {s_maxIngestionWait.TotalMinutes} minutes. TraceId: {capturedTraceId}");

            var rows = queryResult!.Table.Rows;
            var columns = queryResult.Table.Columns;

            int idIndex = GetColumnIndex(columns, "id");
            int parentIdIndex = GetColumnIndex(columns, "operation_ParentId");
            int nameIndex = GetColumnIndex(columns, "name");

            // Find all 3 levels
            var requestRow = rows.FirstOrDefault(r =>
                r[nameIndex]?.ToString()?.Contains("/test-multi-level") == true ||
                r[nameIndex]?.ToString()?.StartsWith("GET") == true);
            var frameworkRow = rows.First(r => r[nameIndex]?.ToString() == "Framework.Process");
            var toolRow = rows.First(r => r[nameIndex]?.ToString() == "Tool.Execute");

            Assert.That(requestRow, Is.Not.Null, "ASP.NET request span not found");

            // Verify: Framework.Process parent = ASP.NET request span
            Assert.That(frameworkRow[parentIdIndex]?.ToString(),
                Is.EqualTo(requestRow![idIndex]?.ToString()),
                "Framework span should be child of ASP.NET request span");

            // Verify: Tool.Execute parent = Framework.Process
            Assert.That(toolRow[parentIdIndex]?.ToString(),
                Is.EqualTo(frameworkRow[idIndex]?.ToString()),
                "Tool span should be child of Framework span");
        }

        private static int GetColumnIndex(IReadOnlyList<LogsTableColumn> columns, string name)
        {
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].Name == name)
                    return i;
            }
            throw new InvalidOperationException($"Column '{name}' not found in query result");
        }
    }
}

#endif