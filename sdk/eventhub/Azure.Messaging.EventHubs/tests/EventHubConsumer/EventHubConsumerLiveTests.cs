﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventHubConsumer" />
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
    public class EventHubConsumerLiveTests
    {
        /// <summary>The maximum number of times that the receive loop should iterate to collect the expected number of messages.</summary>
        private const int ReceiveRetryLimit = 10;

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ConsumerWithNoOptionsCanReceive(TransportType transportType)
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { TransportType = transportType }))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ConsumerWithOptionsCanReceive(TransportType transportType)
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubConsumerOptions { Identifier = "FakeIdentifier" };

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { TransportType = transportType }))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, options))
                    {
                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveCanReadOneEventBatch()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three"))
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        index = 0;

                        Assert.That(receivedEvents, Is.Not.Empty, "There should have been a set of events received.");

                        foreach (var receivedEvent in receivedEvents)
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
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveCanReadMultipleEventBatches()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
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

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events, receive and validate them.

                        await producer.SendAsync(eventBatch);

                        // Recieve and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;
                        var batchNumber = 1;
                        var batchSize = (eventBatch.Length / 3);

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < eventBatch.Length + ReceiveRetryLimit))
                        {
                            var currentReceiveBatch = await consumer.ReceiveAsync(batchSize, TimeSpan.FromMilliseconds(25));
                            receivedEvents.AddRange(currentReceiveBatch);

                            Assert.That(currentReceiveBatch, Is.Not.Empty, $"There should have been a set of events received for batch number: { batchNumber }.");

                            ++batchNumber;
                        }

                        index = 0;

                        foreach (var receivedEvent in receivedEvents)
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
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveCanReadSingleEvent()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("Lonely"))
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        index = 0;

                        foreach (var receivedEvent in receivedEvents)
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
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveCanReadSingleZeroLengthEvent()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
                {
                    new EventData(new byte[0])
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        index = 0;

                        foreach (var receivedEvent in receivedEvents)
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
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveCanReadOneZeroLengthEventBatch()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
                {
                    new EventData(new byte[0]),
                    new EventData(new byte[0]),
                    new EventData(new byte[0])
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        index = 0;

                        Assert.That(receivedEvents, Is.Not.Empty, "There should have been a set of events received.");

                        foreach (var receivedEvent in receivedEvents)
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
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveCanReadEventWithCustomProperties()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
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

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        index = 0;

                        foreach (var receivedEvent in receivedEvents)
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
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ConsumerCannotReceiveWhenClosed(bool sync)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[] { new EventData(Encoding.UTF8.GetBytes("This message won't be sent")) };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        if (sync)
                        {
                            consumer.Close();
                        }
                        else
                        {
                            await consumer.CloseAsync();
                        }

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ObjectDisposedException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
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
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, invalidPartition, EventPosition.Latest))
                    {
                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
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
        public async Task ConsumerCannotReceiveMoreThanMaximumMessageCountMessages(int maximumMessageCount)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = Enumerable
                    .Range(0, 20 * maximumMessageCount)
                    .Select(index => new EventData(new byte[10]))
                    .ToList();

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events.

                        var index = 0;

                        while (index < eventBatch.Count)
                        {
                            var receivedEvents = (await consumer.ReceiveAsync(maximumMessageCount, TimeSpan.FromSeconds(10))).ToList();
                            index += receivedEvents.Count;

                            Assert.That(receivedEvents.Count, Is.LessThanOrEqualTo(maximumMessageCount));
                        }
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReceiveFromNonExistentConsumerGroup()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var consumer = client.CreateConsumer("nonExistentConsumerGroup", partition, EventPosition.Latest))
                    {
                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.MessagingEntityNotFoundException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task NoOwnerLevelConsumerCannotStartReceiving()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var exclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });

                    await exclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOwnerLevelConsumerCannotStartReceiving()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var higherExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });

                    await higherExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    var lowerExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 10 });

                    Assert.That(async () => await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOrNoOwnerLevelConsumerCanStartReceivingFromOtherPartitions()
        {
            await using (var scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partitionIds = await client.GetPartitionIdsAsync();

                    var higherExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[0], EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });

                    await higherExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    var lowerExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[1], EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 10 });

                    Assert.That(async () => await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[2], EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task LowerOrNoOwnerLevelConsumerCanStartReceivingFromOtherConsumerGroups()
        {
            var consumerGroups = new[]
            {
                "notdefault",
                "notdefault2"
            };

            await using (var scope = await EventHubScope.CreateAsync(1, consumerGroups))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var higherExclusiveConsumer = client.CreateConsumer(consumerGroups[0], partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });

                    await higherExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    var lowerExclusiveConsumer = client.CreateConsumer(consumerGroups[1], partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 10 });

                    Assert.That(async () => await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Test fails in Track One as well")]
        public async Task OwnerConsumerClosesNoOwnerLevelConsumer()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var exclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });
                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest);

                    await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));
                    await exclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Test fails in Track One as well")]
        public async Task OwnerConsumerClosesLowerOwnerLevelConsumer()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var higherExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });
                    var lowerExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 10 });

                    await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));
                    await higherExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    Assert.That(async () => await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task OwnerConsumerDoesNotCloseLowerOrNoOwnerLevelConsumersFromOtherPartitions()
        {
            await using (var scope = await EventHubScope.CreateAsync(3))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partitionIds = await client.GetPartitionIdsAsync();

                    var higherExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[0], EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });
                    var lowerExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[1], EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 10 });
                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[2], EventPosition.Latest);

                    await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));
                    await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));
                    await higherExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    Assert.That(async () => await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
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

            await using (var scope = await EventHubScope.CreateAsync(1, consumerGroups))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var higherExclusiveConsumer = client.CreateConsumer(consumerGroups[0], partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });
                    var lowerExclusiveConsumer = client.CreateConsumer(consumerGroups[1], partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 10 });
                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest);

                    await higherExclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    Assert.That(async () => await lowerExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Test fails in Track One as well")]
        public async Task FailingToCreateOwnerConsumerDoesNotCompromiseReceiveBehavior()
        {
            await using (var scope = await EventHubScope.CreateAsync(2, "anotherConsumerGroup"))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partitionIds = await client.GetPartitionIdsAsync();

                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[0], EventPosition.Latest);
                    var exclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[0], EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });

                    await exclusiveConsumer.ReceiveAsync(1, TimeSpan.FromSeconds(2));

                    // Failing at consumer creation should not compromise future ReceiveAsync calls.

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());

                    // It should be possible to create new valid consumers.

                    var newExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[0], EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 10 });
                    var anotherPartitionConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[1], EventPosition.Latest);
                    var anotherConsumerGroupConsumer = client.CreateConsumer("anotherConsumerGroup", partitionIds[0], EventPosition.Latest);

                    Assert.That(async () => await newExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await anotherPartitionConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    Assert.That(async () => await anotherConsumerGroupConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    // Proper exceptions should be thrown as well.

                    var invalidPartitionConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "XYZ", EventPosition.Latest);
                    var invalidConsumerGroupConsumer = client.CreateConsumer("imNotAConsumerGroup", partitionIds[0], EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());
                    Assert.That(async () => await invalidPartitionConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(async () => await invalidConsumerGroupConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.MessagingEntityNotFoundException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Test fails in Track One as well")]
        public async Task FailingToCreateInvalidPartitionConsumerDoesNotCompromiseReceiveBehavior()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var invalidPartitionConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "XYZ", EventPosition.Latest);

                    // Failing at consumer creation should not compromise future ReceiveAsync calls.

                    Assert.That(async () => await invalidPartitionConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());

                    // It should be possible to create new valid consumers.

                    var exclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });

                    Assert.That(async () => await exclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    // Proper exceptions should be thrown as well.

                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest);
                    var invalidConsumerGroupConsumer = client.CreateConsumer("imNotAConsumerGroup", partition, EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());
                    Assert.That(async () => await invalidPartitionConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(async () => await invalidConsumerGroupConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.MessagingEntityNotFoundException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Test fails in Track One as well")]
        public async Task FailingToCreateInvalidConsumerGroupConsumerDoesNotCompromiseReceiveBehavior()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    var invalidConsumerGroupConsumer = client.CreateConsumer("imNotAConsumerGroup", partition, EventPosition.Latest);

                    // Failing at consumer creation should not compromise future ReceiveAsync calls.

                    Assert.That(async () => await invalidConsumerGroupConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.MessagingEntityNotFoundException>());

                    // It should be possible to create new valid consumers.

                    var exclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, new EventHubConsumerOptions { OwnerLevel = 20 });

                    Assert.That(async () => await exclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                    // Proper exceptions should be thrown as well.

                    var nonExclusiveConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest);
                    var invalidPartitionConsumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, "XYZ", EventPosition.Latest);

                    Assert.That(async () => await nonExclusiveConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.ReceiverDisconnectedException>());
                    Assert.That(async () => await invalidPartitionConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<ArgumentOutOfRangeException>());
                    Assert.That(async () => await invalidConsumerGroupConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.InstanceOf<TrackOne.MessagingEntityNotFoundException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Expected behavior currently under discussion")]
        public async Task ConsumerCanReceiveWhenClientIsClosed()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        client.Close();

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumerCannotReceiveEventsSentToAnotherPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three"))
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partitionIds = await client.GetPartitionIdsAsync();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partitionIds[0] }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[1], EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumer to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

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
                            receivedEvents.AddRange(await consumer.ReceiveAsync(batches * eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents, Is.Empty, "There should not have been a set of events received.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ConsumersInDifferentConsumerGroupsShouldAllReceiveEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1, consumerGroup: "anotherConsumerGroup"))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var eventBatch = new[]
                {
                    new EventData(Encoding.UTF8.GetBytes("One")),
                    new EventData(Encoding.UTF8.GetBytes("Two")),
                    new EventData(Encoding.UTF8.GetBytes("Three"))
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    await using (var anotherConsumer = client.CreateConsumer("anotherConsumerGroup", partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumers to connect and set their positions at the
                        // end of the event stream.

                        Assert.That(async () => await consumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                        Assert.That(async () => await anotherConsumer.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await consumer.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(eventBatch.Length), $"The number of received events in consumer group { consumer.ConsumerGroup } did not match the batch size.");

                        receivedEvents.Clear();
                        index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < ReceiveRetryLimit))
                        {
                            receivedEvents.AddRange(await anotherConsumer.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
                        }

                        Assert.That(receivedEvents.Count, Is.EqualTo(eventBatch.Length), $"The number of received events in consumer group { anotherConsumer.ConsumerGroup } did not match the batch size.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(20)]
        [TestCase(40)]
        [TestCase(60)]
        public async Task ReceiveStopsWhenMaximumWaitTimeIsReached(int maximumWaitTimeInSecs)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest))
                    {
                        // Initiate an operation to force the consumers to connect and set their positions at the
                        // end of the event stream.

                        await consumer.ReceiveAsync(1, TimeSpan.Zero);

                        // The consumer will wait until maximum wait time is reached because there are no messages to receive.

                        var startTime = DateTime.UtcNow;

                        await consumer.ReceiveAsync(1, TimeSpan.FromSeconds(maximumWaitTimeInSecs));

                        var elapsedTime = DateTime.UtcNow.Subtract(startTime).TotalSeconds;

                        Assert.That(elapsedTime, Is.GreaterThan(maximumWaitTimeInSecs - 0.1));
                        Assert.That(elapsedTime, Is.LessThan(maximumWaitTimeInSecs + 5));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubConsumer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(20)]
        [TestCase(40)]
        [TestCase(60)]
        public async Task ReceiveStopsWhenDefaultMaximumWaitTimeIsReachedIfMaximumWaitTimeIsNotProvided(int defaultMaximumWaitTimeInSecs)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();
                    var consumerOptions = new EventHubConsumerOptions
                    {
                        DefaultMaximumReceiveWaitTime = TimeSpan.FromSeconds(defaultMaximumWaitTimeInSecs)
                    };

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    await using (var consumer = client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partition, EventPosition.Latest, consumerOptions))
                    {
                        var maximumWaitTimeInSecs = 10;

                        // Initiate an operation to force the consumers to connect and set their positions at the
                        // end of the event stream.

                        await consumer.ReceiveAsync(1, TimeSpan.Zero);

                        // The consumer will wait until default maximum wait time is reached because there are no messages to receive.

                        var startTime = DateTime.UtcNow;

                        await consumer.ReceiveAsync(1);

                        var elapsedTime = DateTime.UtcNow.Subtract(startTime).TotalSeconds;

                        Assert.That(elapsedTime, Is.GreaterThan(defaultMaximumWaitTimeInSecs - 0.1));
                        Assert.That(elapsedTime, Is.LessThan(defaultMaximumWaitTimeInSecs + 5));

                        // The consumer will wait until maximum wait time is reached because there are no messages to receive.

                        startTime = DateTime.UtcNow;

                        await consumer.ReceiveAsync(1, TimeSpan.FromSeconds(maximumWaitTimeInSecs));

                        elapsedTime = DateTime.UtcNow.Subtract(startTime).TotalSeconds;

                        Assert.That(elapsedTime, Is.GreaterThan(maximumWaitTimeInSecs - 0.1));
                        Assert.That(elapsedTime, Is.LessThan(maximumWaitTimeInSecs + 5));
                    }
                }
            }
        }
    }
}
