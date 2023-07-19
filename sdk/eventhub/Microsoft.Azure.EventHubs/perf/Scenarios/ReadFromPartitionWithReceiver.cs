// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;
using Microsoft.Azure.EventHubs.Tests;

namespace Microsoft.Azure.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on reading events
    ///   with the <see cref="PartitionReceiver" />.
    /// </summary>
    ///
    /// <seealso cref="EventHubsPerfTest" />
    ///
    public sealed class ReadFromPartitionWithReceiver : EventHubsPerfTest
    {
        /// <summary>The Event Hub to publish events to; shared across all concurrent instances of the scenario.</summary>
        private static EventHubScope s_scope ;

        /// <summary>The set of consumer groups available for readers to reserve an instance of; shared across all concurrent instances of the scenario.</summary>
        private static ConcurrentQueue<string> s_consumerGroups;

        /// <summary>The client instance that owns the connection to the Event Hubs namespace; each concurrent instance of the scenario will use an independent connection.</summary>
        private EventHubClient _client;

        /// <summary>The receiver instance for reading events.</summary>
        private PartitionReceiver _receiver;

        /// <summary>The identifier of the Event Hub partition from which events should be read.</summary>
        private string _partitionId;

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
        ///   Performs the tasks needed to initialize and set up the environment for the test scenario.
        ///   When multiple instances are run in parallel, the setup will take place once, prior to the
        ///   execution of the first test instance.
        /// </summary>
        ///
        public async override Task GlobalSetupAsync()
        {
            await base.GlobalCleanupAsync().ConfigureAwait(false);

            // The limit for concurrent readers in a consumer group is 5; create
            // enough consumer groups to support the requested parallelism.

            var consumerGroups = Enumerable
                .Range(0, (int)Math.Ceiling(Options.Parallel / 5.0d))
                .Select(index => $"group{ index }");

            // Create the Event Hub scope using the computed consumer groups; queue the
            // groups with 5 instances each, so that readers can reserve one without
            // exceeding the concurrent reader limit.

            s_scope = await EventHubScope.CreateAsync(4, consumerGroups).ConfigureAwait(false);
            s_consumerGroups = new ConcurrentQueue<string>(consumerGroups.SelectMany(group => Repeat(group, 5)));

            // Seed the necessary number of events to the selected partition.  Note that this
            // method makes heavy use of class state such as the TestUtility, Options, and
            // PartitionId.

            await SeedEventsToBeReadAsync(_client, _partitionId).ConfigureAwait(false);

            // Force a pause to give the events time to be committed in the Event Hubs
            // service and made available to read.

            await Task.Delay(TimeSpan.FromSeconds(30)).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for the test scenario.
        ///   When multiple instances are run in parallel, the cleanup will take place once,
        ///   after the execution of all test instances.
        /// </summary>
        ///
        public async override Task GlobalCleanupAsync()
        {
            await s_scope.DisposeAsync().ConfigureAwait(false);
            await base.GlobalCleanupAsync().ConfigureAwait(false);
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

            if (!s_consumerGroups.TryDequeue(out var consumerGroup))
            {
                throw new InvalidOperationException("Unable to reserve a consumer group to read from.");
            }

            _client = EventHubClient.CreateFromConnectionString(TestUtility.BuildEventHubsConnectionString(s_scope.EventHubName));
            _partitionId = (await _client.GetRuntimeInformationAsync().ConfigureAwait(false)).PartitionIds[0];

            _receiver = _client.CreateReceiver(
                consumerGroup,
                _partitionId,
                EventPosition.FromStart());

            // Force the connection and link creation by reading a single event.

            await _receiver.ReceiveAsync(1).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for an instance
        ///   of the test scenario.  When multiple instances are run in parallel, cleanup
        ///   will be run once for each after execution has completed.
        /// </summary>
        ///
        public async override Task CleanupAsync()
        {
            await _client.CloseAsync().ConfigureAwait(false);
            await _receiver.CloseAsync().ConfigureAwait(false);
            await base.CleanupAsync().ConfigureAwait(false);
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
                remainingEvents -= (await _receiver.ReceiveAsync(remainingEvents).ConfigureAwait(false)).Count();
            }

            // If iteration stopped due to cancellation, ensure that the expected exception is thrown.

            cancellationToken.ThrowIfCancellationRequested();
        }

        /// <summary>
        ///   Seeds the Event Hub partition with enough events to satisfy the read operations the test scenario
        ///   is expected to perform.
        /// </summary>
        ///
        /// <param name="client">The client to use for publishing events; ownership is assumed to be retained by the caller.</param>
        /// <param name="partitionId">The identifier of the partition to which events should be published.</param>
        ///
        /// <remarks>
        ///   This method makes heavy use of class state, including the
        ///   test environment and command line options.
        /// </remarks>
        ///
        private async Task SeedEventsToBeReadAsync(EventHubClient client,
                                                   string partitionId)
        {
            // Calculate the number of events needed to satisfy the number of events per iteration
            // and then buffer it to allow for the warm-up.

            var eventCount = Options.Count * Options.Iterations * 3;
            var eventBody = EventGenerator.CreateRandomBody(Options.Size);
            var sender = client.CreatePartitionSender(partitionId);

            try
            {
                foreach (var eventData in EventGenerator.CreateEventsFromBody(eventCount, eventBody))
                {
                    using var batch = sender.CreateBatch();

                    // Fill the batch with as many events that will fit.

                    while (batch.TryAdd(EventGenerator.CreateEventFromBody(eventBody)))
                    {
                    }

                    // If there were no events in the batch, then a single event was generated that is too large to
                    // ever send.  In this context, it will be detected on the first TryAdd call, since events are
                    // sharing a common body.

                    if (batch.Count == 0)
                    {
                        throw new InvalidOperationException("There was an event too large to fit into a batch.");
                    }

                    await sender.SendAsync(batch).ConfigureAwait(false);
                }
            }
            finally
            {
                await sender.CloseAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        ///   Repeats the specified string the requested number of times, capturing the instances
        ///   into a set.
        /// </summary>
        ///
        /// <param name="item">The item to duplicate.</param>
        /// <param name="count">The number of duplicate items that the resulting set should contain.</param>
        ///
        /// <returns>A set of <paramref name="item" /> duplicated <paramref name="count" /> times.</returns>
        ///
        private IEnumerable<string> Repeat(string item,
                                           int count) =>
            Enumerable
                .Range(1, count)
                .Select(index => item);
    }
}
