// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Processor;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventProcessorClientOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventProcessorClientOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventProcessorClientOptions
            {
                Identifier = Guid.NewGuid().ToString(),
                TrackLastEnqueuedEventProperties = false,
                LoadBalancingStrategy = LoadBalancingStrategy.Greedy,
                MaximumWaitTime = TimeSpan.FromMinutes(65),
                CacheEventCount = 1,
                PrefetchCount = 0,
                RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(1), Delay = TimeSpan.FromMinutes(4) },
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets }
            };

            EventProcessorClientOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.Not.SameAs(options), "The clone should be a different instance.");

            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier of the clone should match.");
            Assert.That(clone.TrackLastEnqueuedEventProperties, Is.EqualTo(options.TrackLastEnqueuedEventProperties), "The tracking of last event information of the clone should match.");
            Assert.That(clone.LoadBalancingStrategy, Is.EqualTo(options.LoadBalancingStrategy), "The load balancing strategy of the clone should match.");
            Assert.That(clone.MaximumWaitTime, Is.EqualTo(options.MaximumWaitTime), "The maximum wait time of the clone should match.");
            Assert.That(clone.CacheEventCount, Is.EqualTo(options.CacheEventCount), "The event cache size of the clone should match.");
            Assert.That(clone.PrefetchCount, Is.EqualTo(options.PrefetchCount), "The prefetch count of the clone should match.");
            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventProcessorClientOptions.MaximumWaitTime" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-1000)]
        [TestCase(-10000)]
        public void MaximumWaitTimeIsValidated(int timeSpanDelta)
        {
            var options = new EventProcessorClientOptions();
            Assert.That(() => options.MaximumWaitTime = TimeSpan.FromMilliseconds(timeSpanDelta), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.MaximumWaitTime" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumWaitTimeAllowsNull()
        {
            var options = new EventProcessorClientOptions();
            Assert.That(() => options.MaximumWaitTime = null, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.CacheEventCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void CacheEventCountIsValidated()
        {
            Assert.That(() => new EventProcessorClientOptions { CacheEventCount = 0 }, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.PrefetchCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PrefetchCountIsValidated()
        {
            Assert.That(() => new EventProcessorClientOptions { PrefetchCount = -1 }, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.PrefetchCount" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PrefetchCountAllowsZero()
        {
            Assert.That(() => new EventProcessorClientOptions { PrefetchCount = 0 }, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.ConnectionOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsAreValidated()
        {
            Assert.That(() => new EventProcessorClientOptions { ConnectionOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.RetryOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsAreValidated()
        {
            Assert.That(() => new EventProcessorClientOptions { RetryOptions = null }, Throws.ArgumentNullException);
        }
    }
}
