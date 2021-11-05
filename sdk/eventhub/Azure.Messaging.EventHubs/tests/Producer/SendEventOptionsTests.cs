// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="SendEventOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class SendEventOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="SendEventOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new SendEventOptions
            {
                PartitionId = "0",
                PartitionKey = "some_partition_123"
            };

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.TypeOf<SendEventOptions>(), "The clone should be a SendEventOptions instance.");
            Assert.That(clone, Is.Not.SameAs(options), "The clone should not the same reference as the options.");
            Assert.That(clone.PartitionId, Is.EqualTo(options.PartitionId), "The partition identifier of the clone should match.");
            Assert.That(clone.PartitionKey, Is.EqualTo(options.PartitionKey), "The partition key of the clone should match.");
        }
    }
}
