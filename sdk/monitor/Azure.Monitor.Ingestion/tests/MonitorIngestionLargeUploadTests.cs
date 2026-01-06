// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests
{
    [LiveOnly]
    public class MonitorIngestionLargeUploadTests : RecordedTestBase<MonitorIngestionTestEnvironment>
    {
        private const int Mb = 1024 * 1024;
        public MonitorIngestionLargeUploadTests(bool isAsync) : base(isAsync)
        {
        }

        [OneTimeSetUp]
        public void SetUp()
        {
            LogsIngestionClient.Compression = "gzip";
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            LogsIngestionClient.Compression = null;
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
            clientOptions.Audience = TestEnvironment.GetAudience();
            return InstrumentClient(new LogsIngestionClient(new Uri(TestEnvironment.DCREndpoint), TestEnvironment.Credential, clientOptions));
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
        public void OneFailure()
        {
            LogsIngestionClient client = CreateClient();
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                );

            // Make the request
            var exceptions = Assert.ThrowsAsync<AggregateException>(async () => { await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false); });
            Assert.Multiple(() =>
            {
                Assert.That(exceptions.InnerExceptions.Count, Is.EqualTo(1));
                Assert.That(exceptions.Message.Split('.')[0], Is.EqualTo("1 out of the 801 logs failed to upload"));
            });
            foreach (RequestFailedException exception in exceptions.InnerExceptions)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(exception.ErrorCode, Is.EqualTo("ContentLengthLimitExceeded"));
                    Assert.That(exception.InnerException, Is.Null);
                    Assert.That(exception.Status, Is.EqualTo(413));
                });
            }
        }

        [Test]
        public void TwoFailures()
        {
            LogsIngestionClient client = CreateClient();
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            // Add 2 entries that are going to fail in 2 batches
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                );
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('!', Mb),
                        AdditionalContext = 1
                    }
                );

            // Make the request
            var exceptions = Assert.ThrowsAsync<AggregateException>(async () => { await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries).ConfigureAwait(false); });
            Assert.Multiple(() =>
            {
                Assert.That(exceptions.InnerExceptions.Count, Is.EqualTo(2));
                Assert.That(exceptions.Message.Split('.')[0], Is.EqualTo("2 out of the 802 logs failed to upload"));
            });
            foreach (RequestFailedException exception in exceptions.InnerExceptions)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(exception.ErrorCode, Is.EqualTo("ContentLengthLimitExceeded"));
                    Assert.That(exception.InnerException, Is.Null);
                    Assert.That(exception.Status, Is.EqualTo(413));
                });
            }
        }

        [Test]
        public async Task OneFailureWithEventHandler()
        {
            LogsIngestionClient client = CreateClient();
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                );

            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            var cts = new CancellationTokenSource();
            bool isTriggered = false;
            options.UploadFailed += Options_UploadFailed;
            await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options).ConfigureAwait(false);
            Assert.That(isTriggered, Is.True);
            Task Options_UploadFailed(LogsUploadFailedEventArgs e)
            {
                isTriggered = true;
                Assert.Multiple(() =>
                {
                    Assert.That(e.Exception, Is.InstanceOf<RequestFailedException>());
                    Assert.That(((RequestFailedException)(e.Exception)).ErrorCode, Is.EqualTo("ContentLengthLimitExceeded"));
                    Assert.That(((RequestFailedException)(e.Exception)).InnerException, Is.Null);
                    Assert.That(((RequestFailedException)(e.Exception)).Status, Is.EqualTo(413));
                });
                return Task.CompletedTask;
            }
        }

        [Test]
        public async Task TwoFailuresWithEventHandler()
        {
            LogsIngestionClient client = CreateClient();
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                );
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('!', Mb),
                        AdditionalContext = 1
                    }
                );

            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            bool isTriggered = false;
            options.UploadFailed += Options_UploadFailed;
            await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options).ConfigureAwait(false);
            Assert.That(isTriggered, Is.True);
            Task Options_UploadFailed(LogsUploadFailedEventArgs e)
            {
                isTriggered = true;
                Assert.Multiple(() =>
                {
                    Assert.That(e.Exception, Is.InstanceOf<RequestFailedException>());
                    Assert.That(((RequestFailedException)(e.Exception)).ErrorCode, Is.EqualTo("ContentLengthLimitExceeded"));
                    Assert.That(((RequestFailedException)(e.Exception)).InnerException, Is.Null);
                    Assert.That(((RequestFailedException)(e.Exception)).Status, Is.EqualTo(413));
                });
                return Task.CompletedTask;
            }
        }

        [Test]
        public void TwoFailuresWithEventHandlerCancellationToken()
        {
            LogsIngestionClient client = CreateClient();
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                );
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('!', Mb),
                        AdditionalContext = 1
                    }
                );
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string(';', Mb*5),
                        AdditionalContext = 1
                    }
                );

            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            options.MaxConcurrency = 2;
            bool isTriggered = false;
            var cts = new CancellationTokenSource();
            options.UploadFailed += Options_UploadFailed;
            AggregateException exceptions = Assert.ThrowsAsync<AggregateException>(async () => { await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options, cts.Token).ConfigureAwait(false); });
            Assert.Multiple(() =>
            {
                Assert.That(isTriggered, Is.True);
                Assert.That(cts.IsCancellationRequested, Is.True);
                // check if OperationCanceledException is in the Exception list
                // may not be first one in async case
                Assert.That(exceptions.InnerExceptions.Any(exception => exception is OperationCanceledException), Is.True);
            });
            Task Options_UploadFailed(LogsUploadFailedEventArgs e)
            {
                cts.Cancel();
                isTriggered = true;
                Assert.Multiple(() =>
                {
                    Assert.That(e.Exception, Is.InstanceOf<RequestFailedException>());
                    Assert.That(((RequestFailedException)(e.Exception)).ErrorCode, Is.EqualTo("ContentLengthLimitExceeded"));
                    Assert.That(((RequestFailedException)(e.Exception)).InnerException, Is.Null);
                    Assert.That(((RequestFailedException)(e.Exception)).Status, Is.EqualTo(413));
                });
                return Task.CompletedTask;
            }
        }

        [Test]
        public void OneFailureWithEventHandlerThrowException()
        {
            LogsIngestionClient client = CreateClient();
            var entries = GenerateEntries(800, Recording.Now.DateTime);
            entries.Add(
                    new {
                        Time = Recording.Now.DateTime,
                        Computer = "Computer" + new string('*', Mb),
                        AdditionalContext = 1
                    }
                );

            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            options.UploadFailed += Options_UploadFailed;
            var exceptions = Assert.ThrowsAsync<AggregateException>(async () => { await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options).ConfigureAwait(false); });
            Task Options_UploadFailed(LogsUploadFailedEventArgs e)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(e.Exception, Is.InstanceOf<RequestFailedException>());
                    Assert.That(((RequestFailedException)(e.Exception)).ErrorCode, Is.EqualTo("ContentLengthLimitExceeded"));
                    Assert.That(((RequestFailedException)(e.Exception)).InnerException, Is.Null);
                    Assert.That(((RequestFailedException)(e.Exception)).Status, Is.EqualTo(413));
                });
                throw e.Exception;
            }
        }

        [AsyncOnly]
        [Test]
        public async Task ConcurrencyMultiThread()
        {
            var policy = new ConcurrencyCounterPolicy(8);
            LogsIngestionClient client = CreateClient(policy);
            // Make the request
            LogsUploadOptions options = new LogsUploadOptions();
            options.MaxConcurrency = 8;
            var entries = GenerateEntries(80000, Recording.Now.DateTime);
            Response response = await client.UploadAsync(TestEnvironment.DCRImmutableId, TestEnvironment.StreamName, entries, options).ConfigureAwait(false);
            Assert.Multiple(() =>
            {
                Assert.That(policy.MaxCount, Is.GreaterThan(1));
                //Check the response
                Assert.That(response, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Status, Is.EqualTo(204));
                Assert.That(response.IsError, Is.False);
            });
        }
    }
}
