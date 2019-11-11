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
    ///   The suite of live tests for the <see cref="PartitionReceiver" />
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
    public class PartitionReceiverLiveTests
    {
        /// <summary>The maximum number of times that the receive loop should iterate to collect the expected number of messages.</summary>
        private const int ReceiveRetryLimit = 10;

        /// <summary>The default retry policy to use when performing operations.</summary>
        private readonly EventHubsRetryPolicy DefaultRetryPolicy = new RetryOptions().ToRetryPolicy();

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveCanReadOneEventBatchFromAnEventSet()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventSet = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three"))
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connectionString, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventSet);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventSet.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventSet.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

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
        public async Task ReceiveCanReadOneEventBatchFromAnEventBatch()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventSet = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three"))
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Create the batch of events to publish.

                        using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                        foreach (EventData eventData in eventSet)
                        {
                            eventBatch.TryAdd(eventData);
                        }

                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Count) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Count + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

                        Assert.That(receivedEvents, Is.Not.Empty, "There should have been a set of events received.");

                        foreach (EventData receivedEvent in receivedEvents)
                        {
                            Assert.That(receivedEvent.IsEquivalentTo(eventSet[index]), Is.True, $"The received event at index: { index } did not match the sent batch.");
                            ++index;
                        }

                        Assert.That(index, Is.EqualTo(eventBatch.Count), "The number of received events did not match the batch size.");
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
        public async Task ReceiveCanReadMultipleEventBatches()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventSet = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three")),
                    new EventData(Encoding.UTF8.GetBytes("Four")),
                    new EventData(Encoding.UTF8.GetBytes("Five")),
                    new EventData(Encoding.UTF8.GetBytes("Six")),
                    new EventData(Encoding.UTF8.GetBytes("Seven")),
                    new EventData(Encoding.UTF8.GetBytes("Eight")),
                    new EventData(Encoding.UTF8.GetBytes("Nine")),
                    new EventData(Encoding.UTF8.GetBytes("Ten")),
                    new EventData(Encoding.UTF8.GetBytes("Eleven")),
                    new EventData(Encoding.UTF8.GetBytes("Twelve")),
                    new EventData(Encoding.UTF8.GetBytes("Thirteen")),
                    new EventData(Encoding.UTF8.GetBytes("Fourteen")),
                    new EventData(Encoding.UTF8.GetBytes("Fifteen"))
                };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Create the batch of events to publish.

                        using EventDataBatch eventBatch = await producer.CreateBatchAsync();

                        foreach (EventData eventData in eventSet)
                        {
                            if (!eventBatch.TryAdd(eventData))
                            {
                                Assert.Fail("All of the events could not be added to the batch.");
                            }
                        }

                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events, receive and validate them.

                        await producer.SendAsync(eventBatch);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;
                        var batchNumber = 1;
                        var setSize = (eventSet.Length / 3);

                        while ((receivedEvents.Count < eventSet.Length) && (++index < eventSet.Length + ReceiveRetryLimit))
                        {
                            IEnumerable<EventData> currentReceiveBatch = await receiver.ReceiveAsync(setSize, TimeSpan.FromMilliseconds(25));
                            receivedEvents.AddRange(currentReceiveBatch);

                            Assert.That(currentReceiveBatch, Is.Not.Empty, $"There should have been a set of events received for batch number: { batchNumber }.");

                            ++batchNumber;
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

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
        public async Task ReceiveCanReadSingleEvent()
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

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

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
        public async Task ReceiveCanReadSingleZeroLengthEvent()
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

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

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
        public async Task ReceiveCanReadOneZeroLengthEventSet()
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

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the set of events.

                        await producer.SendAsync(eventSet);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventSet.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventSet.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

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
        public async Task ReceiveCanReadLargeEvent()
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

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition, RetryOptions = retryOptions }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { RetryOptions = retryOptions }))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // A short delay is necessary to persist the large event.

                        await Task.Delay(TimeSpan.FromSeconds(5));

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(500)));
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

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
        public async Task ReceiveCanReadEventWithCustomProperties()
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

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        // Validate the events; once nulls have been removed, they should have been received in the order they were added to the batch.
                        // Because there's a custom equality check, the built-in collection comparison is not adequate.

                        index = 0;

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
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReceiveFromLatestEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Sending some events beforehand so the partition has some information.
                        // We are not expecting to receive these.

                        for (int i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]));
                        }

                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send a single event.

                        var stampEvent = new EventData(new byte[1]);
                        stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                        await producer.SendAsync(stampEvent);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var expectedEventsCount = 1;
                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < expectedEventsCount) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(expectedEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                        Assert.That(receivedEvents.Single().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");

                        // Next receive on this partition shouldn't return any more messages.

                        Assert.That(await receiver.ReceiveAsync(10, TimeSpan.FromSeconds(2)), Is.Empty);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReceiveFromEarliestEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Earliest))
                    {
                        // Sending some events beforehand so the partition has some information.

                        var expectedEventsCount = 10;

                        for (int i = 0; i < expectedEventsCount; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]));
                        }

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < expectedEventsCount) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(expectedEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReceiveFromOffset()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    {
                        // Sending some events beforehand so the partition has some information.

                        for (var i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]));
                        }

                        // Store last enqueued offset.

                        var offset = (await producer.GetPartitionPropertiesAsync(partition)).LastEnqueuedOffset;

                        await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                        await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.FromOffset(offset)))
                        {
                            // Send a single event which is expected to go to the end of stream.

                            var stampEvent = new EventData(new byte[1]);
                            stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                            await producer.SendAsync(stampEvent);

                            // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                            // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                            // to account for availability delays.

                            var expectedEventsCount = 2;
                            var receivedEvents = new List<EventData>();
                            var index = 0;

                            while ((receivedEvents.Count < expectedEventsCount) && (++index < ReceiveRetryLimit))
                            {
                                receivedEvents.AddRange(await receiver.ReceiveAsync(expectedEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                            }

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Last().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");

                            // Next receive on this partition shouldn't return any more messages.

                            Assert.That(await receiver.ReceiveAsync(10, TimeSpan.FromSeconds(2)), Is.Empty);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCanReceiveFromEnqueuedTime()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    {
                        // Sending some events beforehand so the partition has some information.

                        for (var i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]));
                        }

                        // Store last enqueued time.

                        DateTimeOffset enqueuedTime = (await producer.GetPartitionPropertiesAsync(partition)).LastEnqueuedTime;

                        await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                        await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.FromEnqueuedTime(enqueuedTime)))
                        {
                            // Send a single event which is expected to go to the end of stream.
                            // We are expecting to receive only this message.

                            var stampEvent = new EventData(new byte[1]);
                            stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                            await producer.SendAsync(stampEvent);

                            // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                            // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                            // to account for availability delays.

                            var expectedEventsCount = 1;
                            var receivedEvents = new List<EventData>();
                            var index = 0;

                            while ((receivedEvents.Count < expectedEventsCount) && (++index < ReceiveRetryLimit))
                            {
                                receivedEvents.AddRange(await receiver.ReceiveAsync(expectedEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                            }

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Single().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");

                            // Next receive on this partition shouldn't return any more messages.

                            Assert.That(await receiver.ReceiveAsync(10, TimeSpan.FromSeconds(2)), Is.Empty);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReceiverCanReceiveFromSequenceNumber(bool isInclusive)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    {
                        // Sending some events beforehand so the partition has some information.

                        for (var i = 0; i < 10; i++)
                        {
                            await producer.SendAsync(new EventData(new byte[1]));
                        }

                        // Store last enqueued sequence number.

                        var sequenceNumber = (await producer.GetPartitionPropertiesAsync(partition)).LastEnqueuedSequenceNumber;

                        await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                        await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.FromSequenceNumber(sequenceNumber, isInclusive)))
                        {
                            // Send a single event which is expected to go to the end of stream.

                            var stampEvent = new EventData(new byte[1]);
                            stampEvent.Properties["stamp"] = Guid.NewGuid().ToString();

                            await producer.SendAsync(stampEvent);

                            // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                            // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                            // to account for availability delays.

                            var expectedEventsCount = isInclusive ? 2 : 1;
                            var receivedEvents = new List<EventData>();
                            var index = 0;

                            while ((receivedEvents.Count < expectedEventsCount) && (++index < ReceiveRetryLimit))
                            {
                                receivedEvents.AddRange(await receiver.ReceiveAsync(expectedEventsCount + 10, TimeSpan.FromMilliseconds(25)));
                            }

                            Assert.That(receivedEvents.Count, Is.EqualTo(expectedEventsCount), $"The number of received events should be { expectedEventsCount }.");
                            Assert.That(receivedEvents.Last().IsEquivalentTo(stampEvent), Is.True, "The received event did not match the sent event.");

                            // Next receive on this partition shouldn't return any more messages.

                            Assert.That(await receiver.ReceiveAsync(10, TimeSpan.FromSeconds(2)), Is.Empty);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReceiverCannotReceiveWhenClosed(bool sync)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                EventData[] eventBatch = new[] { new EventData(Encoding.UTF8.GetBytes("This message won't be sent")) };

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))

                    {
                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        if (sync)
                        {
                            receiver.Close();
                        }
                        else
                        {
                            await receiver.CloseAsync();
                        }

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<EventHubsClientClosedException>().Or.InstanceOf<ObjectDisposedException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase("XYZ")]
        [TestCase("-1")]
        [TestCase("1000")]
        [TestCase("-")]
        public async Task ReceiverCannotReceiveFromInvalidPartition(string invalidPartition)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                await using (var receiver = consumer.CreatePartitionReceiver(invalidPartition, EventPosition.Latest))
                {
                    Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(50)]
        public async Task ReceiverCannotReceiveMoreThanMaximumMessageCountMessages(int maximumMessageCount)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = Enumerable
                    .Range(0, 20 * maximumMessageCount)
                    .Select(index => new EventData(new byte[10]))
                    .ToList();

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partition }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events.

                        var index = 0;

                        while (index < eventBatch.Count)
                        {
                            var receivedEvents = (await receiver.ReceiveAsync(maximumMessageCount, TimeSpan.FromSeconds(10))).ToList();
                            index += receivedEvents.Count;

                            Assert.That(receivedEvents.Count, Is.LessThanOrEqualTo(maximumMessageCount));
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReceiveFromNonExistentConsumerGroup()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient("nonExistentConsumerGroup", connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<EventHubsResourceNotFoundException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task NoOwnerLevelReceiverCannotStartReceiving()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var exclusiveReceiver = exclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    await exclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOwnerLevelConsumerCannotStartReceiving()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var higherExclusiveReceiver = higherExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    await higherExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                    await using var lowerExclusiveReceiver = lowerExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    Assert.That(async () => await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOrNoOwnerLevelReceiverCanStartReceivingFromOtherPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var higherExclusiveReceiver = higherExclusiveConsumer.CreatePartitionReceiver(partitionIds[0], EventPosition.Latest);
                    await higherExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                    await using var lowerExclusiveReceiver = lowerExclusiveConsumer.CreatePartitionReceiver(partitionIds[1], EventPosition.Latest);
                    Assert.That(async () => await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partitionIds[2], EventPosition.Latest);
                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOrNoOwnerLevelReceiverCanStartReceivingFromOtherConsumerGroups()
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

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(consumerGroups[0], connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var higherExclusiveReceiver = higherExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    await higherExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(consumerGroups[1], connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                    await using var lowerExclusiveReceiver = lowerExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    Assert.That(async () => await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerClosesNoOwnerLevelReceiver()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var exclusiveReceiver = exclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2)), Throws.Nothing);
                    Assert.That(async () => await exclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2)), Throws.Nothing);

                    await Task.Delay(TimeSpan.FromSeconds(5));
                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerClosesLowerOwnerLevelReceiver()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var higherExclusiveReceiver = higherExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                    await using var lowerExclusiveReceiver = lowerExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    Assert.That(async () => await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2)), Throws.Nothing);
                    Assert.That(async () => await higherExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2)), Throws.Nothing);

                    await Task.Delay(TimeSpan.FromSeconds(5));
                    Assert.That(async () => await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerDoesNotCloseLowerOrNoOwnerLevelReceiversFromOtherPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var higherExclusiveReceiver = higherExclusiveConsumer.CreatePartitionReceiver(partitionIds[0], EventPosition.Latest);

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                    await using var lowerExclusiveReceiver = lowerExclusiveConsumer.CreatePartitionReceiver(partitionIds[1], EventPosition.Latest);

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partitionIds[2], EventPosition.Latest);

                    await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));
                    await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));
                    await higherExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    Assert.That(async () => await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerDoesNotCloseLowerOrNoOwnerLevelReceiversFromOtherConsumerGroups()
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

                    await using var higherExclusiveConsumer = new EventHubConsumerClient(consumerGroups[0], connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var higherExclusiveReceiver = higherExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    await using var lowerExclusiveConsumer = new EventHubConsumerClient(consumerGroups[1], connection, new EventHubConsumerClientOptions { OwnerLevel = 10 });
                    await using var lowerExclusiveReceiver = lowerExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    await higherExclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    Assert.That(async () => await lowerExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task FailingToCreateReceiverDoesNotCompromiseReceiveBehavior()
        {
            var customConsumerGroup = "anotherConsumerGroup";

            await using (EventHubScope scope = await EventHubScope.CreateAsync(2, new[] { customConsumerGroup }))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partitionIds = await connection.GetPartitionIdsAsync(DefaultRetryPolicy);

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partitionIds[0], EventPosition.Latest);
                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var exclusiveReceiver = exclusiveConsumer.CreatePartitionReceiver(partitionIds[0], EventPosition.Latest);
                    await exclusiveReceiver.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    // Failing at consumer creation should not compromise future ReceiveAsync calls.

                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());

                    // It should be possible to create new valid consumers.

                    await using var newExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 30 });
                    await using var newExclusiveReceiver = newExclusiveConsumer.CreatePartitionReceiver(partitionIds[0], EventPosition.Latest);
                    await using var anotherPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var anotherPartitionReceiver = anotherPartitionConsumer.CreatePartitionReceiver(partitionIds[1], EventPosition.Latest);
                    await using var anotherConsumerGroupConsumer = new EventHubConsumerClient(customConsumerGroup, connection);
                    await using var anotherConsumerGroupReceiver = anotherConsumerGroupConsumer.CreatePartitionReceiver(partitionIds[0], EventPosition.Latest);

                    Assert.That(async () => await newExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await anotherPartitionReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await anotherConsumerGroupReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    // Proper exceptions should be thrown as well.

                    await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var invalidPartitionReceiver = invalidPartitionConsumer.CreatePartitionReceiver("XYZ", EventPosition.Latest);
                    await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("imNotAConsumerGroup", connection);
                    await using var invalidConsumerGroupReceiver = invalidConsumerGroupConsumer.CreatePartitionReceiver(partitionIds[0], EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());
                    Assert.That(async () => await invalidPartitionReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(async () => await invalidConsumerGroupReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<EventHubsResourceNotFoundException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task FailingToCreateInvalidPartitionReceiverDoesNotCompromiseReceiveBehavior()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var invalidPartitionReceiver = invalidPartitionConsumer.CreatePartitionReceiver("XYZ", EventPosition.Latest);

                    // Failing at consumer creation should not compromise future ReceiveAsync calls.

                    Assert.That(async () => await invalidPartitionReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());

                    // It should be possible to create new valid consumers.

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var exlusiveReceiver = exclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    Assert.That(async () => await exlusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    // Proper exceptions should be thrown as well.

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("imNotAConsumerGroup", connection);
                    await using var invalidConsumerGroupReceiver = invalidConsumerGroupConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());
                    Assert.That(async () => await invalidPartitionReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(async () => await invalidConsumerGroupReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<EventHubsResourceNotFoundException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task FailingToCreateInvalidConsumerGroupReceiverDoesNotCompromiseReceiveBehavior()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using var invalidConsumerGroupConsumer = new EventHubConsumerClient("imNotAConsumerGroup", connection);
                    await using var invalidConsumerGroupReceiver = invalidConsumerGroupConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    // Failing at consumer creation should not compromise future ReceiveAsync calls.

                    Assert.That(async () => await invalidConsumerGroupReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<EventHubsResourceNotFoundException>());

                    // It should be possible to create new valid consumers.

                    await using var exclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection, new EventHubConsumerClientOptions { OwnerLevel = 20 });
                    await using var exclusiveReceiver = exclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);

                    Assert.That(async () => await exclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    // Proper exceptions should be thrown as well.

                    await using var nonExclusiveConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var nonExclusiveReceiver = nonExclusiveConsumer.CreatePartitionReceiver(partition, EventPosition.Latest);
                    await using var invalidPartitionConsumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection);
                    await using var invalidPartitionReceiver = invalidConsumerGroupConsumer.CreatePartitionReceiver("XYZ", EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ConsumerDisconnectedException>());
                    Assert.That(async () => await invalidPartitionReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(async () => await invalidConsumerGroupReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<EventHubsResourceNotFoundException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReceiveEventsSentToAnotherPartition()
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

                    await using (var producer = new EventHubProducerClient(connection, new EventHubProducerClientOptions { PartitionId = partitionIds[0] }))
                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString))
                    await using (var receiver = consumer.CreatePartitionReceiver(partitionIds[1], EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batches of events.

                        var batches = 3;

                        for (var batchesCount = 0; batchesCount < batches; batchesCount++)
                        {
                            await producer.SendAsync(eventBatch);
                        }

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while (++index < ReceiveRetryLimit)
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(batches * eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents, Is.Empty, "There should not have been a set of events received.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiversInDifferentConsumerGroupsShouldAllReceiveEvents()
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

                    await using var producer = new EventHubProducerClient(connectionString, new EventHubProducerClientOptions { PartitionId = partition });
                    await using var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString);
                    await using var anotherConsumer = new EventHubConsumerClient(customConsumerGroup, connection);

                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    await using (var anotherReceiver = anotherConsumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumers to connect and set their positions at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                        Assert.That(async () => await anotherReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(eventBatch.Length), $"The number of received events in consumer group { consumer.ConsumerGroup } did not match the batch size.");

                        receivedEvents.Clear();
                        index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await anotherReceiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(eventBatch.Length), $"The number of received events in consumer group { anotherConsumer.ConsumerGroup } did not match the batch size.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(8)]
        public async Task ReceiveStopsWhenMaximumWaitTimeIsReached(int maximumWaitTimeInSecs)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumers to connect and set their positions at the
                        // end of the event stream.

                        await receiver.ReceiveAsync(1, TimeSpan.Zero);

                        // The consumer will wait until maximum wait time is reached because there are no messages to receive.

                        DateTime startTime = DateTime.UtcNow;

                        await receiver.ReceiveAsync(1, TimeSpan.FromSeconds(maximumWaitTimeInSecs));

                        var elapsedTime = DateTime.UtcNow.Subtract(startTime).TotalSeconds;

                        Assert.That(elapsedTime, Is.GreaterThan(maximumWaitTimeInSecs - 0.1));
                        Assert.That(elapsedTime, Is.LessThan(maximumWaitTimeInSecs + 5));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(3)]
        [TestCase(7)]
        [TestCase(9)]
        public async Task ReceiveStopsWhenDefaultMaximumWaitTimeIsReachedIfMaximumWaitTimeIsNotProvided(int defaultMaximumWaitTimeInSecs)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();
                    var consumerOptions = new EventHubConsumerClientOptions
                    {
                        DefaultMaximumReceiveWaitTime = TimeSpan.FromSeconds(defaultMaximumWaitTimeInSecs)
                    };

                    await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connectionString, consumerOptions))
                    await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        var maximumWaitTimeInSecs = 10;

                        // Initiate an operation to force the consumers to connect and set their positions at the
                        // end of the event stream.

                        await receiver.ReceiveAsync(1, TimeSpan.Zero);

                        // The consumer will wait until default maximum wait time is reached because there are no messages to receive.

                        DateTime startTime = DateTime.UtcNow;

                        await receiver.ReceiveAsync(1);

                        var elapsedTime = DateTime.UtcNow.Subtract(startTime).TotalSeconds;

                        Assert.That(elapsedTime, Is.GreaterThan(defaultMaximumWaitTimeInSecs - 0.1));
                        Assert.That(elapsedTime, Is.LessThan(defaultMaximumWaitTimeInSecs + 5));

                        // The consumer will wait until maximum wait time is reached because there are no messages to receive.

                        startTime = DateTime.UtcNow;

                        await receiver.ReceiveAsync(1, TimeSpan.FromSeconds(maximumWaitTimeInSecs));

                        elapsedTime = DateTime.UtcNow.Subtract(startTime).TotalSeconds;

                        Assert.That(elapsedTime, Is.GreaterThan(maximumWaitTimeInSecs - 0.1));
                        Assert.That(elapsedTime, Is.LessThan(maximumWaitTimeInSecs + 5));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task SmallReceiveWaitTimeDoesNotThrowEventHubsTimeoutException()
        {
            // Issue receives with 1 second so that some of the Receive calls will timeout while creating AMQP link.
            // Even those Receive calls should return NULL instead of bubbling the exception up.

            var receiveTimeoutInSeconds = 1;

            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    IEnumerable<Task> tasks = Enumerable.Range(0, 10)
                        .Select(async i =>
                        {
                            await using (var consumer = new EventHubConsumerClient(EventHubConsumerClient.DefaultConsumerGroupName, connection))
                            await using (var receiver = consumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                            {
                                Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.FromSeconds(receiveTimeoutInSeconds)), Throws.Nothing);
                            }
                        });

                    await Task.WhenAll(tasks);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="PartitionReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverCannotReceiveWhenProxyIsInvalid()
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
                    await using (var invalidProxyReceiver = invalidProxyConsumer.CreatePartitionReceiver(partition, EventPosition.Latest))
                    {
                        Assert.That(async () => await invalidProxyReceiver.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                    }
                }
            }
        }
    }
}
