// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests
{
    public class MonitorIngestionLiveTest : RecordedTestBase<MonitorIngestionTestEnvironment>
    {
        private const int Mb = 1024 * 1024;
        private const int Kb = 1024;

        public MonitorIngestionLiveTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [OneTimeSetUp]
        public void SetUp()
        {
            // make batch size smaller for Uploads for test recording size
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
                LogsIngestionClient.SingleUploadThreshold = Kb;
            else
                LogsIngestionClient.SingleUploadThreshold = Mb;
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            LogsIngestionClient.SingleUploadThreshold = Mb;
            LogsIngestionClient.Compression = null;
        }

        private LogsIngestionClient CreateClient(HttpPipelinePolicy policy = null)
        {
            var options = new LogsIngestionClientOptions();
            if (policy != null)
            {
                options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            }
            var clientOptions = InstrumentClientOptions(options);
            // Set audience for testing including sovereign cloud support
            clientOptions.Audience = TestEnvironment.GetAudience();

            return InstrumentClient(new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.Credential, clientOptions));
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
            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false);

            // Check the response
            Assert.IsNotNull(response);
            Assert.AreEqual(204, response.Status);
            Assert.IsFalse(response.IsError);
        }

        private static List<Object> GenerateEntries(int numEntries, DateTime recordingNow)
        {
            var entries = new List<Object>();
            for (int i = 0; i < numEntries; i++)
            {
                entries.Add(
                    new {
                        Time = recordingNow,
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                );
            }
            return entries;
        }

        [Test]
        public async Task ValidInputFromArrayAsJsonWithSingleBatchWithGzip()
        {
           LogsIngestionClient client = CreateClient();

           // Make the request
           var response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(10, Recording.Now.DateTime)).ConfigureAwait(false);

            // Check the response
            Assert.IsNotNull(response);
            Assert.AreEqual(204, response.Status);
            Assert.IsFalse(response.IsError);
        }

        [LiveOnly]
        [Test]
        public async Task ValidInputFromArrayAsJsonWithMultiBatchWithGzip()
        {
            LogsIngestionClient client = CreateClient();

            // Make the request
            var response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(1000, Recording.Now.DateTime)).ConfigureAwait(false);

            // Check the response
            Assert.IsNotNull(response);
            Assert.AreEqual(204, response.Status);
            Assert.IsFalse(response.IsError);
        }

        [SyncOnly]
        [Test]
        public void ConcurrencySingleThread()
        {
            var policy = new ConcurrencyCounterPolicy(10);
            LogsIngestionClient client = CreateClient(policy);

            var response = client.Upload(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, GenerateEntries(50, Recording.Now.DateTime));

            // Check the response
            Assert.IsNotNull(response);
            Assert.AreEqual(204, response.Status);
            Assert.IsFalse(response.IsError);
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
                        Time = Recording.Now.DateTime,
                        Computer = "Computer1",
                        AdditionalContext = 2,
                    },
                    new
                    {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer2",
                        AdditionalContext = 3
                    },
                });

            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, RequestContent.Create(data)).ConfigureAwait(false); //takes StreamName not tablename
            // Check the response
            Assert.AreEqual(204, response.Status);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public async Task ValidInputAlreadyGzipped()
        {
            LogsIngestionClient client = CreateClient();

            BinaryData data = BinaryData.FromObjectAsJson(
                // Use an anonymous type to create the payload
                new[] {
                    new
                    {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer1",
                        AdditionalContext = 2,
                    },
                    new
                    {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer2",
                        AdditionalContext = 3
                    },
                });
            GZipUtf8JsonRequestContent gzContent = new(data);
            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, gzContent, "gzip").ConfigureAwait(false); //takes StreamName not tablename
            // Check the response
            Assert.AreEqual(204, response.Status);
            Assert.IsFalse(response.IsError);
        }

        [Test]
        public async Task ValidInputWithEventHandler()
        {
            LogsIngestionClient client = CreateClient();
            var entries = GenerateEntries(200, Recording.Now.DateTime);

            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            bool isTriggered = false;
            options.UploadFailed += Options_UploadFailed;
            await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options).ConfigureAwait(false);
            Assert.IsFalse(isTriggered);
            Task Options_UploadFailed(LogsUploadFailedEventArgs e)
            {
                isTriggered = true;
                return Task.CompletedTask;
            }
        }
    }
}
