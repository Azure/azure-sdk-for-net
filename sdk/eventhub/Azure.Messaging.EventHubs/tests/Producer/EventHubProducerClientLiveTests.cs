// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Amqp;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventHubProducerClientClient" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class EventHubProducerClientLiveTests
    {
        /// <summary>The default retry policy to use when performing operations.</summary>
        private readonly EventHubsRetryPolicy DefaultRetryPolicy = new EventHubsRetryOptions().ToRetryPolicy();

        /// <summary>The default set of options for reading, allowing a small wait time.</summary>
        private readonly ReadEventOptions DefaultReadOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(50) };

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerWithNoOptionsCanSend(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString, new EventHubConnectionOptions { TransportType = transportType }))
                await using (var producer = new EventHubProducerClient(connection))
                {
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerWithOptionsCanSend(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var producerOptions = new EventHubProducerClientOptions
                {
                    RetryOptions = new EventHubsRetryOptions { MaximumRetries = 5 },
                    ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType }
                };

                await using (var producer = new EventHubProducerClient(connectionString, producerOptions))
                {
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerWithCustomBufferSizesCanSend(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var producerOptions = new EventHubProducerClientOptions
                {
                    ConnectionOptions = new EventHubConnectionOptions
                    {
                       ReceiveBufferSizeInBytes = 4096,
                       SendBufferSizeInBytes = 12288
                    }
                };

                await using (var producer = new EventHubProducerClient(connectionString, producerOptions))
                {
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerWithIdentifierCanSend()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString, new EventHubProducerClientOptions { Identifier = "CustomIdentif13r!" }))
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendToASpecificPartition()
        {
            await using EventHubScope scope = await EventHubScope.CreateAsync(4);
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
            var sendOptions = new SendEventOptions { PartitionId = partition };
            var sendCount = 5;
            var eventsPerSend = 100;

            for (var sendIndex = 0; sendIndex < sendCount; ++sendIndex)
            {
                var events = Enumerable
                    .Range(0, eventsPerSend)
                    .Select(index => new EventData($"Batch-{ sendIndex }-Event-{ index }"));

                await producer.SendAsync(events, sendOptions, cancellationSource.Token);
            }

            // Validate that events were sent to the correct partition..

            var expectedEvents = (sendCount * eventsPerSend);
            var readEvents = 0;

           await using var consumer = new EventHubConsumerClient(
               EventHubConsumerClient.DefaultConsumerGroupName,
               EventHubsTestEnvironment.Instance.EventHubsConnectionString,
               scope.EventHubName);

            try
            {
                await foreach (var receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                {
                    Assert.That(receivedEvent.Data, Is.Not.Null, "No read should have an empty event.");
                    Assert.That(receivedEvent.Partition.PartitionId, Is.EqualTo(partition), $"The event with body [{ receivedEvent.Data.EventBody }] was not read from the correct partition.");

                    ++readEvents;

                    if (readEvents >= expectedEvents)
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(readEvents, Is.EqualTo(expectedEvents), "The expected number of events should have been read.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatchToASpecificPartition()
        {
            await using EventHubScope scope = await EventHubScope.CreateAsync(4);
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
            var batchOptions = new CreateBatchOptions { PartitionId = partition };
            var sendCount = 5;
            var eventsPerSend = 100;

            for (var sendIndex = 0; sendIndex < sendCount; ++sendIndex)
            {
                var batch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);

                var events = Enumerable
                    .Range(0, eventsPerSend)
                    .Select(index => new EventData($"Batch-{ sendIndex }-Event-{ index }"));

                foreach (var eventData in events)
                {
                    Assert.That(batch.TryAdd(eventData), Is.True, $"The event with body [{ eventData.EventBody }] could not be added to the batch.");
                }

                await producer.SendAsync(batch, cancellationSource.Token);
            }

            // Validate that events were sent to the correct partition..

            var expectedEvents = (sendCount * eventsPerSend);
            var readEvents = 0;

            await using var consumer = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                scope.EventHubName);

            try
            {
                await foreach (var receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                {
                    Assert.That(receivedEvent.Data, Is.Not.Null, "No read should have an empty event.");
                    Assert.That(receivedEvent.Partition.PartitionId, Is.EqualTo(partition), $"The event with body [{ receivedEvent.Data.EventBody }] was not read from the correct partition.");

                    ++readEvents;

                    if (readEvents >= expectedEvents)
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(readEvents, Is.EqualTo(expectedEvents), "The expected number of events should have been read.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendEventsWithCustomProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                EventData[] events = new[]
                {
                    new EventData(new byte[] { 0x22, 0x33 }),
                    new EventData(Encoding.UTF8.GetBytes("This is a really long string of stuff that I wanted to type because I like to")),
                    new EventData(Encoding.UTF8.GetBytes("I wanted to type because I like to")),
                    new EventData(Encoding.UTF8.GetBytes("If you are reading this, you really like test cases"))
                };

                for (var index = 0; index < events.Length; ++index)
                {
                    events[index].Properties[index.ToString()] = "some value";
                    events[index].Properties["Type"] = $"com.microsoft.test.Type{ index }";
                }

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendEventsUsingAPartitionHashKey()
        {
            await using EventHubScope scope = await EventHubScope.CreateAsync(4);
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var sendOptions = new SendEventOptions { PartitionKey = $"pkey={Guid.NewGuid() };" };
            var sendCount = 5;
            var eventsPerSend = 100;

            for (var sendIndex = 0; sendIndex < sendCount; ++sendIndex)
            {
                var events = Enumerable
                    .Range(0, eventsPerSend)
                    .Select(index => new EventData($"Batch-{ sendIndex }-Event-{ index }"));

                await producer.SendAsync(events, sendOptions, cancellationSource.Token);
            }

            // Validate that events were sent to the correct partition..

            var expectedEvents = (sendCount * eventsPerSend);
            var readEvents = 0;
            var firstReadPartition = default(string);

            await using var consumer = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                scope.EventHubName);

            try
            {
                await foreach (var receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                {
                    Assert.That(receivedEvent.Data, Is.Not.Null, "No read should have an empty event.");

                    if (firstReadPartition == null)
                    {
                        firstReadPartition = receivedEvent.Partition.PartitionId;
                    }

                    Assert.That(receivedEvent.Partition.PartitionId, Is.EqualTo(firstReadPartition), $"The event with body [{ receivedEvent.Data.EventBody }] was not read from the correct partition.");
                    ++readEvents;

                    if (readEvents >= expectedEvents)
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(readEvents, Is.EqualTo(expectedEvents), "The expected number of events should have been read.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatchUsingAPartitionHashKey()
        {
            await using EventHubScope scope = await EventHubScope.CreateAsync(4);
            await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.EventHubsConnectionString, scope.EventHubName);

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

            var batchOptions = new CreateBatchOptions { PartitionKey = $"pkey={Guid.NewGuid() };" };
            var sendCount = 5;
            var eventsPerSend = 100;

            for (var sendIndex = 0; sendIndex < sendCount; ++sendIndex)
            {
                var batch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);

                var events = Enumerable
                    .Range(0, eventsPerSend)
                    .Select(index => new EventData($"Batch-{ sendIndex }-Event-{ index }"));

                foreach (var eventData in events)
                {
                    Assert.That(batch.TryAdd(eventData), Is.True, $"The event with body [{ eventData.EventBody }] could not be added to the batch.");
                }

                await producer.SendAsync(batch, cancellationSource.Token);
            }

            // Validate that events were sent to the correct partition..

            var expectedEvents = (sendCount * eventsPerSend);
            var readEvents = 0;
            var firstReadPartition = default(string);

            await using var consumer = new EventHubConsumerClient(
                EventHubConsumerClient.DefaultConsumerGroupName,
                EventHubsTestEnvironment.Instance.EventHubsConnectionString,
                scope.EventHubName);

            try
            {
                await foreach (var receivedEvent in consumer.ReadEventsAsync(cancellationSource.Token))
                {
                    Assert.That(receivedEvent.Data, Is.Not.Null, "No read should have an empty event.");

                    if (firstReadPartition == null)
                    {
                        firstReadPartition = receivedEvent.Partition.PartitionId;
                    }

                    Assert.That(receivedEvent.Partition.PartitionId, Is.EqualTo(firstReadPartition), $"The event with body [{ receivedEvent.Data.EventBody }] was not read from the correct partition.");
                    ++readEvents;

                    if (readEvents >= expectedEvents)
                    {
                        break;
                    }
                }
            }
            catch (OperationCanceledException)
            {
            }

            Assert.That(cancellationSource.IsCancellationRequested, Is.False, "Cancellation should not have been signaled.");
            Assert.That(readEvents, Is.EqualTo(expectedEvents), "The expected number of events should have been read.");
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendSingleLargeEventInASet()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString, new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                {
                    // Actual limit is 1046520 for a single event.
                    EventData[] eventSet = new[] { new EventData(new byte[100000]) };

                    Assert.That(async () => await producer.SendAsync(eventSet), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendASetOfEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    EventData[] events = new[]
                    {
                        new EventData(Encoding.UTF8.GetBytes("This is a message")),
                        new EventData(Encoding.UTF8.GetBytes("This is another message")),
                        new EventData(Encoding.UTF8.GetBytes("So many messages"))
                    };

                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendZeroLengthSet()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    EventData[] events = new[]
                    {
                        new EventData(new BinaryData(Array.Empty<byte>())),
                        new EventData(new BinaryData(Array.Empty<byte>())),
                        new EventData(new BinaryData(Array.Empty<byte>()))
                    };

                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendLargeSet()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString, new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                {
                    // Actual limit is 1046520 for a single event.
                    EventData[] events = new[]
                    {
                        new EventData(new byte[100000 / 3]),
                        new EventData(new byte[100000 / 3]),
                        new EventData(new byte[100000 / 3])
                    };

                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatch()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync();

                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is a message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is another message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("So many messages")));

                    Assert.That(batch.Count, Is.EqualTo(3), "The batch should contain all 3 events.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatchUsingAnIdentityCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var credential = EventHubsTestEnvironment.Instance.Credential;

                await using (var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync();

                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is a message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is another message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("So many messages")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Event more messages")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Will it ever stop?")));

                    Assert.That(batch.Count, Is.EqualTo(5), "The batch should contain all 5 events.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatchUsingTheSharedKeyCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var credential = new AzureNamedKeyCredential(EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);

                await using (var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync();

                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is a message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is another message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("So many messages")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Event more messages")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Will it ever stop?")));

                    Assert.That(batch.Count, Is.EqualTo(5), "The batch should contain all 5 events.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatchUsingTheSasCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var options = new EventHubProducerClientOptions();
                var resource = EventHubConnection.BuildConnectionSignatureAuthorizationResource(options.ConnectionOptions.TransportType, EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName);
                var signature = new SharedAccessSignature(resource, EventHubsTestEnvironment.Instance.SharedAccessKeyName, EventHubsTestEnvironment.Instance.SharedAccessKey);
                var credential = new AzureSasCredential(signature.Value);

                await using (var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.FullyQualifiedNamespace, scope.EventHubName, credential, options))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync();

                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is a message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is another message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("So many messages")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Event more messages")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Will it ever stop?")));

                    Assert.That(batch.Count, Is.EqualTo(5), "The batch should contain all 5 events.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendZeroLengthEventBatch()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync();
                    batch.TryAdd(new EventData(new BinaryData(Array.Empty<byte>())));

                    Assert.That(batch.Count, Is.EqualTo(1), "The batch should contain a single event.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendLargeEventBatch()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString, new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync();

                    // Actual limit is 1046520 for a single event.

                    batch.TryAdd(new EventData(new byte[100000 / 3]));
                    batch.TryAdd(new EventData(new byte[100000 / 3]));
                    batch.TryAdd(new EventData(new byte[100000 / 3]));

                    Assert.That(batch.Count, Is.EqualTo(3), "The batch should contain all 3 events.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotSendSetLargerThanMaximumSize()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    // Actual limit is 1046520 for a single event.

                    EventData[] events = new[]
                    {
                        new EventData(new byte[1500000 / 3]),
                        new EventData(new byte[1500000 / 3]),
                        new EventData(new byte[1500000 / 3])
                    };

                    Assert.That(async () => await producer.SendAsync(events), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.MessageSizeExceeded));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendWhenPartitionIsNull()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("Will it work")) };
                    Assert.That(async () => await producer.SendAsync(events, new SendEventOptions { PartitionId = null }), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotSendWhenClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("Dummy event")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);

                    await producer.CloseAsync();
                    Assert.That(async () => await producer.SendAsync(events), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotSendWhenSharedConnectionIsClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                await using (var producer = new EventHubProducerClient(connection))
                {
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("Dummy event")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);

                    await connection.CloseAsync();
                    Assert.That(async () => await producer.SendAsync(events), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ProducerCannotSendToInvalidPartition(string invalidPartition)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("Lorem Ipsum")) };

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        Assert.That(async () => await producer.SendAsync(events, new SendEventOptions { PartitionId = invalidPartition }), Throws.TypeOf<ArgumentOutOfRangeException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task SendSetUpdatesPartitionProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("I should update stuff")) };

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        // Sending events beforehand so the partition has some information.

                        await producer.SendAsync(events, new SendEventOptions { PartitionId = partition });

                        PartitionProperties oldPartitionProperties = await producer.GetPartitionPropertiesAsync(partition);

                        Assert.That(oldPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        await producer.SendAsync(events);

                        PartitionProperties newPartitionProperties = await producer.GetPartitionPropertiesAsync(partition);

                        Assert.That(newPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        // The following properties should not have been altered.

                        Assert.That(newPartitionProperties.Id, Is.EqualTo(oldPartitionProperties.Id));
                        Assert.That(newPartitionProperties.EventHubName, Is.EqualTo(oldPartitionProperties.EventHubName));
                        Assert.That(newPartitionProperties.BeginningSequenceNumber, Is.EqualTo(oldPartitionProperties.BeginningSequenceNumber));

                        // The following properties should have been updated.

                        Assert.That(newPartitionProperties.LastEnqueuedSequenceNumber, Is.GreaterThan(oldPartitionProperties.LastEnqueuedSequenceNumber));
                        Assert.That(newPartitionProperties.LastEnqueuedOffset, Is.GreaterThan(oldPartitionProperties.LastEnqueuedOffset));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task SendBatchUpdatesPartitionProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        // Sending events beforehand so the partition has some information.

                        using var firstBatch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partition });
                        firstBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("I should update stuff")));

                        await producer.SendAsync(firstBatch);

                        PartitionProperties oldPartitionProperties = await producer.GetPartitionPropertiesAsync(partition);
                        Assert.That(oldPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        // Send another to force the updates.

                        using var secondBatch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partition });
                        secondBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes("I should update stuff")));

                        await producer.SendAsync(secondBatch);

                        PartitionProperties newPartitionProperties = await producer.GetPartitionPropertiesAsync(partition);
                        Assert.That(newPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        // The following properties should not have been altered.

                        Assert.That(newPartitionProperties.Id, Is.EqualTo(oldPartitionProperties.Id));
                        Assert.That(newPartitionProperties.EventHubName, Is.EqualTo(oldPartitionProperties.EventHubName));
                        Assert.That(newPartitionProperties.BeginningSequenceNumber, Is.EqualTo(oldPartitionProperties.BeginningSequenceNumber));

                        // The following properties should have been updated.

                        Assert.That(newPartitionProperties.LastEnqueuedSequenceNumber, Is.GreaterThan(oldPartitionProperties.LastEnqueuedSequenceNumber));
                        Assert.That(newPartitionProperties.LastEnqueuedOffset, Is.GreaterThan(oldPartitionProperties.LastEnqueuedOffset));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task SendDoesNotUpdatePartitionPropertiesWhenSendingToDifferentPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);
                    EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("I should not update stuff")) };

                    await using (var producer0 = new EventHubProducerClient(connection))
                    await using (var producer1 = new EventHubProducerClient(connection))
                    {
                        // Sending events beforehand so the partition has some information.

                        await producer0.SendAsync(events, new SendEventOptions { PartitionId = partitionIds[0] });

                        PartitionProperties oldPartitionProperties = await producer0.GetPartitionPropertiesAsync(partitionIds[0]);

                        Assert.That(oldPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        await producer1.SendAsync(events, new SendEventOptions { PartitionId = partitionIds[1] });

                        PartitionProperties newPartitionProperties = await producer1.GetPartitionPropertiesAsync(partitionIds[0]);

                        Assert.That(newPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        // All properties should remain the same.

                        Assert.That(newPartitionProperties.Id, Is.EqualTo(oldPartitionProperties.Id));
                        Assert.That(newPartitionProperties.EventHubName, Is.EqualTo(oldPartitionProperties.EventHubName));
                        Assert.That(newPartitionProperties.BeginningSequenceNumber, Is.EqualTo(oldPartitionProperties.BeginningSequenceNumber));
                        Assert.That(newPartitionProperties.LastEnqueuedSequenceNumber, Is.EqualTo(oldPartitionProperties.LastEnqueuedSequenceNumber));
                        Assert.That(newPartitionProperties.LastEnqueuedOffset, Is.EqualTo(oldPartitionProperties.LastEnqueuedOffset));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public async Task ProducerDoesNotSendToSpecificPartitionWhenPartitionIdIsNotSpecified(string partitionId)
        {
            var partitions = 10;
            var batchOptions = new CreateBatchOptions { PartitionId = partitionId };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        var batches = 30;
                        var eventsPerBatch = 5;
                        var partitionIds = await producer.GetPartitionIdsAsync();
                        var partitionsCount = 0;

                        // Send the batches of events.

                        for (var index = 0; index < batches; index++)
                        {
                            using var batch = await producer.CreateBatchAsync(batchOptions);

                            for (var eventIndex = 0; eventIndex < eventsPerBatch; ++eventIndex)
                            {
                                batch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event { eventIndex } in the batch")));
                            }

                            await producer.SendAsync(batch);
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                        foreach (string partition in partitionIds)
                        {
                            var receivedEvents = new List<EventData>();
                            var consecutiveEmpties = 0;
                            var maximumConsecutiveEmpties = 10;

                            await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Earliest, DefaultReadOptions, cancellationSource.Token))
                            {
                                if (partitionEvent.Data != null)
                                {
                                    receivedEvents.Add(partitionEvent.Data);
                                    consecutiveEmpties = 0;
                                }
                                else if (++consecutiveEmpties >= maximumConsecutiveEmpties)
                                {
                                    break;
                                }
                            }

                            if (receivedEvents.Count > 0)
                            {
                                partitionsCount++;
                            }
                        }

                        Assert.That(partitionsCount, Is.GreaterThan(1));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerSendsEventsInTheSameSetToTheSamePartition()
        {
            var partitions = 10;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                await using (var producer = new EventHubProducerClient(connection))
                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                {
                    var eventBatch = Enumerable
                        .Range(0, 30)
                        .Select(index => new EventData(Encoding.UTF8.GetBytes("I'm getting used to this amount of messages")))
                        .ToList();

                    var partitionIds = await producer.GetPartitionIdsAsync();
                    var partitionsCount = 0;
                    var receivedEventsCount = 0;

                    // Send the batch of events.

                    await producer.SendAsync(eventBatch);

                    // Read the events.

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                    foreach (string partition in partitionIds)
                    {
                        var receivedEvents = new List<EventData>();
                        var consecutiveEmpties = 0;
                        var maximumConsecutiveEmpties = 10;

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Earliest, DefaultReadOptions, cancellationSource.Token))
                        {
                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= maximumConsecutiveEmpties)
                            {
                                break;
                            }
                        }

                        if (receivedEvents.Count > 0)
                        {
                            partitionsCount++;
                            receivedEventsCount += receivedEvents.Count;
                        }
                    }

                    Assert.That(partitionsCount, Is.EqualTo(1));
                    Assert.That(receivedEventsCount, Is.EqualTo(eventBatch.Count));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerSendsEventsWithTheSamePartitionHashKeyToTheSamePartition()
        {
            var partitions = 10;
            var partitionKey = "some123key-!d";

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                await using (var producer = new EventHubProducerClient(connection))
                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                {
                    var batches = 5;
                    var partitionIds = await producer.GetPartitionIdsAsync();
                    var partitionsCount = 0;
                    var receivedEventsCount = 0;

                    // Send the batches of events.

                    var batchOptions = new SendEventOptions { PartitionKey = partitionKey };

                    for (var index = 0; index < batches; index++)
                    {
                        await producer.SendAsync(new[] { new EventData(Encoding.UTF8.GetBytes($"Just a few messages ({ index })")) }, batchOptions);
                    }

                    // Read the events.

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                    foreach (string partition in partitionIds)
                    {
                        var receivedEvents = new List<EventData>();
                        var consecutiveEmpties = 0;
                        var maximumConsecutiveEmpties = 10;

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Earliest, DefaultReadOptions, cancellationSource.Token))
                        {
                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= maximumConsecutiveEmpties)
                            {
                                break;
                            }
                        }

                        if (receivedEvents.Count > 0)
                        {
                            partitionsCount++;
                            receivedEventsCount += receivedEvents.Count;
                        }
                    }

                    Assert.That(partitionsCount, Is.EqualTo(1));
                    Assert.That(receivedEventsCount, Is.EqualTo(batches));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotSendWhenProxyIsInvalid()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var producerOptions = new EventHubProducerClientOptions
                {
                    RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(2) },

                    ConnectionOptions = new EventHubConnectionOptions
                    {
                        Proxy = new WebProxy("http://1.2.3.4:9999"),
                        TransportType = EventHubsTransportType.AmqpWebSockets
                    }
                };

                await using (var invalidProxyProducer = new EventHubProducerClient(connectionString, producerOptions))
                {
                    Assert.That(async () => await invalidProxyProducer.SendAsync(new[] { new EventData(new byte[1]) }), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendEventsWithAFullyPopulatedAmqpMessage()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromData(new ReadOnlyMemory<byte>[] { new byte[] { 0x11, 0x22, 0x33 } }));
                var eventData = new EventData(message);

                // Header

                message.Header.DeliveryCount = 123;
                message.Header.Durable = true;
                message.Header.FirstAcquirer = true;
                message.Header.Priority = 1;
                message.Header.TimeToLive = TimeSpan.FromDays(2);

                // Properties

                message.Properties.AbsoluteExpiryTime = new DateTimeOffset(2015, 10, 27, 0, 0 ,0 ,0, TimeSpan.Zero);
                message.Properties.ContentEncoding = "utf-8";
                message.Properties.ContentType = "test/unit";
                message.Properties.CorrelationId = new AmqpMessageId("OU812");
                message.Properties.CreationTime = new DateTimeOffset(2012, 3, 4, 8, 0, 0, 0, TimeSpan.Zero);
                message.Properties.GroupId = "Red Squad";
                message.Properties.GroupSequence = 76;
                message.Properties.MessageId = new AmqpMessageId("Bob");
                message.Properties.ReplyTo = new AmqpAddress("1407 Graymalkin Lane");
                message.Properties.ReplyToGroupId = "Home";
                message.Properties.Subject = "You'll never believe this weight loss secret!";
                message.Properties.To = new AmqpAddress("http://some.server.com");
                message.Properties.UserId = new byte[] { 0x11, 0x22 };

                // Application Properties

                message.ApplicationProperties.Add("One", TimeSpan.FromMinutes(5));
                message.ApplicationProperties.Add("Two", 2);

                // Delivery Annotations

                message.DeliveryAnnotations.Add("Three", 3);
                message.DeliveryAnnotations.Add("Four", new DateTimeOffset(2015, 10, 27, 0, 0, 0, TimeSpan.Zero));

                // Message Annotations

                message.MessageAnnotations.Add("Five", 5);
                message.MessageAnnotations.Add("Six", 6.0f);

                // Footer

                message.Footer.Add("Seven", 7);
                message.Footer.Add("Eight", "8");

                // Attempt to send and validate the operation was not rejected.

                await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName));
                Assert.That(async () => await producer.SendAsync(new[] { eventData }), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendEventsWithValueBodies()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var value = new Dictionary<string, string> { { "key", "value" } };
                var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromValue(value));
                var eventData = new EventData(message);

                // Attempt to send and validate the operation was not rejected.

                await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName));
                Assert.That(async () => await producer.SendAsync(new[] { eventData }), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendEventsWithSequenceBodies()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var sequence = new[] { new List<object> { "1", 2 } };
                var message = new AmqpAnnotatedMessage(AmqpMessageBody.FromSequence(sequence));
                var eventData = new EventData(message);

                // Attempt to send and validate the operation was not rejected.

                await using var producer = new EventHubProducerClient(EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName));
                Assert.That(async () => await producer.SendAsync(new[] { eventData }), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerCanRetrieveEventHubProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 4;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var connectionString = EventHubsTestEnvironment.Instance.EventHubsConnectionString;
                var producerOptions = new EventHubProducerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                await using (var producer = new EventHubProducerClient(connectionString, scope.EventHubName, producerOptions))
                {
                    EventHubProperties properties = await producer.GetEventHubPropertiesAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.Name, Is.EqualTo(scope.EventHubName), "The property Event Hub name should match the scope.");
                    Assert.That(properties.PartitionIds.Length, Is.EqualTo(partitionCount), "The properties should have the requested number of partitions.");
                    Assert.That(properties.CreatedOn, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(60)), "The Event Hub should have been created just about now.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerCanRetrievePartitionProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 4;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var options = new EventHubConnectionOptions();
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var producerOptions = new EventHubProducerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                await using (var producer = new EventHubProducerClient(connectionString, scope.EventHubName, producerOptions))
                {
                    var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                    var properties = await producer.GetEventHubPropertiesAsync();
                    var partition = properties.PartitionIds.First();
                    var partitionProperties = await producer.GetPartitionPropertiesAsync(partition, cancellation.Token);

                    Assert.That(partitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");
                    Assert.That(partitionProperties.Id, Is.EqualTo(partition), "The partition identifier should match.");
                    Assert.That(partitionProperties.EventHubName, Is.EqualTo(scope.EventHubName).Using((IEqualityComparer<string>)StringComparer.InvariantCultureIgnoreCase), "The Event Hub path should match.");
                    Assert.That(partitionProperties.BeginningSequenceNumber, Is.Not.EqualTo(default(long)), "The beginning sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedSequenceNumber, Is.Not.EqualTo(default(long)), "The last sequence number should have been populated.");
                    Assert.That(partitionProperties.LastEnqueuedOffset, Is.Not.EqualTo(default(long)), "The last offset should have been populated.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConnectionTransportPartitionIdsMatchPartitionProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    EventHubProperties properties = await producer.GetEventHubPropertiesAsync();
                    var partitions = await producer.GetPartitionIdsAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.PartitionIds, Is.Not.Null, "A set of partition identifiers for the properties should have been returned.");
                    Assert.That(partitions, Is.Not.Null, "A set of partition identifiers should have been returned.");
                    Assert.That(partitions, Is.EquivalentTo(properties.PartitionIds), "The partition identifiers returned directly should match those returned with properties.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotRetrieveMetadataWhenClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    var partition = (await producer.GetPartitionIdsAsync()).First();

                    Assert.That(async () => await producer.GetEventHubPropertiesAsync(), Throws.Nothing);
                    Assert.That(async () => await producer.GetPartitionPropertiesAsync(partition), Throws.Nothing);

                    await producer.CloseAsync();
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    Assert.That(async () => await producer.GetPartitionIdsAsync(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(async () => await producer.GetEventHubPropertiesAsync(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(async () => await producer.GetPartitionPropertiesAsync(partition), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ProducerCannotRetrievePartitionPropertiesWhenPartitionIdIsInvalid(string invalidPartition)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    Assert.That(async () => await producer.GetPartitionPropertiesAsync(invalidPartition), Throws.TypeOf<ArgumentOutOfRangeException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotRetrieveMetadataWhenProxyIsInvalid()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                var invalidProxyOptions = new EventHubProducerClientOptions
                {
                    RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(2) },

                    ConnectionOptions = new EventHubConnectionOptions
                    {
                        Proxy = new WebProxy("http://1.2.3.4:9999"),
                        TransportType = EventHubsTransportType.AmqpWebSockets
                    }
                };

                await using (var producer = new EventHubProducerClient(connectionString))
                await using (var invalidProxyProducer = new EventHubProducerClient(connectionString, invalidProxyOptions))
                {
                    var partition = (await producer.GetPartitionIdsAsync()).First();

                    Assert.That(async () => await invalidProxyProducer.GetPartitionIdsAsync(), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyProducer.GetEventHubPropertiesAsync(), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyProducer.GetPartitionPropertiesAsync(partition), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                }
            }
        }
    }
}
