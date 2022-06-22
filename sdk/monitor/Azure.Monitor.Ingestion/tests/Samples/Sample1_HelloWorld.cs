// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;

namespace Azure.Monitor.Ingestion.Tests.Samples
{
    public partial class IngestionSamples: SamplesBase<IngestionClientTestEnvironment>
    {
        public void LogDataAndQuery()
        {
            #region Snippet:Azure_Monitor_Ingestion_Scenario
            Uri dataCollectionEndpoint = new Uri("...");
            TokenCredential credential = new DefaultAzureCredential();
            string workspaceId = "...";
#if SNIPPET
#else
            dataCollectionEndpoint = new Uri(TestEnvironment.DCREndpoint);
            credential = TestEnvironment.ClientSecretCredential;
#endif
            LogsIngestionClient client = new(dataCollectionEndpoint, credential);
            LogsQueryClient logsQueryClient = new(credential);

            DateTimeOffset currentTime = DateTimeOffset.UtcNow;

            BinaryData data = BinaryData.FromObjectAsJson(
                // Use an anonymous type to create the payload
                new[] {
                    new
                    {
                        Time = currentTime,
                        Computer = "Computer1",
                        AdditionalContext = new
                        {
                            InstanceName = "user1",
                            TimeZone = "Pacific Time",
                            Level = 4,
                            CounterName = "AppMetric1",
                            CounterValue = 15.3
                        }
                    },
                    new
                    {
                        Time = currentTime,
                        Computer = "Computer2",
                        AdditionalContext = new
                        {
                            InstanceName = "user2",
                            TimeZone = "Central Time",
                            Level = 3,
                            CounterName = "AppMetric1",
                            CounterValue = 23.5
                        }
                    },
                });

            // Make the request
            Response response = client.Upload(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(data)); //takes StreamName not tablename

            LogsBatchQuery batch = new LogsBatchQuery();
            string countQueryId = batch.AddWorkspaceQuery(
                workspaceId,
                "MyTable_CL | count;",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> responseLogsQuery = logsQueryClient.QueryBatch(batch);

            Console.WriteLine("Table entry count: " + responseLogsQuery.Value.GetResult<int>(countQueryId).Single());
            #endregion
        }
    }
}
