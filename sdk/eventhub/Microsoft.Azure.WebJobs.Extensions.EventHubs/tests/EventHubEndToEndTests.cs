﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Microsoft.Azure.WebJobs.EventHubs;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    [NonParallelizable]
    [LiveOnly]
    public class EventHubEndToEndTests : WebJobsEventHubTestBase
    {
        private static EventWaitHandle _eventWait;
        private static List<string> _results;
        private static DateTimeOffset _initialOffsetEnqueuedTimeUTC;

        /// <summary>
        ///   Performs the tasks needed to initialize the test fixture.  This
        ///   method runs once for the entire fixture, prior to running any tests.
        /// </summary>
        ///
        [SetUp]
        public void SetUp()
        {
            _results = new List<string>();
            _eventWait = new ManualResetEvent(initialState: false);
        }

        [Test]
        public async Task EventHub_PocoBinding()
        {
            var (jobHost, host) = BuildHost<EventHubTestBindToPocoJobs>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestBindToPocoJobs.SendEvent_TestHub));

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage);
            CollectionAssert.Contains(logs, $"PocoValues(foo,data)");

            var categories = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.Category);
            CollectionAssert.Contains(categories, "Microsoft.Azure.WebJobs.EventHubs.Listeners.EventHubListener.EventProcessor");
        }

        [Test]
        public async Task EventHub_StringBinding()
        {
            var (jobHost, host) = BuildHost<EventHubTestBindToStringJobs>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestBindToStringJobs.SendEvent_TestHub), new { input = "data" });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);

                var logs = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.FormattedMessage);
                CollectionAssert.Contains(logs, $"Input(data)");

                var categories = host.GetTestLoggerProvider().GetAllLogMessages().Select(p => p.Category);
                CollectionAssert.Contains(categories, "Microsoft.Azure.WebJobs.EventHubs.Listeners.EventHubListener.EventProcessor");
            }
        }

        [Test]
        public async Task EventHub_SingleDispatch()
        {
            var (jobHost, host) = BuildHost<EventHubTestSingleDispatchJobs>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestSingleDispatchJobs.SendEvent_TestHub), new { input = "data" });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            AssertSingleDispatchLogs(host);
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

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_SingleDispatch_BinaryData()
        {
            var (jobHost, host) = BuildHost<EventHubTestSingleDispatchJobsBinaryData>();
            using (jobHost)
            {
                await jobHost.CallAsync(nameof(EventHubTestSingleDispatchJobsBinaryData.SendEvent_TestHub), new { input = "data" });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
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

                bool result = _eventWait.WaitOne(Timeout);
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
                        {"TestConnection:clientId", EventHubsTestEnvironment.Instance.ClientId},
                        {"TestConnection:clientSecret", EventHubsTestEnvironment.Instance.ClientSecret},
                        {"TestConnection:tenantId", EventHubsTestEnvironment.Instance.TenantId},
                        {"AzureWebJobsStorage:serviceUri", GetServiceUri()},
                        {"AzureWebJobsStorage:clientId", EventHubsTestEnvironment.Instance.ClientId},
                        {"AzureWebJobsStorage:clientSecret", EventHubsTestEnvironment.Instance.ClientSecret},
                        {"AzureWebJobsStorage:tenantId", EventHubsTestEnvironment.Instance.TenantId},
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

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_MultipleDispatch()
        {
            var (jobHost, host) = BuildHost<EventHubTestMultipleDispatchJobs>();
            using (jobHost)
            {
                int numEvents = 5;
                await jobHost.CallAsync(nameof(EventHubTestMultipleDispatchJobs.SendEvents_TestHub), new { numEvents = numEvents, input = "data" });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            AssertMultipleDispatchLogs(host);
        }

        [Test]
        public async Task EventHub_MultipleDispatch_BinaryData()
        {
            var (jobHost, host) = BuildHost<EventHubTestMultipleDispatchJobsBinaryData>();
            using (jobHost)
            {
                int numEvents = 5;
                await jobHost.CallAsync(nameof(EventHubTestMultipleDispatchJobsBinaryData.SendEvents_TestHub), new { numEvents = numEvents, input = "data" });

                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }

            AssertMultipleDispatchLogs(host);
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

        [Test]
        public async Task EventHub_PartitionKey()
        {
            var (jobHost, host) = BuildHost<EventHubPartitionKeyTestJobs>();
            using (jobHost)
            {
                _eventWait = new ManualResetEvent(initialState: false);
                await jobHost.CallAsync(nameof(EventHubPartitionKeyTestJobs.SendEvents_TestHub), new { input = "data" });

                bool result = _eventWait.WaitOne(Timeout);

                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_InitialOffsetFromStart()
        {
            var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
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
                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_InitialOffsetFromEnd()
        {
            // Send a message to ensure the stream is not empty as we are trying to validate that no messages are delivered in this case
            var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
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
                // We don't expect to get signalled as there should be no messages received with a FromEnd initial offset
                bool result = _eventWait.WaitOne(Timeout);
                Assert.False(result, "An event was received while none were expected.");

                // send a new event which should be received
                await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
                result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        [Test]
        public async Task EventHub_InitialOffsetFromEnqueuedTime()
        {
            var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, _eventHubScope.EventHubName);
            for (int i = 0; i < 3; i++)
            {
                // send one at a time so they will have slightly different enqueued times
                await producer.SendAsync(new EventData[] { new EventData(new BinaryData("data")) });
                await Task.Delay(1000);
            }
            var consumer = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                _eventHubScope.EventHubName);

            var events = consumer.ReadEventsAsync();
            _initialOffsetEnqueuedTimeUTC = DateTime.UtcNow;
            await foreach (PartitionEvent evt in events)
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
                            // for some reason, this doesn't seem to work reliably if including milliseconds in the format
                            var dto = DateTimeOffset.Parse(_initialOffsetEnqueuedTimeUTC.ToString("yyyy-MM-ddTHH:mm:ssZ"));
                            options.InitialOffsetOptions.EnqueuedTimeUtc = dto;
                        });
                    });
                    ConfigureTestEventHub(builder);
                });
            using (jobHost)
            {
                bool result = _eventWait.WaitOne(Timeout);
                Assert.True(result);
            }
        }

        private static void AssertAzureSdkLogs(IEnumerable<LogMessage> logMessages)
        {
            Assert.True(logMessages.Any(x => x.Category.StartsWith("Azure.")));
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
                PartitionContext partitionContext)
            {
                Assert.True((DateTime.Now - enqueuedTimeUtc).TotalSeconds < 30);

                Assert.AreEqual("value1", properties["TestProp1"]);
                Assert.AreEqual("value2", properties["TestProp2"]);

                Assert.NotNull(partitionContext.PartitionId);
                Assert.NotNull(partitionContext.ReadLastEnqueuedEventProperties());

                _eventWait.Set();
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
                _eventWait.Set();
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

                _eventWait.Set();
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
                Assert.True((DateTime.Now - enqueuedTimeUtc).TotalSeconds < 30);
                _eventWait.Set();
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
                _eventWait.Set();
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
                _eventWait.Set();
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
                IDictionary<string, object>[] systemPropertiesArray)
            {
                Assert.AreEqual(events.Length, partitionKeyArray.Length);
                Assert.AreEqual(events.Length, enqueuedTimeUtcArray.Length);
                Assert.AreEqual(events.Length, propertiesArray.Length);
                Assert.AreEqual(events.Length, systemPropertiesArray.Length);

                for (int i = 0; i < events.Length; i++)
                {
                    Assert.AreEqual(s_processedEventCount++, propertiesArray[i]["TestIndex"]);
                }

                if (s_processedEventCount == s_eventCount)
                {
                    _results.AddRange(events);
                    _eventWait.Set();
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
                    _eventWait.Set();
                }
            }
        }

        public class EventHubPartitionKeyTestJobs
        {
            // send more events per partition than the EventHubsOptions.MaxBatchSize
            // so that we get coverage for receiving events from the same partition in multiple chunks
            private const int EventsPerPartition = 15;
            private const int PartitionCount = 5;
            private const int TotalEventsCount = EventsPerPartition * PartitionCount;

            public static async Task SendEvents_TestHub(
                string input,
                [EventHub(TestHubName, Connection = TestHubName)] EventHubProducerClient client)
            {
                List<EventData> list = new List<EventData>();
                EventData evt = new EventData(Encoding.UTF8.GetBytes(input));

                // Send event without PK
                await client.SendAsync(new[] { evt });

                // Send event with different PKs
                for (int i = 0; i < PartitionCount; i++)
                {
                    evt = new EventData(Encoding.UTF8.GetBytes(input));
                    await client.SendAsync(Enumerable.Repeat(evt, EventsPerPartition), new SendEventOptions() { PartitionKey = "test_pk" + i });
                }
            }

            public static void ProcessMultiplePartitionEvents([EventHubTrigger(TestHubName, Connection = TestHubName)] EventData[] events)
            {
                foreach (EventData eventData in events)
                {
                    string message = Encoding.UTF8.GetString(eventData.Body.ToArray());

                    _results.Add(eventData.PartitionKey);
                    _results.Sort();

                    // count is 1 more because we sent an event without PK
                    if (_results.Count == TotalEventsCount + 1 && _results[TotalEventsCount] == "test_pk4")
                    {
                        _eventWait.Set();
                    }
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
                Assert.True((DateTime.Now - enqueuedTimeUtc).TotalSeconds < 30);

                Assert.AreEqual("value1", properties["TestProp1"]);
                Assert.AreEqual("value2", properties["TestProp2"]);

                _eventWait.Set();
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
                _eventWait.Set();
            }
        }

        public class EventHubTestInitialOffsetFromEnqueuedTimeJobs
        {
            private const int ExpectedEventsCount = 2;

            public static void ProcessMultipleEvents([EventHubTrigger(TestHubName, Connection = TestHubName)] EventData[] events)
            {
                Assert.LessOrEqual(events.Length, ExpectedEventsCount);
                foreach (EventData eventData in events)
                {
                    string message = Encoding.UTF8.GetString(eventData.Body.ToArray());

                    _results.Add(eventData.EnqueuedTime.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));

                    if (_results.Count == ExpectedEventsCount)
                    {
                        foreach (var result in _results)
                        {
                            Assert.GreaterOrEqual(DateTimeOffset.Parse(result), _initialOffsetEnqueuedTimeUTC);
                        }
                        _eventWait.Set();
                    }
                }
            }
        }
    }
}