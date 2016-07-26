
namespace Microsoft.Azure.Management.Media.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The response body for a ListKeys API.
    /// </summary>
    public partial class ServiceKeys
    {
        /// <summary>
        /// Initializes a new instance of the ServiceKeys class.
        /// </summary>
        public ServiceKeys() { }

        /// <summary>
        /// Initializes a new instance of the ServiceKeys class.
        /// </summary>
        public ServiceKeys(string primaryAuthEndpoint = default(string), string secondaryAuthEndpoint = default(string), string primaryKey = default(string), string secondaryKey = default(string), string scope = default(string))
        {
            PrimaryAuthEndpoint = primaryAuthEndpoint;
            SecondaryAuthEndpoint = secondaryAuthEndpoint;
            PrimaryKey = primaryKey;
            SecondaryKey = secondaryKey;
            Scope = scope;
        }

        /// <summary>
        /// The primary Authorization endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "primaryAuthEndpoint")]
        public string PrimaryAuthEndpoint { get; set; }

        /// <summary>
        /// The secondary Authorization endpoint.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryAuthEndpoint")]
        public string SecondaryAuthEndpoint { get; set; }

        /// <summary>
        /// The primary resource.
        /// </summary>
        [JsonProperty(PropertyName = "primaryKey")]
        public string PrimaryKey { get; set; }

        /// <summary>
        /// The secondary resource.
        /// </summary>
        [JsonProperty(PropertyName = "secondaryKey")]
        public string SecondaryKey { get; set; }

        /// <summary>
        /// The authorization scope.
        /// </summary>
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

    }
}
