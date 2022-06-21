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

namespace Azure.Monitor.Ingestion.Tests
{
    public class IngestionClientTest : RecordedTestBase<IngestionClientTestEnvironment>
    {
        public IngestionClientTest(bool isAsync) : base(isAsync)
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
            LogsIngestionClient client = CreateClient();
            var currentTime = Recording.UtcNow;

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

            // Check the response
            Assert.AreEqual(204, response.Status);
            Assert.AreEqual("", response.Content.ToString());

            LogsQueryClient logsQueryClient = new LogsQueryClient(TestEnvironment.ClientSecretCredential);
            var batch = new LogsBatchQuery();

            string countQueryId = batch.AddWorkspaceQuery(
                TestEnvironment.WorkspaceId,
                "MyTable_CL | count;",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch);

            // Check the Azure.Monitor.Query Respose
            Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
            Assert.AreEqual("OK", responseLogsQuery.GetRawResponse().ReasonPhrase);
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
            Response response = client.Upload(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(data));

            // Check the response
            Assert.AreEqual(204, response.Status);
            Assert.AreEqual("", response.Content.ToString());

            LogsQueryClient logsQueryClient = new LogsQueryClient(TestEnvironment.ClientSecretCredential);
            var batch = new LogsBatchQuery();
            string countQueryId = batch.AddWorkspaceQuery(
                TestEnvironment.WorkspaceId,
                "MyTable_CL | count;",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch);

            // Check the Azure.Monitor.Query Respose
            Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
            Assert.AreEqual("OK", responseLogsQuery.GetRawResponse().ReasonPhrase);
            Assert.IsTrue(responseLogsQuery.Value.GetResult<int>(countQueryId).Single() >= 2);
        }

        [LiveOnly]
        [Test]
        public void NullInput()
        {
            LogsIngestionClient client = CreateClient();

            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(Stream.Null)));

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

            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(greaterThan1Mb)));

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

            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(data)));

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
            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(TestEnvironment.DCRImmutableId, "Custom-MyTableRawData", RequestContent.Create(stream)));

            Assert.AreEqual("BadArgumentError", exception.ErrorCode);
            StringAssert.StartsWith("Batch query with id '0' failed.", exception.Message);
        }
    }
}
