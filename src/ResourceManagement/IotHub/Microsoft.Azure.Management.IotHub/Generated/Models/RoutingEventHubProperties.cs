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
    /// The properties related to an event hub endpoint.
    /// </summary>
    public partial class RoutingEventHubProperties
    {
        /// <summary>
        /// Initializes a new instance of the RoutingEventHubProperties class.
        /// </summary>
        public RoutingEventHubProperties() { }

        /// <summary>
        /// Initializes a new instance of the RoutingEventHubProperties class.
        /// </summary>
        public RoutingEventHubProperties(string connectionString, string name, string id = default(string), string subscriptionId = default(string), string resourceGroup = default(string))
        {
            ConnectionString = connectionString;
            Name = name;
            Id = id;
            SubscriptionId = subscriptionId;
            ResourceGroup = resourceGroup;
        }

        /// <summary>
        /// The connectionstring of the event hub endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "connectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// The name of the event hub endpoint. name can only include
        /// alphanumeric characters, periods, underscores, hyphens with
        /// maximum length of 64 characters. The following names are
        /// reserved;  events, operationsMonitoringEvents, fileNotifications,
        /// $default. Endpoint names have to be unique across endpoint types.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The identifier of the endpoint. An identifier will be assigned by
        /// the server, and once assigned, the identifier should never be
        /// modified. Modifying this value causes update IoT hub operations
        /// to fail. Do not pass id when specifying a new endpoint. Pass the
        /// same id that you get for an endpoint from the service when
        /// specifying an existing endpoint during update operations.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The subscription identifier of the event hub endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "subscriptionId")]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The name of the resource group of the event hub endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "resourceGroup")]
        public string ResourceGroup { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (ConnectionString == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ConnectionString");
            }
            if (Name == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Name");
            }
            if (this.Name != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Name, "^[A-Za-z0-9-._]{1,64}$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Name", "^[A-Za-z0-9-._]{1,64}$");
                }
            }
        }
    }
}
