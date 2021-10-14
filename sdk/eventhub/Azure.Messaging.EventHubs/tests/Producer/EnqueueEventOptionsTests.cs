// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EnqueueEventOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EnqueueEventOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EnqueueEventOptions.Deconstruct" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void OptionsCanBeDeconstructed()
        {
            var options = new EnqueueEventOptions
            {
                PartitionId = "0",
                PartitionKey = "some_partition_123"
            };

            (var partitionId, var partitionKey) = options;
            Assert.That(partitionId, Is.EqualTo(options.PartitionId), "The partition identifier of the deconstruction should match.");
            Assert.That(partitionKey, Is.EqualTo(options.PartitionKey), "The partition key of the deconstruction should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EnqueueEventOptions.DeconstructOrUseDefaultAttributes" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void DeconstructOrUseDefaultAttributesUsesOptionsWhenProvided()
        {
            var options = new EnqueueEventOptions
            {
                PartitionId = "0",
                PartitionKey = "some_partition_123"
            };

            (var partitionId, var partitionKey) = EnqueueEventOptions.DeconstructOrUseDefaultAttributes(options);
            Assert.That(partitionId, Is.EqualTo(options.PartitionId), "The partition identifier of the deconstruction should match.");
            Assert.That(partitionKey, Is.EqualTo(options.PartitionKey), "The partition key of the deconstruction should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EnqueueEventOptions.Deconstruct" /> and
        ///   <see cref="EnqueueEventOptions.DeconstructOrUseDefaultAttributes" /> methods.
        /// </summary>
        ///
        [Test]
        public void DefaultOptionsMatchDefaultDeconstruction()
        {
            (var defaultPartitionId, var defaultPartitionKey) = EnqueueEventOptions.DeconstructOrUseDefaultAttributes();
            (var newPartitionId, var newPartitionKey) = new EnqueueEventOptions();

            Assert.That(defaultPartitionId, Is.EqualTo(newPartitionId), "The partition identifier of the default attributes should match empty deconstruction.");
            Assert.That(defaultPartitionKey, Is.EqualTo(newPartitionKey), "The partition key of the default attributes should match empty deconstruction.");
        }
    }
}
