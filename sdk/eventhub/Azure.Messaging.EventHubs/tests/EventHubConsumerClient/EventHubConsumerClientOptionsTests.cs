// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubConsumerClientOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubConsumerClientOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClientOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubConsumerClientOptions
            {
                OwnerLevel = 99,
                TrackLastEnqueuedEventInformation = false,
                RetryOptions = new RetryOptions { Mode = RetryMode.Fixed },
                ConnectionOptions = new EventHubConnectionOptions { TransportType = TransportType.AmqpWebSockets },
                DefaultMaximumReceiveWaitTime = TimeSpan.FromMinutes(65),
                Identifier = "an_event_consumer"
            };

            EventHubConsumerClientOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.OwnerLevel, Is.EqualTo(options.OwnerLevel), "The owner level of the clone should match.");
            Assert.That(clone.TrackLastEnqueuedEventInformation, Is.EqualTo(options.TrackLastEnqueuedEventInformation), "The tracking of last event information of the clone should match.");
            Assert.That(clone.DefaultMaximumReceiveWaitTime, Is.EqualTo(options.DefaultMaximumReceiveWaitTime), "The default maximum wait time of the clone should match.");
            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier of the clone should match.");
            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventHubConsumerClientOptions.PrefetchCount" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        public void PrefetchIsValidated()
        {
            var options = new MockOptions();
            Assert.That(() => options.PrefetchCount = (options.MinPrefixCount - 1), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventHubConsumerClientOptions.Identifier" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        public void IdentifierIsValidated()
        {
            var options = new MockOptions();
            var tooLongIdentifier = new string('x', (options.MaxIdentifierLength + 1));

            Assert.That(() => options.Identifier = tooLongIdentifier, Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClientOptions.DefaultMaximumReceiveWaitTime" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void DefaultMaximumReceiveWaitTimeIsValidated()
        {
            Assert.That(() => new EventHubConsumerClientOptions { DefaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(-1) }, Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.Timeout" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase(0)]
        public void DefaultMaximumReceiveWaitTimeUsesNormalizedValueIfNotSpecified(int? noTimeoutValue)
        {
            var options = new EventHubConsumerClientOptions();
            TimeSpan? timeoutValue = (noTimeoutValue.HasValue) ? TimeSpan.Zero : (TimeSpan?)null;

            options.DefaultMaximumReceiveWaitTime = timeoutValue;
            Assert.That(options.DefaultMaximumReceiveWaitTime, Is.EqualTo(timeoutValue), "The value supplied by the caller should be preserved.");
            Assert.That(options.MaximumReceiveWaitTimeOrDefault, Is.Null, "The maximum wait value should be normalized to null internally.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClientOptions.ConnectionOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsAreValidated()
        {
            Assert.That(() => new EventHubConsumerClientOptions { ConnectionOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerClientOptions.RetryOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsAreValidated()
        {
            Assert.That(() => new EventHubConsumerClientOptions { RetryOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   A mock of the <see cref="EventHubConsumerClientOptions" /> to allow the protected validation
        ///   constants to be referenced.
        /// </summary>
        ///
        private class MockOptions : EventHubConsumerClientOptions
        {
            public int MinPrefixCount => EventHubConsumerClientOptions.MinimumPrefetchCount;
            public int MaxIdentifierLength => EventHubConsumerClientOptions.MaximumIdentifierLength;
        }
    }
}
