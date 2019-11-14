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
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Metadata;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
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
        private readonly EventHubsRetryPolicy DefaultRetryPolicy = new RetryOptions().ToRetryPolicy();

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ConsumerWithNoOptionsCanReceive(TransportType transportType)
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
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ConsumerWithOptionsCanReceive(TransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubConsumerClientOptions { TrackLastEnqueuedEventInformation = false };

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
                        // Read the events.

                        var receivedEvents = new List<EventData>();
                        var consecutiveEmpties = 0;
                        var wereEventsPublished = false;

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50)))
                        {
                            // Send a single event to receive.

                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendOptions { PartitionId = partition });
                                wereEventsPublished = true;
                            }

                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= 5)
                            {
                                break;
                            }
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents)
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
                        /// Read the events.

                        var receivedEvents = new List<EventData>();
                        var consecutiveEmpties = 0;
                        var wereEventsPublished = false;

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50)))
                        {
                            // Send a single event to receive.

                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendOptions { PartitionId = partition });
                                wereEventsPublished = true;
                            }

                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= 5)
                            {
                                break;
                            }
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents)
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
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        // Read the events.

                        var receivedEvents = new List<EventData>();
                        var consecutiveEmpties = 0;
                        var wereEventsPublished = false;

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50)))
                        {
                            // Send a single event to receive.

                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventSet, new SendOptions { PartitionId = partition });
                                wereEventsPublished = true;
                            }

                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= 5)
                            {
                                break;
                            }
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        Assert.That(receivedEvents, Is.Not.Empty, "There should have been a set of events received.");

                        foreach (EventData receivedEvent in receivedEvents)
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
                    var retryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(5) };
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { RetryOptions = retryOptions }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { RetryOptions = retryOptions }))
                    {
                        // Read the events.

                        var receivedEvents = new List<EventData>();
                        var consecutiveEmpties = 0;
                        var wereEventsPublished = false;

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50)))
                        {
                            // Send a single event to receive.

                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendOptions { PartitionId = partition });
                                wereEventsPublished = true;
                            }

                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= 5)
                            {
                                break;
                            }
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents)
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
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    {
                        // Read the events.

                        var receivedEvents = new List<EventData>();
                        var consecutiveEmpties = 0;
                        var wereEventsPublished = false;

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50)))
                        {
                            // Send a single event to receive.

                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(eventBatch, new SendOptions { PartitionId = partition });
                                wereEventsPublished = true;
                            }

                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= 5)
                            {
                                break;
                            }
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        var index = 0;

                        foreach (EventData receivedEvent in receivedEvents)
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
                    var receivedEvents = new List<EventData>();
                    var expectedEventsCount = 1;
                    var consecutiveEmpties = 0;
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

                        await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50)))
                        {
                            // Send a single event to receive.

                            if (!wereEventsPublished)
                            {
                                await producer.SendAsync(stampEvent, new SendOptions { PartitionId = partition });
                                wereEventsPublished = true;
                            }

                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= 5)
                            {
                                break;
                            }
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                        Assert.That(receivedEvents.Single().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
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
                            await producer.SendAsync(new EventData(new byte[1]), new SendOptions { PartitionId = partition });
                        }

                        // Read the events.

                        var consecutiveEmpties = 0;
                        var receivedEvents = new List<EventData>();

                        await foreach (PartitionEvent partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Earliest, TimeSpan.FromMilliseconds(50)))
                        {
                            if (partitionEvent.Data != null)
                            {
                                receivedEvents.Add(partitionEvent.Data);
                                consecutiveEmpties = 0;
                            }
                            else if (++consecutiveEmpties >= 5)
                            {
                                break;
                            }
                        }

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
        public async Task ConsumerCanReceiveFromOffset()
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
                            await producer.SendAsync(new EventData(new byte[1]), new SendOptions { PartitionId = partition });
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

                            var expectedEventsCount = 2;
                            var consecutiveEmpties = 0;
                            var receivedEvents = new List<EventData>();

                            await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.FromOffset(offset), TimeSpan.FromMilliseconds(50)))
                            {
                                if (partitionEvent.Data != null)
                                {
                                    receivedEvents.Add(partitionEvent.Data);
                                    consecutiveEmpties = 0;
                                }
                                else if (++consecutiveEmpties >= 5)
                                {
                                    break;
                                }
                            }

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Last().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
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
        public async Task ConsumerCanReceiveFromEnqueuedTime()
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
                            await producer.SendAsync(new EventData(new byte[1]), new SendOptions { PartitionId = partition });
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
                            var consecutiveEmpties = 0;
                            var receivedEvents = new List<EventData>();

                            await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.FromEnqueuedTime(enqueuedTime), TimeSpan.FromMilliseconds(50)))
                            {
                                if (partitionEvent.Data != null)
                                {
                                    receivedEvents.Add(partitionEvent.Data);
                                    consecutiveEmpties = 0;
                                }
                                else if (++consecutiveEmpties >= 5)
                                {
                                    break;
                                }
                            }

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Single().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
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
        public async Task ConsumerCanReceiveFromSequenceNumber(bool isInclusive)
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

                            await producer.SendAsync(stampEvent, new SendOptions { PartitionId = partition });

                            // Read the events.

                            var expectedEventsCount = isInclusive ? 2 : 1;
                            var consecutiveEmpties = 0;
                            var receivedEvents = new List<EventData>();

                            await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.FromSequenceNumber(sequenceNumber, isInclusive), TimeSpan.FromMilliseconds(50)))
                            {
                                if (partitionEvent.Data != null)
                                {
                                    receivedEvents.Add(partitionEvent.Data);
                                    consecutiveEmpties = 0;
                                }
                                else if (++consecutiveEmpties >= 5)
                                {
                                    break;
                                }
                            }

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Last().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");
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
        public async Task ConsumerCannotReceiveWhenClosed(bool sync)
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

                            await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50)))
                            {
                                ++count;

                                if ((count == countBeforeClose) && (!closeCalled))
                                {
                                    if (sync)
                                    {
                                        consumer.Close();
                                    }
                                    else
                                    {
                                        await consumer.CloseAsync();
                                    }
                                }

                                if (count >= maximumCount)
                                {
                                    break;
                                }
                            }
                        };

                        Assert.That(async () => await readAfterClose(), Throws.InstanceOf<EventHubsClientClosedException>());
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
                        Assert.That(async () => await ReadNothingAsync(consumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsResourceNotFoundException>());
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

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await foreach (var exclusiveEvent in exclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                            Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<ConsumerDisconnectedException>());

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

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await foreach (var higherEvent in higherExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                            Assert.That(async () => await ReadNothingAsync(lowerExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<ConsumerDisconnectedException>());

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

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);
                    var firstIteration = true;

                    var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await foreach (var higherEvent in higherExclusiveConsumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                            Assert.That(async () => await ReadNothingAsync(lowerExclusiveConsumer, partitionIds[1], EventPosition.Latest), Throws.Nothing);

                            await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                            Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partitionIds[2], EventPosition.Latest), Throws.Nothing);

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

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(consumerGroups[0], connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await foreach (var higherEvent in higherExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            await using var lowerExclusiveConsumer = new EventHubConsumerClient(consumerGroups[1], connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                            Assert.That(async () => await ReadNothingAsync(lowerExclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

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

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Non-exclusive may read before an exclusive claims.

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

                    // Exclusive may read without an issue.

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    Assert.That(async () => await ReadNothingAsync(exclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

                    // Once the exclusive is active, ensure that the non-exclusive is denied access.

                    await foreach (var exclusiveEvent in exclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<ConsumerDisconnectedException>());
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

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Non-exclusive may read before an exclusive claims.

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                    Assert.That(async () => await ReadNothingAsync(lowerExclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

                    // Exclusive may read without an issue.

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    Assert.That(async () => await ReadNothingAsync(higherExclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

                    // Once the exclusive is active, ensure that the non-exclusive is denied access.

                    await foreach (var higherEvent in higherExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            Assert.That(async () => await ReadNothingAsync(lowerExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<ConsumerDisconnectedException>());
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

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);
                    var firstIteration = true;

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Begin reading with the non-exclusive consumer so that it is actively engaged when the others read.

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await foreach (var nonExclusiveEvent in nonExclusiveConsumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            // Begin reading with the lower-level exclusive consumer so that it is active connected when the higher level exclusive consumer reads.

                            var innerFirstIteration = true;

                            await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                            await foreach (var lowerExclusiveEvent in lowerExclusiveConsumer.ReadEventsFromPartitionAsync(partitionIds[1], EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                            {
                                // Ensure that the higher level consumer can read without interfering with the other active consumers.

                                if (!innerFirstIteration)
                                {
                                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                                    Assert.That(async () => await ReadNothingAsync(higherExclusiveConsumer, partitionIds[2], EventPosition.Latest), Throws.Nothing);

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
                    await foreach (var exclusiveEvent in nonExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            var innerFirstIteration = true;

                            await using var lowerExclusiveConsumer = new EventHubConsumerClient(consumerGroups[1], connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                            await foreach (var lowerEvent in lowerExclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                            {
                                if (!innerFirstIteration)
                                {
                                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                                    Assert.That(async () => await ReadNothingAsync(higherExclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

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

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Create an exclusive consumer with low priority; this consumer should block a non-exclusive consumer but be trumped by the
                    // higher exclusive consumer.

                    var firstIteration = true;
                    var scenariosComplete = false;

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });

                    try
                    {
                        await foreach (var lowerEvent in lowerExclusiveConsumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                        {
                            if (!firstIteration)
                            {
                                // Since there is an exclusive consumer reading, the non-exclusive consumer should be rejected.

                                await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                                Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partitionIds[0], EventPosition.Latest), Throws.InstanceOf<ConsumerDisconnectedException>());

                                // Create the higher level exclusive consumer; this should force the lower exclusive consumer to disconnect.

                                var innerFirstIteration = true;

                                await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 30 });
                                await foreach (var higherEvent in higherExclusiveConsumer.ReadEventsFromPartitionAsync(partitionIds[0], EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                                {
                                    if (!innerFirstIteration)
                                    {
                                        // Consumers for other partitions and consumer groups should be allowed to read without interference.

                                        await using var differentConsumerGroupConsumer = new EventHubConsumerClient(customConsumerGroup, connection);
                                        Assert.That(async () => await ReadNothingAsync(differentConsumerGroupConsumer, partitionIds[0], EventPosition.Latest), Throws.Nothing);

                                        await using var differentPartitionConsumer = new EventHubConsumerClient(customConsumerGroup, connection);
                                        Assert.That(async () => await ReadNothingAsync(differentPartitionConsumer, partitionIds[1], EventPosition.Latest), Throws.Nothing);

                                        // Exceptions for invalid resources should continue to be thrown.

                                        await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("XYZ", connection);
                                        Assert.That(async () => await ReadNothingAsync(invalidConsumerGroupConsumer, partitionIds[0], EventPosition.Latest), Throws.InstanceOf<EventHubsResourceNotFoundException>());

                                        await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
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
                    catch (ConsumerDisconnectedException)
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

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Begin with attempting to read from an invalid partition.

                    await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    Assert.That(async () => await ReadNothingAsync(invalidPartitionConsumer, "XYZ", EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());

                    // It should be possible to create new valid consumers.

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    Assert.That(async () => await ReadNothingAsync(exclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

                    // Exceptions should continue to be thrown properly.

                    await foreach (var exclusiveItem in exclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("fake", connection);
                        Assert.That(async () => await ReadNothingAsync(invalidConsumerGroupConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsResourceNotFoundException>());

                        await using var otherInvalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                        Assert.That(async () => await ReadNothingAsync(otherInvalidPartitionConsumer, "ABC", EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());

                        await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                        Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<ConsumerDisconnectedException>());

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

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    // Begin with attempting to read from an invalid partition.

                    await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("notreal", connection);
                    Assert.That(async () => await ReadNothingAsync(invalidConsumerGroupConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsResourceNotFoundException>());

                    // It should be possible to create new valid consumers.

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    Assert.That(async () => await ReadNothingAsync(exclusiveConsumer, partition, EventPosition.Latest), Throws.Nothing);

                    // Exceptions should continue to be thrown properly.

                    var firstIteration = true;

                    await foreach (var exclusiveItem in exclusiveConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!firstIteration)
                        {
                            await using var otherInvalidConsumerGroupConsumer = new EventHubConsumerClient("XYZ", connection);
                            Assert.That(async () => await ReadNothingAsync(otherInvalidConsumerGroupConsumer, partition, EventPosition.Latest), Throws.InstanceOf<EventHubsResourceNotFoundException>());

                            await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                            Assert.That(async () => await ReadNothingAsync(invalidPartitionConsumer, "ABC", EventPosition.Latest), Throws.InstanceOf<ArgumentOutOfRangeException>());

                            await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                            Assert.That(async () => await ReadNothingAsync(nonExclusiveConsumer, partition, EventPosition.Latest), Throws.InstanceOf<ConsumerDisconnectedException>());

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

                    using var cancellationSource = new CancellationTokenSource();
                    cancellationSource.CancelAfter(TimeSpan.FromMinutes(5));

                    await using var producer = new EventHubProducerClient(connection);
                    await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString);

                    var receivedEvents = new List<EventData>();
                    var wereEventsPublished = false;
                    var maximumConsecutiveEmpties = 5;
                    var consecutiveEmpties = 0;

                    await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partitionIds[1], EventPosition.Latest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (!wereEventsPublished)
                        {
                            // Send the batches of events.

                            var batches = 3;

                            for (var batchesCount = 0; batchesCount < batches; batchesCount++)
                            {
                                await producer.SendAsync(eventBatch, new SendOptions { PartitionId = partitionIds[0] });
                            }

                            wereEventsPublished = true;
                        }

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
                    await producer.SendAsync(eventBatch, new SendOptions { PartitionId = partition });

                    // Read back the events from two different consumer groups.

                    var maximumConsecutiveEmpties = 5;
                    var consecutiveEmpties = 0;
                    var consumerReceivedEvents = new List<EventData>();
                    var anotherReceivedEvents = new List<EventData>();


                    await foreach (var consumerEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Earliest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (consumerEvent.Data != null)
                        {
                            consumerReceivedEvents.Add(consumerEvent.Data);
                            consecutiveEmpties =0;
                        }
                        else if (++consecutiveEmpties >= maximumConsecutiveEmpties)
                        {
                            break;
                        }
                    }

                    consecutiveEmpties = 0;
                    await foreach (var anotherEvent in anotherConsumer.ReadEventsFromPartitionAsync(partition, EventPosition.Earliest, TimeSpan.FromMilliseconds(50), cancellationSource.Token))
                    {
                        if (anotherEvent.Data != null)
                        {
                            anotherReceivedEvents.Add(anotherEvent.Data);
                            consecutiveEmpties = 0;
                        }
                        else if (++consecutiveEmpties >= maximumConsecutiveEmpties)
                        {
                            break;
                        }
                    }

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

                    await foreach (var partitionEvent in consumer.ReadEventsFromPartitionAsync(partition, EventPosition.Latest, TimeSpan.FromSeconds(maximumWaitTimeInSecs), cancellationSource.Token))
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

                var connectionOptions = new EventHubConnectionOptions
                {
                    Proxy = new WebProxy("http://1.2.3.4:9999"),
                    TransportType = TransportType.AmqpWebSockets
                };

                await using (var connection = new EventHubConnection(connectionString))
                await using (var invalidProxyConnection = new EventHubConnection(connectionString, connectionOptions))
                {
                    var options = new EventHubConsumerClientOptions { RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(2) } };
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var invalidProxyConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, invalidProxyConnection, options))
                    {
                        Assert.That(async () => await ReadNothingAsync(invalidProxyConsumer, partition, EventPosition.Latest), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
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
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ConsumerCanRetrieveEventHubProperties(TransportType transportType)
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
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ConsumerCanRetrievePartitionProperties(TransportType transportType)
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task ConsumerCannotRetrieveMetadataWhenClosed(bool sync)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                {
                    var partition = (await consumer.GetPartitionIdsAsync()).First();

                    Assert.That(async () => await consumer.GetEventHubPropertiesAsync(), Throws.Nothing);
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(partition), Throws.Nothing);

                    if (sync)
                    {
                        consumer.Close();
                    }
                    else
                    {
                        await consumer.CloseAsync();
                    }

                    await Task.Delay(TimeSpan.FromSeconds(5));

                    Assert.That(async () => await consumer.GetPartitionIdsAsync(), Throws.TypeOf<EventHubsClientClosedException>());
                    Assert.That(async () => await consumer.GetEventHubPropertiesAsync(), Throws.TypeOf<EventHubsClientClosedException>());
                    Assert.That(async () => await consumer.GetPartitionPropertiesAsync(partition), Throws.TypeOf<EventHubsClientClosedException>());
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
                    RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(2) },

                    ConnectionOptions = new EventHubConnectionOptions
                    {
                        Proxy = new WebProxy("http://1.2.3.4:9999"),
                        TransportType = TransportType.AmqpWebSockets
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
        ///   Iterates a partition for the given consumer a small number of times, ignoring the events.
        /// </summary>
        ///
        /// <param name="consumer">The consumer to use for reading.</param>
        /// <param name="partition">The partition read from.</param>
        /// <param name="startingPosition">The position in the partition to start reading from.</param>
        /// <param name="iterationCount">The number of iterations to perform.</param>
        ///
        private async Task ReadNothingAsync(EventHubConsumerClient consumer,
                                            string partition,
                                            EventPosition startingPosition,
                                            int iterationCount = 5)
        {
            await foreach (var item in consumer.ReadEventsFromPartitionAsync(partition, startingPosition, TimeSpan.FromMilliseconds(50)))
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
