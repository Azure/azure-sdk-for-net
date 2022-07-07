// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   The performance test scenario focused on publishing batches of events.
    /// </summary>
    ///
    /// <seealso cref="EventHubsPerfTest" />
    ///
    public abstract class BatchPublishPerfTest<TOptions> : EventHubsPerfTest<TOptions> where TOptions : EventHubsOptions
    {
        /// <summary>The Event Hub to publish events to; shared across all concurrent instances of the scenario.</summary>
        private static EventHubScope s_scope;

        /// <summary>The producer instance for publishing events; shared across all concurrent instances of the scenario.</summary>
        private static EventHubProducerClient s_producer;

        /// <summary>The body to use when creating events; shared across all concurrent instances of the scenario.</summary>
        private static ReadOnlyMemory<byte> s_eventBody;

        /// <summary>The set of options to use when creating batches.</summary>
        private CreateBatchOptions _batchOptions;

        /// <summary>
        ///   Initializes a new instance of the <see cref="BatchPublishPerfTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public BatchPublishPerfTest(TOptions options) : base(options)
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

            s_scope = await EventHubScope.CreateAsync(Options.PartitionCount).ConfigureAwait(false);
            s_producer = new EventHubProducerClient(TestEnvironment.EventHubsConnectionString, s_scope.EventHubName);
            s_eventBody = EventGenerator.CreateRandomBody(Options.BodySize);
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
            _batchOptions = await CreateBatchOptions(s_producer).ConfigureAwait(false);
        }

        /// <summary>
        ///   Performs the tasks needed to clean up the environment for the test scenario.
        ///   When multiple instances are run in parallel, the cleanup will take place once,
        ///   after the execution of all test instances.
        /// </summary>
        ///
        public async override Task GlobalCleanupAsync()
        {
            await s_producer.CloseAsync().ConfigureAwait(false);
            await s_scope.DisposeAsync().ConfigureAwait(false);
            await base.GlobalCleanupAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///   Executes the performance test scenario asynchronously.
        /// </summary>
        ///
        /// <param name="cancellationToken">The token used to signal when cancellation is requested.</param>
        ///
        public async override Task<int> RunBatchAsync(CancellationToken cancellationToken)
        {
            using var batch = await s_producer.CreateBatchAsync(_batchOptions, cancellationToken).ConfigureAwait(false);

            // Fill the batch with events using the same body.  This will result in a batch of events of equal size.
            // The events will only differ by the id property that is assigned to them.

            foreach (var eventData in EventGenerator.CreateEventsFromBody(Options.BatchSize, s_eventBody))
            {
                if (!batch.TryAdd(eventData))
                {
                    throw new InvalidOperationException("It was not possible to fit the requested number of events in a single batch.");
                }
            }

            try
            {
                await s_producer.SendAsync(batch, cancellationToken).ConfigureAwait(false);
                return Options.BatchSize;
            }
            catch (EventHubsException ex) when (cancellationToken.IsCancellationRequested && ex.IsTransient)
            {
                // If SendAsync() is canceled during a retry loop, the most recent exception is thrown.
                // If the exception is transient, it should be wrapped in an OperationCanceledException
                // which is ignored by the performance  framework.

                throw new OperationCanceledException("EventHubsException thrown during cancellation", ex);
            }
        }

        /// <summary>
        ///   Determines the set of <see cref="Azure.Messaging.EventHubs.Producer.CreateBatchOptions"/>
        ///   needed for this test scenario.
        /// </summary>
        ///
        /// <param name="producer">The active producer for the test scenario.</param>
        ///
        /// <returns>The set of options to use when creating batches to be published.</returns>
        ///
        protected abstract Task<CreateBatchOptions> CreateBatchOptions(EventHubProducerClient producer);
    }
}
