// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="BatchOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class BatchOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="BatchOptions.CloneToSend" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new BatchOptions
            {
                PartitionKey = "some_partition_123",
                MaximumSizeInBytes = (int.MaxValue + 122L)
            };

            BatchOptions clone = options.Clone();
            Assert.That(clone, Is.TypeOf<BatchOptions>(), "The clone should be a BatchOptions instance.");
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.Not.SameAs(options), "The clone should not the same reference as the options.");
            Assert.That(clone.PartitionKey, Is.EqualTo(options.PartitionKey), "The partition key of the clone should match.");
            Assert.That(clone.MaximumSizeInBytes, Is.EqualTo(options.MaximumSizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BatchOptions.MaximumSizeInBytes" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumBatchSizeInBytesEnforcesMinimum()
        {
            var options = new BatchOptions();
            Assert.That(() => options.MaximumSizeInBytes = (EventHubProducerClient.MinimumBatchSizeLimit - 1), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BatchOptions.MaximumSizeInBytes" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumBatchSizeInBytesDoesNotLimitMaximum()
        {
            var options = new BatchOptions();
            Assert.That(() => options.MaximumSizeInBytes = int.MaxValue, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="BatchOptions.MaximumSizeInBytes" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumBatchSizeInBytesAllowsNull()
        {
            var options = new BatchOptions();
            Assert.That(() => options.MaximumSizeInBytes = null, Throws.Nothing);
        }
    }
}
