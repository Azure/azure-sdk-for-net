// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Monitor.Query.Logs;
using Azure.Monitor.Query.Logs.Models;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests.Samples
{
    public partial class IngestionSamples : SamplesBase<MonitorIngestionTestEnvironment>
    {
        public async Task LogDataAsync()
        {
            #region Snippet:UploadCustomLogsAsync
            var endpoint = new Uri("<data_collection_endpoint>");
            var ruleId = "<data_collection_rule_id>";
            var streamName = "<stream_name>";

#if SNIPPET
            var credential = new DefaultAzureCredential();
#else
            endpoint = new Uri(TestEnvironment.DCREndpoint);
            TokenCredential credential = TestEnvironment.Credential;
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
            Response response = await client.UploadAsync(
                ruleId,
                streamName,
                RequestContent.Create(data)).ConfigureAwait(false);
            #endregion
        }

        public async Task QueryDataAsync()
        {
            #region Snippet:VerifyLogsAsync
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
                await logsQueryClient.QueryBatchAsync(batch).ConfigureAwait(false);

            Console.WriteLine("Table entry count: " +
                queryResponse.Value.GetResult<int>(countQueryId).Single());
            #endregion
        }

        public async Task LogDataIEnumerableEventHandlerAsync()
        {
            #region Snippet:LogDataIEnumerableEventHandlerAsync
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

            var entries = new List<Object>();
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
            // Set concurrency and EventHandler in LogsUploadOptions
            LogsUploadOptions options = new LogsUploadOptions();
            options.MaxConcurrency = 10;
            options.UploadFailed += Options_UploadFailed;

            // Upload our logs
            Response response = await client.UploadAsync(ruleId, streamName, entries, options).ConfigureAwait(false);

            Task Options_UploadFailed(LogsUploadFailedEventArgs e)
            {
                // Throw exception from EventHandler to stop Upload if there is a failure
                IReadOnlyList<object> failedLogs = e.FailedLogs;
                // 413 status is RequestTooLarge - don't throw here because other batches can successfully upload
                if ((e.Exception is RequestFailedException) && (((RequestFailedException)e.Exception).Status != 413))
                    throw e.Exception;
                else
                    return Task.CompletedTask;
            }
            #endregion
        }

        public async Task LogDataIEnumerableAsync()
        {
            #region Snippet:UploadLogDataIEnumerableAsync
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

            var entries = new List<Object>();
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

            // Upload our logs
            Response response = await client.UploadAsync(ruleId, streamName, entries).ConfigureAwait(false);
            #endregion
        }

        public async Task LogDataIEnumerableAsyncAot()
        {
            #region Snippet:UploadLogDataIEnumerableAsyncAot
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

            var entries = new List<BinaryData>();
            for (int i = 0; i < 100; i++)
            {
                entries.Add(BinaryData.FromBytes(
                    JsonSerializer.SerializeToUtf8Bytes(new Person($"Person{i}", "Department{i}", i))));
            }

            // Upload our logs
            Response response = await client.UploadAsync(ruleId, streamName, entries).ConfigureAwait(false);
            #endregion
        }

        public async Task UploadWithMaxConcurrencyAsync(){
            #region Snippet:UploadWithMaxConcurrencyAsync
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
            Response response = await client.UploadAsync(ruleId, streamName, entries, options).ConfigureAwait(false);
            #endregion
        }
    }

#pragma warning disable SA1402 // File may only contain a single class
    #region Snippet:IngestionAotSerializationTypes

    public record Person(string Name, string Department, int EmployeeNumber)
    {
    }

    [JsonSerializable(typeof(Person))]
    public partial class ExampleDeserializationContext : JsonSerializerContext
    {
    }
    #endregion
#pragma warning restore SA1402 // File may only contain a single class
}
