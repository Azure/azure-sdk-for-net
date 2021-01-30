// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using NUnit.Framework;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   The suite of live tests for the idempotent publishing feature of the
    ///   <see cref="EventHubProducerClientClient" /> class.
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
    public class IdempotentPublishingLiveTests
    {
        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
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
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                await using var producer = new EventHubProducerClient(connectionString, options);
                Assert.That(async () => await producer.GetPartitionIdsAsync(cancellationSource.Token), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
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
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true, ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType }};

                await using var producer = new EventHubProducerClient(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                var sendOptions = new SendEventOptions { PartitionId = partition };

                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(2), sendOptions, cancellationSource.Token), Throws.Nothing, "The first publishing operation was not successful.");
                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(2), sendOptions, cancellationSource.Token), Throws.Nothing, "The second publishing operation was not successful.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
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
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true, ConnectionOptions = new EventHubConnectionOptions { TransportType = transportType }};

                await using var producer = new EventHubProducerClient(connectionString, options);

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
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerInitializesPropertiesWhenRequested()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

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
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerInitializesPropertiesWhenPublishing()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

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
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerManagesConcurrencyWhenPublishingEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                var sendOptions = new SendEventOptions { PartitionId = partition };

                async Task sendEvents (int delayMilliseconds)
                {
                    await Task.Delay(delayMilliseconds);
                    await producer.SendAsync(EventGenerator.CreateEvents(2), sendOptions, cancellationSource.Token);
                }

                var pendingSends = Task.WhenAll(
                    sendEvents(100),
                    sendEvents(50),
                    sendEvents(0)
                );

                Assert.That(async () => await pendingSends, Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerManagesConcurrencyWhenPublishingBatches()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                var batchOptions = new CreateBatchOptions { PartitionId = partition };

                async Task sendBatch (int delayMilliseconds)
                {
                    await Task.Delay(delayMilliseconds);

                    using var batch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);
                    batch.TryAdd(EventGenerator.CreateEvents(1).First());
                    batch.TryAdd(EventGenerator.CreateEvents(1).First());
                    batch.TryAdd(EventGenerator.CreateEvents(1).First());

                    await producer.SendAsync(batch, cancellationSource.Token);
                }

                var pendingSends = Task.WhenAll(
                    sendBatch(100),
                    sendBatch(50),
                    sendBatch(0)
                );

                Assert.That(async () => await pendingSends, Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerAllowsPublishingConcurrentlyToDifferentPartitions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(4))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                async Task sendEvents(string partition, int delayMilliseconds)
                {
                    await Task.Delay(delayMilliseconds);
                    await producer.SendAsync(EventGenerator.CreateEvents(5), new SendEventOptions { PartitionId = partition }, cancellationSource.Token);
                }

                var partitions = await producer.GetPartitionIdsAsync(cancellationSource.Token);
                var pendingSends = new List<Task>();

                foreach (var partition in partitions)
                {
                    pendingSends.Add(sendEvents(partition, 50));
                    pendingSends.Add(sendEvents(partition, 0));
                }

                Assert.That(async () => await Task.WhenAll(pendingSends), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerSequencesEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).Last();
                var sendOptions = new SendEventOptions { PartitionId = partition };

                var partitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);
                var eventSequenceNumber = partitionProperties.LastPublishedSequenceNumber;

                var events = EventGenerator.CreateEvents(10).ToArray();
                Assert.That(events.Any(item => item.PublishedSequenceNumber.HasValue), Is.False, "Events should start out as unpublished with no sequence number.");

                await producer.SendAsync(events, sendOptions, cancellationSource.Token);
                Assert.That(events.All(item => item.PublishedSequenceNumber.HasValue), Is.True, "Events should be sequenced after publishing.");

                foreach (var item in events)
                {
                    Assert.That(item.PublishedSequenceNumber, Is.EqualTo(++eventSequenceNumber), $"The sequence numbers should be contiguous.  Event { eventSequenceNumber } was out of order.");
                }
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerSequencesBatches()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).Last();
                var batchOptions = new CreateBatchOptions { PartitionId = partition };

                var partitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);
                var eventSequenceNumber = partitionProperties.LastPublishedSequenceNumber;

                using var firstBatch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);
                firstBatch.TryAdd(EventGenerator.CreateEvents(1).First());
                firstBatch.TryAdd(EventGenerator.CreateEvents(1).First());
                firstBatch.TryAdd(EventGenerator.CreateEvents(1).First());

                using var secondBatch = await producer.CreateBatchAsync(batchOptions, cancellationSource.Token);
                secondBatch.TryAdd(EventGenerator.CreateEvents(1).First());
                secondBatch.TryAdd(EventGenerator.CreateEvents(1).First());
                secondBatch.TryAdd(EventGenerator.CreateEvents(1).First());
                secondBatch.TryAdd(EventGenerator.CreateEvents(1).First());

                Assert.That(firstBatch.StartingPublishedSequenceNumber.HasValue, Is.False, "Batches should start out as unpublished with no sequence number, the first batch was incorrect.");
                Assert.That(secondBatch.StartingPublishedSequenceNumber.HasValue, Is.False, "Batches should start out as unpublished with no sequence number, the second batch was incorrect.");

                await producer.SendAsync(firstBatch, cancellationSource.Token);
                await producer.SendAsync(secondBatch, cancellationSource.Token);

                Assert.That(firstBatch.StartingPublishedSequenceNumber.HasValue, "Batches should be sequenced after publishing, the first batch was incorrect.");
                Assert.That(firstBatch.StartingPublishedSequenceNumber, Is.EqualTo(eventSequenceNumber + 1), "Batches should be sequenced after publishing, the first batch was incorrect.");

                Assert.That(secondBatch.StartingPublishedSequenceNumber.HasValue, "Batches should be sequenced after publishing, the second batch was incorrect.");
                Assert.That(secondBatch.StartingPublishedSequenceNumber, Is.EqualTo(eventSequenceNumber + 1 + firstBatch.Count), "Batches should be sequenced after publishing, the second batch was incorrect.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerUpdatesPropertiesAfterPublishingEvents()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = (await producer.GetPartitionIdsAsync(cancellationSource.Token)).First();
                var initialPartitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);

                var sendOptions = new SendEventOptions { PartitionId = partition };
                var events = EventGenerator.CreateEvents(10).ToArray();
                await producer.SendAsync(events, sendOptions, cancellationSource.Token);

                var updatedPartitionProperties = await producer.GetPartitionPublishingPropertiesAsync(partition);
                Assert.That(updatedPartitionProperties.IsIdempotentPublishingEnabled, Is.True, "Idempotent publishing should be enabled.");
                Assert.That(updatedPartitionProperties.ProducerGroupId, Is.EqualTo(initialPartitionProperties.ProducerGroupId), "The producer group identifier should not have changed.");
                Assert.That(updatedPartitionProperties.OwnerLevel, Is.EqualTo(initialPartitionProperties.OwnerLevel), "The owner level should not have changed.");
                Assert.That(updatedPartitionProperties.LastPublishedSequenceNumber, Is.GreaterThan(initialPartitionProperties.LastPublishedSequenceNumber), "The last published sequence number should have increased.");
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerUpdatesPropertiesAfterPublishingBatches()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(1))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                await using var producer = new EventHubProducerClient(connectionString, options);

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
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanInitializeWithPartitionOptions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = default(string);
                var partitionProperties =  default(PartitionPublishingProperties);

                // Create a producer for a small scope that will Send some events and read the properties.

                await using (var initialProducer = new EventHubProducerClient(connectionString, options))
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

                await using var producer = new EventHubProducerClient(connectionString, options);
                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token), Throws.Nothing);
            }
        }

        /// <summary>
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerCanInitializeWithPartialPartitionOptions()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = default(string);
                var partitionProperties =  default(PartitionPublishingProperties);

                // Create a producer for a small scope that will Send some events and read the properties.

                await using (var initialProducer = new EventHubProducerClient(connectionString, options))
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
                await using var producer = new EventHubProducerClient(connectionString, options);

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
        ///   Verifies that the <see cref="EventHubProducerClient" /> is able to
        ///   perform operations when the idempotent publishing feature is enabled.
        /// </summary>
        ///
        [Test]
        public async Task ProducerIsRejectedWithPartitionOptionsForInvalidState()
        {
            await using (EventHubScope scope = await EventHubScope.CreateAsync(2))
            {
                var connectionString = EventHubsTestEnvironment.Instance.BuildConnectionStringForEventHub(scope.EventHubName);
                var options = new EventHubProducerClientOptions { EnableIdempotentPartitions = true };

                var cancellationSource = new CancellationTokenSource();
                cancellationSource.CancelAfter(EventHubsTestEnvironment.Instance.TestExecutionTimeLimit);

                var partition = default(string);
                var partitionProperties =  default(PartitionPublishingProperties);

                // Create a producer for a small scope that will Send some events and read the properties.

                await using (var initialProducer = new EventHubProducerClient(connectionString, options))
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

                await using var producer = new EventHubProducerClient(connectionString, options);

                Assert.That(async () => await producer.SendAsync(EventGenerator.CreateEvents(10), new SendEventOptions { PartitionId = partition }, cancellationSource.Token),
                    Throws.InstanceOf<EventHubsException>().And.Property("Reason").EqualTo(EventHubsException.FailureReason.InvalidClientState));
            }
        }
    }
}
