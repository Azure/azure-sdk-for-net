// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests
{
    [LiveOnly]
    public class ErrorTest : RecordedTestBase<MonitorIngestionTestEnvironment>
    {
        private const int Mb = 1024 * 1024;
        public ErrorTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        private LogsIngestionClient CreateClient(HttpPipelinePolicy policy = null)
        {
            var options = new LogsIngestionClientOptions();
            if (policy != null)
            {
                options.AddPolicy(policy, HttpPipelinePosition.PerCall);
            }
            var clientOptions = InstrumentClientOptions(options);
            return InstrumentClient(new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.Credential, clientOptions));
        }

        private static List<Object> GenerateEntries(int numEntries, DateTime recordingNow)
        {
            var entries = new List<Object>();
            for (int i = 0; i < numEntries; i++)
            {
                entries.Add(new Object[] {
                    new {
                        Time = recordingNow,
                        Computer = "Computer" + i.ToString(),
                        AdditionalContext = i
                    }
                });
            }
            return entries;
        }

        [Test]
        public void OneFailure()
        {
            LogsIngestionClient client = CreateClient();
            // set compression to gzip so SDK does not gzip data (assumes already gzipped)
            LogsIngestionClient.Compression = "gzip";
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(new object[] {
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                });

            // Make the request
            var exceptions = Assert.ThrowsAsync<AggregateException>(async () => { await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false); });
            Assert.AreEqual(1, exceptions.InnerExceptions.Count);
            Assert.AreEqual("1 out of the 801 logs failed to upload", exceptions.Message.Split('.')[0]);
            foreach (RequestFailedException exception in exceptions.InnerExceptions)
            {
                Assert.AreEqual("ContentLengthLimitExceeded", exception.ErrorCode);
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual(413, exception.Status);
            }
        }

        [Test]
        public void TwoFailures()
        {
            LogsIngestionClient client = CreateClient();
            // set compression to gzip so SDK does not gzip data (assumes already gzipped)
            LogsIngestionClient.Compression = "gzip";
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            // Add 2 entries that are going to fail in 2 batches
            entries.Add(new object[] {
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                });
            entries.Add(new object[] {
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('!', Mb),
                        AdditionalContext = 1
                    }
                });

            // Make the request
            var exceptions = Assert.ThrowsAsync<AggregateException>(async () => { await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false); });
            Assert.AreEqual(2, exceptions.InnerExceptions.Count);
            Assert.AreEqual("2 out of the 802 logs failed to upload", exceptions.Message.Split('.')[0]);
            foreach (RequestFailedException exception in exceptions.InnerExceptions)
            {
                Assert.AreEqual("ContentLengthLimitExceeded", exception.ErrorCode);
                Assert.IsNull(exception.InnerException);
                Assert.AreEqual(413, exception.Status);
            }
        }

        [Test]
        public async Task OneFailureWithEventHandler()
        {
            LogsIngestionClient client = CreateClient();
            // set compression to gzip so SDK does not gzip data (assumes already gzipped)
            LogsIngestionClient.Compression = "gzip";
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(new object[] {
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                });

            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            var cts = new CancellationTokenSource();
            bool isTriggered = false;
            options.UploadFailed += Options_UploadFailed;
            //await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options, cts.Token).ConfigureAwait(false);
            await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options).ConfigureAwait(false);
            Assert.IsTrue(isTriggered);
            Task Options_UploadFailed(UploadFailedEventArgs e)
            {
                isTriggered = true;
                Assert.IsInstanceOf<RequestFailedException>(e.Exception);
                Assert.AreEqual("ContentLengthLimitExceeded", ((RequestFailedException)(e.Exception)).ErrorCode);
                Assert.IsNull(((RequestFailedException)(e.Exception)).InnerException);
                Assert.AreEqual(413, ((RequestFailedException)(e.Exception)).Status);
                return Task.CompletedTask;
            }
        }

        [Test]
        public async Task TwoFailuresWithEventHandler()
        {
            LogsIngestionClient client = CreateClient();
            // set compression to gzip so SDK does not gzip data (assumes already gzipped)
            LogsIngestionClient.Compression = "gzip";
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(new object[] {
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                });
            entries.Add(new object[] {
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('!', Mb),
                        AdditionalContext = 1
                    }
                });

            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            bool isTriggered = false;
            options.UploadFailed += Options_UploadFailed;
            await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options).ConfigureAwait(false);
            Assert.IsTrue(isTriggered);
            Task Options_UploadFailed(UploadFailedEventArgs e)
            {
                isTriggered = true;
                Assert.IsInstanceOf<RequestFailedException>(e.Exception);
                Assert.AreEqual("ContentLengthLimitExceeded", ((RequestFailedException)(e.Exception)).ErrorCode);
                Assert.IsNull(((RequestFailedException)(e.Exception)).InnerException);
                Assert.AreEqual(413, ((RequestFailedException)(e.Exception)).Status);
                return Task.CompletedTask;
            }
        }
    }
}
