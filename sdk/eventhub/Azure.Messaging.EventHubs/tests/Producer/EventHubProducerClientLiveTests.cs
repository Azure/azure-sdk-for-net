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
        public async Task ProducerCanSendToASpecificPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        EventData[] events = new[] { new EventData(Encoding.UTF8.GetBytes("AWord")) };
                        Assert.That(async () => await producer.SendAsync(events, new SendEventOptions { PartitionId = partition }), Throws.Nothing);
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
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                IEnumerable<EventData> events = Enumerable
                    .Range(0, 25)
                    .Select(index => new EventData(Encoding.UTF8.GetBytes(new string('X', index + 5))));

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    var batchOptions = new SendEventOptions { PartitionKey = "some123key-!d" };
                    Assert.That(async () => await producer.SendAsync(events, batchOptions), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendMultipleSetsOfEventsUsingAPartitionHashKey()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var batchOptions = new SendEventOptions { PartitionKey = "some123key-!d" };

                for (var index = 0; index < 5; ++index)
                {
                    IEnumerable<EventData> events = Enumerable
                        .Range(0, 25)
                        .Select(index => new EventData(Encoding.UTF8.GetBytes(new string((char)(65 + index), index + 5))));

                    var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                    await using (var producer = new EventHubProducerClient(connectionString))
                    {
                        Assert.That(async () => await producer.SendAsync(events, batchOptions), Throws.Nothing, $"Batch { index } should not have thrown an exception.");
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
        public async Task ProducerCanSendAnEventBatchUsingAPartitionHashKey()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                IEnumerable<EventData> events = Enumerable
                    .Range(0, 25)
                    .Select(index => new EventData(Encoding.UTF8.GetBytes(new string('X', index + 5))));

                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var batchOptions = new CreateBatchOptions { PartitionKey = "some123key-!d" };

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync(batchOptions);

                    foreach (EventData eventData in events)
                    {
                        Assert.That(() => batch.TryAdd(eventData), Is.True, "An event was rejected by the batch; all events should be accepted.");
                    }

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
        public async Task ProducerCanSendSingleZeroLengthEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    var singleEvent = new EventData(Array.Empty<byte>());
                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.Nothing);
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   connect to the Event Hubs service and perform operations.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanSendSingleLargeEvent()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString, new EventHubProducerClientOptions { RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(5) } }))
                {
                    // Actual limit is 1046520 for a single event.

                    var singleEvent = new EventData(new byte[100000]);
                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.Nothing);
                }
            }
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
        public async Task ProducerCannotSendSingleEventLargerThanMaximumSize()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    // Actual limit is 1046520 for a single event.

                    var singleEvent = new EventData(new byte[1500000]);
                    EventData[] eventBatch = new[] { new EventData(new byte[1500000]) };

                    Assert.That(async () => await producer.SendAsync(singleEvent), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.MessageSizeExceeded));
                    Assert.That(async () => await producer.SendAsync(eventBatch), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.MessageSizeExceeded));
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
                        new EventData(Array.Empty<byte>()),
                        new EventData(Array.Empty<byte>()),
                        new EventData(Array.Empty<byte>())
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
        public async Task ProducerCanSendZeroLengthEventBatch()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var producer = new EventHubProducerClient(connectionString))
                {
                    using EventDataBatch batch = await producer.CreateBatchAsync();
                    batch.TryAdd(new EventData(Array.Empty<byte>()));

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
        public async Task ProducerCanSendSetToASpecificPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        EventData[] events = new[]
                        {
                            new EventData(Encoding.UTF8.GetBytes("This is a message")),
                            new EventData(Encoding.UTF8.GetBytes("This is another message")),
                            new EventData(Encoding.UTF8.GetBytes("Do we need more messages"))
                        };

                        Assert.That(async () => await producer.SendAsync(events, new SendEventOptions { PartitionId = partition }), Throws.Nothing);
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
        public async Task ProducerCanSendBatchToASpecificPartition()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);

                await using (var connection = new EventHubConnection(connectionString))
                {
                    var partition = (await connection.GetPartitionIdsAsync(DefaultRetryPolicy)).First();

                    await using (var producer = new EventHubProducerClient(connection))
                    {
                        using EventDataBatch batch = await producer.CreateBatchAsync(new CreateBatchOptions { PartitionId = partition });
                        batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is a message")));
                        batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("This is another message")));
                        batch.TryAdd(new EventData(Encoding.UTF8.GetBytes("Do we need more messages")));

                        Assert.That(async () => await producer.SendAsync(batch), Throws.Nothing);
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
                        await producer.SendAsync(new EventData(Encoding.UTF8.GetBytes($"Just a few messages ({ index })")), batchOptions);
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
                    Assert.That(async () => await invalidProxyProducer.SendAsync(new EventData(new byte[1])), Throws.InstanceOf<WebSocketException>().Or.InstanceOf<TimeoutException>());
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
