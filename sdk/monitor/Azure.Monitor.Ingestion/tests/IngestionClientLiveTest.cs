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
using System.Collections;

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
        public void NullInput()
        {
            LogsIngestionClient client = CreateClient();

            var exception = Assert.Throws<RequestFailedException>(async () => await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(Stream.Null)).ConfigureAwait(false));

            Assert.AreEqual(null, exception.ErrorCode);
            Assert.AreEqual(500, exception.Status);
            StringAssert.StartsWith("Service request failed.", exception.Message);
        }

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
            var entries = new List<IEnumerable>();
            for (int i = 0; i < 10; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
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
            var entries = new List<IEnumerable>();
            for (int i = 0; i < 10000; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }
            IEnumerable<BinaryData> x = LogsIngestionClient.Batching(entries);
            int count = 0;
            foreach (var entry in x)
            {
                Console.WriteLine(entry);
                count++;
            }
            Assert.Greater(1, count);
        }

        //[Test]
        //public async Task ValidInputFromArrayAsJsonWithSingleBatch()
        //{
        //    LogsIngestionClient client = CreateClient();

        //    var entries = new List<IEnumerable>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        entries.Add(new Object[] {
        //            new {
        //                Time = "2021",
        //                Computer = "Computer" + i.ToString(),
        //                AdditionalContext = i
        //            }
        //        });
        //    }

        //    // Make the request
        //    Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false);

        //    // Check the response
        //    Assert.AreEqual(204, response.Status);

        //    LogsQueryClient logsQueryClient = new(TestEnvironment.ClientSecretCredential);
        //    var batch = new LogsBatchQuery();

        //    string query = TestEnvironment.TableName + " | count;";
        //    string countQueryId = batch.AddWorkspaceQuery(
        //        TestEnvironment.Ingestion_WorkspaceId,
        //        query,
        //        new QueryTimeRange(TimeSpan.FromDays(1)));

        //    Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch).ConfigureAwait(false);

        //    // Check the Azure.Monitor.Query Response
        //    Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
        //    Assert.IsTrue(responseLogsQuery.Value.GetResult<int>(countQueryId).Single() >= 2);
        //}

        [Test]
        public async Task ValidInputFromArrayAsJsonWithSingleBatch()
        {
            LogsIngestionClient client = CreateClient();

            DateTime now = DateTime.Now;

            var entries = new List<Object>();
            for (int i = 0; i < 10; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = DateTime.Now,
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }

            // Make the request
            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(204, response.Status);

            //LogsQueryClient logsQueryClient = new(TestEnvironment.ClientSecretCredential);
            //var batch = new LogsBatchQuery();

            //string query = TestEnvironment.TableName + " | count;";
            //string countQueryId = batch.AddWorkspaceQuery(
            //    TestEnvironment.Ingestion_WorkspaceId,
            //    query,
            //    new QueryTimeRange(TimeSpan.FromDays(1)));

            //Response<LogsBatchQueryResultCollection> responseLogsQuery = await logsQueryClient.QueryBatchAsync(batch).ConfigureAwait(false);

            //// Check the Azure.Monitor.Query Response
            //Assert.AreEqual(200, responseLogsQuery.GetRawResponse().Status);
            //Assert.IsTrue(responseLogsQuery.Value.GetResult<int>(countQueryId).Single() >= 2);
        }

        [Test]
        public async Task ValidInputFromArrayAsJsonWithMultiBatch()
        {
            LogsIngestionClient client = CreateClient();

            var entries = new List<IEnumerable>();
            for (int i = 0; i < 10000; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }

            // Make the request
            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false);

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
    }
}
