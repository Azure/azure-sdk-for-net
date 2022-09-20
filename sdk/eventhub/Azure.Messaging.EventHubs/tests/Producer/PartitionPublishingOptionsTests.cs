// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="PartitionPublishingOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class PartitionPublishingOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new PartitionPublishingOptions
            {
                OwnerLevel = 3,
                ProducerGroupId = 99,
                StartingSequenceNumber = 42
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.OwnerLevel, Is.EqualTo(options.OwnerLevel), "The owner level should have been copied.");
            Assert.That(clone.ProducerGroupId, Is.EqualTo(options.ProducerGroupId), "The producer group identifier should have been copied.");
            Assert.That(clone.StartingSequenceNumber, Is.EqualTo(options.StartingSequenceNumber), "The starting sequence number should have been copied.");
        }
    }
}
