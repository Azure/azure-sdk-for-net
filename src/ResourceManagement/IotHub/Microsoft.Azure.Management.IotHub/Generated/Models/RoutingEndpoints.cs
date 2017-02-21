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
    /// The properties related to the user-provided endpoints to which IoT hub
    /// routes the messages to, based on the routing rules. A maximum of 10
    /// endpoints is allowed across all endpoint types for paid hubs and a
    /// maximum of 1 endpoint is allowed across all endpoint types for free
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
        public RoutingEndpoints(IList<RoutingMessagingEndpointProperties> serviceBusQueues = default(IList<RoutingMessagingEndpointProperties>), IList<RoutingMessagingEndpointProperties> serviceBusTopics = default(IList<RoutingMessagingEndpointProperties>), IList<RoutingEventHubProperties> eventHubs = default(IList<RoutingEventHubProperties>))
        {
            ServiceBusQueues = serviceBusQueues;
            ServiceBusTopics = serviceBusTopics;
            EventHubs = eventHubs;
        }

        /// <summary>
        /// The list of service bus queue endpoints to which IoT hub routes
        /// the messages to, based on the routing rules.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusQueues")]
        public IList<RoutingMessagingEndpointProperties> ServiceBusQueues { get; set; }

        /// <summary>
        /// The list of service bus topic endpoints to which IoT hub routes
        /// the messages to, based on the routing rules.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusTopics")]
        public IList<RoutingMessagingEndpointProperties> ServiceBusTopics { get; set; }

        /// <summary>
        /// The list of eventhub endpoints to which IoT hub routes the
        /// messages to, based on the routing rules. This list should not
        /// include the in-built eventhub endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "eventHubs")]
        public IList<RoutingEventHubProperties> EventHubs { get; set; }

    }
}
