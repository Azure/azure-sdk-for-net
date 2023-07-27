// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Azure.Storage.Blobs;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Processor.Perf.Infrastructure
{
    /// <summary>
    ///   The performance test scenario focused on an event processor.
    /// </summary>
    ///
    /// <seealso cref="EventPerfTest{T}" />
    ///
    public abstract class ProcessorTest<TOptions> : EventPerfTest<TOptions> where TOptions : ProcessorOptions
    {
        /// <summary>The Azure Blob storage client for the container used to store ownership and checkpoint data.</summary>
        private readonly BlobContainerClient _checkpointStore;

        /// <summary>
        ///   The active <see cref="EventHubsTestEnvironment" /> instance for the
        ///   performance test scenarios.
        /// </summary>
        ///
        protected EventHubsTestEnvironment TestEnvironment => EventHubsTestEnvironment.Instance;

        /// <summary>
        ///   The active <see cref="StorageTestEnvironment" /> instance for the
        ///   performance test scenarios.
        /// </summary>
        ///
        protected StorageTestEnvironment StorageTestEnvironment => StorageTestEnvironment.Instance;

        /// <summary>
        ///   The Event Hub used for the test.
        /// </summary>
        ///
        protected EventHubScope Scope { get; private set; }

        /// <summary>
        ///   The <see cref="EventProcessorClient" /> to use for the current test scenario.
        /// </summary>
        ///
        protected EventProcessorClient EventProcessorClient { get; private set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ProcessorTest{TOptions}" /> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public ProcessorTest(TOptions options) : base(options)
        {
            var containerName = $"CheckpointStore-{Guid.NewGuid()}".ToLowerInvariant();
            _checkpointStore = new BlobContainerClient(StorageTestEnvironment.StorageConnectionString, containerName);
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   This setup will take place once for each instance, running after the global setup has
        ///   completed.
        /// </summary>
        ///
        public override async Task SetupAsync()
        {
            await base.SetupAsync();

            // Create the Event Hub and seed it with events.

            Scope = await EventHubScope.CreateAsync(Options.PartitionCount).ConfigureAwait(false);

            await using var producer = new EventHubProducerClient(TestEnvironment.EventHubsConnectionString, Scope.EventHubName);
            await SeedEventsToBeReadAsync(producer, Options.EventBodySize, Options.EventSeedCount).ConfigureAwait(false);

            // Ensure that the Blob storage container for processor data exists.

            await _checkpointStore.CreateIfNotExistsAsync().ConfigureAwait(false);

            // Create the processor client.

            var clientOptions = new EventProcessorClientOptions { LoadBalancingStrategy = Options.LoadBalancingStrategy };

            if (Options.CacheEventCount.HasValue)
            {
                clientOptions.CacheEventCount = Options.CacheEventCount.Value;
            }

            if (Options.MaximumWaitTimeMs.HasValue)
            {
                clientOptions.MaximumWaitTime = TimeSpan.FromMilliseconds(Options.MaximumWaitTimeMs.Value);
            }

            if (Options.PrefetchCount.HasValue)
            {
                clientOptions.PrefetchCount = Options.PrefetchCount.Value;
            }

            EventProcessorClient = new EventProcessorClient(
                _checkpointStore,
                Scope.ConsumerGroups[0],
                TestEnvironment.EventHubsConnectionString,
                Scope.EventHubName,
                clientOptions);
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   This setup will take place once for each instance, running before the global cleanup is
        ///   run.
        /// </summary>
        ///
        public override async Task CleanupAsync()
        {
            try
            {
                await _checkpointStore.DeleteIfExistsAsync().ConfigureAwait(false);
            }
            finally
            {
                await Scope.DisposeAsync().ConfigureAwait(false);
            }

            await base.CleanupAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///   Seeds the Event Hub partition with enough events to satisfy the read operations the test scenario
        ///   is expected to perform.
        /// </summary>
        ///
        /// <param name="producer">The producer to use for publishing events; ownership is assumed to be retained by the caller.</param>
        /// <param name="bodySizeBytes">The size, in bytes, that the body of events used to seed the Event Hub should be.</param>
        /// <param name="eventCount">The number of events that should be published, distributed among partitions.</param>
        ///
        private static async Task SeedEventsToBeReadAsync(EventHubProducerClient producer,
                                                          int bodySizeBytes,
                                                          int eventCount)
        {
            // Use the same event body for all events being published, to ensure consistency of the data being
            // read and processed for the test.

            var eventBody = EventGenerator.CreateRandomBody(bodySizeBytes);
            var remainingEvents = eventCount;

            while (remainingEvents > 0)
            {
                using var batch = await producer.CreateBatchAsync().ConfigureAwait(false);

                while ((batch.TryAdd(EventGenerator.CreateEventFromBody(eventBody))) && (remainingEvents > 0))
                {
                    --remainingEvents;
                }

                // If there were no events in the batch, then a single event was generated that is too large to
                // ever send.  In this context, it will be detected on the first TryAdd call, since events are
                // sharing a common body.

                if (batch.Count == 0)
                {
                    throw new InvalidOperationException("There was an event too large to fit into a batch.");
                }

                await producer.SendAsync(batch).ConfigureAwait(false);
            }
        }
    }
}
