// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

// Ignore Spelling: Poco evt

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    [NonParallelizable]
    [LiveOnly(true)]
    public class EventHubEndToEndTests : WebJobsEventHubTestBase
    {
        private static readonly TimeSpan NoEventReadTimeout = TimeSpan.FromSeconds(5);

        private static EventWaitHandle _eventWait1;
        private static EventWaitHandle _eventWait2;
        private static List<string> _results;
        private static DateTimeOffset _initialOffsetEnqueuedTimeUTC;

        [SetUp]
        public void SetUp()
        {
            _results = new List<string>();
            _eventWait1 = new ManualResetEvent(initialState: false);
            _eventWait2 = new ManualResetEvent(initialState: false);
        }

        [TearDown]
        public void TearDown()
        {
            _eventWait1.Dispose();
            _eventWait2.Dispose();
        }

        [Test]
        public async Task EventHub_PocoBinding()
        {
            var (jobHost, host) = BuildHost<EventHubTestBindToPocoJobs>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestBindToPocoJobs.SendEvent_TestHub));

                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }

            var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage);
            CollectionAssert.Contains(logs, $"PocoValues(foo,data)");

            var categories = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.Category);
            CollectionAssert.Contains(categories, "Microsoft.Azure.WebJobs.EventHubs.Listeners.EventHubListener.PartitionProcessor");
        }

        [Test]
        public async Task EventHub_StringBinding()
        {
            var (jobHost, host) = BuildHost<EventHubTestBindToStringJobs>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestBindToStringJobs.SendEvent_TestHub), new { input = "data" });

                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);

                var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage);
                CollectionAssert.Contains(logs, $"Input(data)");

                var categories = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.Category);
                CollectionAssert.Contains(categories, "Microsoft.Azure.WebJobs.EventHubs.Listeners.EventHubListener.PartitionProcessor");
            }
        }

        [Test]
        public async Task EventHub_SingleDispatch()
        {
            var watch = ValueStopwatch.StartNew();
            var (jobHost, host) = BuildHost<EventHubTestSingleDispatchJobs>();

            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestSingleDispatchJobs.SendEvent_TestHub), new { input = "data" });

                bool result = _eventWait1.WaitOne(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                Assert.True(result);

                using var cancellationSource = new CancellationTokenSource(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                await AwaitCheckpointing(host, cancellationSource.Token);
                await StopWithDrainAsync(host);
            }

            AssertSingleDispatchLogs(host);
        }

        [Test]
        public async Task EventHub_SingleDispatch_Dispose()
        {
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
            var (jobHost, _) = BuildHost<EventHubTestSingleDispatchJobs_Dispose>(ConfigureTestEventHub);

            Assert.True(_eventWait1.WaitOne(Timeout));
            jobHost.Dispose();
            Assert.True(_eventWait2.WaitOne(Timeout));
        }

        [Test]
        public async Task EventHub_SingleDispatch_StopWithoutDrain()
        {
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
            var (jobHost, _) = BuildHost<EventHubTestSingleDispatchJobs_Dispose>(ConfigureTestEventHub);

            Assert.True(_eventWait1.WaitOne(Timeout));
            await jobHost.StopAsync();
            Assert.True(_eventWait2.WaitOne(Timeout));
        }

        [Test]
        public async Task EventHub_SingleDispatch_ConsumerGroup()
        {
            var (jobHost, host) = BuildHost<EventHubTestSingleDispatchWithConsumerGroupJobs>(builder =>
            {
                ConfigureTestEventHub(builder);
                builder
                    .ConfigureAppConfiguration(builder =>
                    {
                        builder.AddInMemoryCollection(new Dictionary<string, string>()
                        {
                            {"consumerGroup", "$Default"}
                        });
                    });
            });
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestSingleDispatchWithConsumerGroupJobs.SendEvent_TestHub));

                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_SingleDispatch_BinaryData()
        {
            var watch = ValueStopwatch.StartNew();
            var (jobHost, host) = BuildHost<EventHubTestSingleDispatchJobsBinaryData>();

            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestSingleDispatchJobsBinaryData.SendEvent_TestHub), new { input = "data" });

                bool result = _eventWait1.WaitOne(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                Assert.True(result);

                using var cancellationSource = new CancellationTokenSource(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                await AwaitCheckpointing(host, cancellationSource.Token);
                await StopWithDrainAsync(host);
            }

            AssertSingleDispatchLogs(host);
        }

        [Test]
        public async Task EventHub_ProducerClient()
        {
            var (jobHost, host) = BuildHost<EventHubTestClientDispatch>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestClientDispatch.SendEvents));

                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_Collector()
        {
            var (jobHost, host) = BuildHost<EventHubTestCollectorDispatch>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestCollectorDispatch.SendEvents));

                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_CollectorPartitionKey()
        {
            var (jobHost, host) = BuildHost<EventHubTestCollectorDispatch>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestCollectorDispatch.SendEventsWithKey));

                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task CanSendAndReceive_ConnectionStringInConfiguration()
        {
            await AssertCanSendReceiveMessage(host =>
                host.ConfigureAppConfiguration(configurationBuilder =>
                    configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"TestConnection", EventHubsTestEnvironment.Instance.EventHubsConnectionString},
                        {"AzureWebJobsStorage", StorageTestEnvironment.Instance.StorageConnectionString}
                    })));
        }

        [Test]
        public async Task CanSendAndReceive_TokenCredentialInConfiguration()
        {
            await AssertCanSendReceiveMessage(host =>
                host.ConfigureAppConfiguration(configurationBuilder =>
                    configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"TestConnection:fullyQualifiedNamespace", EventHubsTestEnvironment.Instance.FullyQualifiedNamespace},
                        {"AzureWebJobsStorage:serviceUri", GetServiceUri()}
                    })));
        }

        [Test]
        public async Task CanSendAndReceive_BlobServiceUri_InConfiguration()
        {
            await AssertCanSendReceiveMessage(host =>
                host.ConfigureAppConfiguration(configurationBuilder =>
                    configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"TestConnection:fullyQualifiedNamespace", EventHubsTestEnvironment.Instance.FullyQualifiedNamespace},
                        {"TestConnection:clientId", EventHubsTestEnvironment.Instance.ClientId},
                        {"TestConnection:clientSecret", EventHubsTestEnvironment.Instance.ClientSecret},
                        {"TestConnection:tenantId", EventHubsTestEnvironment.Instance.TenantId},
                        {"AzureWebJobsStorage:blobServiceUri", GetServiceUri()},
                        {"AzureWebJobsStorage:clientId", EventHubsTestEnvironment.Instance.ClientId},
                        {"AzureWebJobsStorage:clientSecret", EventHubsTestEnvironment.Instance.ClientSecret},
                        {"AzureWebJobsStorage:tenantId", EventHubsTestEnvironment.Instance.TenantId},
                    })));
        }

        [Test]
        public async Task CanSendAndReceive_AccountName_InConfiguration()
        {
            // Use of an account name assumes an endpoint suffix that is only valid in some Azure
            // cloud environments. If the current execution environment uses a different suffix,
            // ignore the test.

            var defaultSuffix = StorageClientProvider<object, ClientOptions>.DefaultStorageEndpointSuffix;

            if (!string.Equals(EventHubsTestEnvironment.Instance.StorageEndpointSuffix, defaultSuffix, StringComparison.OrdinalIgnoreCase))
            {
                Assert.Ignore($"This test can only be run in the Azure cloud associated with the suffix: `{defaultSuffix}`.");
            }

            await AssertCanSendReceiveMessage(host =>
                host.ConfigureAppConfiguration(configurationBuilder =>
                    configurationBuilder.AddInMemoryCollection(new Dictionary<string, string>()
                    {
                        {"TestConnection:fullyQualifiedNamespace", EventHubsTestEnvironment.Instance.FullyQualifiedNamespace},
                        {"TestConnection:clientId", EventHubsTestEnvironment.Instance.ClientId},
                        {"TestConnection:clientSecret", EventHubsTestEnvironment.Instance.ClientSecret},
                        {"TestConnection:tenantId", EventHubsTestEnvironment.Instance.TenantId},
                        {"AzureWebJobsStorage:accountName", StorageTestEnvironment.Instance.StorageAccountName},
                        {"AzureWebJobsStorage:clientId", EventHubsTestEnvironment.Instance.ClientId},
                        {"AzureWebJobsStorage:clientSecret", EventHubsTestEnvironment.Instance.ClientSecret},
                        {"AzureWebJobsStorage:tenantId", EventHubsTestEnvironment.Instance.TenantId},
                    })));
        }

        private static string GetServiceUri()
        {
            return "https://" + StorageTestEnvironment.Instance.StorageAccountName + ".blob." + StorageTestEnvironment.Instance.StorageEndpointSuffix;
        }

        public async Task AssertCanSendReceiveMessage(Action<IHostBuilder> hostConfiguration)
        {
            var (jobHost, host) = BuildHost<EventHubTestSingleDispatchJobWithConnection>(hostConfiguration);
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestSingleDispatchJobWithConnection.SendEvent_TestHub), new { input = "data" });

                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_MultipleDispatch()
        {
            var watch = ValueStopwatch.StartNew();
            var (jobHost, host) = BuildHost<EventHubTestMultipleDispatchJobs>();

            using (jobHost)
            {
                int numEvents = 5;
                await jobHost.CallAsync(nameof(EventHubTestMultipleDispatchJobs.SendEvents_TestHub), new { numEvents = numEvents, input = "data" });

                bool result = _eventWait1.WaitOne(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                Assert.True(result);

                using var cancellationSource = new CancellationTokenSource(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                await AwaitCheckpointing(host, cancellationSource.Token);
                await StopWithDrainAsync(host);
            }

            AssertMultipleDispatchLogs(host);
        }

        [Test]
        public async Task EventHub_MultipleDispatch_BinaryData()
        {
            var watch = ValueStopwatch.StartNew();
            var (jobHost, host) = BuildHost<EventHubTestMultipleDispatchJobsBinaryData>();

            using (jobHost)
            {
                int numEvents = 5;
                await jobHost.CallAsync(nameof(EventHubTestMultipleDispatchJobsBinaryData.SendEvents_TestHub), new { numEvents = numEvents, input = "data" });

                bool result = _eventWait1.WaitOne(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                Assert.True(result);

                using var cancellationSource = new CancellationTokenSource(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                await AwaitCheckpointing(host, cancellationSource.Token);
                await StopWithDrainAsync(host);
            }

            AssertMultipleDispatchLogs(host);
        }

        [Test]
        public async Task EventHub_MultipleDispatch_MinBatchSize()
        {
            const int minEventBatchSize = 5;

            var watch = ValueStopwatch.StartNew();
            var (jobHost, host) = BuildHost<EventHubTestMultipleDispatchMinBatchSizeJobs>(
                builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.Configure<EventHubOptions>(options =>
                        {
                            options.MinEventBatchSize = minEventBatchSize; // Increase from 1 to 5
                        });
                    });
                    ConfigureTestEventHub(builder);
                },
                host =>
                {
                    var factory = host.Services.GetService<EventHubClientFactory>();
                    EventHubTestMultipleDispatchMinBatchSizeJobs.InitializeCheckpoints(factory).GetAwaiter().GetResult();
                });

            using (jobHost)
            {
                int numEvents = 5;
                await jobHost.CallAsync(nameof(EventHubTestMultipleDispatchMinBatchSizeJobs.SendEvents_TestHub), new { numEvents = numEvents, input = "data" });

                bool result = _eventWait1.WaitOne(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                Assert.True(result);

                using var cancellationSource = new CancellationTokenSource(GetRemainingTimeoutMilliseconds(watch.GetElapsedTime()));
                await AwaitCheckpointing(host, cancellationSource.Token);
                await StopWithDrainAsync(host);
            }

            AssertMultipleDispatchLogsMinBatch(host);
        }

        [Test]
        public async Task EventHub_MultipleDispatch_Dispose()
        {
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
            var (jobHost, _) = BuildHost<EventHubTestMultipleDispatchJobs_Dispose>();

            Assert.True(_eventWait1.WaitOne(Timeout));
            jobHost.Dispose();
            Assert.True(_eventWait2.WaitOne(Timeout));
        }

        [Test]
        public async Task EventHub_MultipleDispatch_StopWithoutDrain()
        {
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
            var (jobHost, _) = BuildHost<EventHubTestMultipleDispatchJobs_Dispose>();

            Assert.True(_eventWait1.WaitOne(Timeout));
            await jobHost.StopAsync();
            Assert.True(_eventWait2.WaitOne(Timeout));
        }

        [Test]
        public async Task EventHub_PartitionKey()
        {
            var (jobHost, host) = BuildHost<EventHubPartitionKeyTestJobs>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubPartitionKeyTestJobs.SendEvents_TestHub), new { input = "data" });
                bool result = _eventWait1.WaitOne(Timeout);

                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_InitialOffsetFromStart()
        {
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });

            var (jobHost, host) = BuildHost<EventHubTestInitialOffsetFromStartEndJobs>(
                builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.Configure<EventHubOptions>(options =>
                        {
                            options.InitialOffsetOptions.Type = OffsetType.FromStart;
                        });
                    });
                    ConfigureTestEventHub(builder);
                });
            using (jobHost)
            {
                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_InitialOffsetFromEnd()
        {
            // Send a message to ensure the stream is not empty as we are trying to validate that no messages are delivered in this case
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });

            var (jobHost, host) = BuildHost<EventHubTestInitialOffsetFromStartEndJobs>(
                builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.Configure<EventHubOptions>(options =>
                        {
                            options.InitialOffsetOptions.Type = OffsetType.FromEnd;
                        });
                    });
                    ConfigureTestEventHub(builder);
                });
            using (jobHost)
            {
                // We don't expect to get signaled as there should be no messages received with a FromEnd initial offset
                bool result = _eventWait1.WaitOne(NoEventReadTimeout);
                Assert.False(result, "An event was received while none were expected.");

                // send events which should be received.  To ensure that the test is
                // resilient to any errors where the link needs to be reestablished,
                // continue sending events until cancellation takes place.

                using var cts = new CancellationTokenSource();

                var sendTask = Task.Run(async () =>
                {
                    while (!cts.IsCancellationRequested)
                    {
                        await producer.SendAsync(new[] { new EventData("data") }, cts.Token).ConfigureAwait(false);
                    }
                });

                result = _eventWait1.WaitOne(Timeout);

                cts.Cancel();
                try { await sendTask; } catch { /* Ignore, we're not testing sends */ }

                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_InitialOffsetFromEnqueuedTime()
        {
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);

            for (int i = 0; i < 5; i++)
            {
                // send one at a time so they will have slightly different enqueued times
                await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
                await Task.Delay(1000);
            }
            await using var consumer = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                _eventHubScope.EventHubName);

            await foreach (PartitionEvent evt in consumer.ReadEventsAsync())
            {
                // use the timestamp from the first event for our FromEnqueuedTime
                _initialOffsetEnqueuedTimeUTC = evt.Data.EnqueuedTime;
                break;
            }

            var initialOffsetOptions = new InitialOffsetOptions();
            var (jobHost, host) = BuildHost<EventHubTestInitialOffsetFromEnqueuedTimeJobs>(
                builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.Configure<EventHubOptions>(options =>
                        {
                            options.InitialOffsetOptions.Type = OffsetType.FromEnqueuedTime;

                            // Reads from enqueue time are non-inclusive.  To ensure that we start with the desired event, set the time slightly in the past.
                            options.InitialOffsetOptions.EnqueuedTimeUtc = _initialOffsetEnqueuedTimeUTC.Subtract(TimeSpan.FromMilliseconds(250));
                        });
                    });
                    ConfigureTestEventHub(builder);
                });
            using (jobHost)
            {
                bool result = _eventWait1.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        private static void AssertSingleDispatchLogs(IHost host)
        {
            IEnumerable<LogMessage> logMessages = host.GetTestLoggerProvider()
                .GetAllLogMessages();

            Assert.AreEqual(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("Trigger Details:")
                && x.FormattedMessage.Contains("Offset:")).Count(), 1);

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("OpenAsync")).Any());

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("CheckpointAsync")
                && x.FormattedMessage.Contains("lease")
                && x.FormattedMessage.Contains("offset")
                && x.FormattedMessage.Contains("sequenceNumber")).Any());

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("Sending events to EventHub")).Any());

            AssertAzureSdkLogs(logMessages);
        }

        private static void AssertMultipleDispatchLogsMinBatch(IHost host)
        {
            IEnumerable<LogMessage> logMessages = host.GetTestLoggerProvider()
                .GetAllLogMessages();

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("Trigger Details:")
                && x.FormattedMessage.Contains("Offset:")).Any());

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("OpenAsync")).Any());

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("CheckpointAsync")
                && x.FormattedMessage.Contains("lease")
                && x.FormattedMessage.Contains("offset")
                && x.FormattedMessage.Contains("sequenceNumber")).Any());

            // Events are being sent in the EventHubTestMultipleDispatchMinBatchSizeJobs
            // class directly for this test

            AssertAzureSdkLogs(logMessages);
        }

        private static void AssertMultipleDispatchLogs(IHost host)
        {
            IEnumerable<LogMessage> logMessages = host.GetTestLoggerProvider()
                .GetAllLogMessages();

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("Trigger Details:")
                && x.FormattedMessage.Contains("Offset:")).Any());

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("OpenAsync")).Any());

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("CheckpointAsync")
                && x.FormattedMessage.Contains("lease")
                && x.FormattedMessage.Contains("offset")
                && x.FormattedMessage.Contains("sequenceNumber")).Any());

            Assert.True(logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                && x.FormattedMessage.Contains("Sending events to EventHub")).Any());

            AssertAzureSdkLogs(logMessages);
        }

        private static void AssertAzureSdkLogs(IEnumerable<LogMessage> logMessages)
        {
            Assert.True(logMessages.Any(x => x.Category.StartsWith("Azure.")));
        }

        private static async Task StopWithDrainAsync(IHost host)
        {
            var drainModeManager = host.Services.GetService<IDrainModeManager>();
            await drainModeManager.EnableDrainModeAsync(CancellationToken.None);
            await host.StopAsync();
        }

         private static async Task AwaitCheckpointing(IHost host, CancellationToken cancellationToken)
        {
            var logMessages = host.GetTestLoggerProvider()
                .GetAllLogMessages();

            while (true)
            {
                if (logMessages.Where(x => !string.IsNullOrEmpty(x.FormattedMessage)
                    && x.FormattedMessage.Contains("CheckpointAsync")
                    && x.FormattedMessage.Contains("sequenceNumber")).Any())
                {
                    return;
                }

                // No need to explicitly check the cancellation token;
                // the delay will throw if the token is signaled.
                await Task.Delay(100, cancellationToken).ConfigureAwait(false);
            }
        }

        public class EventHubTestSingleDispatchJobs
        {
            public static void SendEvent_TestHub(string input, [EventHub(TestHubName, Connection = TestHubName)] out EventData evt)
            {
                evt = new EventData(Encoding.UTF8.GetBytes(input));
                evt.Properties.Add("TestProp1", "value1");
                evt.Properties.Add("TestProp2", "value2");
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = TestHubName)] string evt,
                string partitionKey, DateTime enqueuedTimeUtc, IDictionary<string, object> properties,
                IDictionary<string, object> systemProperties,
                PartitionContext partitionContext,
                TriggerPartitionContext triggerPartitionContext)
            {
                Assert.AreEqual("value1", properties["TestProp1"]);
                Assert.AreEqual("value2", properties["TestProp2"]);

                Assert.NotNull(partitionContext.PartitionId);
                Assert.AreNotEqual(default(LastEnqueuedEventProperties), partitionContext.ReadLastEnqueuedEventProperties());

                Assert.NotNull(triggerPartitionContext.PartitionId);
                Assert.AreNotEqual(default(LastEnqueuedEventProperties), triggerPartitionContext.ReadLastEnqueuedEventProperties());
                Assert.True(triggerPartitionContext.IsCheckpointingAfterInvocation);

                _eventWait1.Set();
            }
        }

        public class EventHubTestSingleDispatchJobs_Dispose
        {
            public static async Task SendEvent_TestHub([EventHubTrigger(TestHubName, Connection = TestHubName)] string evt, CancellationToken cancellationToken)
            {
                _eventWait1.Set();
                // wait for the host to call dispose
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(100, CancellationToken.None);
                }
                _eventWait2.Set();
            }
        }

        public class EventHubTestMultipleDispatchJobs_Dispose
        {
            public static async Task SendEvent_TestHub([EventHubTrigger(TestHubName, Connection = TestHubName)] string[] evt, CancellationToken cancellationToken)
            {
                _eventWait1.Set();
                // wait for the host to call dispose
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, CancellationToken.None);
                }
                _eventWait2.Set();
            }
        }

        public class EventHubTestCollectorDispatch
        {
            private static string s_partitionKey = null;

            public static async Task SendEvents([EventHub(TestHubName, Connection = TestHubName)] IAsyncCollector<EventData> collector)
            {
                await collector.AddAsync(new EventData(new BinaryData("Event 1")));
                await collector.FlushAsync();
            }

            public static async Task SendEventsWithKey([EventHub(TestHubName, Connection = TestHubName)] IAsyncCollector<EventData> collector)
            {
                s_partitionKey = "test-key";

                await collector.AddAsync(new EventData(new BinaryData("Event 1")), s_partitionKey);
                await collector.FlushAsync();
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = TestHubName)] EventData eventData)
            {
                Assert.AreEqual(eventData.EventBody.ToString(), "Event 1");

                if (!string.IsNullOrEmpty(s_partitionKey))
                {
                    Assert.AreEqual(eventData.PartitionKey, s_partitionKey);
                }

                _eventWait1.Set();
            }
        }

        public class EventHubTestClientDispatch
        {
            public static async Task SendEvents([EventHub(TestHubName, Connection = TestHubName)] EventHubProducerClient producer)
            {
                await producer.SendAsync(new[]
                {
                    new EventData(new BinaryData("Event 1")),
                });
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = TestHubName)] EventData eventData)
            {
                Assert.AreEqual(eventData.EventBody.ToString(), "Event 1");
                _eventWait1.Set();
            }
        }

        public class EventHubTestSingleDispatchWithConsumerGroupJobs
        {
            public static void SendEvent_TestHub([EventHub(TestHubName, Connection = TestHubName)] out string evt)
            {
                evt = nameof(EventHubTestSingleDispatchWithConsumerGroupJobs);
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = TestHubName, ConsumerGroup = "%consumerGroup%")] string evt)
            {
                Assert.AreEqual(evt, nameof(EventHubTestSingleDispatchWithConsumerGroupJobs));

                _eventWait1.Set();
            }
        }

        public class EventHubTestSingleDispatchJobsBinaryData
        {
            public static void SendEvent_TestHub(string input, [EventHub(TestHubName, Connection = TestHubName)] out BinaryData evt)
            {
                evt = new BinaryData(input);
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = TestHubName)] BinaryData evt,
                       string partitionKey, DateTime enqueuedTimeUtc, IDictionary<string, object> properties,
                       IDictionary<string, object> systemProperties)
            {
                Assert.AreEqual("data", evt.ToString());
                _eventWait1.Set();
            }
        }

        public class EventHubTestBindToPocoJobs
        {
            public static void SendEvent_TestHub([EventHub(TestHubName, Connection = TestHubName)] out TestPoco evt)
            {
                evt = new TestPoco() {Value = "data", Name = "foo"};
            }

            public static void BindToPoco([EventHubTrigger(TestHubName, Connection = TestHubName)] TestPoco input, ILogger logger)
            {
                Assert.AreEqual(input.Value, "data");
                Assert.AreEqual(input.Name, "foo");
                logger.LogInformation($"PocoValues(foo,data)");
                _eventWait1.Set();
            }
        }

        public class EventHubTestBindToStringJobs
        {
            public static void SendEvent_TestHub(string input, [EventHub(TestHubName, Connection = TestHubName)] out EventData evt)
            {
                evt = new EventData(Encoding.UTF8.GetBytes(input));
            }

            public static void BindToString([EventHubTrigger(TestHubName, Connection = TestHubName)] string input, ILogger logger)
            {
                logger.LogInformation($"Input({input})");
                _eventWait1.Set();
            }
        }

        public class EventHubTestMultipleDispatchJobs
        {
            private static int s_eventCount;
            private static int s_processedEventCount;
            public static void SendEvents_TestHub(int numEvents, string input, [EventHub(TestHubName, Connection = TestHubName)] out EventData[] events)
            {
                s_eventCount = numEvents;
                events = new EventData[numEvents];
                for (int i = 0; i < numEvents; i++)
                {
                    var evt = new EventData(Encoding.UTF8.GetBytes(input));
                    evt.Properties.Add("TestIndex", i);
                    evt.Properties.Add("TestProp1", "value1");
                    evt.Properties.Add("TestProp2", "value2");
                    events[i] = evt;
                }
            }

            public static void ProcessMultipleEvents([EventHubTrigger(TestHubName, Connection = TestHubName)] string[] events,
                string[] partitionKeyArray, DateTime[] enqueuedTimeUtcArray, IDictionary<string, object>[] propertiesArray,
                IDictionary<string, object>[] systemPropertiesArray, PartitionContext partitionContext, TriggerPartitionContext triggerPartitionContext)
            {
                Assert.AreEqual(events.Length, partitionKeyArray.Length);
                Assert.AreEqual(events.Length, enqueuedTimeUtcArray.Length);
                Assert.AreEqual(events.Length, propertiesArray.Length);
                Assert.AreEqual(events.Length, systemPropertiesArray.Length);

                for (int i = 0; i < events.Length; i++)
                {
                    Assert.AreEqual(s_processedEventCount++, propertiesArray[i]["TestIndex"]);
                }

                Assert.NotNull(partitionContext.PartitionId);
                Assert.AreNotEqual(default(LastEnqueuedEventProperties), partitionContext.ReadLastEnqueuedEventProperties());

                Assert.NotNull(triggerPartitionContext.PartitionId);
                Assert.AreNotEqual(default(LastEnqueuedEventProperties), triggerPartitionContext.ReadLastEnqueuedEventProperties());
                Assert.True(triggerPartitionContext.IsCheckpointingAfterInvocation);

                if (s_processedEventCount == s_eventCount)
                {
                    _results.AddRange(events);
                    _eventWait1.Set();
                }
            }
        }

        public class EventHubTestMultipleDispatchJobsBinaryData
        {
            private static int s_eventCount;
            private static int s_processedEventCount;
            public static void SendEvents_TestHub(int numEvents, string input, [EventHub(TestHubName, Connection = TestHubName)] out BinaryData[] events)
            {
                s_eventCount = numEvents;
                events = new BinaryData[numEvents];
                for (int i = 0; i < numEvents; i++)
                {
                    events[i] = new BinaryData(input);
                }
            }

            public static void ProcessMultipleEventsBinaryData([EventHubTrigger(TestHubName, Connection = TestHubName)] BinaryData[] events,
                    string[] partitionKeyArray, DateTime[] enqueuedTimeUtcArray, IDictionary<string, object>[] propertiesArray,
                    IDictionary<string, object>[] systemPropertiesArray)
            {
                Assert.AreEqual(events.Length, partitionKeyArray.Length);
                Assert.AreEqual(events.Length, enqueuedTimeUtcArray.Length);
                Assert.AreEqual(events.Length, propertiesArray.Length);
                Assert.AreEqual(events.Length, systemPropertiesArray.Length);

                s_processedEventCount += events.Length;

                // filter for the ID the current test is using
                if (s_processedEventCount == s_eventCount)
                {
                    _eventWait1.Set();
                }
            }
        }

        public class EventHubTestMultipleDispatchMinBatchSizeJobs
        {
            private static int s_eventCount;
            private static int s_processedEventCount;

            internal static async Task InitializeCheckpoints(EventHubClientFactory factory)
            {
                var producer = factory.GetEventHubProducerClient(TestHubName, TestHubName);
                var blobClient = factory.GetCheckpointStoreClient();
                var checkpointStore = new BlobCheckpointStoreInternal(blobClient);

                await blobClient.CreateIfNotExistsAsync();

                foreach (var partition in await producer.GetPartitionIdsAsync())
                {
                    await checkpointStore.UpdateCheckpointAsync(
                        producer.FullyQualifiedNamespace,
                        producer.EventHubName,
                        EventHubConsumerClient.DefaultConsumerGroupName,
                        partition,
                        producer.Identifier,
                        new CheckpointPosition("-1", -1),
                        CancellationToken.None);
                }
            }

            public static async Task SendEvents_TestHub(int numEvents, string input, [EventHub(TestHubName, Connection = TestHubName)] EventHubProducerClient client)
            {
                // Send all of the events to the same partition so the test is deterministic
                s_eventCount = numEvents;
                var options = new SendEventOptions()
                {
                    PartitionKey = "key1"
                };

                // send one event at a time with a short time gap in between
                for (int i = 0; i < numEvents; i++)
                {
                    var evt = new EventData(Encoding.UTF8.GetBytes(input));
                    await client.SendAsync(new[] { evt }, options).ConfigureAwait(false);
                    await Task.Delay(1000);
                }
            }

            public static void ProcessMultipleEvents([EventHubTrigger(TestHubName, Connection = TestHubName)] string[] events,
                string[] partitionKeyArray, DateTime[] enqueuedTimeUtcArray, IDictionary<string, object>[] propertiesArray,
                IDictionary<string, object>[] systemPropertiesArray, PartitionContext partitionContext, TriggerPartitionContext triggerPartitionContext)
            {
                Assert.AreEqual(events.Length, partitionKeyArray.Length);
                Assert.AreEqual(events.Length, enqueuedTimeUtcArray.Length);
                Assert.AreEqual(events.Length, propertiesArray.Length);
                Assert.AreEqual(events.Length, systemPropertiesArray.Length);

                // We are expecting to have all of the events sent processed in one batch
                Assert.AreEqual(s_eventCount, events.Length);

                s_processedEventCount += events.Length;

                if (s_processedEventCount >= s_eventCount)
                {
                    _eventWait1.Set();
                }
            }
        }

        public class EventHubPartitionKeyTestJobs
        {
            // send more events per partition than the EventHubsOptions.MaxBatchSize
            // so that we get coverage for receiving events from the same partition in multiple chunks
            private const int EventsPerPartition = 15;
            private const int PartitionCount = 5;
            private const string PartitionKeyPrefix = "test_pk";

            public static async Task SendEvents_TestHub(
                string input,
                [EventHub(TestHubName, Connection = TestHubName)] EventHubProducerClient client)
            {
                var evt = new EventData(Encoding.UTF8.GetBytes(input));
                var tasks = new List<Task>();

                // Send event without PK
                await client.SendAsync(new[] { evt });

                // Send event with different PKs
                for (int i = 0; i < PartitionCount; i++)
                {
                    evt = new EventData(Encoding.UTF8.GetBytes(input));
                    tasks.Add(client.SendAsync(Enumerable.Repeat(evt, EventsPerPartition), new SendEventOptions() { PartitionKey = PartitionKeyPrefix + i }));
                }

                await Task.WhenAll(tasks);
            }

            public static void ProcessMultiplePartitionEvents([EventHubTrigger(TestHubName, Connection = TestHubName)] EventData[] events)
            {
                foreach (EventData eventData in events)
                {
                    string message = Encoding.UTF8.GetString(eventData.Body.ToArray());
                    _results.Add(eventData.PartitionKey);

                    Assert.True(eventData.PartitionKey.StartsWith(PartitionKeyPrefix));
                }

                // The size of the batch read may not contain all events sent.  If any
                // were read, the format of the partition key was read and verified.

                if (_results.Count > 0)
                {
                   _eventWait1.Set();
                }
            }
        }

        public class EventHubTestSingleDispatchJobWithConnection
        {
            public static void SendEvent_TestHub(string input, [EventHub(TestHubName, Connection = "TestConnection")] out EventData evt)
            {
                evt = new EventData(Encoding.UTF8.GetBytes(input));
                evt.Properties.Add("TestProp1", "value1");
                evt.Properties.Add("TestProp2", "value2");
            }

            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = "TestConnection")] string evt, DateTime enqueuedTimeUtc, IDictionary<string, object> properties)
            {
                Assert.AreEqual("value1", properties["TestProp1"]);
                Assert.AreEqual("value2", properties["TestProp2"]);

                _eventWait1.Set();
            }
        }
        public class TestPoco
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        public class EventHubTestInitialOffsetFromStartEndJobs
        {
            public static void ProcessSingleEvent([EventHubTrigger(TestHubName, Connection = TestHubName)] string evt,
                       string partitionKey, DateTime enqueuedTimeUtc, IDictionary<string, object> properties,
                       IDictionary<string, object> systemProperties)
            {
                _eventWait1.Set();
            }
        }

        public class EventHubTestInitialOffsetFromEnqueuedTimeJobs
        {
            private const int ExpectedEventsCount = 2;

            public static void ProcessMultipleEvents([EventHubTrigger(TestHubName, Connection = TestHubName)] EventData[] events)
            {
                // there's potentially some level of rewind due to clock differences; allow a small delta when validating.
                var earliestAllowedOffset = _initialOffsetEnqueuedTimeUTC.Subtract(TimeSpan.FromMilliseconds(500));

                foreach (EventData eventData in events)
                {
                    string message = Encoding.UTF8.GetString(eventData.Body.ToArray());

                    _results.Add(eventData.EnqueuedTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));

                    if (_results.Count >= ExpectedEventsCount)
                    {
                        foreach (var result in _results)
                        {
                            Assert.GreaterOrEqual(DateTimeOffset.Parse(result), earliestAllowedOffset);
                        }
                        _eventWait1.Set();
                    }
                }
            }
        }
    }
}