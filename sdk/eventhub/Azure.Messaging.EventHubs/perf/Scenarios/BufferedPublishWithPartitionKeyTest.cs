// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
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
    public class BufferedPublishWithPartitionKeyTest : BufferedPublishPerfTest<EventHubsBufferedOptions>
    {
        /// <summary>The set of randomly generated partition keys to choose from.</summary>
        private static string[] s_partitionKeys;

        /// <summary>The random number generator to use for this test.</summary>
        private Random _random = new();

        /// <summary>
        ///   Initializes the <see cref="BufferedPublishWithPartitionKeyTest"/> class.
        /// </summary>
        ///
        static BufferedPublishWithPartitionKeyTest()
        {
            // Generate a set of partition keys.  For simplicity, take advantage
            // of the random file name generator; though this is limited to 11 characters,
            // it is sufficient for performance testing purposes.

            s_partitionKeys = Enumerable
                .Range(0, 128)
                .Select(index => Path.GetRandomFileName().Replace(".", string.Empty))
                .ToArray();
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="BufferedPublishWithPartitionKeyTest"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public BufferedPublishWithPartitionKeyTest(EventHubsBufferedOptions options) : base(options)
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
                PartitionKey = s_partitionKeys[_random.Next(0, s_partitionKeys.Length - 1)]
            };
    }
}
