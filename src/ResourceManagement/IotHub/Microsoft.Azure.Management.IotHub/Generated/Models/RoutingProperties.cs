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
    /// https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-messaging
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
        public RoutingProperties(RoutingEndpoints endpoints = default(RoutingEndpoints), IList<RouteProperties> routes = default(IList<RouteProperties>), RouteProperties fallbackRoute = default(RouteProperties))
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
        /// The list of routing rules that users can provide, which the IoT
        /// hub uses to route messages to various in-built and user-provided
        /// endpoints. A maximum of 100 routing rules is allowed for paid
        /// hubs and a maximum of 5 routing rules is allowed for free hubs.
        /// </summary>
        [JsonProperty(PropertyName = "routes")]
        public IList<RouteProperties> Routes { get; set; }

        /// <summary>
        /// The properties of the route that will be used as a fallback route
        /// when none of the conditions specified in the 'routes' section are
        /// met. This is an optional parameter. When this property is not
        /// set, the messages which do not meet any of the conditions
        /// specified in the 'routes' section will get dropped.
        /// </summary>
        [JsonProperty(PropertyName = "fallbackRoute")]
        public RouteProperties FallbackRoute { get; set; }

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
                        element.Validate(false);
                    }
                }
            }
            if (this.FallbackRoute != null)
            {
                this.FallbackRoute.Validate(true);
            }
        }
    }
}
