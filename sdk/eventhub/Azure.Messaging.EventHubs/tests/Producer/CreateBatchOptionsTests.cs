// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="CreateBatchOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class CreateBatchOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="CreateBatchOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new CreateBatchOptions
            {
                PartitionId = "0",
                PartitionKey = "some_partition_123",
                MaximumSizeInBytes = (int.MaxValue + 122L)
            };

            CreateBatchOptions clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");
            Assert.That(clone, Is.TypeOf<CreateBatchOptions>(), "The clone should be a CreateBatchOptions instance.");
            Assert.That(clone, Is.Not.SameAs(options), "The clone should not the same reference as the options.");
            Assert.That(clone.PartitionId, Is.EqualTo(options.PartitionId), "The partition identifier of the clone should match.");
            Assert.That(clone.PartitionKey, Is.EqualTo(options.PartitionKey), "The partition key of the clone should match.");
            Assert.That(clone.MaximumSizeInBytes, Is.EqualTo(options.MaximumSizeInBytes), "The maximum size should match.");
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CreateBatchOptions.MaximumSizeInBytes" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumBatchSizeInBytesEnforcesMinimum()
        {
            var options = new CreateBatchOptions();
            Assert.That(() => options.MaximumSizeInBytes = (EventHubProducerClient.MinimumBatchSizeLimit - 1), Throws.InstanceOf<ArgumentException>());
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CreateBatchOptions.MaximumSizeInBytes" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumBatchSizeInBytesDoesNotLimitMaximum()
        {
            var options = new CreateBatchOptions();
            Assert.That(() => options.MaximumSizeInBytes = int.MaxValue, Throws.Nothing);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="CreateBatchOptions.MaximumSizeInBytes" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void MaximumBatchSizeInBytesAllowsNull()
        {
            var options = new CreateBatchOptions();
            Assert.That(() => options.MaximumSizeInBytes = null, Throws.Nothing);
        }
    }
}
