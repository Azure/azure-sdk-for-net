// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Messaging.EventHubs.Tests;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Perf
{
    /// <summary>
    ///   The performance test scenario focused on publishing sets of events
    ///   without a batch.
    /// </summary>
    ///
    /// <seealso cref="EventHubsPerfTest" />
    ///
    public abstract class EventPublishPerfTest : EventHubsPerfTest
    {
        /// <summary>The Event Hub to publish events to; shared across all concurrent instances of the scenario.</summary>
        private static EventHubScope s_scope;

        /// <summary>The producer instance for publishing events; shared across all concurrent instances of the scenario.</summary>
        private static EventHubProducerClient s_producer;

        /// <summary>The body to use when creating events.</summary>
        private static ReadOnlyMemory<byte> s_eventBody;

        /// <summary>The set of options to use when publishing events.</summary>
        private static SendEventOptions s_sendOptions;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EventPublishPerfTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public EventPublishPerfTest(SizeCountOptions options) : base(options)
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

            s_scope = await EventHubScope.CreateAsync(4).ConfigureAwait(false);
            s_producer = new EventHubProducerClient(TestEnvironment.EventHubsConnectionString, s_scope.EventHubName);
            s_sendOptions = await CreateSendOptions(s_producer).ConfigureAwait(false);
            s_eventBody = EventGenerator.CreateRandomBody(Options.Size);

            // Publish an empty event to force the connection and link to be established.

            await s_producer.SendAsync(new[] { new EventData(Array.Empty<byte>()) }, s_sendOptions).ConfigureAwait(false);
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
        public async override Task RunAsync(CancellationToken cancellationToken)
        {
            // Generate a set of events using the same body.  This will result in publishing a set of events
            // of equal size. The events will only differ by the id property that is assigned to them.

            await s_producer.SendAsync(
                EventGenerator.CreateEventsFromBody(Options.Count, s_eventBody),
                s_sendOptions,
                cancellationToken
            ).ConfigureAwait(false);
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
