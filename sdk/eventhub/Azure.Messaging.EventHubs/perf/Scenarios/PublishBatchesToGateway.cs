// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on publishing batches of events
    ///   to the Event Hubs gateway endpoint.
    /// </summary>
    ///
    /// <seealso cref="BatchPublishPerfTest" />
    ///
    public sealed class PublishBatchesToGateway : BatchPublishPerfTest<EventHubsOptions>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PublishBatchesToGateway"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public PublishBatchesToGateway(EventHubsOptions options) : base(options)
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
        protected override Task<CreateBatchOptions> CreateBatchOptions(EventHubProducerClient producer) =>
            Task.FromResult(new CreateBatchOptions());
    }
}
