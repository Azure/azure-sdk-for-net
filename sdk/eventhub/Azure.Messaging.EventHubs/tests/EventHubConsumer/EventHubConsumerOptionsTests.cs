using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubConsumerOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class EventHubConsumerOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubConsumerOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubConsumerOptions
            {
                OwnerLevel = 99,
                RetryOptions = new RetryOptions { Mode = RetryMode.Fixed },
                DefaultMaximumReceiveWaitTime = TimeSpan.FromMinutes(65),
                Identifier = "an_event_consumer"
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.OwnerLevel, Is.EqualTo(options.OwnerLevel), "The owner level of the clone should match.");
            Assert.That(clone.DefaultMaximumReceiveWaitTime, Is.EqualTo(options.DefaultMaximumReceiveWaitTime), "The default maximum wait time of the clone should match.");
            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier of the clone should match.");

            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///  Verifies that setting the <see cref="EventHubConsumerOptions.PrefetchCount" /> is
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
        ///  Verifies that setting the <see cref="EventHubConsumerOptions.Identifier" /> is
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
        ///   Verifies functionality of the <see cref="EventHubConsumerOptions.DefaultMaximumReceiveWaitTime" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void DefaultMaximumReceiveWaitTimeIsValidated()
        {
            Assert.That(() => new EventHubConsumerOptions { DefaultMaximumReceiveWaitTime = TimeSpan.FromMilliseconds(-1) }, Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerOptions.Timeout" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase(0)]
        public void DefaultMaximumReceiveWaitTimeUsesNormalizesValueINotSpecified(int? noTimeoutValue)
        {
            var options = new EventHubConsumerOptions();
            var timeoutValue = (noTimeoutValue.HasValue) ? TimeSpan.Zero : (TimeSpan?)null;

            options.DefaultMaximumReceiveWaitTime = timeoutValue;
            Assert.That(options.DefaultMaximumReceiveWaitTime, Is.EqualTo(timeoutValue), "The value supplied by the caller should be preserved.");
            Assert.That(options.MaximumReceiveWaitTimeOrDefault, Is.Null, "The maximum wait value should be normalized to null internally.");
        }

        /// <summary>
        ///   A mock of the <see cref="EventHubConsumerOptions" /> to allow the protected validation
        ///   constants to be referenced.
        /// </summary>
        ///
        private class MockOptions : EventHubConsumerOptions
        {
            public int MinPrefixCount => EventHubConsumerOptions.MinimumPrefetchCount;
            public int MaxIdentifierLength => EventHubConsumerOptions.MaximumIdentifierLength;
        }
    }
}
