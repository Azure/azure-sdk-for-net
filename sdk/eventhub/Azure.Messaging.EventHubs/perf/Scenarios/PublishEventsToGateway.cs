// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Messaging.EventHubs.Producer;
using Azure.Test.Perf;

namespace Azure.Messaging.EventHubs.Perf.Scenarios
{
    /// <summary>
    ///   The performance test scenario focused on publishing events
    ///   to the Event Hubs gateway endpoint.
    /// </summary>
    ///
    /// <seealso cref="EventPublishPerfTest" />
    ///
    public sealed class PublishEventsToGateway : EventPublishPerfTest<EventHubsOptions>
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="PublishEventsToGateway"/> class.
        /// </summary>
        ///
        /// <param name="options">The set of options to consider for configuring the scenario.</param>
        ///
        public PublishEventsToGateway(EventHubsOptions options) : base(options)
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
        protected override Task<SendEventOptions> CreateSendOptions(EventHubProducerClient producer) => Task.FromResult(new SendEventOptions());
    }
}
