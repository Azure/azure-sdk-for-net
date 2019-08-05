// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="EventHubProducer" />
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
    public class EventHubProducerLiveTests
    {
        /// <summary>The maximum number of times that the receive loop should iterate to collect the expected number of messages.</summary>
        private const int ReceiveRetryLimit = 10;

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ProducerWithNoOptionsCanSend(TransportType transportType)
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { TransportType = transportType }))
                await using (var producer = client.CreateProducer())
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(TransportType.AmqpTcp)]
        [TestCase(TransportType.AmqpWebSockets)]
        public async Task ProducerWithOptionsCanSend(TransportType transportType)
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var producerOptions = new EventHubProducerOptions { RetryOptions = new RetryOptions { MaximumRetries = 5 } };

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { TransportType = transportType }))
                await using (var producer = client.CreateProducer(producerOptions))
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendToASpecificPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();
                    var producerOptions = new EventHubProducerOptions { PartitionId = partition };

                    await using (var producer = client.CreateProducer(producerOptions))
                    {
                        var events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                        Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendEventsWithCustomProperties()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var events = new[]
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

                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendEventsUsingAPartitionHashKey()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var events = Enumerable
                    .Range(0, 25)
                    .Select(index => new EventData(Encoding.UTF8.GetBytes(new String('X', index + 5))));

                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var batchOptions = new SendOptions { PartitionKey = "some123key-!d" };
                    Assert.That(async () => await producer.SendAsync(events, batchOptions), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendMultipleSetsOfEventsUsingAPartitionHashKey()
        {
            await using (var scope = await EventHubScope.CreateAsync(4))
            {
                var batchOptions = new SendOptions { PartitionKey = "some123key-!d" };

                for (var index = 0; index < 5; ++index)
                {
                    var events = Enumerable
                        .Range(0, 25)
                        .Select(index => new EventData(Encoding.UTF8.GetBytes(new String((char)(65 + index), index + 5))));

                    var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                    await using (var client = new EventHubClient(connectionString))
                    await using (var producer = client.CreateProducer())
                    {
                        Assert.That(async () => await producer.SendAsync(events, batchOptions), Throws.Nothing, $"Batch { index } should not have thrown an exception.");
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatchUsingAPartitionHashKey()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var events = Enumerable
                    .Range(0, 25)
                    .Select(index => new EventData(Encoding.UTF8.GetBytes(new String('X', index + 5))));

                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var batchOptions = new BatchOptions { PartitionKey = "some123key-!d" };

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    using var batch = await producer.CreateBatchAsync(batchOptions);

                    foreach (var eventData in events)
                    {
                        Assert.That(() => batch.TryAdd(eventData), Is.True, "An event was rejected by the batch; all events should be accepted.");
                    }

                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendSingleZeroLengthEvent()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var singleEvent = new EventData(Array.Empty<byte>());
                    var eventSet = new[] { new EventData(new byte[0]) };

                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.Nothing);
                    Assert.That(async () => await producer.SendAsync(eventSet), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendSingleLargeEvent()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event.
                    var singleEvent = new EventData(new byte[100000]);

                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendSingleLargeEventInASet()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event.
                    var eventSet = new[] { new EventData(new byte[100000]) };

                    Assert.That(async () => await producer.SendAsync(eventSet), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotSendSingleEventLargerThanMaximumSize()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event.
                    var singleEvent = new EventData(new byte[1500000]);
                    var eventBatch = new[] { new EventData(new byte[1500000]) };

                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.TypeOf<MessageSizeExceededException>());
                    Assert.That(async () => await producer.SendAsync(eventBatch), Throws.TypeOf<MessageSizeExceededException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendASetOfEvents()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var events = new[]
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
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendZeroLengthSet()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var events = new[]
                    {
                        new EventData(Array.Empty<byte>()),
                        new EventData(Array.Empty<byte>()),
                        new EventData(Array.Empty<byte>())
                    };

                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendLargeSet()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event.
                    var events = new[]
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
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendAnEventBatch()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    using var batch = await producer.CreateBatchAsync();

                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is a message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is another message")));
                    batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("So many messages")));

                    Assert.That(batch.Count, Is.EqualTo(3), "The batch should contain all 3 events.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendZeroLengthEventBatch()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    using var batch = await producer.CreateBatchAsync();
                    batch.TryAdd(new EventData(new byte[0]));

                    Assert.That(batch.Count, Is.EqualTo(1), "The batch should contain a single event.");
                    Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendLargeEventBatch()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString, new EventHubClientOptions { RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                await using (var producer = client.CreateProducer())
                {
                    using var batch = await producer.CreateBatchAsync();

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
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotSendSetLargerThanMaximumSize()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event.
                    var events = new[]
                    {
                        new EventData(new byte[1500000 / 3]),
                        new EventData(new byte[1500000 / 3]),
                        new EventData(new byte[1500000 / 3])
                    };

                    Assert.That(async () => await producer.SendAsync(events), Throws.TypeOf<MessageSizeExceededException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendSetToASpecificPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();
                    var producerOptions = new EventHubProducerOptions { PartitionId = partition };

                    await using (var producer = client.CreateProducer(producerOptions))
                    {
                        var events = new[]
                        {
                            new EventData(Encoding.UTF8.GetBytes("This is a message")),
                            new EventData(Encoding.UTF8.GetBytes("This is another message")),
                            new EventData(Encoding.UTF8.GetBytes("Do we need more messages"))
                        };

                        Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendWhenPartitionIsNull()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var producerOptions = new EventHubProducerOptions { PartitionId = null };

                    await using (var producer = client.CreateProducer(producerOptions))
                    {
                        var events = new[] { new EventData(Encoding.UTF8.GetBytes("Will it work")) };
                        Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ProducerCannotSendWhenClosed(bool sync)
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("Dummy event")) };
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);

                    if (sync)
                    {
                        producer.Close();
                    }
                    else
                    {
                        await producer.CloseAsync();
                    }

                    Assert.That(async () => await producer.SendAsync(events), Throws.TypeOf<ObjectDisposedException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
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
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("Lorem Ipsum")) };

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = invalidPartition }))
                    {
                        Assert.That(async () => await producer.SendAsync(events), Throws.TypeOf<ArgumentOutOfRangeException>());
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task SendUpdatesPartitionProperties()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partition = (await client.GetPartitionIdsAsync()).First();
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("I should update stuff")) };

                    await using (var producer = client.CreateProducer(new EventHubProducerOptions { PartitionId = partition }))
                    {
                        // Sending events beforehand so the partition has some information.

                        await producer.SendAsync(events);

                        var oldPartitionProperties = await client.GetPartitionPropertiesAsync(partition);

                        Assert.That(oldPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        await producer.SendAsync(events);

                        var newPartitionProperties = await client.GetPartitionPropertiesAsync(partition);

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
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task SendDoesNotUpdatePartitionPropertiesWhenSendingToDifferentPartition()
        {
            await using (var scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var partitionIds = await client.GetPartitionIdsAsync();
                    var events = new[] { new EventData(Encoding.UTF8.GetBytes("I should not update stuff")) };

                    await using (var producer0 = client.CreateProducer(new EventHubProducerOptions { PartitionId = partitionIds[0] }))
                    await using (var producer1 = client.CreateProducer(new EventHubProducerOptions { PartitionId = partitionIds[1] }))
                    {
                        // Sending events beforehand so the partition has some information.

                        await producer0.SendAsync(events);

                        var oldPartitionProperties = await client.GetPartitionPropertiesAsync(partitionIds[0]);

                        Assert.That(oldPartitionProperties, Is.Not.Null, "A set of partition properties should have been returned.");

                        await producer1.SendAsync(events);

                        var newPartitionProperties = await client.GetPartitionPropertiesAsync(partitionIds[0]);

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
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ProducerDoesNotSendToSpecificPartitionWhenPartitionIdIsNotSpecified(bool nullPartition)
        {
            var partitions = 10;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                {
                    var producerOptions = new EventHubProducerOptions { };

                    if (nullPartition)
                    {
                        producerOptions.PartitionId = null;
                    }

                    await using (var producer = client.CreateProducer(producerOptions))
                    {
                        var batches = 30;
                        var partitionIds = await client.GetPartitionIdsAsync();
                        var partitionsCount = 0;
                        var consumers = new List<EventHubConsumer>();

                        try
                        {
                            for (var index = 0; index < partitions; index++)
                            {
                                consumers.Add(client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[index], EventPosition.Latest));

                                // Initiate an operation to force the consumer to connect and set its position at the
                                // end of the event stream.

                                await consumers[index].ReceiveAsync(1, TimeSpan.Zero);
                            }

                            // Send the batches of events.

                            for (var index = 0; index < batches; index++)
                            {
                                await producer.SendAsync(new EventData(Encoding.UTF8.GetBytes("It's not healthy to send so many messages")));
                            }

                            // Receive the events; because there is some non-determinism in the messaging flow, the
                            // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                            // to account for availability delays.

                            foreach (var consumer in consumers)
                            {
                                var receivedEvents = new List<EventData>();
                                var index = 0;

                                while (++index < ReceiveRetryLimit)
                                {
                                    receivedEvents.AddRange(await consumer.ReceiveAsync(batches + 10, TimeSpan.FromMilliseconds(25)));
                                }

                                if (receivedEvents.Count > 0)
                                {
                                    partitionsCount++;
                                }
                            }
                        }
                        finally
                        {
                            await Task.WhenAll(consumers.Select(consumer => consumer.CloseAsync()));
                        }

                        Assert.That(partitionsCount, Is.GreaterThan(1));
                    }
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerSendsEventsInTheSameSetToTheSamePartition()
        {
            var partitions = 10;

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var eventBatch = Enumerable
                        .Range(0, 30)
                        .Select(index => new EventData(Encoding.UTF8.GetBytes("I'm getting used to this amount of messages")))
                        .ToList();

                    var partitionIds = await client.GetPartitionIdsAsync();
                    var partitionsCount = 0;
                    var receivedEventsCount = 0;
                    var consumers = new List<EventHubConsumer>();

                    try
                    {
                        for (var index = 0; index < partitions; index++)
                        {
                            consumers.Add(client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[index], EventPosition.Latest));

                            // Initiate an operation to force the consumer to connect and set its position at the
                            // end of the event stream.

                            await consumers[index].ReceiveAsync(1, TimeSpan.Zero);
                        }

                        // Send the batch of events.

                        await producer.SendAsync(eventBatch);

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        foreach (var consumer in consumers)
                        {
                            var receivedEvents = new List<EventData>();
                            var index = 0;

                            while (++index < ReceiveRetryLimit)
                            {
                                receivedEvents.AddRange(await consumer.ReceiveAsync(eventBatch.Count + 10, TimeSpan.FromMilliseconds(25)));
                            }

                            if (receivedEvents.Count > 0)
                            {
                                partitionsCount++;
                                receivedEventsCount += receivedEvents.Count;
                            }
                        }
                    }
                    finally
                    {
                        foreach (var consumer in consumers)
                        {
                            consumer.Close();
                        }
                    }

                    Assert.That(partitionsCount, Is.EqualTo(1));
                    Assert.That(receivedEventsCount, Is.EqualTo(eventBatch.Count));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerSendsEventsWithTheSamePartitionHashKeyToTheSamePartition()
        {
            var partitions = 10;
            var partitionKey = "some123key-!d";

            await using (var scope = await EventHubScope.CreateAsync(partitions))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var batches = 5;
                    var partitionIds = await client.GetPartitionIdsAsync();
                    var partitionsCount = 0;
                    var receivedEventsCount = 0;
                    var consumers = new List<EventHubConsumer>();

                    try
                    {
                        for (var index = 0; index < partitions; index++)
                        {
                            consumers.Add(client.CreateConsumer(EventHubConsumer.DefaultConsumerGroupName, partitionIds[index], EventPosition.Latest));

                            // Initiate an operation to force the consumer to connect and set its position at the
                            // end of the event stream.

                            await consumers[index].ReceiveAsync(1, TimeSpan.Zero);
                        }

                        // Send the batches of events.

                        var batchOptions = new SendOptions { PartitionKey = partitionKey };

                        for (var index = 0; index < batches; index++)
                        {
                            await producer.SendAsync(new EventData(Encoding.UTF8.GetBytes($"Just a few messages ({ index })")), batchOptions);
                        }

                        // Receive the events; because there is some non-determinism in the messaging flow, the
                        // sent events may not be immediately available.  Allow for a small number of attempts to receive, in order
                        // to account for availability delays.

                        foreach (var consumer in consumers)
                        {
                            var receivedEvents = new List<EventData>();
                            var index = 0;

                            while (++index < ReceiveRetryLimit)
                            {
                                receivedEvents.AddRange(await consumer.ReceiveAsync(batches + 10, TimeSpan.FromMilliseconds(25)));
                            }

                            if (receivedEvents.Count > 0)
                            {
                                partitionsCount++;
                                receivedEventsCount += receivedEvents.Count;

                                foreach (var receivedEvent in receivedEvents)
                                {
                                    Assert.That(receivedEvent.PartitionKey, Is.EqualTo(partitionKey));
                                }
                            }
                        }
                    }
                    finally
                    {
                        foreach (var consumer in consumers)
                        {
                            consumer.Close();
                        }
                    }

                    Assert.That(partitionsCount, Is.EqualTo(1));
                    Assert.That(receivedEventsCount, Is.EqualTo(batches));
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        [Ignore("Expected behavior currently under discussion")]
        public async Task ProducerCanSendWhenClientIsClosed()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    client.Close();

                    var events = new EventData(Encoding.UTF8.GetBytes("Do not delete me!"));
                    Assert.That(async () => await producer.SendAsync(events), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCannotSendWhenProxyIsInvalid()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);
                var clientOptions = new EventHubClientOptions
                {
                    Proxy = new WebProxy("http://1.2.3.4:9999"),
                    TransportType = TransportType.AmqpWebSockets,
                    RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(2) }
                };

                await using (var invalidProxyClient = new EventHubClient(connectionString, clientOptions))
                await using (var invalidProxyProducer = invalidProxyClient.CreateProducer())
                {
                    Assert.That(async () => await invalidProxyProducer.SendAsync(new EventData(new byte[1])), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
                }
            }
        }
    }
}
