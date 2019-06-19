using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventReceiverOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class ReceiverOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventReceiverOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventReceiverOptions
            {
                ConsumerGroup = "custom$consumer",
                BeginReceivingAt = EventPosition.FromOffset(65),
                ExclusiveReceiverPriority = 99,
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(4), TimeSpan.FromSeconds(5), 6),
                DefaultMaximumReceiveWaitTime = TimeSpan.FromMinutes(65),
                Identifier = "an_event_receiver"
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.ConsumerGroup, Is.EqualTo(options.ConsumerGroup), "The consumer group of the clone should match.");
            Assert.That(clone.BeginReceivingAt, Is.EqualTo(options.BeginReceivingAt), "The position to begin reading events of the clone should match.");
            Assert.That(clone.ExclusiveReceiverPriority, Is.EqualTo(options.ExclusiveReceiverPriority), "The exclusive priority of the clone should match.");
            Assert.That(clone.DefaultMaximumReceiveWaitTime, Is.EqualTo(options.DefaultMaximumReceiveWaitTime), "The default maximum wait time of the clone should match.");
            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier of the clone should match.");

            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)clone.Retry, (ExponentialRetry)options.Retry), "The retry of the clone should be considered equal.");
            Assert.That(clone.Retry, Is.Not.SameAs(options.Retry), "The retry of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventReceiverOptions.PrefetchCount" /> is
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
        ///  Verifies that setting the <see cref="EventReceiverOptions.Identifier" /> is
        ///  validated.
        /// </summary>
        ///
        [Test]
        public void IdentifierIsValidated()
        {
            var options = new MockOptions();
            var tooLongIdentifier = new String('x', (options.MaxIdentifierLength + 1));

            Assert.That(() => options.Identifier = tooLongIdentifier, Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventReceiverOptions.DefaultMaximumReceiveWaitTime" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void DefaultMaximumReceiveWaitTimeIsValidated()
        {
            Assert.That(() => new EventReceiverOptions { DefaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(-1) }, Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventSenderOptions.Timeout" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase(0)]
        public void DefaultMaximumReceiveWaitTimeUsesNormalizesValueINotSpecified(int? noTimeoutValue)
        {
            var options = new EventReceiverOptions();
            var timeoutValue = (noTimeoutValue.HasValue) ? TimeSpan.Zero : (TimeSpan?)null;

            options.DefaultMaximumReceiveWaitTime = timeoutValue;
            Assert.That(options.DefaultMaximumReceiveWaitTime, Is.EqualTo(timeoutValue), "The value supplied by the caller should be preserved.");
            Assert.That(options.MaximumReceiveWaitTimeOrDefault, Is.Null, "The maximum wait value should be normalized to null internally.");
        }

        /// <summary>
        ///   A mock of the <see cref="EventReceiverOptions" /> to allow the protected validation
        ///   constants to be referenced.
        /// </summary>
        ///
        private class MockOptions : EventReceiverOptions
        {
            public int MinPrefixCount => EventReceiverOptions.MinimumPrefetchCount;
            public int MaxIdentifierLength => EventReceiverOptions.MaximumIdentifierLength;
        }
    }
}
