// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on publishing events
    ///   to an Event Hub partition.
    /// </summary>
    ///
    /// <seealso cref="EventPublishPerfTest" />
    ///
    public sealed class PublishEventsToPartition : EventPublishPerfTest<EventHubsPartitionOptions>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PublishEventsToPartition"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public PublishEventsToPartition(EventHubsPartitionOptions options) : base(options)
        {
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
        protected async override Task<SendEventOptions> CreateSendOptions(EventHubProducerClient producer)
        {
            // Query the available partitions and select the partition for use in the batch options.

            var partitions = await producer.GetPartitionIdsAsync().ConfigureAwait(false);
            var partitionsToPublish = Options.ShouldUseAllPartitions ? partitions.Length : Options.Partitions;
            var partition = partitions[ParallelIndex % partitionsToPublish];

            return new SendEventOptions
            {
                PartitionId = partition
            };
        }
    }
}
