// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Primitives;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessorOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventProcessorOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventProcessorOptions
            {
                RetryOptions = new EventHubsRetryOptions { Mode = EventHubsRetryMode.Fixed },
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                MaximumWaitTime = TimeSpan.FromMilliseconds(9994),
                PrefetchCount = 65,
                LoadBalancingUpdateInterval = TimeSpan.FromDays(3),
                PartitionOwnershipExpirationInterval = TimeSpan.FromHours(16),
                Identifier = "Rick Springfield is a bad friend",
                TrackLastEnqueuedEventProperties = false,
                DefaultStartingPosition = EventPosition.FromOffset("555")
            };

            EventProcessorOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.Not.SameAs(options), "The options should be a copy, not the same instance.");

            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
            Assert.That(clone.MaximumWaitTime, Is.EqualTo(options.MaximumWaitTime), "The maximum wait time should match.");
            Assert.That(clone.PrefetchCount, Is.EqualTo(options.PrefetchCount), "The prefetch count should match.");
            Assert.That(clone.PrefetchSizeInBytes, Is.EqualTo(options.PrefetchSizeInBytes), "The prefetch size should match.");
            Assert.That(clone.LoadBalancingUpdateInterval, Is.EqualTo(options.LoadBalancingUpdateInterval), "The load balancing update interval should match.");
            Assert.That(clone.PartitionOwnershipExpirationInterval, Is.EqualTo(options.PartitionOwnershipExpirationInterval), "The partition ownership interval should match.");
            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier should match.");
            Assert.That(clone.TrackLastEnqueuedEventProperties, Is.EqualTo(options.TrackLastEnqueuedEventProperties), "Tracking of last enqueued events should match.");
            Assert.That(clone.DefaultStartingPosition, Is.EqualTo(options.DefaultStartingPosition), "The default starting position should match.");
            Assert.That(clone.LoadBalancingStrategy, Is.EqualTo(options.LoadBalancingStrategy), "The load balancing strategy should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.ConnectionOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsAreValidated()
        {
            Assert.That(() => new EventProcessorOptions { ConnectionOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.RetryOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsAreValidated()
        {
            Assert.That(() => new EventProcessorOptions { RetryOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.MaximumWaitTime" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void MaximumWaitTimeIsValidated(int waitTimeSeconds)
        {
            Assert.That(() => new EventProcessorOptions { MaximumWaitTime = TimeSpan.FromSeconds(waitTimeSeconds) }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.MaximumWaitTime" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumWaitTimeAllowsNull()
        {
            var options = new EventProcessorOptions();
            Assert.That(() => options.MaximumWaitTime = null, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.PrefetchCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void PrefetchCountIsValidated(int count)
        {
            Assert.That(() => new EventProcessorOptions { PrefetchCount = count }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.PrefetchCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PrefetchCountAllowsZero()
        {
            Assert.That(() => new EventProcessorOptions { PrefetchCount = 0 }, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.PrefetchSize" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void PrefetchSizeInBytesIsValidated(int count)
        {
            Assert.That(() => new EventProcessorOptions { PrefetchSizeInBytes = count }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.PrefetchSize" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PrefetchSizeInBytesAllowsZero()
        {
            Assert.That(() => new EventProcessorOptions { PrefetchSizeInBytes = 0 }, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.PrefetchSize" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PrefetchSizeInBytesAllowsNull()
        {
            Assert.That(() => new EventProcessorOptions { PrefetchSizeInBytes = null }, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.LoadBalancingUpdateInterval" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void LoadBalancingUpdateIntervalIsValidated(int intervalSeconds)
        {
            Assert.That(() => new EventProcessorOptions { LoadBalancingUpdateInterval = TimeSpan.FromSeconds(intervalSeconds) }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorOptions.PartitionOwnershipExpirationInterval " />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void PartitionOwnershipExpirationInterval(int intervalSeconds)
        {
            Assert.That(() => new EventProcessorOptions { PartitionOwnershipExpirationInterval = TimeSpan.FromSeconds(intervalSeconds) }, Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
