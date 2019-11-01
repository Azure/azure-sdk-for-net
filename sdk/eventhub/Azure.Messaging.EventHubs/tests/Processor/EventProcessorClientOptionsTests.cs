// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
                MaximumReceiveWaitTime = TimeSpan.FromMinutes(65),
                TrackLastEnqueuedEventInformation = false,
                RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(1), Delay = TimeSpan.FromMinutes(4) },
                ConnectionOptions = new EventHubConnectionOptions { TransportType = TransportType.AmqpWebSockets }
            };

            EventProcessorClientOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.Not.SameAs(options), "The clone should be a different instance.");

            Assert.That(clone.MaximumReceiveWaitTime, Is.EqualTo(options.MaximumReceiveWaitTime), "The maximum receive wait time of the clone should match.");
            Assert.That(clone.TrackLastEnqueuedEventInformation, Is.EqualTo(options.TrackLastEnqueuedEventInformation), "The tracking of last event information of the clone should match.");
            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventProcessorClientOptions.MaximumReceiveWaitTime" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(-1000)]
        [TestCase(-10000)]
        public void MaximumReceiveWaitTimeIsValidated(int timeSpanDelta)
        {
            var options = new EventProcessorClientOptions();
            Assert.That(() => options.MaximumReceiveWaitTime = TimeSpan.FromMilliseconds(timeSpanDelta), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventProcessorClientOptions.MaximumReceiveWaitTime" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumReceiveWaitTimeAllowsNull()
        {
            var options = new EventProcessorClientOptions();
            Assert.That(() => options.MaximumReceiveWaitTime = null, Throws.Nothing);
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
