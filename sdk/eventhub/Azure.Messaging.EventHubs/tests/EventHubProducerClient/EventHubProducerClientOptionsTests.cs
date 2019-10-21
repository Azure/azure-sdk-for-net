// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubProducerClientOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubProducerClientOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubProducerClientOptions
            {
                PartitionId = "some_partition_id_123",
                ConnectionOptions = new EventHubConnectionOptions { TransportType = TransportType.AmqpWebSockets },
                RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(36) }
            };

            EventHubProducerClientOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.PartitionId, Is.EqualTo(options.PartitionId), "The partition identifier of the clone should match.");
            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.PartitionId" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase("    ")]
        [TestCase(" ")]
        [TestCase("")]
        public void PartitionIdIsValidated(string partition)
        {
            Assert.That(() => new EventHubProducerClientOptions { PartitionId = partition }, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.PartitionId" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PartitionIdAllowsNull()
        {
            Assert.That(() => new EventHubProducerClientOptions { PartitionId = null }, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.ConnectionOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsAreValidated()
        {
            Assert.That(() => new EventHubProducerClientOptions { ConnectionOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.RetryOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsAreValidated()
        {
            Assert.That(() => new EventHubProducerClientOptions { RetryOptions = null }, Throws.ArgumentNullException);
        }
    }
}
