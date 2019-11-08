﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Errors;
using Moq;
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
        [TestCase(null)]
        [TestCase("")]
        public void ConstructorValidatesTheEventHubName(string value)
        {
            Assert.That(() => new PartitionContext(value, "test"), Throws.InstanceOf<ArgumentException>(), "The constructor with consumer should validate.");
            Assert.That(() => new PartitionContext(value, "test", Mock.Of<TransportConsumer>()), Throws.InstanceOf<ArgumentException>(), "The constructor with no consumer should validate.");
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
            Assert.That(() => new PartitionContext("hub-name", value), Throws.InstanceOf<ArgumentException>(), "The constructor with consumer should validate.");
            Assert.That(() => new PartitionContext("hub-name", value, Mock.Of<TransportConsumer>()), Throws.InstanceOf<ArgumentException>(), "The constructor with no consumer should validate.");
        }

        /// <summary>
        ///   Verifies functionality of the constructor.
        /// </summary>
        ///
        [Test]
        public void ConstructorValidatesTheConsumer()
        {
            Assert.That(() => new PartitionContext("hub-name", "partition", null), Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionContext.ReadLastEnqueuedEventInformation" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ReadLastEnqueuedEventInformationDelegatesToTheConsumer()
        {
            var lastEvent = new EventData
            (
                eventBody: Array.Empty<byte>(),
                lastPartitionSequenceNumber: 1234,
                lastPartitionOffset: 42,
                lastPartitionEnqueuedTime: DateTimeOffset.Parse("2015-10-27T00:00:00Z"),
                lastPartitionInformationRetrievalTime: DateTimeOffset.Parse("2012-03-04T08:42Z")
            );

            var eventHubName = "hub-name";
            var partitionId = "id-value";
            var mockConsumer = new LastEventConsumerMock(lastEvent);
            var context = new PartitionContext(eventHubName, partitionId, mockConsumer);
            var information = context.ReadLastEnqueuedEventInformation();

            Assert.That(information.EventHubName, Is.EqualTo(eventHubName), "The event hub name should match.");
            Assert.That(information.PartitionId, Is.EqualTo(partitionId), "The partition identifier should match.");
            Assert.That(information.LastEnqueuedSequenceNumber, Is.EqualTo(lastEvent.LastPartitionSequenceNumber), "The sequence number should match.");
            Assert.That(information.LastEnqueuedOffset, Is.EqualTo(lastEvent.LastPartitionOffset), "The offset should match.");
            Assert.That(information.LastEnqueuedTime, Is.EqualTo(lastEvent.LastPartitionEnqueuedTime), "The last enqueue time should match.");
            Assert.That(information.InformationReceived, Is.EqualTo(lastEvent.LastPartitionInformationRetrievalTime), "The retrieval time should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionContext.ReadLastEnqueuedEventInformation" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public async Task TheConsumerIsNotKeptAlive()
        {
            var eventHubName = "hub-name";
            var partitionId = "id-value";
            var mockConsumer = new LastEventConsumerMock(new EventData(Array.Empty<byte>()));
            var context = new PartitionContext(eventHubName, partitionId, mockConsumer);

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
                    Assert.That(() => context.ReadLastEnqueuedEventInformation(), Throws.TypeOf<EventHubsClientClosedException>());
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

            public override Task<IEnumerable<EventData>> ReceiveAsync(int maximumMessageCount, TimeSpan? maximumWaitTime, CancellationToken cancellationToken) => throw new NotImplementedException();
            public override Task CloseAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
        }
    }
}
