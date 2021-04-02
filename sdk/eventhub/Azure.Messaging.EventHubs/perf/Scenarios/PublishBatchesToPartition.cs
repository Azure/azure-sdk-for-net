// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on publishing a set of events.
    /// </summary>
    ///
    /// <seealso cref="BatchPublishPerfTest" />
    ///
    public sealed class PublishBatchesToPartition : BatchPublishPerfTest
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PublishBatchesToPartition"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public PublishBatchesToPartition(SizeCountOptions options) : base(options)
        {
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
        protected async override Task<CreateBatchOptions> CreateBatchOptions(EventHubProducerClient producer)
        {
            // Query the available partitions and select the first for use in the batch options.

            var partition = (await producer.GetPartitionIdsAsync().ConfigureAwait(false)).First();

            return new CreateBatchOptions
            {
                PartitionId = partition
            };
        }
    }
}
