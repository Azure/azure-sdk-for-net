// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Processor;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventProcessor" />
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
    public class EventProcessorLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task SingleEventProcessorCanReceive()
        {
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    // Create the event processor hub to collect information about our single
                    // processor host.

                    var hub = new EventProcessorHub(EventHubConsumer.DefaultConsumerGroupName, client);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Send some sets of events to the event hub so our processor can receive
                    // them.

                    var eventSet = new[]
                    {
                        new EventData(Encoding.UTF8.GetBytes("One")),
                        new EventData(Encoding.UTF8.GetBytes("Two")),
                        new EventData(Encoding.UTF8.GetBytes("Three"))
                    };

                    var amountOfSets = 5;
                    var expectedEventsCount = amountOfSets * eventSet.Length;

                    await using (var producer = client.CreateProducer())
                    {
                        for (int i = 0; i < amountOfSets; i++)
                        {
                            await producer.SendAsync(eventSet);
                        }
                    }

                    // Wait a few seconds so the data has enough time to reach the event processor.
                    // TODO: we will need to extend this delay once the load balancing is implemented.

                    await Task.Delay(5000);

                    // Stop receiving events.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(hub.EventsCount.Values.Sum(), Is.EqualTo(expectedEventsCount));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Won't work without load balancing")]
        public async Task MultipleEventProcessorsCanReceive()
        {
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    // Create the event processor hub to collect information about our multiple
                    // processor hosts.

                    var hub = new EventProcessorHub(EventHubConsumer.DefaultConsumerGroupName, client, 3);

                    // Start the event processors.

                    await hub.StartAllAsync();

                    // Send some sets of events to the event hub so our processors can receive
                    // them.

                    var eventSet = new[]
                    {
                        new EventData(Encoding.UTF8.GetBytes("One")),
                        new EventData(Encoding.UTF8.GetBytes("Two")),
                        new EventData(Encoding.UTF8.GetBytes("Three"))
                    };

                    var amountOfSets = 5;
                    var expectedEventsCount = amountOfSets * eventSet.Length;

                    await using (var producer = client.CreateProducer())
                    {
                        for (int i = 0; i < amountOfSets; i++)
                        {
                            await producer.SendAsync(eventSet);
                        }
                    }

                    // Wait a few seconds so the data has enough time to reach the event processors.
                    // TODO: we will need to extend this delay once the load balancing is implemented.

                    await Task.Delay(5000);

                    // Stop receiving events.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(hub.EventsCount.Values.Sum(), Is.EqualTo(expectedEventsCount));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorCanResumeAfterStopping()
        {
            await using (var scope = await EventHubScope.CreateAsync(10))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    // Create the event processor hub to collect information about our single
                    // processor host.

                    var hub = new EventProcessorHub(EventHubConsumer.DefaultConsumerGroupName, client);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Send some events to the event hub so our processor can receive them.

                    var eventsCount = 10;

                    await using (var producer = client.CreateProducer())
                    {
                        var singleEvent = new EventData(Encoding.UTF8.GetBytes("I'm single"));

                        for (int i = 0; i < eventsCount; i++)
                        {
                            await producer.SendAsync(singleEvent);
                        }
                    }

                    // Wait a few seconds so the data has enough time to reach the event processor.
                    // TODO: we will need to extend this delay once the load balancing is implemented.

                    await Task.Delay(5000);

                    // Stop receiving events.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(hub.EventsCount.Values.Sum(), Is.EqualTo(eventsCount));

                    // Clear the counter so we can restart counting from zero.

                    hub.EventsCount.Clear();

                    // Resume the event processor execution.  There are no checkpoints, so we are expecting
                    // to receive the same amount events.

                    await hub.StartAllAsync();

                    // Wait a few seconds so the data has enough time to reach the event processor.
                    // TODO: we will need to extend this delay once the load balancing is implemented.

                    await Task.Delay(5000);

                    // Stop receiving events for good.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(hub.EventsCount.Values.Sum(), Is.EqualTo(eventsCount));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventProcessor" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task EventProcessorClosesPartitionProcessorWhenStopping()
        {
            var partitions = 10;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    // Create the event processor hub to collect information about our single
                    // processor host.

                    var hub = new EventProcessorHub(EventHubConsumer.DefaultConsumerGroupName, client);

                    // Start the event processor.

                    await hub.StartAllAsync();

                    // Assert that no close reason has been set.  This way, we know the partition
                    // processor close method hasn't been called yet.

                    Assert.That(hub.CloseReason.Count, Is.EqualTo(0));

                    // Stop receiving events.

                    await hub.StopAllAsync();

                    // Validate results.

                    Assert.That(hub.CloseReason.Count, Is.EqualTo(partitions));

                    foreach(var kvp in hub.CloseReason)
                    {
                        Assert.That(kvp.Value, Is.EqualTo(PartitionProcessorCloseReason.Shutdown));
                    }
                }
            }
        }
    }
}
