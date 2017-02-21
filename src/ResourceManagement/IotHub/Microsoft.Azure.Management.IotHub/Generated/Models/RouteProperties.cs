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
    /// The properties related to a routing rule based on which the IoT hub
    /// routes messages to endpoints.
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
        public RouteProperties(string name, IList<string> endpointNames, bool isEnabled, string condition = default(string))
        {
            Name = name;
            Condition = condition;
            EndpointNames = endpointNames;
            IsEnabled = isEnabled;
        }
        /// <summary>
        /// Static constructor for RouteProperties class.
        /// </summary>
        static RouteProperties()
        {
            Source = "DeviceMessages";
        }

        /// <summary>
        /// The name of the route. name can only include alphanumeric
        /// characters, periods, underscores, hyphens with maximum length of
        /// 64 characters and must be unique.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The condition which is evaluated in order to apply the routing
        /// rule. If the condition is not provided it will evaluate to true
        /// by default. For grammar, See:
        /// https://docs.microsoft.com/en-us/azure/iot-hub/iot-hub-devguide-query-language
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
        /// Used to specify whether a route is enabled or not.
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
        public virtual void Validate(bool isFallback)
        {
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (EndpointNames == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "EndpointNames");
            }
            if (this.Name != null)
            {
                if (this.Name.Length > 64)
                {
                    throw new ValidationException(ValidationRules.Pattern, "Name", "Name Length cannot be greate than 64");
                }

                if (!isFallback && !System.Text.RegularExpressions.Regex.IsMatch(this.Name, "^[A-Za-z0-9-._]{1,64}$"))
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
