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
    /// The properties of a routing rule that your IoT hub uses to route
    /// messages to endpoints.
    /// </summary>
    public partial class RouteProperties
    {
        /// <summary>
        /// Initializes a new instance of the RouteProperties class.
        /// </summary>
        public RouteProperties() { }

        /// <summary>
        /// Initializes a new instance of the RouteProperties class.
        /// </summary>
        public RouteProperties(string name, string source, IList<string> endpointNames, bool isEnabled, string condition = default(string))
        {
            Name = name;
            Source = source;
            Condition = condition;
            EndpointNames = endpointNames;
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// The name of the route. The name can only include alphanumeric
        /// characters, periods, underscores, hyphens, has a maximum length
        /// of 64 characters,  and must be unique.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The source that the routing rule is to be applied to, such as
        /// DeviceMessages. Possible values include: 'DeviceMessages',
        /// 'TwinChangeEvents', 'DeviceLifecycleEvents',
        /// 'DeviceJobLifecycleEvents'
        /// </summary>
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        /// <summary>
        /// The condition that is evaluated to apply the routing rule. If no
        /// condition is provided, it evaluates to true by default. For
        /// grammar, See:
        /// https://docs.microsoft.com/azure/iot-hub/iot-hub-devguide-query-language
        /// </summary>
        [JsonProperty(PropertyName = "condition")]
        public string Condition { get; set; }

        /// <summary>
        /// The list of endpoints to which messages that satisfy the condition
        /// are routed. Currently only one endpoint is allowed.
        /// </summary>
        [JsonProperty(PropertyName = "endpointNames")]
        public IList<string> EndpointNames { get; set; }

        /// <summary>
        /// Used to specify whether a route is enabled.
        /// </summary>
        [JsonProperty(PropertyName = "isEnabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (Source == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Source");
            }
            if (EndpointNames == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EndpointNames");
            }
            if (this.Name != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Name, "^[A-Za-z0-9-._]{1,64}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Name", "^[A-Za-z0-9-._]{1,64}$");
                }
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
