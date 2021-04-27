// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Monitor.Query;
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

            LogsClient client = new LogsClient(new DefaultAzureCredential());
            /*@@*/string workspaceId = TestEnvironment.WorkspaceId;
            //@@string workspaceId = "<workspace_id>";
            Response<LogsQueryResult> response = await client.QueryAsync(workspaceId, "AzureActivity | top 10 by TimeGenerated");

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

            LogsClient client = new LogsClient(new DefaultAzureCredential());
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif
            Response<LogsQueryResult> response = await client.QueryAsync(workspaceId, "AzureActivity | top 10 by TimeGenerated");

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

            LogsClient client = new LogsClient(new DefaultAzureCredential());
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            // Query TOP 10 resource groups by event count
            Response<IReadOnlyList<string>> response = await client.QueryAsync<string>(workspaceId,
                "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count | project ResourceGroup");

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

            LogsClient client = new LogsClient(new DefaultAzureCredential());
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            // Query TOP 10 resource groups by event count
            Response<IReadOnlyList<MyLogEntryModel>> response = await client.QueryAsync<MyLogEntryModel>(workspaceId,
                "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count");

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

            LogsClient client = new LogsClient(new DefaultAzureCredential());
#if SNIPPET
            string workspaceId = "<workspace_id>";
#else
            string workspaceId = TestEnvironment.WorkspaceId;
#endif

            // Query TOP 10 resource groups by event count
            // And total event count
            LogsBatchQuery batch = client.CreateBatchQuery();
            string countQueryId = batch.AddQuery(workspaceId, "AzureActivity | count");
            string topQueryId = batch.AddQuery(workspaceId, "AzureActivity | summarize Count = count() by ResourceGroup | top 10 by Count");

            Response<LogsBatchQueryResult> response = await batch.SubmitAsync();

            var count = response.Value.GetResult<int>(countQueryId).Single();
            var topEntries = response.Value.GetResult<MyLogEntryModel>(topQueryId);

            Console.WriteLine($"AzureActivity has total {count} events");
            foreach (var logEntryModel in topEntries)
            {
                Console.WriteLine($"{logEntryModel.ResourceGroup} had {logEntryModel.Count} events");
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