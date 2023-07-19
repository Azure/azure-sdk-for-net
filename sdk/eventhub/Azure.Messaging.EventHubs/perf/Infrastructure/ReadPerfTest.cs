// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   The performance test scenario focused on reading events from an
    ///   Event Hub partition.
    /// </summary>
    ///
    /// <seealso cref="EventHubsPerfTest" />
    ///
    public abstract class ReadPerfTest<TOptions> : EventHubsPerfTest<TOptions> where TOptions : EventHubsOptions
    {
        /// <summary>
        ///   The Event Hub to publish events to; shared across all concurrent instances of the scenario.
        /// </summary>
        ///
        protected static EventHubScope Scope { get; private set; }

        /// <summary>
        ///   The set of consumer groups available for readers to reserve an instance of; shared across
        ///   all concurrent instances of the scenario.
        /// </summary>
        ///
        protected static ConcurrentQueue<string> ConsumerGroups { get; private set;}

        /// <summary>
        ///   The identifier of the Event Hub partition from which events should be read; shared across
        ///   all concurrent instances of the scenario.
        /// </summary>
        ///
        protected static string PartitionId { get; private set; }

        /// <summary>
        ///   Initializes a new instance of the <see cref="ReadPerfTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public ReadPerfTest(TOptions options) : base(options)
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
            await base.GlobalSetupAsync().ConfigureAwait(false);

            // The limit for concurrent readers in a consumer group is 5; create
            // enough consumer groups to support the requested parallelism.

            var consumerGroups = Enumerable
                .Range(0, (int)Math.Ceiling(Options.Parallel / 5.0d))
                .Select(index => $"group{ index }");

            // Create the Event Hub scope using the computed consumer groups; queue the
            // groups with 5 instances each, so that readers can reserve one without
            // exceeding the concurrent reader limit.

            Scope = await EventHubScope.CreateAsync(Options.PartitionCount, consumerGroups).ConfigureAwait(false);
            ConsumerGroups = new ConcurrentQueue<string>(consumerGroups.SelectMany(group => Repeat(group, 5)));

            // Select the first available partition to use for operations.

            await using var producer = new EventHubProducerClient(TestEnvironment.EventHubsConnectionString, Scope.EventHubName);
            PartitionId = (await producer.GetPartitionIdsAsync().ConfigureAwait(false)).First();

            // Seed the necessary number of events to the selected partition.  Note that this
            // method makes heavy use of class state such as the TestEnvironment, Options, and
            // PartitionId.

            await SeedEventsToBeReadAsync(producer).ConfigureAwait(false);

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
            await Scope.DisposeAsync().ConfigureAwait(false);
            await base.GlobalCleanupAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///   Seeds the Event Hub partition with enough events to satisfy the read operations the test scenario
        ///   is expected to perform.
        /// </summary>
        ///
        /// <param name="producer">The producer to use for publishing events; ownership is assumed to be retained by the caller.</param>
        ///
        /// <remarks>
        ///   This method makes heavy use of class state, including the
        ///   test environment and command line options.
        /// </remarks>
        ///
        private async Task SeedEventsToBeReadAsync(EventHubProducerClient producer)
        {
            // Calculate the number of events needed to satisfy the number of events per iteration
            // and then buffer it to allow for the warm-up.

            var eventCount = Options.BatchSize * Options.Iterations * 3;
            var eventBody = EventGenerator.CreateRandomBody(Options.BodySize);
            var batchOptions = new CreateBatchOptions { PartitionId = PartitionId };

            foreach (var eventData in EventGenerator.CreateEventsFromBody(eventCount, eventBody))
            {
                using var batch = await producer.CreateBatchAsync(batchOptions).ConfigureAwait(false);

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

                await producer.SendAsync(batch).ConfigureAwait(false);
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
