using System;
using System.Net;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubClientOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class EventHubClientOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClientOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubClientOptions
            {
                Retry = new ExponentialRetry(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2), 3),
                TransportType = TransportType.AmqpWebSockets,
                DefaultTimeout = TimeSpan.FromDays(1),
                Proxy = Mock.Of<IWebProxy>()
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.TransportType, Is.EqualTo(options.TransportType), "The connection type of the clone should match.");
            Assert.That(clone.DefaultTimeout, Is.EqualTo(options.DefaultTimeout), "The default timeout of the clone should match.");
            Assert.That(clone.Proxy, Is.EqualTo(options.Proxy), "The proxy of the clone should match.");

            Assert.That(ExponentialRetry.HaveSameConfiguration((ExponentialRetry)clone.Retry, (ExponentialRetry)options.Retry), Is.True, "The retry of the clone should be considered equal.");
            Assert.That(clone.Retry, Is.Not.SameAs(options.Retry), "The retry of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClientOptions.Retry" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryIsValidated()
        {
            Assert.That(() => new EventHubClientOptions { Retry = null }, Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClientOptions.DefaultTimeout" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void DefaultTimeoutIsValidated()
        {
            Assert.That(() => new EventHubClientOptions { DefaultTimeout = TimeSpan.FromMilliseconds(-1) }, Throws.ArgumentException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClientOptions.DefaultTimeout" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void DefaultTimeoutUsesDefaultValueIfNotSpecified()
        {
            var options = new EventHubClientOptions();
            var defaultTimeoutValue = options.TimeoutOrDefault;

            options.DefaultTimeout = TimeSpan.Zero;
            Assert.That(options.DefaultTimeout, Is.EqualTo(TimeSpan.Zero), "The value supplied by the caller should be preserved.");
            Assert.That(options.TimeoutOrDefault, Is.EqualTo(defaultTimeoutValue), "The timeout value should be defaulted internally.");
        }
    }
}
