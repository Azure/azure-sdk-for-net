// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Messaging.EventHubs.Core;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of tests for the <see cref="EventHubProducerClientOptions" />
    ///   class.
    /// </summary>
    ///
    [TestFixture]
    public class EventHubProducerClientOptionsTests
    {
        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.Clone" />
        ///   method.
        /// </summary>
        ///
        [Test]
        public void CloneProducesACopy()
        {
            var options = new EventHubProducerClientOptions
            {
                Identifier = "Test-123",
                EnableIdempotentPartitions = true,
                ConnectionOptions = new EventHubConnectionOptions { TransportType = EventHubsTransportType.AmqpWebSockets },
                RetryOptions = new EventHubsRetryOptions { TryTimeout = TimeSpan.FromMinutes(36) }
            };

            options.PartitionOptions.Add("0", new PartitionPublishingOptions
            {
                OwnerLevel = 3,
                ProducerGroupId = 99,
                StartingSequenceNumber = 42
            });

            var clone = options.Clone();
            Assert.That(clone, Is.Not.Null, "The clone should not be null.");

            Assert.That(clone.Identifier, Is.EqualTo(options.Identifier), "The identifier should match.");
            Assert.That(clone.EnableIdempotentPartitions, Is.EqualTo(options.EnableIdempotentPartitions), "The flag to enable idempotent publishing should have been copied.");
            Assert.That(clone.ConnectionOptions.TransportType, Is.EqualTo(options.ConnectionOptions.TransportType), "The connection options of the clone should copy properties.");
            Assert.That(clone.ConnectionOptions, Is.Not.SameAs(options.ConnectionOptions), "The connection options of the clone should be a copy, not the same instance.");
            Assert.That(clone.RetryOptions.IsEquivalentTo(options.RetryOptions), Is.True, "The retry options of the clone should be considered equal.");
            Assert.That(clone.RetryOptions, Is.Not.SameAs(options.RetryOptions), "The retry options of the clone should be a copy, not the same instance.");
            Assert.That(clone.PartitionOptions, Is.Not.SameAs(options.PartitionOptions), "The partitions options of the clone should be a copy, not the same instance.");
            Assert.That(clone.PartitionOptions.Keys, Is.EquivalentTo(options.PartitionOptions.Keys), "The partition options of the clone should contain the same items");

            foreach (var key in options.PartitionOptions.Keys)
            {
                Assert.That(clone.PartitionOptions[key], Is.Not.SameAs(options.PartitionOptions[key]), $"The partition options of the clone for partition: `{ key }` should be a copy, not the same instance.");

                foreach (var property in typeof(PartitionPublishingOptions).GetProperties(BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.Instance))
                {
                    Assert.That(property.GetValue(clone.PartitionOptions[key], null), Is.EqualTo(property.GetValue(options.PartitionOptions[key], null)), $"The partition options of the clone for partition: `{ key }` should have the same value for { property.Name }.");
                }
            }
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.ConnectionOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void ConnectionOptionsAreValidated()
        {
            Assert.That(() => new EventHubProducerClientOptions { ConnectionOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.RetryOptions" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void RetryOptionsAreValidated()
        {
            Assert.That(() => new EventHubProducerClientOptions { RetryOptions = null }, Throws.ArgumentNullException);
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.CreateFeatureFlags" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void CreateFeatureFlagsDetectsWhenNoFeaturesWereRequested()
        {
            var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = false };
            Assert.That(options.CreateFeatureFlags(), Is.EqualTo(TransportProducerFeatures.None));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.CreateFeatureFlags" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void CreateFeatureFlagsDetectsIdempotentPublishing()
        {
            var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };
            Assert.That(options.CreateFeatureFlags(), Is.EqualTo(TransportProducerFeatures.IdempotentPublishing));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.GetPublishingOptionsOrDefaultForPartition" />
        ///   property.
        /// </summary>
        ///
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void GetPublishingOptionsOrDefaultForPartitionDefaultsWhenNoPartitionIsSpecified(string partitionId)
        {
            var options = new EventHubProducerClientOptions();
            options.PartitionOptions.Add("1", new PartitionPublishingOptions { ProducerGroupId = 1 });

            Assert.That(options.GetPublishingOptionsOrDefaultForPartition(partitionId), Is.EqualTo(default(PartitionPublishingOptions)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.GetPublishingOptionsOrDefaultForPartition" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void GetPublishingOptionsOrDefaultForPartitionDefaultsWhenNoPartitionIsFound()
        {
            var options = new EventHubProducerClientOptions();
            options.PartitionOptions.Add("1", new PartitionPublishingOptions { ProducerGroupId = 1 });

            Assert.That(options.GetPublishingOptionsOrDefaultForPartition("0"), Is.EqualTo(default(PartitionPublishingOptions)));
        }

        /// <summary>
        ///   Verifies functionality of the <see cref="EventHubProducerClientOptions.GetPublishingOptionsOrDefaultForPartition" />
        ///   property.
        /// </summary>
        ///
        [Test]
        public void GetPublishingOptionsOrDefaultForPartitionReturnsTheOptionsWhenThePartitionIsFound()
        {
            var partitionId = "12";
            var expectedPartitionOptions = new PartitionPublishingOptions { ProducerGroupId = 1 };

            var options = new EventHubProducerClientOptions();
            options.PartitionOptions.Add(partitionId, expectedPartitionOptions);

            Assert.That(options.GetPublishingOptionsOrDefaultForPartition(partitionId), Is.SameAs(expectedPartitionOptions));
        }
    }
}
