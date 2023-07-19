// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Experimental.Tests
{
    /// <summary>
    ///   The suite of live tests for the <see cref="IdempotentProducer" />
    ///   class.
    /// </summary>
    ///
    /// <remarks>
    ///   These tests have a dependency on live Azure services and may
    ///   incur costs for the associated Azure subscription.
    /// </remarks>
    ///
    [TestFixture]
    [Category(TestCategory.Live)]
    [Category(TestCategory.DisallowVisualStudioLiveUnitTesting)]
    public class IdempotentProducerLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   connect to the Event Hubs service and opt into the idempotent publishing
        ///   feature.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanOptIntoIdempotentPublishing()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using var producer = new IdempotentProducer(connectionString, options);
                Assert.That(async () => await producer.GetPartitionIdsAsync(cancellationSource.Token), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerCanPublishEvents(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true, ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                await using var producer = new IdempotentProducer(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                var sendOptions = new SendEventOptions { PartitionId = partition };

                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(2), sendOptions, cancellationSource.Token), Throws.Nothing, "The first publishing operation was not successful.");
                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(2), sendOptions, cancellationSource.Token), Throws.Nothing, "The second publishing operation was not successful.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        [TestCase(EventHubsTransportType.AmqpTcp)]
        [TestCase(EventHubsTransportType.AmqpWebSockets)]
        public async Task ProducerCanPublishBatches(EventHubsTransportType transportType)
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true, ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType } };

                await using var producer = new IdempotentProducer(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync()).First();
                var batchOptions = new CreateBatchOptions { PartitionId = partition };

                using var firstBatch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);
                firstBatch.TryAdd(EventGenerator.CreateEvents(1).First());

                using var secondBatch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);
                secondBatch.TryAdd(EventGenerator.CreateEvents(1).First());
                secondBatch.TryAdd(EventGenerator.CreateEvents(1).First());

                Assert.That(async () => await producer.SendAsync(firstBatch, cancellationSource.Token), Throws.Nothing, "The first publishing operation was not successful.");
                Assert.That(async () => await producer.SendAsync(secondBatch, cancellationSource.Token), Throws.Nothing, "The second publishing operation was not successful.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerInitializesPropertiesWhenRequested()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true };

                await using var producer = new IdempotentProducer(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).Last();
                var partitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);

                Assert.That(partitionProperties, Is.Not.Null, "The properties should have been created.");
                Assert.That(partitionProperties.IsIdempotentPublishingEnabled, Is.True, "Idempotent publishing should be enabled.");
                Assert.That(partitionProperties.ProducerGroupId.HasValue, Is.True, "The producer group identifier should have a value.");
                Assert.That(partitionProperties.OwnerLevel.HasValue, Is.True, "The owner level should have a value.");
                Assert.That(partitionProperties.LastPublishedSequenceNumber.HasValue, Is.True, "The last published sequence number should have a value.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerInitializesPropertiesWhenPublishing()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true };

                await using var producer = new IdempotentProducer(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                var sendOptions = new SendEventOptions { PartitionId = partition };

                var events = EventGenerator.CreateEvents(10).ToArray();
                await producer.SendAsync(events, sendOptions, cancellationSource.Token);

                var partitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);
                Assert.That(partitionProperties, Is.Not.Null, "The properties should have been created.");
                Assert.That(partitionProperties.IsIdempotentPublishingEnabled, Is.True, "Idempotent publishing should be enabled.");
                Assert.That(partitionProperties.ProducerGroupId.HasValue, Is.True, "The producer group identifier should have a value.");
                Assert.That(partitionProperties.OwnerLevel.HasValue, Is.True, "The owner level should have a value.");
                Assert.That(partitionProperties.LastPublishedSequenceNumber.HasValue, Is.True, "The last published sequence number should have a value.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerUpdatesPropertiesAfterPublishingBatches()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true };

                await using var producer = new IdempotentProducer(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                var initialPartitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);
                var batchOptions = new CreateBatchOptions { PartitionId = partition };

                using var batch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);
                batch.TryAdd(EventGenerator.CreateEvents(1).First());
                batch.TryAdd(EventGenerator.CreateEvents(1).First());
                batch.TryAdd(EventGenerator.CreateEvents(1).First());

                await producer.SendAsync(batch, cancellationSource.Token);

                var updatedPartitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);
                Assert.That(updatedPartitionProperties.IsIdempotentPublishingEnabled, Is.True, "Idempotent publishing should be enabled.");
                Assert.That(updatedPartitionProperties.ProducerGroupId, Is.EqualTo(initialPartitionProperties.ProducerGroupId), "The producer group identifier should not have changed.");
                Assert.That(updatedPartitionProperties.OwnerLevel, Is.EqualTo(initialPartitionProperties.OwnerLevel), "The owner level should not have changed.");
                Assert.That(updatedPartitionProperties.LastPublishedSequenceNumber, Is.GreaterThan(initialPartitionProperties.LastPublishedSequenceNumber), "The last published sequence number should have increased.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanInitializeWithPartitionOptions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = default(string);
                var partitionProperties = default(PartitionPublishingProperties);

                // Create a producer for a small scope that will Send some events and read the properties.

                await using (var initialProducer = new IdempotentProducer(connectionString, options))
                {
                    partition = (await initialProducer.GetPartitionIdsAsync(cancellationSource.Token)).Last();

                    await initialProducer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token);
                    partitionProperties = await initialProducer.GetPartitionPublishingPropertiesAsync(partition);
                }

                // Create a new producer using the previously read properties to set options for the partition.

                options.PartitionOptions.Add(partition, new PartitionPublishingOptions
                {
                    ProducerGroupId = partitionProperties.ProducerGroupId,
                    OwnerLevel = partitionProperties.OwnerLevel,
                    StartingSequenceNumber = partitionProperties.LastPublishedSequenceNumber
                });

                await using var producer = new IdempotentProducer(connectionString, options);
                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanInitializeWithPartialPartitionOptions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = default(string);
                var partitionProperties = default(PartitionPublishingProperties);

                // Create a producer for a small scope that will Send some events and read the properties.

                await using (var initialProducer = new IdempotentProducer(connectionString, options))
                {
                    partition = (await initialProducer.GetPartitionIdsAsync(cancellationSource.Token)).Last();

                    await initialProducer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token);
                    partitionProperties = await initialProducer.GetPartitionPublishingPropertiesAsync(partition);
                }

                // Create a new producer using the previously read properties to set options for the partition.

                options.PartitionOptions.Add(partition, new PartitionPublishingOptions
                {
                    ProducerGroupId = partitionProperties.ProducerGroupId,
                    OwnerLevel = partitionProperties.OwnerLevel
                });

                Assert.That(options.PartitionOptions[partition].StartingSequenceNumber.HasValue, Is.False, "The partition options should not specifiy a starting sequence number.");
                await using var producer = new IdempotentProducer(connectionString, options);

                // Verify that the properties were fully initialized when using partial options.

                partitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);
                Assert.That(partitionProperties, Is.Not.Null, "The properties should have been created.");
                Assert.That(partitionProperties.IsIdempotentPublishingEnabled, Is.True, "Idempotent publishing should be enabled.");
                Assert.That(partitionProperties.ProducerGroupId.HasValue, Is.True, "The producer group identifier should have a value.");
                Assert.That(partitionProperties.OwnerLevel.HasValue, Is.True, "The owner level should have a value.");
                Assert.That(partitionProperties.LastPublishedSequenceNumber.HasValue, Is.True, "The last published sequence number should have a value.");

                // Ensure that the state supports publishing.

                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="IdempotentProducer" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerIsRejectedWithPartitionOptionsForInvalidState()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new IdempotentProducerOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = default(string);
                var partitionProperties = default(PartitionPublishingProperties);

                // Create a producer for a small scope that will Send some events and read the properties.

                await using (var initialProducer = new IdempotentProducer(connectionString, options))
                {
                    partition = (await initialProducer.GetPartitionIdsAsync(cancellationSource.Token)).Last();

                    await initialProducer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token);
                    partitionProperties = await initialProducer.GetPartitionPublishingPropertiesAsync(partition);
                }

                // Create a new producer using the previously read properties to set options for the partition.

                options.PartitionOptions.Add(partition, new PartitionPublishingOptions
                {
                    ProducerGroupId = partitionProperties.ProducerGroupId,
                    OwnerLevel = partitionProperties.OwnerLevel,
                    StartingSequenceNumber = (partitionProperties.LastPublishedSequenceNumber - 5)
                });

                await using var producer = new IdempotentProducer(connectionString, options);

                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token),
                    Throws.InstanceOf<EventHubsException>().And.Property("Reason").EqualTo(EventHubsException.FailureReason.InvalidClientState));
            }
        }
    }
}
