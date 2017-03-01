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
    /// The properties related to the fallback route based on which the IoT
    /// hub routes messages to the fallback endpoint.
    /// </summary>
    public partial class FallbackRouteProperties
    {
        /// <summary>
        /// Initializes a new instance of the FallbackRouteProperties class.
        /// </summary>
        public FallbackRouteProperties() { }

        /// <summary>
        /// Initializes a new instance of the FallbackRouteProperties class.
        /// </summary>
        public FallbackRouteProperties(IList<string> endpointNames, bool isEnabled, string condition = default(string))
        {
            Condition = condition;
            EndpointNames = endpointNames;
            IsEnabled = isEnabled;
        }
        /// <summary>
        /// Static constructor for FallbackRouteProperties class.
        /// </summary>
        static FallbackRouteProperties()
        {
            Source = "DeviceMessages";
        }

        /// <summary>
        /// The condition which is evaluated in order to apply the fallback
        /// route. If the condition is not provided it will evaluate to true
        /// by default. For grammar, See:
        /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-query-language
        /// </summary>
        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }

        /// <summary>
        /// The list of endpoints to which the messages that satisfy the
        /// condition are routed to. Currently only 1 endpoint is allowed.
        /// </summary>
        [JsonProperty(PropertyName = "endpointNames")]
        public IList<string> EndpointNames { get; set; }

        /// <summary>
        /// Used to specify whether the fallback route is enabled or not.
        /// </summary>
        [JsonProperty(PropertyName = "isEnabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// The source to which the routing rule is to be applied to. e.g.
        /// DeviceMessages
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public static string Source { get; private set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (EndpointNames == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EndpointNames");
            }
            if (this.EndpointNames != null)
            {
                if (this.EndpointNames.Count > 1)
                {
                    throw new ValidationException(ValidationRules.MaxItems, "EndpointNames", 1);
                }
                if (this.EndpointNames.Count < 1)
                {
                    throw new ValidationException(ValidationRules.MinItems, "EndpointNames", 1);
                }
            }
        }
    }
}
