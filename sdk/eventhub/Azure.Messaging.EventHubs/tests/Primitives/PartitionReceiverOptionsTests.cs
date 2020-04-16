// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionReceiverOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionReceiverOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiverOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new PartitionReceiverOptions
            {
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                RetryOptions = new EventHubsRetryOptions { Mode = EventHubsRetryMode.Fixed },
                DefaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(9994),
                OwnerLevel = 99,
                PrefetchCount = 65,
                TrackLastEnqueuedEventProperties = false
            };

            PartitionReceiverOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.Not.SameAs(options), "The options should be a copy, not the same instance.");

            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
            Assert.That(clone.DefaultMaximumReceiveWaitTime, Is.EqualTo(options.DefaultMaximumReceiveWaitTime), "The maximum wait time should match.");
            Assert.That(clone.OwnerLevel, Is.EqualTo(options.OwnerLevel), "The owner level of the clone should match.");
            Assert.That(clone.PrefetchCount, Is.EqualTo(options.PrefetchCount), "The prefetch count should match.");
            Assert.That(clone.TrackLastEnqueuedEventProperties, Is.EqualTo(options.TrackLastEnqueuedEventProperties), "Tracking of last enqueued events should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiverOptions.ConnectionOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsAreValidated()
        {
            Assert.That(() => new PartitionReceiverOptions { ConnectionOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiverOptions.RetryOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsAreValidated()
        {
            Assert.That(() => new PartitionReceiverOptions { RetryOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiverOptions.DefaultMaximumReceiveWaitTime" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void DefaultMaximumReceiveWaitTimeIsValidated(int waitTimeSeconds)
        {
            Assert.That(() => new PartitionReceiverOptions { DefaultMaximumReceiveWaitTime = TimeSpan.FromSeconds(waitTimeSeconds) }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="PartitionReceiverOptions.PrefetchCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void PrefetchCountIsValidated(int count)
        {
            Assert.That(() => new PartitionReceiverOptions { PrefetchCount = count }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
