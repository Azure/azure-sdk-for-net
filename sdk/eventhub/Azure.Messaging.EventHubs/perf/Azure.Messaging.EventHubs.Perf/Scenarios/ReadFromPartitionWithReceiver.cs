// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Consumer;
using Azure.Messaging.EventHubs.Primitives;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on publishing events
    ///   to an Event Hubs partition.
    /// </summary>
    ///
    /// <seealso cref="ReadPerfTest" />
    ///
    public sealed class ReadFromPartitionWithReceiver : ReadPerfTest
    {
        /// <summary>The receiver to use for reading from the partition.</summary>
        private PartitionReceiver _receiver;

        /// <summary>
        ///   Initializes a new instance of the <see cref="ReadFromPartitionWithReceiver"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public ReadFromPartitionWithReceiver(SizeCountOptions options) : base(options)
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
            await base.SetupAsync();

            // Attempt to take a consumer group from the available set; to ensure that the
            // test scenario can support the requested level of parallelism without violating
            // the concurrent reader limits of a consumer group, the default consumer group
            // should not be used.

            if (!ConsumerGroups.TryDequeue(out var consumerGroup))
            {
                throw new InvalidOperationException("Unable to reserve a consumer group to read from.");
            }

            _receiver = new PartitionReceiver(
                consumerGroup,
                PartitionId,
                EventPosition.Earliest,
                TestEnvironment.EventHubsConnectionString,
                Scope.EventHubName);

            // Force the connection and link creation by reading a single event.

            await _receiver.ReceiveBatchAsync(1).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for an instance
        ///   of the test scenario.  When multiple instances are run in parallel, cleanup
        ///   will be run once for each after execution has completed.
        /// </summary>
        ///
        public async override Task CleanupAsync()
        {
            await _receiver.CloseAsync().ConfigureAwait(false);
            await base.CleanupAsync();
        }

        /// <summary>
        ///   Executes the performance test scenario asynchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public async override Task RunAsync(CancellationToken cancellationToken)
        {
            // Read the requested number of events.

            var remainingEvents = Options.Count;

            while ((!cancellationToken.IsCancellationRequested) && (remainingEvents > 0))
            {
                remainingEvents -= (await _receiver.ReceiveBatchAsync(remainingEvents).ConfigureAwait(false)).Count();
            }

            // If iteration stopped due to cancellation, ensure that the expected exception is thrown.

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}
