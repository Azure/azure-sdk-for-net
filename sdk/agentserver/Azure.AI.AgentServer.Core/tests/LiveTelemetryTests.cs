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
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests
{
    /// <summary>
    /// Live E2E tests that export traces to a real Application Insights resource
    /// and query back via Log Analytics to verify span parent-child hierarchy.
    /// </summary>
    /// <remarks>
    /// These tests require:
    /// - APPLICATIONINSIGHTS_CONNECTION_STRING (for trace export)
    /// - WORKSPACE_ID (Log Analytics workspace for querying)
    /// - Azure credentials (DefaultAzureCredential via test framework)
    ///
    /// Provisioned by test-resources.bicep. Excluded from normal CI via [Category("Live")].
    /// </remarks>
    [Category("Live")]
    public class LiveTelemetryTests : RecordedTestBase<AgentServerTestEnvironment>
    {
        private const string AgentServerSourceName = "Azure.AI.AgentServer.Test";
        private static readonly ActivitySource s_agentServerSource = new(AgentServerSourceName);
        private static readonly ActivitySource s_frameworkSource = new("Experimental.Microsoft.Agents.AI.Test");

        // App Insights ingestion can take 2-5 minutes
        private static readonly TimeSpan s_maxIngestionWait = TimeSpan.FromMinutes(6);
        private static readonly TimeSpan s_pollInterval = TimeSpan.FromSeconds(30);

        public LiveTelemetryTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task TracesShowCorrectParentChildHierarchy()
        {
            // Generate a unique operation ID to find our traces
            string uniqueMarker = Guid.NewGuid().ToString("N");

            // Set up an ActivityListener to ensure activities are created
            using var listener = new ActivityListener
            {
                ShouldListenTo = source =>
                    source.Name == AgentServerSourceName ||
                    source.Name == "Experimental.Microsoft.Agents.AI.Test",
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded
            };
            ActivitySource.AddActivityListener(listener);

            string parentSpanId;
            string childSpanId;
            string traceId;

            // Create spans with parent-child relationship
            using (var parentActivity = s_agentServerSource.StartActivity("AgentServer.ProcessRequest", ActivityKind.Server))
            {
                Assert.That(parentActivity, Is.Not.Null, "Parent activity should be created");
                parentActivity!.SetTag("test.marker", uniqueMarker);
                parentActivity.SetTag("gen_ai.system", "az.ai.agent");

                parentSpanId = parentActivity.SpanId.ToHexString();
                traceId = parentActivity.TraceId.ToHexString();

                // Create child span simulating framework activity
                using (var childActivity = s_frameworkSource.StartActivity(
                    "AgentFramework.ExecuteTool",
                    ActivityKind.Internal,
                    parentActivity.Context))
                {
                    Assert.That(childActivity, Is.Not.Null, "Child activity should be created");
                    childActivity!.SetTag("test.marker", uniqueMarker);
                    childActivity.SetTag("gen_ai.operation.name", "execute_tool");

                    childSpanId = childActivity.SpanId.ToHexString();

                    // Simulate some work
                    await Task.Delay(50);
                }
            }

            // Now query App Insights to verify the traces arrived with correct hierarchy
            var logsClient = new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()));

            // KQL query to find our specific trace by operation_Id (trace ID)
            string kql = $@"
                union requests, dependencies
                | where operation_Id == '{traceId}'
                | where customDimensions['test.marker'] == '{uniqueMarker}'
                | project operation_Id, id, operation_ParentId, name, itemType, timestamp
                | order by timestamp asc";

            // Poll until data appears (ingestion delay)
            LogsQueryResult? queryResult = null;
            var stopwatch = Stopwatch.StartNew();
            bool dataFound = false;

            while (stopwatch.Elapsed < s_maxIngestionWait)
            {
                try
                {
                    var response = await logsClient.QueryWorkspaceAsync(
                        TestEnvironment.WorkspaceId,
                        kql,
                        new LogsQueryTimeRange(TimeSpan.FromMinutes(30)),
                        new LogsQueryOptions { AllowPartialErrors = true });

                    queryResult = response.Value;

                    if (queryResult.Table.Rows.Count >= 2)
                    {
                        dataFound = true;
                        break;
                    }
                }
                catch (RequestFailedException)
                {
                    // Transient errors during ingestion, retry
                }

                await Task.Delay(s_pollInterval);
            }

            Assert.That(dataFound, Is.True,
                $"Expected at least 2 trace entries in App Insights within {s_maxIngestionWait.TotalMinutes} minutes. " +
                $"TraceId: {traceId}, Marker: {uniqueMarker}");

            // Verify hierarchy
            var rows = queryResult!.Table.Rows;
            var columns = queryResult.Table.Columns;

            int idIndex = GetColumnIndex(columns, "id");
            int parentIdIndex = GetColumnIndex(columns, "operation_ParentId");
            int nameIndex = GetColumnIndex(columns, "name");

            // Find parent span (AgentServer.ProcessRequest)
            var parentRow = rows.FirstOrDefault(r =>
                r[nameIndex]?.ToString() == "AgentServer.ProcessRequest");
            Assert.That(parentRow, Is.Not.Null, "Parent span 'AgentServer.ProcessRequest' not found in App Insights");

            // Find child span (AgentFramework.ExecuteTool)
            var childRow = rows.FirstOrDefault(r =>
                r[nameIndex]?.ToString() == "AgentFramework.ExecuteTool");
            Assert.That(childRow, Is.Not.Null, "Child span 'AgentFramework.ExecuteTool' not found in App Insights");

            // Verify parent-child relationship
            string actualChildParentId = childRow![parentIdIndex]?.ToString() ?? "";
            string actualParentId = parentRow![idIndex]?.ToString() ?? "";

            Assert.That(actualChildParentId, Is.EqualTo(actualParentId),
                "Child span's operation_ParentId should equal parent span's id");

            // Verify they share the same operation_Id (trace ID)
            int operationIdIndex = GetColumnIndex(columns, "operation_Id");
            Assert.That(childRow[operationIdIndex]?.ToString(), Is.EqualTo(parentRow[operationIdIndex]?.ToString()),
                "Parent and child spans should share the same operation_Id (trace ID)");
        }

        [RecordedTest]
        public async Task MultiLevelHierarchyPreservedInAppInsights()
        {
            string uniqueMarker = Guid.NewGuid().ToString("N");

            using var listener = new ActivityListener
            {
                ShouldListenTo = source =>
                    source.Name == AgentServerSourceName ||
                    source.Name == "Experimental.Microsoft.Agents.AI.Test",
                Sample = (ref ActivityCreationOptions<ActivityContext> _) => ActivitySamplingResult.AllDataAndRecorded
            };
            ActivitySource.AddActivityListener(listener);

            string traceId;

            // Create 3-level hierarchy: Server → Framework → Tool
            using (var serverSpan = s_agentServerSource.StartActivity("Server.Handle", ActivityKind.Server))
            {
                serverSpan!.SetTag("test.marker", uniqueMarker);
                traceId = serverSpan.TraceId.ToHexString();

                using (var frameworkSpan = s_frameworkSource.StartActivity(
                    "Framework.Process", ActivityKind.Internal, serverSpan.Context))
                {
                    frameworkSpan!.SetTag("test.marker", uniqueMarker);

                    using (var toolSpan = s_frameworkSource.StartActivity(
                        "Tool.Execute", ActivityKind.Internal, frameworkSpan.Context))
                    {
                        toolSpan!.SetTag("test.marker", uniqueMarker);
                        await Task.Delay(50);
                    }
                }
            }

            // Query and verify
            var logsClient = new LogsQueryClient(
                TestEnvironment.LogsEndpoint,
                TestEnvironment.Credential,
                InstrumentClientOptions(new LogsQueryClientOptions()));

            string kql = $@"
                union requests, dependencies
                | where operation_Id == '{traceId}'
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
                    var response = await logsClient.QueryWorkspaceAsync(
                        TestEnvironment.WorkspaceId,
                        kql,
                        new LogsQueryTimeRange(TimeSpan.FromMinutes(30)),
                        new LogsQueryOptions { AllowPartialErrors = true });

                    queryResult = response.Value;

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
                $"Expected 3 trace entries within {s_maxIngestionWait.TotalMinutes} minutes. TraceId: {traceId}");

            var rows = queryResult!.Table.Rows;
            var columns = queryResult.Table.Columns;

            int idIndex = GetColumnIndex(columns, "id");
            int parentIdIndex = GetColumnIndex(columns, "operation_ParentId");
            int nameIndex = GetColumnIndex(columns, "name");

            // Find all 3 spans
            var serverRow = rows.First(r => r[nameIndex]?.ToString() == "Server.Handle");
            var frameworkRow = rows.First(r => r[nameIndex]?.ToString() == "Framework.Process");
            var toolRow = rows.First(r => r[nameIndex]?.ToString() == "Tool.Execute");

            // Verify: Framework.Process parent = Server.Handle
            Assert.That(frameworkRow[parentIdIndex]?.ToString(), Is.EqualTo(serverRow[idIndex]?.ToString()),
                "Framework span should be child of Server span");

            // Verify: Tool.Execute parent = Framework.Process
            Assert.That(toolRow[parentIdIndex]?.ToString(), Is.EqualTo(frameworkRow[idIndex]?.ToString()),
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
