// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests
{
    public class MonitorIngestionLiveTest : RecordedTestBase<MonitorIngestionTestEnvironment>
    {
        private const int Mb = 1024 * 1024;
        public MonitorIngestionLiveTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        private LogsIngestionClient CreateClient()
        {
            var clientOptions = InstrumentClientOptions(new LogsIngestionClientOptions());
            return InstrumentClient(new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.ClientSecretCredential, clientOptions));
        }

        [Test]
        public void NullInput()
        {
            LogsIngestionClient client = CreateClient();
            Assert.ThrowsAsync<ArgumentNullException>(async () => await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, null).ConfigureAwait(false));
        }

        [Test]
        public void EmptyData()
        {
            LogsIngestionClient client = CreateClient();

            var entries = new List<IEnumerable>();

            var exception = Assert.ThrowsAsync<ArgumentException>(async () => await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false));
            StringAssert.StartsWith("Value cannot be an empty collection.", exception.Message);
        }

        [Test]
        public void NullStream()
        {
            LogsIngestionClient client = CreateClient();

            Stream stream = null;
            var exception = Assert.Throws<NullReferenceException>(() => client.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(stream)));
        }

        [LiveOnly]
        [Test]
        public async Task UploadOneLogGreaterThan1Mb()
        {
            LogsIngestionClient client = CreateClient();

            var entries = new List<IEnumerable>();
            entries.Add(new Object[] {
                new {
                    Time = "2021",
                    Computer = "Computer" + new string('*', Mb * 5),
                    AdditionalContext = 1
                }
            });

            // Make the request
            var response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(UploadLogsStatus.SUCCESS, response.Value.Status);
        }

        private static List<Object> GenerateEntries(int numEntries)
        {
            DateTime now = DateTime.Now;
            var entries = new List<Object>();
            for (int i = 0; i < numEntries; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = now,
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }
            return entries;
        }

        [Test]
        public async Task ValidInputFromArrayAsJsonWithSingleBatchWithGzip()
        {
            LogsIngestionClient client = CreateClient();

           // Make the request
           var response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(10)).ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(UploadLogsStatus.SUCCESS, response.Value.Status);
        }

        [Test]
        public async Task ValidInputFromObjectAsJsonNoBatchingAsync()
        {
            LogsIngestionClient client = CreateClient();

            BinaryData data = BinaryData.FromObjectAsJson(
                // Use an anonymous type to create the payload
                new[] {
                    new
                    {
                        Time = DateTime.Now,
                        Computer = "Computer1",
                        AdditionalContext = 2,
                    },
                    new
                    {
                        Time = DateTime.Now,
                        Computer = "Computer2",
                        AdditionalContext = 3
                    },
                });

            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(data), "gzip").ConfigureAwait(false); //takes StreamName not tablename
            // Check the response
            Assert.AreEqual(204, response.Status);
        }

        [LiveOnly]
        [Test]
        public async Task ValidInputFromArrayAsJsonWithMultiBatchWithGzip()
        {
            LogsIngestionClient client = CreateClient();

            // Make the request
            var response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(10000)).ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(UploadLogsStatus.SUCCESS, response.Value.Status);
        }

        [LiveOnly]
        [Test]
        public async Task InvalidInputFromObjectAsJsonNoBatchingNoGzipAsync()
        {
            LogsIngestionClient client = CreateClient();

            Response<UploadLogsResult> response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(10000)).ConfigureAwait(false); //takes StreamName not tablename
            // Check the response - run without Batching and Gzip for error 413
            Assert.AreEqual(UploadLogsStatus.FAILURE, response.Value.Status);
            Assert.AreEqual(413, response.Value.Errors.FirstOrDefault().Error.Code);
            Assert.AreEqual(10000, response.Value.Errors.FirstOrDefault().FailedLogs.Count());
        }
    }
}
