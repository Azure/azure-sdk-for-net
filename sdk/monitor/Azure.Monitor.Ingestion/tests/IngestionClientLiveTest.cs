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
        private const int Mb = 1024 * 1024;
        public IngestionClientLiveTest(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        private LogsIngestionClient CreateClient()
        {
            return new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.ClientSecretCredential);
        }

        [LiveOnly]
        [Test]
        public void NullInput()
        {
            LogsIngestionClient client = CreateClient();
            Assert.Throws<ArgumentNullException>(() => client.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, null));
        }
        [LiveOnly]
        [Test]
        public void EmptyData()
        {
            LogsIngestionClient client = CreateClient();

            var entries = new List<IEnumerable>();

            var exception = Assert.Throws<ArgumentException>(() => client.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries));
            StringAssert.StartsWith("Value cannot be an empty collection.", exception.Message);
        }
        [LiveOnly]
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
        [LiveOnly]
        [Test]
        public void ValidateBatchingOneChunkNoGzip()
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
            IEnumerable<Tuple<List<IEnumerable>, BinaryData>> x = LogsIngestionClient.Batch(entries);
            Assert.AreEqual(1, x.Count());
        }

        [LiveOnly]
        [Test]
        public void ValidateBatchingMultiChunkNoGzip()
        {
            var entries = new List<IEnumerable>();
            for (int i = 0; i < 20000; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = i + "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }
            IEnumerable<Tuple<List<IEnumerable>, BinaryData>> x = LogsIngestionClient.Batch(entries);
            Assert.Greater(x.Count(), 1);
        }
        [LiveOnly]
        [Test]
        public async Task ValidInputFromArrayAsJsonWithSingleBatchWithGzip()
        {
            LogsIngestionClient client = CreateClient();

            DateTime now = DateTime.Now;

            var entries = new List<Object>();
            for (int i = 0; i < 10; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = now,
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }

           // Make the request
           var response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(UploadLogsStatus.SUCCESS, response.Value.Status);
        }
        [LiveOnly]
        [Test]
        public void ValidInputFromObjectAsJsonNoBatching()
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

            Response response = client.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(data), "gzip"); //takes StreamName not tablename
            // Check the response
            Assert.AreEqual(204, response.Status);
        }

        [LiveOnly]
        [Test]
        public async Task ValidInputFromArrayAsJsonWithMultiBatchWithGzip()
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
            var response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false);

            // Check the response
            Assert.AreEqual(UploadLogsStatus.SUCCESS, response.Value.Status);
        }

        [LiveOnly]
        [Test]
        public void InvalidInputFromObjectAsJsonNoBatchingNoGzip()
        {
            LogsIngestionClient client = CreateClient();

            var entries = new List<IEnumerable>();
            for (int i = 0; i < 100000; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = "2021",
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }

            Response<UploadLogsResult> response = client.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries); //takes StreamName not tablename
            // Check the response - run without Batching and Gzip for error 413
            Assert.AreEqual(UploadLogsStatus.FAILURE, response.Value.Status);
            Assert.AreEqual(413, response.Value.Errors.FirstOrDefault().Error.Code);
            Assert.AreEqual(10000, response.Value.Errors.FirstOrDefault().FailedLogs.Count());
        }
    }
}
