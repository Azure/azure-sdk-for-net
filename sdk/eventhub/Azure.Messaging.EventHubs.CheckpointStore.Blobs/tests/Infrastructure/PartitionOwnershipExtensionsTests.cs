// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.CheckpointStore.Blobs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionOwnershipExtensions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionOwnershipExtensionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsFullyQualifiedNamespace()
        {
            var first = new MockPartitionOwnership("namespace1", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId");
            var second = new MockPartitionOwnership("namespace2", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId");

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsEventHubName()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName1", "consumerGroup", "ownerIdentifier", "partitionId");
            var second = new MockPartitionOwnership("namespace", "eventHubName2", "consumerGroup", "ownerIdentifier", "partitionId");

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsConsumerGroup()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup1", "ownerIdentifier", "partitionId");
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup2", "ownerIdentifier", "partitionId");

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsOwnerIdentifier()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier1", "partitionId");
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier2", "partitionId");

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsPartitionId()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId1");
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId2");

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        [TestCase(10, 20)]
        [TestCase(10, null)]
        public void IsEquivalentToDetectsOffset(long? offset1, long? offset2)
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: offset1);
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", offset: offset2);

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        [TestCase(10, 20)]
        [TestCase(10, null)]
        public void IsEquivalentToDetectsSequenceNumber(long? sequenceNumber1, long? sequenceNumber2)
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", sequenceNumber: sequenceNumber1);
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", sequenceNumber: sequenceNumber2);

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsLastModifiedTime()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", lastModifiedTime: DateTimeOffset.Parse("1975-04-04T00:00:00Z"));
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", lastModifiedTime: DateTimeOffset.Parse("1975-04-04T01:00:00Z"));

            Assert.That(first.IsEquivalentTo(second), Is.False);

            var third = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", lastModifiedTime: null);

            Assert.That(first.IsEquivalentTo(third), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsETag()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", eTag: "eTag1");
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", eTag: "eTag2");

            Assert.That(first.IsEquivalentTo(second), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsEqualPartitionOwnership()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", 10, 20, DateTimeOffset.Parse("1975-04-04T00:00:00Z"), "eTag");
            var second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId", 10, 20, DateTimeOffset.Parse("1975-04-04T00:00:00Z"), "eTag");

            Assert.That(first.IsEquivalentTo(second), Is.True);

            // Set the optional parameters to null.

            first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId");
            second = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId");

            Assert.That(first.IsEquivalentTo(second), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsSameInstance()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId");

            Assert.That(first.IsEquivalentTo(first), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsTwoNulls()
        {
            Assert.That(((PartitionOwnership)null).IsEquivalentTo(null), Is.True);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullInstance()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId");

            Assert.That(((PartitionOwnership)null).IsEquivalentTo(first), Is.False);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionOwnershipExtensions.IsEquivalentTo" /> test
        ///   helper.
        /// </summary>
        ///
        [Test]
        public void IsEquivalentToDetectsNullArgument()
        {
            var first = new MockPartitionOwnership("namespace", "eventHubName", "consumerGroup", "ownerIdentifier", "partitionId");

            Assert.That(first.IsEquivalentTo(null), Is.False);
        }

        /// <summary>
        ///   A workaround so we can create <see cref="PartitionOwnership"/> instances.
        ///   This class can be removed once the following issue has been closed: https://github.com/Azure/azure-sdk-for-net/issues/7585
        /// </summary>
        ///
        private class MockPartitionOwnership : PartitionOwnership
        {
            /// <summary>
            ///   Initializes a new instance of the <see cref="MockPartitionOwnership"/> class.
            /// </summary>
            ///
            /// <param name="fullyQualifiedNamespace">The fully qualified Event Hubs namespace this partition ownership is associated with.  This is likely to be similar to <c>{yournamespace}.servicebus.windows.net</c>.</param>
            /// <param name="eventHubName">The name of the specific Event Hub this partition ownership is associated with, relative to the Event Hubs namespace that contains it.</param>
            /// <param name="consumerGroup">The name of the consumer group this partition ownership is associated with.</param>
            /// <param name="ownerIdentifier">The identifier of the associated <see cref="EventProcessor" /> instance.</param>
            /// <param name="partitionId">The identifier of the Event Hub partition this partition ownership is associated with.</param>
            /// <param name="offset">The offset of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="sequenceNumber">The sequence number of the last <see cref="EventData" /> received by the associated partition processor.</param>
            /// <param name="lastModifiedTime">The date and time, in UTC, that the last update was made to this ownership.</param>
            /// <param name="eTag">The entity tag needed to update this ownership.</param>
            ///
            public MockPartitionOwnership(string fullyQualifiedNamespace,
                                          string eventHubName,
                                          string consumerGroup,
                                          string ownerIdentifier,
                                          string partitionId,
                                          long? offset = null,
                                          long? sequenceNumber = null,
                                          DateTimeOffset? lastModifiedTime = null,
                                          string eTag = null) : base(fullyQualifiedNamespace, eventHubName, consumerGroup, ownerIdentifier, partitionId, offset, sequenceNumber, lastModifiedTime, eTag)
            {
            }
        }
    }
}
