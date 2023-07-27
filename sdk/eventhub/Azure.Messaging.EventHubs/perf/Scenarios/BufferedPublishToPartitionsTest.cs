// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario based on publishing events with the
    ///   <see cref="EventHubBufferedProducerClient" /> using partition keys for
    ///    partition assignment.
    /// </summary>
    ///
    /// <seealso cref="BufferedPublishPerfTest{TOptions}" />
    ///
    public class BufferedPublishToPartitionsTest : BufferedPublishPerfTest<EventHubsBufferedOptions>
    {
        /// <summary>The random number generator to use for this test.</summary>
        private Random _random = new();

        /// <summary>
        ///   Initializes a new instance of the <see cref="BufferedPublishToPartitionsTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public BufferedPublishToPartitionsTest(EventHubsBufferedOptions options) : base(options)
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
        protected override EnqueueEventOptions CreateEnqueueOptions() =>
            new EnqueueEventOptions
            {
                PartitionId = Partitions[_random.Next(0, Partitions.Length - 1)]
            };
    }
}
