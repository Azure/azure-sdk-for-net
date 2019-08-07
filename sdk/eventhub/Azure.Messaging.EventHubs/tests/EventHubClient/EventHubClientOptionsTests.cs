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
    [Parallelizable(ParallelScope.All)]
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
                RetryOptions = new RetryOptions { MaximumRetries = 27 },
                TransportType = TransportType.AmqpWebSockets,
                Proxy = Mock.Of<IWebProxy>()
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.TransportType, Is.EqualTo(options.TransportType), "The connection type of the clone should match.");
            Assert.That(clone.Proxy, Is.EqualTo(options.Proxy), "The proxy of the clone should match.");

            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubClientOptions.Retry" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsIsValidated()
        {
            Assert.That(() => new EventHubClientOptions { RetryOptions = null }, Throws.ArgumentException);
        }
    }
}
