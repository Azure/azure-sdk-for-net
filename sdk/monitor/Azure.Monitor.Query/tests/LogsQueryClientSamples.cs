// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsQueryClientSamples : SamplesBase<MonitorQueryTestEnvironment>
    {
        [Test]
        [Explicit]
        public async Task QueryLogsWithStatistics()
        {
            #region Snippet:QueryLogsWithStatistics
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif
            var client = new LogsQueryClient(new DefaultAzureCredential());

            Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                workspaceId,
                "AzureActivity | top 10 by TimeGenerated",
                new QueryTimeRange(TimeSpan.FromDays(1)),
                new LogsQueryOptions
                {
                    IncludeStatistics = true,
                });

            BinaryData stats = response.Value.GetStatistics();
            using var statsDoc = JsonDocument.Parse(stats);
            var queryStats = statsDoc.RootElement.GetProperty("query");
            Console.WriteLine(queryStats.GetProperty("executionTime").GetDouble());

            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsWithVisualization()
        {
            #region Snippet:QueryLogsWithVisualization
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif
            var client = new LogsQueryClient(new DefaultAzureCredential());

            Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                workspaceId,
                @"StormEvents
                    | summarize event_count = count() by State
                    | where event_count > 10
                    | project State, event_count
                    | render columnchart",
                new QueryTimeRange(TimeSpan.FromDays(1)),
                new LogsQueryOptions
                {
                    IncludeVisualization = true,
                });

            BinaryData viz = response.Value.GetVisualization();
            using var vizDoc = JsonDocument.Parse(viz);
            var queryViz = vizDoc.RootElement.GetProperty("visualization");
            Console.WriteLine(queryViz.GetString());

            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsByWorkspaceAsTable()
        {
            #region Snippet:QueryLogsAsTable
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif
            #region Snippet:CreateLogsClient
            var client = new LogsQueryClient(new DefaultAzureCredential());
            #endregion

            Response<LogsQueryResult> result = await client.QueryWorkspaceAsync(
                workspaceId,
                "AzureActivity | top 10 by TimeGenerated",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            LogsTable table = result.Value.Table;

            foreach (var row in table.Rows)
            {
                Console.WriteLine($"{row["OperationName"]} {row["ResourceGroup"]}");
            }
            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsAsTablePrintAll()
        {
            #region Snippet:QueryLogsPrintTable

#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            var client = new LogsQueryClient(new DefaultAzureCredential());
            Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                workspaceId,
                "AzureActivity | top 10 by TimeGenerated",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            LogsTable table = response.Value.Table;

            foreach (var column in table.Columns)
            {
                Console.Write(column.Name + ";");
            }

            Console.WriteLine();

            var columnCount = table.Columns.Count;
            foreach (var row in table.Rows)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    Console.Write(row[i] + ";");
                }

                Console.WriteLine();
            }

            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsAsPrimitive()
        {
            #region Snippet:QueryLogsAsPrimitive

#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            var client = new LogsQueryClient(new DefaultAzureCredential());

            // Query TOP 10 resource groups by event count
            #region Snippet:QueryLogsAsPrimitiveCall
            Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
                workspaceId,
                "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup",
                new QueryTimeRange(TimeSpan.FromDays(1)));
            #endregion

            foreach (var resourceGroup in response.Value)
            {
                Console.WriteLine(resourceGroup);
            }

            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsAsModels()
        {
            #region Snippet:QueryLogsAsModels

#if SNIPPET
            var client = new LogsQueryClient(new DefaultAzureCredential());
            string workspaceId = "<workspace_id>";
#else
            var client = new LogsQueryClient(TestEnvironment.LogsEndpoint, new DefaultAzureCredential());
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            // Query TOP 10 resource groups by event count
            #region Snippet:QueryLogsAsModelCall
            Response<IReadOnlyList<MyLogEntryModel>> response = await client.QueryWorkspaceAsync<MyLogEntryModel>(
                workspaceId,
                "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
                new QueryTimeRange(TimeSpan.FromDays(1)));
            #endregion

            foreach (var logEntryModel in response.Value)
            {
                Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
            }

            #endregion
        }

        [Test]
        [Explicit]
        public async Task BatchQuery()
        {
            #region Snippet:BatchQuery

#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            var client = new LogsQueryClient(new DefaultAzureCredential());

            // Query TOP 10 resource groups by event count
            // And total event count
            var batch = new LogsBatchQuery();

            #region Snippet:BatchQueryAddAndGet
            string countQueryId = batch.AddWorkspaceQuery(
                workspaceId,
                "AzureActivity | count",
                new QueryTimeRange(TimeSpan.FromDays(1)));
            string topQueryId = batch.AddWorkspaceQuery(
                workspaceId,
                "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> response = await client.QueryBatchAsync(batch);

            var count = response.Value.GetResult<int>(countQueryId).Single();
            var topEntries = response.Value.GetResult<MyLogEntryModel>(topQueryId);
            #endregion

            Console.WriteLine($"AzureActivity has total {count} events");
            foreach (var logEntryModel in topEntries)
            {
                Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
            }

            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsWithTimeout()
        {
            #region Snippet:QueryLogsWithTimeout
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            var client = new LogsQueryClient(new DefaultAzureCredential());

            // Query TOP 10 resource groups by event count
            Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
                workspaceId,
                @"AzureActivity
                    | summarize Count = count() by ResourceGroup
                    | top 10 by Count
                    | project ResourceGroup",
                new QueryTimeRange(TimeSpan.FromDays(1)),
                new LogsQueryOptions
                {
                    ServerTimeout = TimeSpan.FromMinutes(10)
                });

            foreach (var resourceGroup in response.Value)
            {
                Console.WriteLine(resourceGroup);
            }

            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsWithAdditionalWorkspace()
        {
            #region Snippet:QueryLogsWithAdditionalWorkspace
#if SNIPPET
            string workspaceId = "<workspace_id>";
            string additionalWorkspaceId = "<additional_workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
            string additionalWorkspaceId = TestEnvironment.WorkspaceId;
#endif

            var client = new LogsQueryClient(new DefaultAzureCredential());

            // Query TOP 10 resource groups by event count
            Response<IReadOnlyList<string>> response = await client.QueryWorkspaceAsync<string>(
                workspaceId,
                @"AzureActivity
                    | summarize Count = count() by ResourceGroup
                    | top 10 by Count
                    | project ResourceGroup",
                new QueryTimeRange(TimeSpan.FromDays(1)),
                new LogsQueryOptions
                {
                    AdditionalWorkspaces = { additionalWorkspaceId }
                });

            foreach (var resourceGroup in response.Value)
            {
                Console.WriteLine(resourceGroup);
            }

            #endregion
        }

        [Test]
        [Explicit]
        public async Task BadRequest()
        {
            #region Snippet:BadRequest
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            var client = new LogsQueryClient(new DefaultAzureCredential());

            try
            {
                await client.QueryWorkspaceAsync(
                    workspaceId, "My Not So Valid Query", new QueryTimeRange(TimeSpan.FromDays(1)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            #endregion
        }

        #region Snippet:QueryLogsAsModelsModel

        public class MyLogEntryModel
        {
            public string ResourceGroup { get; set; }
            public int Count { get; set; }
        }
        #endregion

        [Test]
        [Explicit]
        public async Task QueryLogsWithPartialSuccess()
        {
            var client = new LogsQueryClient(new DefaultAzureCredential());

            #region Snippet:QueryLogsWithPartialSuccess
            Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                TestEnvironment.WorkspaceId,
                "My Not So Valid Query",
                new QueryTimeRange(TimeSpan.FromDays(1)),
                new LogsQueryOptions
                {
                    AllowPartialErrors = true
                });
            LogsQueryResult result = response.Value;

            if (result.Status == LogsQueryResultStatus.PartialFailure)
            {
                var errorCode = result.Error.Code;
                var errorMessage = result.Error.Message;

                // code omitted for brevity
            }
            #endregion
        }

        [Test]
        [Explicit]
        public async Task QueryLogsByResourceAsTable()
        {
            #region Snippet:QueryResource
            var client = new LogsQueryClient(new DefaultAzureCredential());

#if SNIPPET
            string resourceId = "/subscriptions/<subscription_id>/resourceGroups/<resource_group_name>/providers/<resource_provider>/<resource>";
            string tableName = "<table_name>";
#else
            string tableName = "MyTable_CL";
            string resourceId = TestEnvironment.WorkspacePrimaryResourceId;
#endif
            Response<LogsQueryResult> results = await client.QueryResourceAsync(
                new ResourceIdentifier(resourceId),
                $"{tableName} | distinct * | project TimeGenerated",
                new QueryTimeRange(TimeSpan.FromDays(7)));

            LogsTable resultTable = results.Value.Table;
            foreach (LogsTableRow row in resultTable.Rows)
            {
                Console.WriteLine($"{row["OperationName"]} {row["ResourceGroup"]}");
            }

            foreach (LogsTableColumn columns in resultTable.Columns)
            {
                Console.WriteLine("Name: " + columns.Name + " Type: " + columns.Type);
            }
            #endregion
        }
    }
}
