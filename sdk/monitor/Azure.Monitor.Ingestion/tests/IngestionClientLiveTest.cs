// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using Azure.Monitor.Query;
using Azure.Monitor.Query.Models;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Azure.Monitor.Ingestion.Tests
{
    public class IngestionClientLiveTest : RecordedTestBase<IngestionClientTestEnvironment>
    {
        public IngestionClientLiveTest(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        private LogsIngestionClient CreateClient()
        {
            return new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.ClientSecretCredential);
        }

        [Test]
        public async Task ValidInputFromObjectAsJson()
        {
            //var clientSecretCrendential = new ClientSecretCredential("72f988bf-86f1-41af-91ab-2d7cd011db47", "1b0fddd6-a6b5-4f72-a40d-90045a6081dd", "8ew8Q~4PxRXTaQkXDEQWAc0CRfcoVGimYatema2v");
            //var dcrImmutableId = "dcr-54e5c6ad9aa444ec87cbe7f6621ba956";
            //var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";

            //LogsIngestionClient client = new LogsIngestionClient(new Uri(dcrEndpoint), clientSecretCrendential);

            LogsIngestionClient client = CreateClient();
            var currentTime = Recording.UtcNow;

            BinaryData data = BinaryData.FromObjectAsJson(
                // Use an anonymous type to create the payload
                new object[] {
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
                        Computer = 4,
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
            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(data), "gzip").ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(204, response.Status);

            LogsQueryClient logsQueryClient = new(TestEnvironment.ClientSecretCredential);
            var batch = new LogsBatchQuery();

            string query = TestEnvironment.TableName + " | count;";
            string countQueryId = batch.AddWorkspaceQuery(
                TestEnvironment.Ingestion_WorkspaceId,
                query,
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch).ConfigureAwait(false);

            // Check the Azure.Monitor.Query Response
            Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
            Assert.IsTrue(responseLogsQuery.Value.GetResult<int>(countQueryId).Single() >= 2);
        }

        [LiveOnly]
        [Test]
        public async Task ValidInputFromStreamAsync()
        {
            LogsIngestionClient client = CreateClient();
            Stream stream = BinaryData.FromString("{\"Time\"=currentTime,\"Computer\"=\"Computer1\",\"AdditionalContext\":[{\"InstanceName\"=\"user1\",\"TimeZone\"=\"PacificTime\",\"Level\"=4,\"CounterName\"=\"AppMetric1\",\"CounterValue\"=15.3}]}").ToStream();

            BinaryData data = BinaryData.FromStream(stream);
            // Make the request
            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(data)).ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(204, response.Status);

            LogsQueryClient logsQueryClient = new(TestEnvironment.ClientSecretCredential);
            var batch = new LogsBatchQuery();
            string query = TestEnvironment.TableName + " | count;";
            string countQueryId = batch.AddWorkspaceQuery(
                TestEnvironment.Ingestion_WorkspaceId,
                query,
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch).ConfigureAwait(false);

            // Check the Azure.Monitor.Query Response
            Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
            Assert.IsTrue(responseLogsQuery.Value.GetResult<int>(countQueryId).Single() >= 2);
        }

        [LiveOnly]
        [Test]
        public void NullInput()
        {
            LogsIngestionClient client = CreateClient();

            var exception = Assert.Throws<RequestFailedException>(async () => await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(Stream.Null)).ConfigureAwait(false));

            Assert.AreEqual(null, exception.ErrorCode);
            Assert.AreEqual(500, exception.Status);
            StringAssert.StartsWith("Service request failed.", exception.Message);
        }

        [LiveOnly]
        [Test]
        public void GreaterThan1MbData() //Should fail when we don't have batching
        {
            LogsIngestionClient client = CreateClient();

            var currentTime = Recording.UtcNow;
            const int Mb = 1024 * 1024;
            string greaterThan1Mb = new string('*', Mb + 5); //1,048,576 is 1 Mb

            var exception = Assert.Throws<RequestFailedException>(async () => await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(greaterThan1Mb)).ConfigureAwait(false));

            Assert.AreEqual("ContentLengthLimitExceeded", exception.ErrorCode);
            Assert.AreEqual(413, exception.Status);
            StringAssert.StartsWith("Maximum allowed content length: 1048576 bytes (1 MB).", exception.Message);
        }

        [LiveOnly]
        [Test]
        public void EmptyData()
        {
            LogsIngestionClient client = CreateClient();

            var data = BinaryData.FromString("").ToStream();

            var exception = Assert.Throws<RequestFailedException>(async () => await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(data)).ConfigureAwait(false));

            Assert.AreEqual(null, exception.ErrorCode);
            Assert.AreEqual(500, exception.Status);
            StringAssert.StartsWith("Service request failed.", exception.Message);
        }

        [LiveOnly]
        [Test]
        public void NullStream()
        {
            LogsIngestionClient client = CreateClient();

            Stream stream = null;
            var exception = Assert.Throws<RequestFailedException>(async () => await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(stream)).ConfigureAwait(false));

            Assert.AreEqual("BadArgumentError", exception.ErrorCode);
            StringAssert.StartsWith("Batch query with id '0' failed.", exception.Message);
        }

        [Test]
        public void ValidateBatchingOneChunk()
        {
            var entries = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                string input = "{" +
                    "\"Time\": \"2021-12-08T23:51:14.1104269Z\"," +
                    "\"Computer\": \"Computer1\"," +
                    "\"AdditionalContext\": \"" + i.ToString() + "\"" + "}";
                entries.Add(input.Replace("\\", String.Empty));
            }
            IEnumerable<BinaryData> x = LogsIngestionClient.Batching(entries);
            int count = 0;
            foreach (var entry in x)
            {
                Console.WriteLine(entry);
                count++;
            }
            Assert.AreEqual(1, count);
        }

        [Test]
        public void ValidateBatchingMultiChunk()
        {
            var entries = new List<string>();
            for (int i = 0; i < 7000; i++)
            {
                string input = "{" +
                    "\"Time\": \"2021-12-08T23:51:14.1104269Z\"," +
                    "\"Computer\": \"Computer1\"," +
                    "\"AdditionalContext\": \"" + i.ToString() + "\"" + "}";
                entries.Add(input.Replace("\\", String.Empty));
            }
            IEnumerable<BinaryData> x = LogsIngestionClient.Batching(entries);
            int count = 0;
            foreach (var entry in x)
            {
                Console.WriteLine(entry);
                count++;
            }
            Assert.AreEqual(2, count);
        }
    }
}
