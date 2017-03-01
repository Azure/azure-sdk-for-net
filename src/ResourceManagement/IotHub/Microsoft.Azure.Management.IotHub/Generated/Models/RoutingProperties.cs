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
    /// The routing related properties of the IoT hub. See:
    /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-messaging
    /// </summary>
    public partial class RoutingProperties
    {
        /// <summary>
        /// Initializes a new instance of the RoutingProperties class.
        /// </summary>
        public RoutingProperties()
        {
        }

        /// <summary>
        /// Initializes a new instance of the RoutingProperties class.
        /// </summary>
        public RoutingProperties(RoutingEndpoints endpoints = default(RoutingEndpoints), IList<RouteProperties> routes = default(IList<RouteProperties>), FallbackRouteProperties fallbackRoute = default(FallbackRouteProperties))
        {
            Endpoints = endpoints;
            Routes = routes;
            FallbackRoute = fallbackRoute;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endpoints")]
        public RoutingEndpoints Endpoints { get; set; }

        /// <summary>
        /// The list of user-provided routing rules that the IoT hub uses to
        /// route messages to built-in and custom endpoints. A maximum of 100
        /// routing rules are allowed for paid hubs and a maximum of 5
        /// routing rules are allowed for free hubs.
        /// </summary>
        [JsonProperty(PropertyName = "routes")]
        public IList<RouteProperties> Routes { get; set; }

        /// <summary>
        /// The properties of the route that is used as a fall-back route when
        /// none of the conditions specified in the 'routes' section are met.
        /// This is an optional parameter. When this property is not set, the
        /// messages which do not meet any of the conditions specified in the
        /// 'routes' section get routed to the built-in eventhub endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "fallbackRoute")]
        public FallbackRouteProperties FallbackRoute { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Routes != null)
            {
                foreach (var element in this.Routes)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
            if (this.FallbackRoute != null)
            {
                this.FallbackRoute.Validate();
            }
        }
    }
}
