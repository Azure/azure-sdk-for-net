
namespace Microsoft.Azure.Management.NotificationHubs.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Namespace/NotificationHub Connection String
    /// </summary>
    public partial class ResourceListKeys
    {
        /// <summary>
        /// Initializes a new instance of the ResourceListKeys class.
        /// </summary>
        public ResourceListKeys() { }

        /// <summary>
        /// Initializes a new instance of the ResourceListKeys class.
        /// </summary>
        public ResourceListKeys(string primaryConnectionString = default(string), string secondaryConnectionString = default(string))
        {
            PrimaryConnectionString = primaryConnectionString;
            SecondaryConnectionString = secondaryConnectionString;
        }

        /// <summary>
        /// Gets or sets the primaryConnectionString of the created Namespace
        /// AuthorizationRule.
        /// </summary>
        [JsonProperty(PropertyName = "primaryConnectionString")]
        public string PrimaryConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the secondaryConnectionString of the created
        /// Namespace AuthorizationRule
        /// </summary>
        [JsonProperty(PropertyName = "secondaryConnectionString")]
        public string SecondaryConnectionString { get; set; }

    }
}
