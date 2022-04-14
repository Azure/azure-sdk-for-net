// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario based on publishing events with the
    ///   <see cref="EventHubBufferedProducerClient" /> using round-robin partition
    ///   assignment.
    /// </summary>
    ///
    /// <seealso cref="BufferedPublishPerfTest{TOptions}" />
    ///
    public class BufferedPublishWithRoundRobinTest : BufferedPublishPerfTest<EventHubsBufferedOptions>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="BufferedPublishWithRoundRobinTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public BufferedPublishWithRoundRobinTest(EventHubsBufferedOptions options) : base (options)
        {
        }

        /// <summary>
        ///   Determines the set of <see cref="EnqueueEventOptions"/> needed for this test scenario.
        /// </summary>
        ///
        /// <returns>The set of options to use when enqueuing events to be published.</returns>
        ///
        /// <remarks>
        ///     This method is expected to be called each time that a set of events
        ///     is to be enqueued; it should be kept light and fast.
        /// </remarks>
        ///
        protected override EnqueueEventOptions CreateEnqueueOptions() => default;
    }
}
