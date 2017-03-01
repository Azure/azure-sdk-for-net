// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The properties related to the custom endpoints to which your IoT hub
    /// routes messages based on the routing rules. A maximum of 10 custom
    /// endpoints are allowed across all endpoint types for paid hubs and
    /// only 1 custom endpoint is allowed across all endpoint types for free
    /// hubs.
    /// </summary>
    public partial class RoutingEndpoints
    {
        /// <summary>
        /// Initializes a new instance of the RoutingEndpoints class.
        /// </summary>
        public RoutingEndpoints() { }

        /// <summary>
        /// Initializes a new instance of the RoutingEndpoints class.
        /// </summary>
        public RoutingEndpoints(IList<RoutingServiceBusQueueEndpointProperties> serviceBusQueues = default(IList<RoutingServiceBusQueueEndpointProperties>), IList<RoutingServiceBusTopicEndpointProperties> serviceBusTopics = default(IList<RoutingServiceBusTopicEndpointProperties>), IList<RoutingEventHubProperties> eventHubs = default(IList<RoutingEventHubProperties>))
        {
            ServiceBusQueues = serviceBusQueues;
            ServiceBusTopics = serviceBusTopics;
            EventHubs = eventHubs;
        }

        /// <summary>
        /// The list of Service Bus queue endpoints that IoT hub routes the
        /// messages to, based on the routing rules.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusQueues")]
        public IList<RoutingServiceBusQueueEndpointProperties> ServiceBusQueues { get; set; }

        /// <summary>
        /// The list of Service Bus topic endpoints that the IoT hub routes
        /// the messages to, based on the routing rules.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusTopics")]
        public IList<RoutingServiceBusTopicEndpointProperties> ServiceBusTopics { get; set; }

        /// <summary>
        /// The list of Event Hubs endpoints that IoT hub routes messages to,
        /// based on the routing rules. This list does not include the
        /// built-in Event Hubs endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "eventHubs")]
        public IList<RoutingEventHubProperties> EventHubs { get; set; }

    }
}
