﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsQueryClientSamples: SamplesBase<MonitorQueryTestEnvironment>
    {
        [Test]
        [Explicit]
        public async Task QueryLogsAsTable()
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
            Response<LogsQueryResult> response = await client.QueryWorkspaceAsync(
                workspaceId,
                "AzureActivity | top 10 by TimeGenerated",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            LogsTable table = response.Value.Table;

            foreach (var row in table.Rows)
            {
                Console.WriteLine(row["OperationName"] + " " + row["ResourceGroup"]);
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
            Response<IReadOnlyList<int>> response = await client.QueryWorkspaceAsync<int>(
                workspaceId,
                "AzureActivity | summarize count()",
                new QueryTimeRange(TimeSpan.FromDays(1)),
                options: new LogsQueryOptions
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
            Response<IReadOnlyList<int>> response = await client.QueryWorkspaceAsync<int>(
                workspaceId,
                "AzureActivity | summarize count()",
                new QueryTimeRange(TimeSpan.FromDays(1)),
                options: new LogsQueryOptions
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
    }
}
