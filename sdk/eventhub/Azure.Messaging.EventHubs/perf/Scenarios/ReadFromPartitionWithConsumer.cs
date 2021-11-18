// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on reading events from an
    ///   Event Hub partition using the <see cref="EventHubConsumerClient" />.
    /// </summary>
    ///
    /// <seealso cref="ReadPerfTest" />
    ///
    public sealed class ReadFromPartitionWithConsumer : ReadPerfTest<EventHubsOptions>
    {
        /// <summary>The consumer to use for reading from the partition.</summary>
        private EventHubConsumerClient _consumer;

        /// <summary>The asynchronous enumerator to use for reading; this ensures consistency across calls to RunAsync.</summary>
        private ConfiguredCancelableAsyncEnumerable<PartitionEvent>.Enumerator _readEnumerator;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ReadFromPartitionWithConsumer"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public ReadFromPartitionWithConsumer(EventHubsOptions options) : base(options)
        {
        }

        /// <summary>
        ///   Performs the tasks needed to initialize and set up the environment for an instance
        ///   of the test scenario.  When multiple instances are run in parallel, setup will be
        ///   run once for each prior to its execution.
        /// </summary>
        ///
        public async override Task SetupAsync()
        {
            await base.SetupAsync().ConfigureAwait(false);

            // Attempt to take a consumer group from the available set; to ensure that the
            // test scenario can support the requested level of parallelism without violating
            // the concurrent reader limits of a consumer group, the default consumer group
            // should not be used.

            if (!ConsumerGroups.TryDequeue(out var consumerGroup))
            {
                throw new InvalidOperationException("Unable to reserve a consumer group to read from.");
            }

            _consumer = new EventHubConsumerClient(consumerGroup, TestEnvironment.EventHubsConnectionString, Scope.EventHubName);

            // In order to allow reading across multiple iterations, capture an enumerator.  Without using a consistent
            // enumerator, a new AMQP link would be created and the position reset each time RunAsync was invoked.

            _readEnumerator = _consumer
                .ReadEventsFromPartitionAsync(PartitionId, EventPosition.Earliest)
                .ConfigureAwait(false)
                .GetAsyncEnumerator();

            // Force the connection and link creation by reading a single event.

            if (!(await _readEnumerator.MoveNextAsync()))
            {
                throw new InvalidOperationException("Unable to read from the partition.");
            }
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for an instance
        ///   of the test scenario.  When multiple instances are run in parallel, cleanup
        ///   will be run once for each after execution has completed.
        /// </summary>
        ///
        public async override Task CleanupAsync()
        {
            await _readEnumerator.DisposeAsync();
            await _consumer.CloseAsync().ConfigureAwait(false);
            await base.CleanupAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///   Executes the performance test scenario asynchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public async override Task<int> RunBatchAsync(CancellationToken cancellationToken)
        {
            // Read the requested number of events.

            var readCount = 0;

            while ((!cancellationToken.IsCancellationRequested) && (++readCount <= Options.BatchSize))
            {
                if (!(await _readEnumerator.MoveNextAsync()))
                {
                    throw new InvalidOperationException("Unable to read from the partition.");
                }
            }

            // If iteration stopped due to cancellation, ensure that the expected exception is thrown.

            cancellationToken.ThrowIfCancellationRequested();
            return Options.BatchSize;
        }
    }
}
