// Copyright (c) Microsoft Corporation. All rights reserved.
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
    ///   The suite of live tests for the <see cref="EventReceiver" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a depenency on live Azure services and may
    ///   incur costs for the assocaied Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [NonParallelizable]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class EventReceiverLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="EventReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverWithNoOptionsCanReceive()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var receiver = client.CreateReceiver(partition))
                    {
                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventReceiver" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ReceiverWithOptionsCanReceive()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                var options = new EventReceiverOptions
                {
                    ConsumerGroup = "$Default",
                    BeginReceivingAt = EventPosition.NewEventsOnly
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var receiver = client.CreateReceiver(partition, options))
                    {
                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventReceiver" /> is able to
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

                var receiverOptions = new EventReceiverOptions
                {
                    BeginReceivingAt = EventPosition.NewEventsOnly
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var sender = client.CreateSender(new EventSenderOptions { PartitionId = partition }))
                    await using (var receiver = client.CreateReceiver(partition, receiverOptions))
                    {
                        // Initiate an operation to force the receiver to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events.

                        await sender.SendAsync(eventBatch);

                        // Recieve and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < 3))
                        {
                            receivedEvents.AddRange(await receiver.ReceiveAsync(eventBatch.Length + 10, TimeSpan.FromMilliseconds(25)));
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
        ///   Verifies that the <see cref="EventReceiver" /> is able to
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

                var receiverOptions = new EventReceiverOptions
                {
                    BeginReceivingAt = EventPosition.NewEventsOnly
                };

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();

                    await using (var sender = client.CreateSender(new EventSenderOptions { PartitionId = partition }))
                    await using (var receiver = client.CreateReceiver(partition, receiverOptions))
                    {
                        // Initiate an operation to force the receiver to connect and set its position at the
                        // end of the event stream.

                        Assert.That(async () => await receiver.ReceiveAsync(1, TimeSpan.Zero), Throws.Nothing);

                        // Send the batch of events, receive and validate them.

                        await sender.SendAsync(eventBatch);

                        // Recieve and validate the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        var receivedEvents = new List<EventData>();
                        var index = 0;
                        var batchNumber = 1;
                        var batchSize = (eventBatch.Length / 3);

                        while ((receivedEvents.Count < eventBatch.Length) && (++index < eventBatch.Length + 3))
                        {
                            var currentReceiveBatch = await receiver.ReceiveAsync(batchSize, TimeSpan.FromMilliseconds(25));
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
    }
}
