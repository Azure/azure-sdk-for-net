// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Experimental.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="IdempotentProducerOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class IdempotentProducerOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="IdempotentProducerOptions.ToCoreOptions" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void ToCoreOptionsCopiesProperties()
        {
            var options = new IdempotentProducerOptions
            {
                Identifier = "Test-123",
                EnableIdempotentPartitions = true,
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(36) }
            };

            options.PartitionOptions.Add("0", new PartitionPublishingOptions
            {
                OwnerLevel = 3,
                ProducerGroupId = 99,
                StartingSequenceNumber = 42
            });

            var clone = options.ToCoreOptions();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier should match.");
            Assert.That(clone.EnableIdempotentPartitions, Is.EqualTo(options.EnableIdempotentPartitions), "The flag to enable idempotent publishing should have been copied.");
            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.PartitionOptions, Is.Not.SameAs(options.PartitionOptions), "The partitions options of the clone should be a copy, not the same instance.");
            Assert.That(clone.PartitionOptions.Keys, Is.EquivalentTo(options.PartitionOptions.Keys), "The partition options of the clone should contain the same items");
        }
    }
}
