// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;

namespace Azure.Monitor.Ingestion.Tests.Samples
{
    public partial class IngestionSamples : SamplesBase<MonitorIngestionTestEnvironment>
    {
        public void SetUpClient()
        {
            #region Snippet:CreateLogsIngestionClient
            var endpoint = new Uri("<data_collection_endpoint_uri>");
            var credential = new DefaultAzureCredential();
            var client = new LogsIngestionClient(endpoint, credential);
            #endregion
        }

        public void SetUpClientWithOptions()
        {
            #region Snippet:CreateLogsIngestionClientWithOptions
            var endpoint = new Uri("<data_collection_endpoint_uri>");
            var credential = new DefaultAzureCredential();
            var clientOptions = new LogsIngestionClientOptions
            {
                Audience = LogsIngestionAudience.AzureChina
            };
            var client = new LogsIngestionClient(endpoint, credential, clientOptions);
            #endregion
        }

        public void LogData()
        {
            #region Snippet:UploadCustomLogs
            var endpoint = new Uri("<data_collection_endpoint_uri>");
            var ruleId = "<data_collection_rule_id>";
            var streamName = "<stream_name>";

#if SNIPPET
            var credential = new DefaultAzureCredential();
#else
            TokenCredential credential = new DefaultAzureCredential();
            endpoint = new Uri(TestEnvironment.DCREndpoint);
            credential = TestEnvironment.Credential;
#endif
            LogsIngestionClient client = new(endpoint, credential);

            DateTimeOffset currentTime = DateTimeOffset.UtcNow;

            // Use BinaryData to serialize instances of an anonymous type into JSON
            BinaryData data = BinaryData.FromObjectAsJson(
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

            // Upload our logs
            Response response = client.Upload(ruleId, streamName, RequestContent.Create(data));
            #endregion
        }

        public void QueryData()
        {
            #region Snippet:VerifyLogs
            var workspaceId = "<log_analytics_workspace_id>";
            var tableName = "<table_name>";

#if SNIPPET
            var credential = new DefaultAzureCredential();
#else
            TokenCredential credential = TestEnvironment.Credential;
#endif
            LogsQueryClient logsQueryClient = new(credential);

            LogsBatchQuery batch = new();
            string query = tableName + " | Count;";
            string countQueryId = batch.AddWorkspaceQuery(
                workspaceId,
                query,
                new LogsQueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> queryResponse =
                logsQueryClient.QueryBatch(batch);

            Console.WriteLine("Table entry count: " +
                queryResponse.Value.GetResult<int>(countQueryId).Single());
            #endregion
        }

        public void UploadWithMaxConcurrency(){
            #region Snippet:UploadWithMaxConcurrency
            var endpoint = new Uri("<data_collection_endpoint_uri>");
            var ruleId = "<data_collection_rule_id>";
            var streamName = "<stream_name>";

#if SNIPPET
            var credential = new DefaultAzureCredential();
#else
            TokenCredential credential = new DefaultAzureCredential();
            endpoint = new Uri(TestEnvironment.DCREndpoint);
            credential = TestEnvironment.Credential;
#endif
            var client = new LogsIngestionClient(endpoint, credential);

            DateTimeOffset currentTime = DateTimeOffset.UtcNow;

            var entries = new List<object>();
            for (int i = 0; i < 100; i++)
            {
                entries.Add(
                    new {
                        Time = currentTime,
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                );
            }
            // Set concurrency in LogsUploadOptions
            var options = new LogsUploadOptions
            {
                MaxConcurrency = 10
            };

            // Upload our logs
            Response response = client.Upload(ruleId, streamName, entries, options);
            #endregion
        }
    }
}
