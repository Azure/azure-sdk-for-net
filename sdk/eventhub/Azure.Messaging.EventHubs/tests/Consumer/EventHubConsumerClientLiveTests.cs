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
using Azure.Identity;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventHubConsumerClient" />
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
    public class EventHubConsumerClientLiveTests
    {
        /// <summary>The default retry policy to use when performing operations.</summary>
        private readonly EventHubsRetryPolicy DefaultRetryPolicy = new EventHubsRetryOptions().ToRetryPolicy();

        /// <summary>The default set of options for reading, allowing a small wait time.</summary>
        private readonly ReadEventOptions DefaultReadOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(250) };

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerWithNoOptionsCanRead(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString, new EventHubConnectionOptions { TransportType = transportType }))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerWithOptionsCanRead(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubConsumerClientOptions { RetryOptions = new EventHubsRetryOptions { MaximumRetries = 7 } };

                await using (var connection = new EventHubConnection(connectionString, new EventHubConnectionOptions { TransportType = transportType }))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, options))
                    {
                        Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadSingleEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("Lonely"))
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    {
                        var wereEventsPublished = false;

                        async Task<bool> PublishEvents()
                        {
                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendEventOptions { PartitionId = partition }).ConfigureAwait(false);
                                wereEventsPublished = true;
                            }

                            return false;
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                        var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Latest, expectedEventCount: eventBatch.Length, iterationCallback: PublishEvents, cancellationToken: cancellationSource.Token);

                        // Validate the events; because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents.Select(item => item.Data))
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(eventBatch[index]), Is.True, $"The received event at index: { index } did not match the sent batch.");
                            ++index;
                        }

                        Assert.That(index, Is.EqualTo(eventBatch.Length), "The number of received events did not match the batch size.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadSingleZeroLengthEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventBatch = new[]
                {
                    new EventData(new byte[0])
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    {
                        var wereEventsPublished = false;

                        async Task<bool> PublishEvents()
                        {
                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendEventOptions { PartitionId = partition }).ConfigureAwait(false);
                                wereEventsPublished = true;
                            }

                            return false;
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                        var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Latest, expectedEventCount: eventBatch.Length, iterationCallback: PublishEvents, cancellationToken: cancellationSource.Token);

                        // Validate the events; because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents.Select(item => item.Data))
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(eventBatch[index]), Is.True, $"The received event at index: { index } did not match the sent batch.");
                            ++index;
                        }

                        Assert.That(index, Is.EqualTo(eventBatch.Length), "The number of received events did not match the batch size.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadOneZeroLengthEventSet()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventSet = new[]
                {
                    new EventData(new byte[0]),
                    new EventData(new byte[0]),
                    new EventData(new byte[0])
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    {
                        var wereEventsPublished = false;

                        async Task<bool> PublishEvents()
                        {
                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventSet, new SendEventOptions { PartitionId = partition }).ConfigureAwait(false);
                                wereEventsPublished = true;
                            }

                            return false;
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                        var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Latest, expectedEventCount: eventSet.Length, iterationCallback: PublishEvents, cancellationToken: cancellationSource.Token);

                        // Validate the events; because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        Assert.That(receivedEvents, Is.Not.Empty, "There should have been a set of events received.");

                        foreach (EventData receivedEvent in receivedEvents.Select(item => item.Data))
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(eventSet[index]), Is.True, $"The received event at index: { index } did not match the sent batch.");
                            ++index;
                        }

                        Assert.That(index, Is.EqualTo(eventSet.Length), "The number of received events did not match the batch size.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadLargeEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                // The actual limit is 1046520 for a single event

                EventData[] eventBatch = new[]
                {
                    new EventData(new byte[100000])
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var retryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(5) };
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    {
                        var wereEventsPublished = false;
                        var readOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(2) };

                        async Task<bool> PublishEvents()
                        {
                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendEventOptions { PartitionId = partition }).ConfigureAwait(false);
                                wereEventsPublished = true;
                            }

                            return false;
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                        var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Latest, readOptions, expectedEventCount: eventBatch.Length, iterationCallback: PublishEvents, cancellationToken: cancellationSource.Token);

                        // Validate the events; because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents.Select(item => item.Data))
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(eventBatch[index]), Is.True, $"The received event at index: { index } did not match the sent batch.");
                            ++index;
                        }

                        Assert.That(index, Is.EqualTo(eventBatch.Length), "The number of received events did not match the batch size.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadEventWithCustomProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventBatch = new[]
                {
                    new EventData(new byte[] { 0x22, 0x33 }),
                    new EventData(Encoding.UTF8.GetBytes("This is a really long string of stuff that I wanted to type because I like to")),
                    new EventData(Encoding.UTF8.GetBytes("I wanted to type because I like to")),
                    new EventData(Encoding.UTF8.GetBytes("If you are reading this, you really like test cases"))
                };

                for (var index = 0; index < eventBatch.Length; ++index)
                {
                    eventBatch[index].Properties[index.ToString()] = "some value";
                    eventBatch[index].Properties["Type"] = $"com.microsoft.test.Type{ index }";
                }

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    {
                        var wereEventsPublished = false;

                        async Task<bool> PublishEvents()
                        {
                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendEventOptions { PartitionId = partition }).ConfigureAwait(false);
                                wereEventsPublished = true;
                            }

                            return false;
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                        var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Latest, expectedEventCount: eventBatch.Length, iterationCallback: PublishEvents, cancellationToken: cancellationSource.Token);

                        // Validate the events; because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents.Select(item => item.Data))
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(eventBatch[index]), Is.True, $"The received event at index: { index } did not match the sent batch.");
                            ++index;
                        }

                        Assert.That(index, Is.EqualTo(eventBatch.Length), "The number of received events did not match the batch size.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromLatestEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var expectedEventsCount = 1;
                    var wereEventsPublished = false;

                    var stampEvent = new EventData(new byte[1]);
                    stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        // Sending some events beforehand so the partition has some information.
                        // We are not expecting to receive these.

                        for (int i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]));
                        }

                        async Task<bool> PublishStampEvent()
                        {
                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(stampEvent, new SendEventOptions { PartitionId = partition }).ConfigureAwait(false);
                                wereEventsPublished = true;
                            }

                            return false;
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                        var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Latest, expectedEventCount: expectedEventsCount, iterationCallback: PublishStampEvent, cancellationToken: cancellationSource.Token);

                        // Validate the events.

                        Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                        Assert.That(receivedEvents.Single().Data.IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromEarliestEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var expectedEventsCount = 10;

                    await using (var producer = new EventHubProducerClient(connection))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        for (int i = 0; i < expectedEventsCount; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]), new SendEventOptions { PartitionId = partition });
                        }

                        // Read the events.

                        using var cancellationSource = new CancellationTokenSource();
                        cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                        var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Earliest, expectedEventCount: expectedEventsCount, cancellationToken: cancellationSource.Token);

                        // Validate the events.

                        Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ConsumerCanReadFromOffset(bool isInclusive)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        // Sending some events beforehand so the partition has some information.

                        for (var i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]), new SendEventOptions { PartitionId = partition });
                        }

                        // Store last enqueued offset.

                        var offset = (await producer.GetPartitionPropertiesAsync(partition)).LastEnqueuedOffset;

                        await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                        {
                            // Send a single event which is expected to go to the end of stream.

                            var stampEvent = new EventData(new byte[1]);
                            stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                            await producer.SendAsync(stampEvent);

                            // Read the events.

                            var expectedEventsCount = isInclusive ? 2 : 1;
                            var readOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(1) };

                            using var cancellationSource = new CancellationTokenSource();
                            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                            var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.FromOffset(offset, isInclusive), readOptions, expectedEventCount: expectedEventsCount, cancellationToken: cancellationSource.Token);

                            // Validate the events.

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Last().Data.IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromEnqueuedTime()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        // Sending some events beforehand so the partition has some information.

                        for (var i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]), new SendEventOptions { PartitionId = partition });
                        }

                        // Store last enqueued time.

                        DateTimeOffset enqueuedTime = (await producer.GetPartitionPropertiesAsync(partition)).LastEnqueuedTime;

                        // Send a single event which is expected to go to the end of stream.
                        // We are expecting to receive only this message.

                        var stampEvent = new EventData(new byte[1]);
                        stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                        await producer.SendAsync(stampEvent);

                        await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                        {
                            // Read the events.

                            var expectedEventsCount = 1;
                            var readOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(1) };

                            using var cancellationSource = new CancellationTokenSource();
                            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                            var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.FromEnqueuedTime(enqueuedTime), readOptions, expectedEventCount: expectedEventsCount, cancellationToken: cancellationSource.Token);

                            // Validate the events.

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Single().Data.IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ConsumerCanReadFromSequenceNumber(bool isInclusive)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        // Sending some events beforehand so the partition has some information.

                        for (var i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]));
                        }

                        // Store last enqueued sequence number.

                        var sequenceNumber = (await producer.GetPartitionPropertiesAsync(partition)).LastEnqueuedSequenceNumber;

                        await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                        {
                            // Send a single event which is expected to go to the end of stream.

                            var stampEvent = new EventData(new byte[1]);
                            stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                            await producer.SendAsync(stampEvent, new SendEventOptions { PartitionId = partition });

                            // Read the events.

                            var expectedEventsCount = isInclusive ? 2 : 1;
                            var readOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(1) };

                            using var cancellationSource = new CancellationTokenSource();
                            cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                            var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.FromSequenceNumber(sequenceNumber, isInclusive), readOptions, expectedEventCount: expectedEventsCount, cancellationToken: cancellationSource.Token);

                            // Validate the events.

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Last().Data.IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = await consumer.GetPartitionIdsAsync(cancellationSource.Token);
                    var eventsPerPartition = 10;
                    var expectedCount = (eventsPerPartition * partitions.Length);

                    // Send events to each partition.  Because reading begins at the beginning of the partition by
                    // default, these should be observed without publishing in the read loop.

                    await using (var producer = new EventHubProducerClient(connectionString))
                    {
                        foreach (var partition in partitions)
                        {
                            using var batch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                            for (var index = 0; index < eventsPerPartition; ++index)
                            {
                                batch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event: { index } for Partition: { partition }")));
                            }

                            await producer.SendAsync(batch, cancellationSource.Token);
                        }
                    }

                    // Read events from all partitions.

                    var receivedEvents = partitions.ToDictionary(partitionId => partitionId, _ => 0);
                    var receivedPartitionEvents = await ReadUntilEmptyAsync(consumer, expectedEventCount: expectedCount, cancellationToken: cancellationSource.Token);

                    foreach (var partitionEvent in receivedPartitionEvents)
                    {
                        ++receivedEvents[partitionEvent.Partition.PartitionId];
                    }

                    // Verify the results.

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The publishing and reading should have completed normally.");
                    Assert.That(receivedPartitionEvents.Count, Is.GreaterThanOrEqualTo(expectedCount), "There was an incorrect number of events received.");

                    foreach (var partition in partitions)
                    {
                        Assert.That(receivedEvents[partition], Is.EqualTo(eventsPerPartition), $"The wrong number of events was received for Partition: { partition }.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadAllPartitionsFromLatest()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                await using (var producer = new EventHubProducerClient(connectionString))
                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = await consumer.GetPartitionIdsAsync(cancellationSource.Token);
                    var eventsPerPartition = 10;
                    var expectedCount = (eventsPerPartition * partitions.Length);

                    // Define a local function to publish events, since it will be done multiple times.

                    async Task PublishEvents()
                    {
                        foreach (var partition in partitions)
                        {
                            using var batch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                            for (var index = 0; index < eventsPerPartition; ++index)
                            {
                                batch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event: { index } for Partition: { partition }")));
                            }

                            await producer.SendAsync(batch, cancellationSource.Token);
                            await Task.Delay(TimeSpan.FromSeconds(1), cancellationSource.Token);
                        }
                    }

                    // Publish events before reading, then verify that they were not read.

                    await PublishEvents();

                    // Read events from all partitions.

                    var receivedEvents = partitions.ToDictionary(partitionId => partitionId, _ => 0);
                    var receivedPartitionEvents = await ReadUntilEmptyAsync(consumer, new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(50) }, startReadingAtFirst: false, expectedEventCount: 0, cancellationToken: cancellationSource.Token);

                    foreach (var partitionEvent in receivedPartitionEvents)
                    {
                        ++receivedEvents[partitionEvent.Partition.PartitionId];
                    }

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The publishing and reading should have completed normally.");
                    Assert.That(receivedPartitionEvents.Count, Is.EqualTo(0), "No events should have been read.");

                    // Read events across partitions, starting at the latest.  To ensure that events are observed, publish during the first
                    // empty event emitted.

                    var wereEventsPublished = false;

                    async Task<bool> PublishOnFirstIteration()
                    {
                        if (!wereEventsPublished)
                        {
                            await PublishEvents().ConfigureAwait(false);
                            wereEventsPublished = true;
                        }

                        return false;
                    }

                    receivedEvents = partitions.ToDictionary(partitionId => partitionId, _ => 0);
                    receivedPartitionEvents = await ReadUntilEmptyAsync(consumer, startReadingAtFirst: false, expectedEventCount: expectedCount, iterationCallback: PublishOnFirstIteration, cancellationToken: cancellationSource.Token);

                    foreach (var partitionEvent in receivedPartitionEvents)
                    {
                        ++receivedEvents[partitionEvent.Partition.PartitionId];
                    }

                    // Verify the results; events for the partitions should now have been present.

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The publishing and reading should have completed normally.");
                    Assert.That(receivedPartitionEvents.Count, Is.GreaterThanOrEqualTo(expectedCount), "There was an incorrect number of events received.");

                    foreach (var partition in partitions)
                    {
                        Assert.That(receivedEvents[partition], Is.EqualTo(eventsPerPartition), $"The wrong number of events was received for Partition: { partition }.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitionsWhenUsingPartitionKeys()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = await consumer.GetPartitionIdsAsync(cancellationSource.Token);
                    var eventsPerPartition = 5;
                    var expectedCount = (eventsPerPartition * partitions.Length);

                    // Send events using a set of partition keys.  Routing is controlled by the service and partitions may not
                    // receive an even distribution.  Because reading begins at the beginning of the partition by default, these
                    // should be observed without publishing in the read loop.

                    await using (var producer = new EventHubProducerClient(connectionString))
                    {
                        foreach (var partition in partitions)
                        {
                            using var batch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionKey = $"Key{ partition.GetHashCode() }" }, cancellationSource.Token);

                            for (var index = 0; index < eventsPerPartition; ++index)
                            {
                                batch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event: { index } for Partition: { partition }")));
                            }

                            await producer.SendAsync(batch, cancellationSource.Token);
                        }
                    }

                    // Read events from all partitions.

                    var receivedEvents = await ReadUntilEmptyAsync(consumer, expectedEventCount: expectedCount, cancellationToken: cancellationSource.Token);

                    // Verify the results.

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The publishing and reading should have completed normally.");
                    Assert.That(receivedEvents.Count, Is.EqualTo(expectedCount), "There was an incorrect number of events received.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitionsWhenUsingAutomaticRouting()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitions = await consumer.GetPartitionIdsAsync(cancellationSource.Token);
                    var eventsPerPartition = 5;
                    var expectedCount = (eventsPerPartition * partitions.Length);
                    var eventsBatched = 0;

                    // Send events without influencing the partition.  Routing is controlled by the service and partitions may not
                    // receive an even distribution.  Because reading begins at the beginning of the partition by default, these
                    // should be observed without publishing in the read loop.

                    await using (var producer = new EventHubProducerClient(connectionString))
                    {
                        foreach (var partition in partitions)
                        {
                            using var batch = await producer.CreateBatchAsync(cancellationSource.Token);

                            for (var index = 0; index < eventsPerPartition; ++index)
                            {
                                batch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event: { index } of this batch.  Number: { ++eventsBatched } overall.")));
                            }

                            await producer.SendAsync(batch, cancellationSource.Token);
                        }
                    }

                    // Read events from all partitions.

                    var receivedEvents = await ReadUntilEmptyAsync(consumer, expectedEventCount: expectedCount, cancellationToken: cancellationSource.Token);

                    // Verify the results.

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The publishing and reading should have completed normally.");
                    Assert.That(receivedEvents.Count, Is.EqualTo(expectedCount), "There was an incorrect number of events received.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadUsingAnIdentityCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var credential = new ClientSecretCredential(TestEnvironment.EventHubsTenant, TestEnvironment.EventHubsClient, TestEnvironment.EventHubsSecret);

                await using (var producer = new EventHubProducerClient(TestEnvironment.FullyQualifiedNamespace, scope.EventHubName, credential))
                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, TestEnvironment.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();
                    var expectedEventsCount = 10;

                    for (int i = 0; i < expectedEventsCount; i++)
                    {
                        await producer.SendAsync(new EventData(new byte[1]), new SendEventOptions { PartitionId = partition });
                    }

                    // Read the events.

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromSeconds(45));

                    var receivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Earliest, expectedEventCount: expectedEventsCount, cancellationToken: cancellationSource.Token);
                    Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCanReadFromAllPartitionsUsingAnIdentityCredential()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                var credential = new ClientSecretCredential(TestEnvironment.EventHubsTenant, TestEnvironment.EventHubsClient, TestEnvironment.EventHubsSecret);

                using var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(TimeSpan.FromSeconds(90));

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, TestEnvironment.FullyQualifiedNamespace, scope.EventHubName, credential))
                {
                    var partitions = await consumer.GetPartitionIdsAsync(cancellationSource.Token);
                    var eventsPerPartition = 10;
                    var expectedCount = (eventsPerPartition * partitions.Length);

                    // Send events to each partition.  Because reading begins at the beginning of the partition by
                    // default, these should be observed without publishing in the read loop.

                    await using (var producer = new EventHubProducerClient(TestEnvironment.FullyQualifiedNamespace, scope.EventHubName, credential))
                    {
                        foreach (var partition in partitions)
                        {
                            using var batch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partition }, cancellationSource.Token);

                            for (var index = 0; index < eventsPerPartition; ++index)
                            {
                                batch.TryAdd(new EventData(Encoding.UTF8.GetBytes($"Event: { index } for Partition: { partition }")));
                            }

                            await producer.SendAsync(batch, cancellationSource.Token);
                        }
                    }

                    // Read events from all partitions.

                    var receivedEvents = await ReadUntilEmptyAsync(consumer, expectedEventCount: expectedCount, cancellationToken: cancellationSource.Token);

                    // Verify the results.

                    Assert.That(cancellationSource.IsCancellationRequested, Is.False, "The publishing and reading should have completed normally.");
                    Assert.That(receivedEvents.Count, Is.GreaterThanOrEqualTo(expectedCount), "There was an incorrect number of events received.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ConsumerCannotReadWhenClosed(bool sync)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        Func<Task> readAfterClose = async () =>
                        {
                            var count = 0;
                            var maximumCount = 25;
                            var countBeforeClose = 3;
                            var closeCalled = false;

                            await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, DefaultReadOptions))
                            {
                                ++count;

                                if ((count == countBeforeClose) && (!closeCalled))
                                {
                                    await consumer.CloseAsync();
                                }

                                if (count >= maximumCount)
                                {
                                    break;
                                }
                            }
                        };

                        Assert.That(async () => await readAfterClose(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ConsumerCannotReceiveFromInvalidPartition(string invalidPartition)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    Assert.That(async () => await ReadNothingAsync(consumer, invalidPartition, EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReceiveFromNonExistentConsumerGroup()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient("nonExistentConsumerGroup", connection))
                    {
                        Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ResourceNotFound));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task NoOwnerLevelConsumerCannotStartReading()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var firstIteration = true;

                    var exclusiveReadOptions = DefaultReadOptions.Clone();
                    exclusiveReadOptions.OwnerLevel = 20;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await foreach (var exclusiveEvent in exclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, exclusiveReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                            Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected));

                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOwnerLevelConsumerCannotStartReading()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();
                    var firstIteration = true;

                    var higherExclusiveReadOptions = DefaultReadOptions.Clone();
                    higherExclusiveReadOptions.OwnerLevel = 30;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await foreach (var higherEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, higherExclusiveReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            var lowerExclusiveReadOptions = DefaultReadOptions.Clone();
                            lowerExclusiveReadOptions.OwnerLevel = 20;

                            Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest, lowerExclusiveReadOptions), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected));
                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOrNoOwnerLevelConsumerCanStartReceivingFromOtherPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitionIds = (await consumer.GetPartitionIdsAsync());
                    var firstIteration = true;

                    var higherExclusiveReadOptions = DefaultReadOptions.Clone();
                    higherExclusiveReadOptions.OwnerLevel = 20;

                    var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await foreach (var higherEvent in consumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, higherExclusiveReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            var lowerExclusiveReadOptions = DefaultReadOptions.Clone();
                            lowerExclusiveReadOptions.OwnerLevel = 10;

                            Assert.That(async () => await ReadNothingAsync(consumer, partitionIds[1], EventPosition.Latest, lowerExclusiveReadOptions), Throws.Nothing);
                            Assert.That(async () => await ReadNothingAsync(consumer, partitionIds[2], EventPosition.Latest, DefaultReadOptions), Throws.Nothing);

                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOrNoOwnerLevelConsumerCanStartReadingFromOtherConsumerGroups()
        {
            var consumerGroups = new[]
            {
                "notdefault",
                "notdefault2"
            };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, consumerGroups))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    var higherExclusiveReadOptions = DefaultReadOptions.Clone();
                    higherExclusiveReadOptions.OwnerLevel = 20;

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(consumerGroups[0], connection);
                    await foreach (var higherEvent in higherExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, higherExclusiveReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            var lowerExclusiveReadOptions = DefaultReadOptions.Clone();
                            lowerExclusiveReadOptions.OwnerLevel = 10;

                            await using var lowerExclusiveConsumer = new EventHubConsumerClient(consumerGroups[1], connection);
                            Assert.That(async () => await ReadNothingAsync(lowerExclusiveConsumer, partition, EventPosition.Latest, lowerExclusiveReadOptions), Throws.Nothing);

                            await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                            Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerClosesNoOwnerLevelConsumer()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Non-exclusive may read before an exclusive claims.

                    Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest), Throws.Nothing);

                    // Exclusive may read without an issue.

                    var exclusiveReadOptions = DefaultReadOptions.Clone();
                    exclusiveReadOptions.OwnerLevel = 20;

                    Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest, exclusiveReadOptions), Throws.Nothing);

                    // Once the exclusive is active, ensure that the non-exclusive is denied access.

                    await foreach (var exclusiveEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, exclusiveReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected));
                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerClosesLowerOwnerLevelConsumer()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();
                    var firstIteration = true;

                    var higherExclusiveReadOptions = DefaultReadOptions.Clone();
                    higherExclusiveReadOptions.OwnerLevel = 30;

                    var lowerExclusiveReadOptions = DefaultReadOptions.Clone();
                    lowerExclusiveReadOptions.OwnerLevel = 20;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Non-exclusive may read before an exclusive claims.

                    Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest, lowerExclusiveReadOptions), Throws.Nothing);

                    // Exclusive may read without an issue.

                    Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest, higherExclusiveReadOptions), Throws.Nothing);

                    // Once the exclusive is active, ensure that the non-exclusive is denied access.

                    await foreach (var higherEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, higherExclusiveReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest, lowerExclusiveReadOptions), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected));
                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerDoesNotCloseLowerOrNoOwnerLevelConsumersFromOtherPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitionIds = await consumer.GetPartitionIdsAsync();
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Begin reading with the non-exclusive consumer so that it is actively engaged when the others read.

                    await foreach (var nonExclusiveEvent in consumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, DefaultReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            // Begin reading with the lower-level exclusive consumer so that it is active connected when the higher level exclusive consumer reads.

                            var innerFirstIteration = true;

                            var lowerExclusiveReadOptions = DefaultReadOptions.Clone();
                            lowerExclusiveReadOptions.OwnerLevel = 20;

                            await foreach (var lowerExclusiveEvent in consumer.ReadEventsFromPartitionAsync(partitionIds[1], EventPosition.Latest, lowerExclusiveReadOptions, cancellationSource.Token))
                            {
                                // Ensure that the higher level consumer can read without interfering with the other active consumers.

                                if (!innerFirstIteration)
                                {
                                    var higherExclusiveReadOptions = DefaultReadOptions.Clone();
                                    higherExclusiveReadOptions.OwnerLevel = 30;

                                    Assert.That(async () => await ReadNothingAsync(consumer, partitionIds[2], EventPosition.Latest, higherExclusiveReadOptions), Throws.Nothing);
                                    break;
                                }

                                await Task.Delay(150);
                                innerFirstIteration = false;
                            }

                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerDoesNotCloseLowerOrNoOwnerLevelConsumersFromOtherConsumerGroups()
        {
            var consumerGroups = new[]
            {
                "notdefault",
                "notdefault2"
            };

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, consumerGroups))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(consumerGroups[0], connection);
                    await foreach (var nonExclusiveEvent in nonExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, DefaultReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            var innerFirstIteration = true;

                            var lowerExclusiveReadOptions = DefaultReadOptions.Clone();
                            lowerExclusiveReadOptions.OwnerLevel = 10;

                            await using var lowerExclusiveConsumer = new EventHubConsumerClient(consumerGroups[1], connection);
                            await foreach (var lowerEvent in lowerExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, lowerExclusiveReadOptions, cancellationSource.Token))
                            {
                                if (!innerFirstIteration)
                                {
                                    var higherExclusiveReadOptions = DefaultReadOptions.Clone();
                                    higherExclusiveReadOptions.OwnerLevel = 20;

                                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                                    Assert.That(async () => await ReadNothingAsync(higherExclusiveConsumer, partition, EventPosition.Latest, higherExclusiveReadOptions), Throws.Nothing);

                                    break;
                                }

                                await Task.Delay(150);
                                innerFirstIteration = false;
                            }

                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task FailingToCreateConsumerDoesNotCompromiseReadBehavior()
        {
            var customConsumerGroup = "anotherConsumerGroup";

            await using (EventHubScope scope = await EventHubScope.CreateAsync(2, new[] { customConsumerGroup }))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var defaultGroupConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partitionIds = await defaultGroupConsumer.GetPartitionIdsAsync();

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Create an exclusive consumer with low priority; this consumer should block a non-exclusive consumer but be trumped by the
                    // higher exclusive consumer.

                    var firstIteration = true;
                    var scenariosComplete = false;

                    var lowerExclusiveReadOptions = DefaultReadOptions.Clone();
                    lowerExclusiveReadOptions.OwnerLevel = 10;

                    try
                    {
                        await foreach (var lowerEvent in defaultGroupConsumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, lowerExclusiveReadOptions, cancellationSource.Token))
                        {
                            if (!firstIteration)
                            {
                                // Since there is an exclusive consumer reading, the non-exclusive consumer should be rejected.

                                Assert.That(async () => await ReadNothingAsync(defaultGroupConsumer, partitionIds[0], EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected));

                                // Create the higher level exclusive consumer; this should force the lower exclusive consumer to disconnect.

                                var innerFirstIteration = true;

                                var higherExclusiveReadOptions = DefaultReadOptions.Clone();
                                higherExclusiveReadOptions.OwnerLevel = 20;

                                await foreach (var higherEvent in defaultGroupConsumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, higherExclusiveReadOptions, cancellationSource.Token))
                                {
                                    if (!innerFirstIteration)
                                    {
                                        // Consumers for other partitions and consumer groups should be allowed to read without interference.

                                        await using var differentConsumerGroupConsumer = new EventHubConsumerClient(customConsumerGroup, connectionString);
                                        Assert.That(async () => await ReadNothingAsync(differentConsumerGroupConsumer, partitionIds[0], EventPosition.Latest), Throws.Nothing);

                                        await using var differentGroupAndPartitionConsumer = new EventHubConsumerClient(customConsumerGroup, connectionString);
                                        Assert.That(async () => await ReadNothingAsync(differentGroupAndPartitionConsumer, partitionIds[1], EventPosition.Latest), Throws.Nothing);

                                        // Exceptions for invalid resources should continue to be thrown.

                                        await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("XYZ", connectionString);
                                        Assert.That(async () => await ReadNothingAsync(invalidConsumerGroupConsumer, partitionIds[0], EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ResourceNotFound));

                                        await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString);
                                        Assert.That(async () => await ReadNothingAsync(invalidPartitionConsumer, "ABC", EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());

                                        scenariosComplete = true;
                                        break;
                                    }

                                    await Task.Delay(150);
                                    innerFirstIteration = false;
                                }

                                break;
                            }

                            await Task.Delay(250);
                            firstIteration = false;
                        }
                    }
                    catch (EventHubsException ex) when (ex.Reason == EventHubsException.FailureReason.ConsumerDisconnected)
                    {
                        // This is an possible outcome depending on whether the inner dispose
                        // completes before the outer iteration ticks.  Since there is an element of
                        // non-determinism here, allow this.
                        //
                        // To ensure that things are in the correct state, validate that the
                        // scenarios were completed before iteration stopped.
                    }

                    Assert.That(scenariosComplete, Is.True, "The lower exclusive consumer should not have been disconnected before the scenarios were completed.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task FailingToCreateInvalidPartitionConsumerDoesNotCompromiseReadBehavior()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Begin with attempting to read from an invalid partition.

                    Assert.That(async () => await ReadNothingAsync(consumer, "XYZ", EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());

                    // It should be possible to create new valid consumers.

                    var exclusiveReadOptions = DefaultReadOptions.Clone();
                    exclusiveReadOptions.OwnerLevel = 20;

                    Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest, exclusiveReadOptions), Throws.Nothing);

                    // Exceptions should continue to be thrown properly.

                    await foreach (var exclusiveItem in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, exclusiveReadOptions, cancellationSource.Token))
                    {
                        await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("fake", connectionString);
                        Assert.That(async () => await ReadNothingAsync(invalidConsumerGroupConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ResourceNotFound));

                        await using var otherInvalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString);
                        Assert.That(async () => await ReadNothingAsync(otherInvalidPartitionConsumer, "ABC", EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());

                        await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString);
                        Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected));

                        break;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task FailingToCreateInvalidConsumerGroupConsumerDoesNotCompromiseReadBehavior()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    var exclusiveReadOptions = DefaultReadOptions.Clone();
                    exclusiveReadOptions.OwnerLevel = 20;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Begin with attempting to read from an invalid partition.

                    await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("notreal", connection);
                    Assert.That(async () => await ReadNothingAsync(invalidConsumerGroupConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ResourceNotFound));

                    // It should be possible to create new valid consumers.

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    Assert.That(async () => await ReadNothingAsync(exclusiveConsumer, partition, EventPosition.Latest, exclusiveReadOptions), Throws.Nothing);

                    // Exceptions should continue to be thrown properly.

                    var firstIteration = true;

                    await foreach (var exclusiveItem in exclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, exclusiveReadOptions, cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            await using var otherInvalidConsumerGroupConsumer = new EventHubConsumerClient("XYZ", connection);
                            Assert.That(async () => await ReadNothingAsync(otherInvalidConsumerGroupConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ResourceNotFound));

                            await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                            Assert.That(async () => await ReadNothingAsync(invalidPartitionConsumer, "ABC", EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());

                            await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                            Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ConsumerDisconnected));

                            break;
                        }

                        await Task.Delay(250);
                        firstIteration = false;
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadEventsSentToAnotherPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three"))
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);
                    var wereEventsPublished = false;

                    await using var producer = new EventHubProducerClient(connection);
                    await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString);

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    async Task<bool> PublishEvents()
                    {
                        if (!wereEventsPublished)
                        {
                            // Send the batches of events.

                            var batches = 3;

                            for (var batchesCount = 0; batchesCount < batches; batchesCount++)
                            {
                                await producer.SendAsync(eventBatch, new SendEventOptions { PartitionId = partitionIds[0] });
                            }

                            await Task.Delay(TimeSpan.FromSeconds(1));
                            wereEventsPublished = true;
                        }

                        return false;
                    }

                    var receivedEvents = await ReadUntilEmptyAsync(consumer, partitionIds[1], EventPosition.Latest, expectedEventCount: eventBatch.Length, iterationCallback: PublishEvents, cancellationToken: cancellationSource.Token);
                    Assert.That(receivedEvents, Is.Empty, "There should not have been a set of events received.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumersInDifferentConsumerGroupsShouldAllReadEvents()
        {
            var customConsumerGroup = "anotherConsumerGroup";

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1, new[] { customConsumerGroup }))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three"))
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString);
                    await using var anotherConsumer = new EventHubConsumerClient(customConsumerGroup, connection);

                    // Send the batch of events.

                    await using var producer = new EventHubProducerClient(connectionString);
                    await producer.SendAsync(eventBatch, new SendEventOptions { PartitionId = partition });

                    // Read back the events from two different consumer groups.

                    var readOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(1) };
                    var consumerReceivedEvents = await ReadUntilEmptyAsync(consumer, partition, EventPosition.Earliest, readOptions, expectedEventCount: eventBatch.Length, cancellationToken: cancellationSource.Token);
                    var anotherReceivedEvents = await ReadUntilEmptyAsync(anotherConsumer, partition, EventPosition.Earliest, readOptions, expectedEventCount: eventBatch.Length, cancellationToken: cancellationSource.Token);

                    Assert.That(consumerReceivedEvents.Count, Is.EqualTo(eventBatch.Length), $"The number of received events in consumer group { consumer.ConsumerGroup } did not match the batch size.");
                    Assert.That(anotherReceivedEvents.Count, Is.EqualTo(eventBatch.Length), $"The number of received events in consumer group { anotherConsumer.ConsumerGroup } did not match the batch size.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        public async Task ReadStopsWhenMaximumWaitTimeIsReached(int maximumWaitTimeInSecs)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);

                    var startTime = DateTime.UtcNow;
                    var elapsedTime = 0.0;
                    var readOptions = new ReadEventOptions { MaximumWaitTime = TimeSpan.FromSeconds(maximumWaitTimeInSecs) };

                    await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, readOptions, cancellationSource.Token))
                    {
                        elapsedTime = DateTime.UtcNow.Subtract(startTime).TotalSeconds;
                        break;
                    }

                    Assert.That(elapsedTime, Is.GreaterThan(maximumWaitTimeInSecs - 0.1));
                    Assert.That(elapsedTime, Is.LessThan(maximumWaitTimeInSecs + 5));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReadWhenProxyIsInvalid()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    var options = new EventHubConsumerClientOptions
                    {
                        RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(2) },

                        ConnectionOptions = new EventHubConnectionOptions
                        {
                            Proxy = new WebProxy("http://1.2.3.4:9999"),
                            TransportType = EventHubsTransportType.AmqpWebSockets
                        }
                    };

                    await using (var invalidProxyConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, options))
                    {
                        var readOptions = new ReadEventOptions { MaximumWaitTime = null };
                        Assert.That(async () => await ReadNothingAsync(invalidProxyConsumer, partition, EventPosition.Latest, readOptions, 25), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerCanRetrieveEventHubProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 4;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var connectionString = TestEnvironment.EventHubsConnectionString;
                var consumerOptions = new EventHubConsumerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, scope.EventHubName, consumerOptions))
                {
                    EventHubProperties properties = await consumer.GetEventHubPropertiesAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.Name, Is.EqualTo(scope.EventHubName), "The property Event Hub name should match the scope.");
                    Assert.That(properties.PartitionIds.Length, Is.EqualTo(partitionCount), "The properties should have the requested number of partitions.");
                    Assert.That(properties.CreatedOn, Is.EqualTo(DateTimeOffset.UtcNow).Within(TimeSpan.FromSeconds(60)), "The Event Hub should have been created just about now.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ConsumerCanRetrievePartitionProperties(EventHubsTransportType transportType)
        {
            var partitionCount = 4;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(partitionCount))
            {
                var options = new EventHubConnectionOptions();
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var consumerOptions = new EventHubConsumerClientOptions { ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, scope.EventHubName, consumerOptions))
                {
                    var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(20));
                    var properties = await consumer.GetEventHubPropertiesAsync();
                    var partition = properties.PartitionIds.First();
                    var partitionProperties = await consumer.GetPartitionPropertiesAsync(partition, cancellation.Token);

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
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConnectionTransportPartitionIdsMatchPartitionProperties()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    EventHubProperties properties = await consumer.GetEventHubPropertiesAsync();
                    var partitions = await consumer.GetPartitionIdsAsync();

                    Assert.That(properties, Is.Not.Null, "A set of properties should have been returned.");
                    Assert.That(properties.PartitionIds, Is.Not.Null, "A set of partition identifiers for the properties should have been returned.");
                    Assert.That(partitions, Is.Not.Null, "A set of partition identifiers should have been returned.");
                    Assert.That(partitions, Is.EquivalentTo(properties.PartitionIds), "The partition identifiers returned directly should match those returned with properties.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotRetrieveMetadataWhenClosed()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();

                    Assert.That(async () => await consumer.GetEventHubPropertiesAsync(), Throws.Nothing);
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(partition), Throws.Nothing);

                    await consumer.CloseAsync();
                    await Task.Delay(TimeSpan.FromSeconds(5));

                    Assert.That(async () => await consumer.GetPartitionIdsAsync(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(async () => await consumer.GetEventHubPropertiesAsync(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(partition), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ConsumerCannotRetrievePartitionPropertiesWhenPartitionIdIsInvalid(string invalidPartition)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(invalidPartition), Throws.TypeOf<ArgumentOutOfRangeException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotRetrieveMetadataWhenProxyIsInvalid()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var invalidProxyOptions = new EventHubConsumerClientOptions
                {
                    RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(2) },

                    ConnectionOptions = new EventHubConnectionOptions
                    {
                        Proxy = new WebProxy("http://1.2.3.4:9999"),
                        TransportType = EventHubsTransportType.AmqpWebSockets
                    }
                };

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                await using (var invalidProxyConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, invalidProxyOptions))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();

                    Assert.That(async () => await invalidProxyConsumer.GetPartitionIdsAsync(), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyConsumer.GetEventHubPropertiesAsync(), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    Assert.That(async () => await invalidProxyConsumer.GetPartitionPropertiesAsync(partition), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                }
            }
        }

        /// <summary>
        ///   Reads from the requested partition until there are no events available for
        ///   a number of consecutive iterations.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="partition">The partition read from.</param>
        /// <param name="startingPosition">The position in the partition to start reading from.</param>
        /// <param name="readOptions">The options to apply when reading.</param>
        /// <param name="expectedEventCount">The expected count of events; when the read count is below this number, the delay will be applied between loop iterations.</param>
        /// <param name="consecutiveEmptyLimit">The limit for the number of consecutive empty events before reading is terminated.</param>
        /// <param name="consecutiveEmptyDelayThreshold">The threshold of consecutive empty events to allow before applying the delay or termination; this number should be less than <paramref name="consecutiveEmptyLimit"/>.</param>
        /// <param name="consecutiveEmptyDelayMilliseconds">The delay, in milliseconds, to apply between iterations when the <paramref name="consecutiveEmptyDelayThreshold"/> is reached and less than the <paramref name="expectedEventCount"/> events have been read.</param>
        /// <param name="iterationCallback">A callback to invoke at the beginning of each read iteration; if this returns <c>true</c>, reading will be terminated.</param>
        /// <param name="cancellationToken">The token to consider for cancellation of the operation.</param>
        ///
        /// <returns>The set of partition events that were read which contain event data.</returns>
        ///
        private async Task<IList<PartitionEvent>> ReadUntilEmptyAsync(EventHubConsumerClient consumer,
                                                                      string partition,
                                                                      EventPosition startingPosition,
                                                                      ReadEventOptions readOptions = default,
                                                                      int expectedEventCount = int.MaxValue,
                                                                      int consecutiveEmptyLimit = 15,
                                                                      int consecutiveEmptyDelayThreshold = 5,
                                                                      int consecutiveEmptyDelayMilliseconds = 250,
                                                                      Func<Task<bool>> iterationCallback = default,
                                                                      CancellationToken cancellationToken = default)
        {
            readOptions ??= DefaultReadOptions;

            var readEvents = new List<PartitionEvent>();
            var consecutiveEmpties = 0;
            var readAwaitable = consumer.ReadEventsFromPartitionAsync(partition, startingPosition, readOptions, cancellationToken).ConfigureAwait(false);

            await foreach (var partitionEvent in readAwaitable)
            {
                if (iterationCallback != null)
                {
                    if (await iterationCallback().ConfigureAwait(false))
                    {
                        break;
                    }
                }

                if (partitionEvent.Data != null)
                {
                    readEvents.Add(partitionEvent);
                    consecutiveEmpties = 0;
                }
                else if (++consecutiveEmpties >= consecutiveEmptyDelayThreshold)
                {
                    if (consecutiveEmpties >= consecutiveEmptyLimit)
                    {
                        break;
                    }

                    if (readEvents.Count < expectedEventCount)
                    {
                        await Task.Delay(consecutiveEmptyDelayMilliseconds, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            return readEvents;
        }

        /// <summary>
        ///   Reads from all partitions until there are no events available for
        ///   a number of consecutive iterations.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="startingPosition">The position in the partition to start reading from.</param>
        /// <param name="readOptions">The options to apply when reading.</param>
        /// <param name="startReadingAtFirst"><c>true</c> if reading should begin at the beginning of the event stream; otherwise, reading begins at the end of the stream.</param>
        /// <param name="expectedEventCount">The expected count of events; when the read count is below this number, the delay will be applied between loop iterations.</param>
        /// <param name="consecutiveEmptyLimit">The limit for the number of consecutive empty events before reading is terminated.</param>
        /// <param name="consecutiveEmptyDelayThreshold">The threshold of consecutive empty events to allow before applying the delay or termination; this number should be less than <paramref name="consecutiveEmptyLimit"/>.</param>
        /// <param name="consecutiveEmptyDelayMilliseconds">The delay, in milliseconds, to apply between iterations when the <paramref name="consecutiveEmptyDelayThreshold"/> is reached and less than the <paramref name="expectedEventCount"/> events have been read.</param>
        /// <param name="iterationCallback">A callback to invoke at the beginning of each read iteration; if this returns <c>true</c>, reading will be terminated.</param>
        /// <param name="cancellationToken">The token to consider for cancellation of the operation.</param>
        ///
        /// <returns>The set of partition events that were read which contain event data.</returns>
        ///
        private async Task<IList<PartitionEvent>> ReadUntilEmptyAsync(EventHubConsumerClient consumer,
                                                                      ReadEventOptions readOptions = default,
                                                                      bool startReadingAtFirst = true,
                                                                      int expectedEventCount = int.MaxValue,
                                                                      int consecutiveEmptyLimit = 15,
                                                                      int consecutiveEmptyDelayThreshold = 5,
                                                                      int consecutiveEmptyDelayMilliseconds = 250,
                                                                      Func<Task<bool>> iterationCallback = default,
                                                                      CancellationToken cancellationToken = default)
        {
            readOptions ??= DefaultReadOptions;

            var readEvents = new List<PartitionEvent>();
            var consecutiveEmpties = 0;
            var readAwaitable = consumer.ReadEventsAsync(startReadingAtFirst, readOptions, cancellationToken).ConfigureAwait(false);

            await foreach (var partitionEvent in readAwaitable)
            {
                if (iterationCallback != null)
                {
                    if (await iterationCallback().ConfigureAwait(false))
                    {
                        break;
                    }
                }

                if (partitionEvent.Data != null)
                {
                    readEvents.Add(partitionEvent);
                    consecutiveEmpties = 0;
                }
                else if (++consecutiveEmpties >= consecutiveEmptyDelayThreshold)
                {
                    if (consecutiveEmpties >= consecutiveEmptyLimit)
                    {
                        break;
                    }

                    if (readEvents.Count < expectedEventCount)
                    {
                        await Task.Delay(consecutiveEmptyDelayMilliseconds, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            return readEvents;
        }

        /// <summary>
        ///   Iterates a partition for the given consumer a small number of times, ignoring the events.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="partition">The partition read from.</param>
        /// <param name="startingPosition">The position in the partition to start reading from.</param>
        /// <param name="iterationCount">The number of iterations to perform.</param>
        /// <param name="readOptions">The options to apply when reading.</param>
        ///
        private async Task ReadNothingAsync(EventHubConsumerClient consumer,
                                            string partition,
                                            EventPosition startingPosition,
                                            ReadEventOptions readOptions = default,
                                            int iterationCount = 5)
        {
            readOptions ??= new ReadEventOptions { MaximumWaitTime = TimeSpan.FromMilliseconds(150) };

            await foreach (var item in consumer.ReadEventsFromPartitionAsync(partition, startingPosition, readOptions))
            {
                await Task.Delay(250);

                if (--iterationCount <= 0)
                {
                    break;
                }
            }

            // Delay for a moment to ensure that cleanup has registered with the
            // service and the associated link is no longer alive.

            await Task.Delay(250);
        }
    }
}
