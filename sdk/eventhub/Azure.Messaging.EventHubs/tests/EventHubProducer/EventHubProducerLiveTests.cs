// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    ///   These tests have a depenency on live Azure services and may
    ///   incur costs for the assocaied Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class EventHubProducerLiveTests
    {
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
                var producerOptions = new EventHubProducerOptions { Retry = new ExponentialRetry(TimeSpan.FromSeconds(0.25), TimeSpan.FromSeconds(45), 5) };

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
        public async Task ProducerCanSendEventsUsingAPartitionHashHey()
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
        public async Task ProducerCanSendMultipleBatchesOfEventsUsingAPartitionHashHey()
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
        public async Task ProducerCanSendSingleZeroLengthEvent()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var singleEvent = new EventData(new byte[0]);
                    var eventBatch = new[] { new EventData(new byte[0]) };

                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.Nothing);
                    Assert.That(async () => await producer.SendAsync(eventBatch), Throws.Nothing);
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

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event
                    var singleEvent = new EventData(new byte[1000000]);
                    var eventBatch = new[] { new EventData(new byte[1000000]) };

                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.Nothing);
                    Assert.That(async () => await producer.SendAsync(eventBatch), Throws.Nothing);
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
                    // Actual limit is 1046520 for a single event
                    var singleEvent = new EventData(new byte[1500000]);
                    var eventBatch = new[] { new EventData(new byte[1500000]) };

                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.TypeOf<TrackOne.MessageSizeExceededException>());
                    Assert.That(async () => await producer.SendAsync(eventBatch), Throws.TypeOf<TrackOne.MessageSizeExceededException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendBatch()
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
        public async Task ProducerCanSendZeroLengthBatch()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    var events = new[]
                    {
                        new EventData(new byte[0]),
                        new EventData(new byte[0]),
                        new EventData(new byte[0])
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
        public async Task ProducerCanSendLargeBatch()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event
                    var events = new[]
                    {
                        new EventData(new byte[1000000 / 3]),
                        new EventData(new byte[1000000 / 3]),
                        new EventData(new byte[1000000 / 3])
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
        public async Task ProducerCannotSendBatchLargerThanMaximumSize()
        {
            await using (var scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = TestEnvironment.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var client = new EventHubClient(connectionString))
                await using (var producer = client.CreateProducer())
                {
                    // Actual limit is 1046520 for a single event
                    var events = new[]
                    {
                        new EventData(new byte[1500000 / 3]),
                        new EventData(new byte[1500000 / 3]),
                        new EventData(new byte[1500000 / 3])
                    };

                    Assert.That(async () => await producer.SendAsync(events), Throws.TypeOf<TrackOne.MessageSizeExceededException>());
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducer" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendBatchToASpecificPartition()
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
    }
}
