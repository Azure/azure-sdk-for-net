using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubProducerOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class EventHubProducerOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubProducerOptions
            {
                PartitionId = "some_partition_id_123",
                RetryOptions = new RetryOptions { TryTimeout = TimeSpan.FromMinutes(36) }
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.PartitionId, Is.EqualTo(options.PartitionId), "The partition identifier of the clone should match.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerOptions.PartitionId" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase("    ")]
        [TestCase(" ")]
        [TestCase("")]
        public void PartitionIdIsValidated(string partition)
        {
            Assert.That(() => new EventHubProducerOptions { PartitionId = partition }, Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerOptions.PartitionId" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void PartitionIdAllowsNull()
        {
            Assert.That(() => new EventHubProducerOptions { PartitionId = null }, Throws.Nothing);
        }
    }
}
