// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionContext" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionContextTests
    {
        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConsumer()
        {
            Assert.That(() => new PartitionContext("fqns", "hub", "consumerGroup", "partition", null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheNamespace(string value)
        {
            Assert.That(() => new PartitionContext(value, "hub", "consumerGroup", "partition"), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHub(string value)
        {
            Assert.That(() => new PartitionContext("fqns", value, "consumerGroup", "partition"), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheConsumerGroup(string value)
        {
            Assert.That(() => new PartitionContext("fqns", "hub", value, "partition"), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesThePartition(string value)
        {
            Assert.That(() => new PartitionContext("fqns", "hub", "consumerGroup", value), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionContext.ReadLastEnqueuedEventProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadLastEnqueuedEventPropertiesDelegatesToTheConsumer()
        {
            var lastEvent = new EventData
            (
                eventBody: new BinaryData(Array.Empty<byte>()),
                lastPartitionSequenceNumber: 1234,
                lastPartitionOffset: "42",
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                lastPartitionPropertiesRetrievalTime: DateTimeOffset.Parse("2012-03-04T08:42Z")
            );

            var mockConsumer = new LastEventConsumerMock(lastEvent);
            var context = new PartitionContext("fqns", "hub", "consumerGroup", "partition", mockConsumer);
            var information = context.ReadLastEnqueuedEventProperties();

            Assert.That(information.SequenceNumber, Is.EqualTo(lastEvent.LastPartitionSequenceNumber), "The sequence number should match.");
            Assert.That(information.OffsetString, Is.EqualTo(lastEvent.LastPartitionOffset), "The offset should match.");
            Assert.That(information.EnqueuedTime, Is.EqualTo(lastEvent.LastPartitionEnqueuedTime), "The last enqueue time should match.");
            Assert.That(information.LastReceivedTime, Is.EqualTo(lastEvent.LastPartitionPropertiesRetrievalTime), "The retrieval time should match.");
            Assert.That(mockConsumer.IsClosed, Is.False, "The consumer should not have been closed or disposed of.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionContext.ReadLastEnqueuedEventProperties" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task TheConsumerIsNotKeptAlive()
        {
            var mockConsumer = new LastEventConsumerMock(new EventData(new BinaryData(Array.Empty<byte>())));
            var context = new PartitionContext("fqns", "hub", "consumerGroup", "partition", mockConsumer);

            // Attempt to clear out the consumer and force GC.

            mockConsumer = null;

            // Because cleanup may be non-deterministic, allow a small set of
            // retries.

            var attempts = 0;
            var maxAttempts = 5;

            while (attempts <= maxAttempts)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));

                GC.Collect();
                GC.WaitForPendingFinalizers();

                try
                {
                    Assert.That(() => context.ReadLastEnqueuedEventProperties(), Throws.InstanceOf<EventHubsException>().And.Property(nameof(EventHubsException.Reason)).EqualTo(EventHubsException.FailureReason.ClientClosed));
                }
                catch (AssertionException)
                {
                    if (++attempts <= maxAttempts)
                    {
                        continue;
                    }

                    throw;
                }

                // If things have gotten here, the test passes.

                break;
            }
        }

        /// <summary>
        ///   Allows for setting the last received event by the consumer
        ///   for testing purposes.
        /// </summary>
        ///
        private class LastEventConsumerMock : TransportConsumer
        {
            public LastEventConsumerMock(EventData lastEvent)
            {
                LastReceivedEvent = lastEvent;
            }

            public override Task<IReadOnlyList<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken) => throw new NotImplementedException();
            public override Task CloseAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
        }
    }
}
