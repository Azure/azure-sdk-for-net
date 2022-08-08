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
    ///   The performance test scenario focused on publishing sets of events
    ///   without a batch.
    /// </summary>
    ///
    /// <seealso cref="EventHubsPerfTest" />
    ///
    public abstract class EventPublishPerfTest<TOptions> : EventHubsPerfTest<TOptions> where TOptions : EventHubsOptions
    {
        /// <summary>The Event Hub to publish events to; shared across all concurrent instances of the scenario.</summary>
        private static EventHubScope s_scope;

        /// <summary>The producer instance for publishing events; shared across all concurrent instances of the scenario.</summary>
        private static EventHubProducerClient s_producer;

        /// <summary>The body to use when creating events; shared across all concurrent instances of the scenario.</summary>
        private static ReadOnlyMemory<byte> s_eventBody;

        /// <summary>The set of options to use when publishing events.</summary>
        private SendEventOptions _sendOptions;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventPublishPerfTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public EventPublishPerfTest(TOptions options) : base(options)
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
            _sendOptions = await CreateSendOptions(s_producer).ConfigureAwait(false);
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
            try
            {
                // Generate a set of events using the same body.  This will result in publishing a set of events
                // of equal size. The events will only differ by the id property that is assigned to them.

                await s_producer.SendAsync(
                    EventGenerator.CreateEventsFromBody(Options.BatchSize, s_eventBody),
                    _sendOptions,
                    cancellationToken
                ).ConfigureAwait(false);

                return Options.BatchSize;
            }
            catch (EventHubsException ex) when (cancellationToken.IsCancellationRequested && ex.IsTransient)
            {
                // If SendAsync() is canceled during a retry loop, the most recent exception is thrown.
                // If the exception is transient, it should be wrapped in an OperationCancelledException
                // which is ignored by the performance framework.

                throw new OperationCanceledException("EventHubsException thrown during cancellation", ex);
            }
        }

        /// <summary>
        ///   Determines the set of <see cref="Azure.Messaging.EventHubs.Producer.SendEventOptions"/>
        ///   needed for this test scenario.
        /// </summary>
        ///
        /// <param name="producer">The active producer for the test scenario.</param>
        ///
        /// <returns>The set of options to use when publishing events.</returns>
        ///
        protected abstract Task<SendEventOptions> CreateSendOptions(EventHubProducerClient producer);
    }
}
