// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Models;
using NUnit.Framework;

namespace Azure.Monitor.Query.Tests
{
    public class LogsClientSamples: SamplesBase<MonitorQueryClientTestEnvironment>
    {
        [Test]
        public async Task QueryLogsAsTable()
        {
            #region Snippet:QueryLogsAsTable
#if SNIPPET
            Uri endpoint = new Uri("https://api.loganalytics.io");
            string workspaceId = "<workspace_id>";
#else
            Uri endpoint = TestEnvironment.LogsEndpoint;
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            LogsClient client = new LogsClient(endpoint, new DefaultAzureCredential());
            Response<LogsQueryResult> response = await client.QueryAsync(workspaceId, "AzureActivity | top 10 by TimeGenerated", TimeSpan.FromDays(1));

            LogsQueryResultTable table = response.Value.PrimaryTable;

            foreach (var row in table.Rows)
            {
                Console.WriteLine(row["OperationName"] + " " + row["ResourceGroup"]);
            }

            #endregion
        }

        [Test]
        public async Task QueryLogsAsTablePrintAll()
        {
            #region Snippet:QueryLogsPrintTable

#if SNIPPET
            Uri endpoint = new Uri("https://api.loganalytics.io");
            string workspaceId = "<workspace_id>";
#else
            Uri endpoint = TestEnvironment.LogsEndpoint;
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            LogsClient client = new LogsClient(endpoint, new DefaultAzureCredential());
            Response<LogsQueryResult> response = await client.QueryAsync(workspaceId, "AzureActivity | top 10 by TimeGenerated", TimeSpan.FromDays(1));

            LogsQueryResultTable table = response.Value.PrimaryTable;

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
        public async Task QueryLogsAsPrimitive()
        {
            #region Snippet:QueryLogsAsPrimitive

#if SNIPPET
            Uri endpoint = new Uri("https://api.loganalytics.io");
            string workspaceId = "<workspace_id>";
#else
            Uri endpoint = TestEnvironment.LogsEndpoint;
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            LogsClient client = new LogsClient(endpoint, new DefaultAzureCredential());

            // Query TOP 10 resource groups by event count
            Response<IReadOnlyList<string>> response = await client.QueryAsync<string>(workspaceId,
                "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup",
                TimeSpan.FromDays(1));

            foreach (var resourceGroup in response.Value)
            {
                Console.WriteLine(resourceGroup);
            }

            #endregion
        }

        [Test]
        public async Task QueryLogsAsModels()
        {
            #region Snippet:QueryLogsAsModels

            LogsClient client = new LogsClient(TestEnvironment.LogsEndpoint, new DefaultAzureCredential());
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            // Query TOP 10 resource groups by event count
            Response<IReadOnlyList<MyLogEntryModel>> response = await client.QueryAsync<MyLogEntryModel>(workspaceId,
                "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count",
                TimeSpan.FromDays(1));

            foreach (var logEntryModel in response.Value)
            {
                Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
            }

            #endregion
        }

        [Test]
        public async Task BatchQuery()
        {
            #region Snippet:BatchQuery

#if SNIPPET
            Uri endpoint = new Uri("https://api.loganalytics.io");
            string workspaceId = "<workspace_id>";
#else
            Uri endpoint = TestEnvironment.LogsEndpoint;
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            LogsClient client = new LogsClient(endpoint, new DefaultAzureCredential());

            // Query TOP 10 resource groups by event count
            // And total event count
            LogsBatchQuery batch = new LogsBatchQuery();
            string countQueryId = batch.AddQuery(workspaceId, "AzureActivity | count", TimeSpan.FromDays(1));
            string topQueryId = batch.AddQuery(workspaceId, "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count", TimeSpan.FromDays(1));

            Response<LogsBatchQueryResult> response = await client.QueryBatchAsync(batch);

            var count = response.Value.GetResult<int>(countQueryId).Single();
            var topEntries = response.Value.GetResult<MyLogEntryModel>(topQueryId);

            Console.WriteLine($"AzureActivity has total {count} events");
            foreach (var logEntryModel in topEntries)
            {
                Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
            }

            #endregion
        }

        [Test]
        public async Task QueryLogsWithTimeout()
        {
            #region Snippet:QueryLogsWithTimeout
#if SNIPPET
            Uri endpoint = new Uri("https://api.loganalytics.io");
            string workspaceId = "<workspace_id>";
#else
            Uri endpoint = TestEnvironment.LogsEndpoint;
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            LogsClient client = new LogsClient(endpoint, new DefaultAzureCredential());

            // Query TOP 10 resource groups by event count
            Response<IReadOnlyList<int>> response = await client.QueryAsync<int>(workspaceId,
                "AzureActivity | summarize count()",
                TimeSpan.FromDays(1),
                options: new LogsQueryOptions()
                {
                    Timeout = TimeSpan.FromMinutes(10)
                });

            foreach (var resourceGroup in response.Value)
            {
                Console.WriteLine(resourceGroup);
            }

            #endregion
        }

        [Test]
        public async Task BadRequest()
        {
            #region Snippet:BadRequest
#if SNIPPET
            Uri endpoint = new Uri("https://api.loganalytics.io");
            string workspaceId = "<workspace_id>";
#else
            Uri endpoint = TestEnvironment.LogsEndpoint;
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            LogsClient client = new LogsClient(endpoint, new DefaultAzureCredential());

            try
            {
                await client.QueryAsync(workspaceId, "My Not So Valid Query", TimeSpan.FromDays(1));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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