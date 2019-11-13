// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Messaging.EventHubs.Authorization;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
using Azure.Messaging.EventHubs.Metadata;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionReceiver" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionReceiverTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string consumerGroup)
        {
            Assert.That(() => new PartitionReceiver(consumerGroup, "id", "name", true, TimeSpan.Zero, Mock.Of<TransportConsumer>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesThePartition(string partition)
        {
            Assert.That(() => new PartitionReceiver("group", partition, "name", true, TimeSpan.Zero, Mock.Of<TransportConsumer>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHub(string eventHubName)
        {
            Assert.That(() => new PartitionReceiver("group", "id", eventHubName, true, TimeSpan.Zero, Mock.Of<TransportConsumer>()), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheTransportConsumer()
        {
            Assert.That(() => new PartitionReceiver("group", "id", "name", true, TimeSpan.Zero, null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTrackingLastEnqueuedEvent()
        {
            var expected = true;
            var receiver = new PartitionReceiver("group", "id", "name", expected, TimeSpan.Zero, Mock.Of<TransportConsumer>());

            Assert.That(GetTrackingLastEnqueuedEvent(receiver), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorSetsTheDefaultMaximumReceiveWaitTime()
        {
            var expected = TimeSpan.FromMilliseconds(270);
            var receiver = new PartitionReceiver("group", "id", "name", false, expected, Mock.Of<TransportConsumer>());

            Assert.That(GetDefaultMaximumReceiveWaitTime(receiver), Is.EqualTo(expected));
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConnectionConstructorInitializesPublicState()
        {
            var consumerGroup = "group";
            var partition = "0";
            var eventHubName = "the-hub";
            var receiver = new PartitionReceiver(consumerGroup, partition, eventHubName, true, TimeSpan.Zero, Mock.Of<TransportConsumer>());

            Assert.That(receiver.ConsumerGroup, Is.SameAs(consumerGroup), "The consumer group should have been set.");
            Assert.That(receiver.PartitionId, Is.SameAs(partition), "The partition should have been set.");
            Assert.That(receiver.EventHubName, Is.SameAs(eventHubName), "The Event Hub name should have been set.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReadLastEnqueuedEventInformation" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void ReadLastEnqueuedEventInformationRespectsTheTrackingEnabledFlag(bool trackingEnabled)
        {
            var receiver = new PartitionReceiver("group", "id", "name", trackingEnabled, TimeSpan.Zero, Mock.Of<TransportConsumer>());

            if (trackingEnabled)
            {
                var metrics = receiver.ReadLastEnqueuedEventInformation();
                Assert.That(metrics.EventHubName, Is.Not.Null.And.Not.Empty, "The Event Hub name should be present.");
                Assert.That(metrics.PartitionId, Is.Not.Null.And.Not.Empty, "The partition id should be present.");
            }
            else
            {
                Assert.That(() => receiver.ReadLastEnqueuedEventInformation(), Throws.TypeOf<InvalidOperationException>(), "Last enqueued event information cannot be read if tracking is not enabled.");
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReadLastEnqueuedEventInformation" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadLastEnqueuedEventInformationPopulatesFromTheLastReceivedEvent()
        {
            var lastEvent = new EventData
            (
                eventBody: Array.Empty<byte>(),
                lastPartitionSequenceNumber: 12345,
                lastPartitionOffset: 89101,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                lastPartitionInformationRetrievalTime: DateTimeOffset.Parse("2012-03-04T08:49:00Z")
            );

            var eventHub = "someHub";
            var partition = "PART";
            var transportMock = new ObservableTransportConsumerMock { LastReceivedEvent = lastEvent };
            var receiver = new PartitionReceiver("group", partition, eventHub, true, TimeSpan.Zero, transportMock);
            var metrics = receiver.ReadLastEnqueuedEventInformation();

            Assert.That(metrics.EventHubName, Is.EqualTo(eventHub), "The Event Hub name should match.");
            Assert.That(metrics.PartitionId, Is.EqualTo(partition), "The partition id should match.");
            Assert.That(metrics.LastEnqueuedSequenceNumber, Is.EqualTo(lastEvent.LastPartitionSequenceNumber), "The sequence number should match.");
            Assert.That(metrics.LastEnqueuedOffset, Is.EqualTo(lastEvent.LastPartitionOffset), "The offset should match.");
            Assert.That(metrics.LastEnqueuedTime, Is.EqualTo(lastEvent.LastPartitionEnqueuedTime), "The enqueue time should match.");
            Assert.That(metrics.InformationReceived, Is.EqualTo(lastEvent.LastPartitionInformationRetrievalTime), "The retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(-32767)]
        [TestCase(-1)]
        [TestCase(0)]
        public void ReceiveAsyncValidatesTheMaximumCount(int maximumMessageCount)
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var receiver = new PartitionReceiver("group", "0", "hub", true, TimeSpan.Zero, transportConsumer);
            var expectedWaitTime = TimeSpan.FromDays(1);

            using var cancellation = new CancellationTokenSource();
            Assert.That(async () => await receiver.ReceiveAsync(maximumMessageCount, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-1000)]
        [TestCase(-10000)]
        public void ReceiveAsyncValidatesTheMaximumWaitTime(int timeSpanDelta)
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var receiver = new PartitionReceiver("group", "0", "hub", true, TimeSpan.Zero, transportConsumer);
            var expectedWaitTime = TimeSpan.FromMilliseconds(timeSpanDelta);

            using var cancellation = new CancellationTokenSource();
            Assert.That(async () => await receiver.ReceiveAsync(32, expectedWaitTime, cancellation.Token), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.ReceiveAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task ReceiveAsyncInvokesTheTransportConsumer()
        {
            var defaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(8);
            var transportConsumer = new ObservableTransportConsumerMock();
            var receiver = new PartitionReceiver("group", "0", "hub", true, defaultMaximumReceiveWaitTime, transportConsumer);
            var expectedMessageCount = 45;

            using var cancellation = new CancellationTokenSource();
            await receiver.ReceiveAsync(expectedMessageCount, null, cancellation.Token);

            (var actualMessageCount, TimeSpan? actualWaitTime) = transportConsumer.ReceiveCalledWith;

            Assert.That(actualMessageCount, Is.EqualTo(expectedMessageCount), "The message counts should match.");
            Assert.That(actualWaitTime, Is.EqualTo(defaultMaximumReceiveWaitTime), "The wait time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task CloseAsyncClosesTheTransportConsumer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var receiver = new PartitionReceiver("group", "0", "hub", true, TimeSpan.Zero, transportConsumer);

            await receiver.CloseAsync();
            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiver.CloseAsync" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloseClosesTheTransportConsumer()
        {
            var transportConsumer = new ObservableTransportConsumerMock();
            var receiver = new PartitionReceiver("group", "0", "hub", true, TimeSpan.Zero, transportConsumer);

            receiver.Close();
            Assert.That(transportConsumer.WasCloseCalled, Is.True);
        }

        /// <summary>
        ///   Retrieves the TrackingLastEnqueuedEvent for the receiver using its private accessor.
        /// </summary>
        ///
        private static bool GetTrackingLastEnqueuedEvent(PartitionReceiver receiver) =>
            (bool)
                typeof(PartitionReceiver)
                    .GetProperty("TrackingLastEnqueuedEvent", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(receiver);

        /// <summary>
        ///   Retrieves the DefaultMaximumReceiveWaitTime for the receiver using its private accessor.
        /// </summary>
        ///
        private static TimeSpan GetDefaultMaximumReceiveWaitTime(PartitionReceiver receiver) =>
            (TimeSpan)
                typeof(PartitionReceiver)
                    .GetProperty("DefaultMaximumReceiveWaitTime", BindingFlags.Instance | BindingFlags.NonPublic)
                    .GetValue(receiver);

        /// <summary>
        ///   Allows for observation of operations performed by the consumer for testing purposes.
        /// </summary>
        ///
        private class ObservableTransportConsumerMock : TransportConsumer
        {
            public bool WasCloseCalled = false;
            public (int, TimeSpan?) ReceiveCalledWith;

            public new EventData LastReceivedEvent
            {
                get => base.LastReceivedEvent;
                set => base.LastReceivedEvent = value;
            }

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount,
                                                                      TimeSpan? maximumWaitTime,
                                                                      CancellationToken cancellationToken)
            {
                ReceiveCalledWith = (maximumMessageCount, maximumWaitTime);
                return Task.FromResult(Enumerable.Empty<EventData>());
            }

            public override Task CloseAsync(CancellationToken cancellationToken)
            {
                WasCloseCalled = true;
                return Task.CompletedTask;
            }
        }
    }
}
