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

        [RecordedTest]
        public void TestOperation()
        {
            Assert.IsTrue(true);
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion

        [Test]
        public async Task ValidInputFromObjectAsJson()
        {
            // var clientSecretCrendential = <ClientSecretCredential>;
            // var dcrImmutableId = <dcrImmutableId>;
            var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";
            var currentTime = DateTimeOffset.UtcNow.ToString("O");

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

            LogsIngestionClient client = new(
                new Uri(dcrEndpoint),
                clientSecretCrendential);

            // Make the request
            Response response = client.Upload(dcrImmutableId, "Custom-MyTableRawData", RequestContent.Create(data)); //takes StreamName not tablename

            // Check the response
            Assert.AreEqual(204, response.Status);
            Assert.AreEqual("", response.Content.ToString());

            LogsQueryClient logsQueryClient = new LogsQueryClient(clientSecretCrendential);
            var batch = new LogsBatchQuery();
            string workspaceId = "22101c38-d67f-4ded-994e-67f093aff9f4";
            string countQueryId = batch.AddWorkspaceQuery(
                workspaceId,
                "MyTable_CL | count;",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch);

            // Check the Azure.Monitor.Query Respose
            Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
            Assert.AreEqual("OK", responseLogsQuery.GetRawResponse().ReasonPhrase);
            Assert.IsTrue(responseLogsQuery.Value.GetResult<int>(countQueryId).Single() >= 2);
        }

        [Test]
        public async Task ValidInputFromStreamAsync() //need Workspace id
        {
            // var clientSecretCrendential = <ClientSecretCredential>;
            // var dcrImmutableId = <dcrImmutableId>;
            var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";
            var currentTime = DateTimeOffset.UtcNow.ToString("O");

            Stream stream = BinaryData.FromString("{\"Time\"=currentTime,\"Computer\"=\"Computer1\",\"AdditionalContext\":[{\"InstanceName\"=\"user1\",\"TimeZone\"=\"PacificTime\",\"Level\"=4,\"CounterName\"=\"AppMetric1\",\"CounterValue\"=15.3}]}").ToStream();

            BinaryData data = BinaryData.FromStream(stream);
            LogsIngestionClient client = new(
                new Uri(dcrEndpoint),
                clientSecretCrendential);

            // Make the request
            Response response = client.Upload(dcrImmutableId, "Custom-MyTableRawData", RequestContent.Create(data));

            // Check the response
            Assert.AreEqual(204, response.Status);
            Assert.AreEqual("", response.Content.ToString());

            LogsQueryClient logsQueryClient = new LogsQueryClient(clientSecretCrendential);
            var batch = new LogsBatchQuery();
            string workspaceId = "22101c38-d67f-4ded-994e-67f093aff9f4";
            string countQueryId = batch.AddWorkspaceQuery(
                workspaceId,
                "MyTable_CL | count;",
                new QueryTimeRange(TimeSpan.FromDays(1)));

            Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch);

            // Check the Azure.Monitor.Query Respose
            Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
            Assert.AreEqual("OK", responseLogsQuery.GetRawResponse().ReasonPhrase);
            Assert.IsTrue(responseLogsQuery.Value.GetResult<int>(countQueryId).Single() >= 2);
        }

        [Test]
        public void NullInput()
        {
            // var clientSecretCrendential = <ClientSecretCredential>;
            // var dcrImmutableId = <dcrImmutableId>;
            var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";

            //var data = BinaryData.FromString(null).ToStream();

            LogsIngestionClient client = new(
                new Uri(dcrEndpoint),
                clientSecretCrendential);

            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(dcrImmutableId, "Custom-MyTableRawData", RequestContent.Create(Stream.Null)));

            Assert.AreEqual(null, exception.ErrorCode);
            Assert.AreEqual(500, exception.Status);
            StringAssert.StartsWith("Service request failed.", exception.Message);
        }

        [Test]
        public void GreaterThan1MbData() //Should fail when we don't have batching
        {
            // var clientSecretCrendential = <ClientSecretCredential>;
            // var dcrImmutableId = <dcrImmutableId>;
            var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";

            var currentTime = DateTimeOffset.UtcNow.ToString("O");
            const int Mb = 1024 * 1024;
            string greaterThan1Mb = new string('*', Mb + 5); //1,048,576 is 1 Mb

            LogsIngestionClient client = new(
                new Uri(dcrEndpoint),
                clientSecretCrendential);

            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(dcrImmutableId, "Custom-MyTableRawData", RequestContent.Create(greaterThan1Mb)));

            Assert.AreEqual("ContentLengthLimitExceeded", exception.ErrorCode);
            Assert.AreEqual(413, exception.Status);
            StringAssert.StartsWith("Maximum allowed content length: 1048576 bytes (1 MB).", exception.Message);
        }

        [Test]
        public void EmptyData()
        {
            // var clientSecretCrendential = <ClientSecretCredential>;
            // var dcrImmutableId = <dcrImmutableId>;
            var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";

            var data = BinaryData.FromString("").ToStream();

            LogsIngestionClient client = new(
                new Uri(dcrEndpoint),
                clientSecretCrendential);

            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(dcrImmutableId, "Custom-MyTableRawData", RequestContent.Create(data)));

            Assert.AreEqual(null, exception.ErrorCode);
            Assert.AreEqual(500, exception.Status);
            StringAssert.StartsWith("Service request failed.", exception.Message);
        }

        public void NullStream()
        {
            // var clientSecretCrendential = <ClientSecretCredential>;
            // var dcrImmutableId = <dcrImmutableId>;
            var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";

            LogsIngestionClient client = new(
                new Uri(dcrEndpoint),
                clientSecretCrendential);

            Stream stream = null;
            var exception = Assert.Throws<RequestFailedException>(() => client.Upload(dcrImmutableId, "Custom-MyTableRawData", RequestContent.Create(stream)));

            Assert.AreEqual("BadArgumentError", exception.ErrorCode);
            StringAssert.StartsWith("Batch query with id '0' failed.", exception.Message);
        }
    }
}
