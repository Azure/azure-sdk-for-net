namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Resource type managed by the resource provider.
    /// </summary>
    public partial class ProviderResourceType
    {
        /// <summary>
        /// Gets or sets the resource type.
        /// </summary>
        [JsonProperty(PropertyName = "resourceType")]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the collection of locations where this resource type
        /// can be created in.
        /// </summary>
        [JsonProperty(PropertyName = "locations")]
        public IList<string> Locations { get; set; }

        /// <summary>
        /// Gets or sets the api version.
        /// </summary>
        [JsonProperty(PropertyName = "apiVersions")]
        public IList<string> ApiVersions { get; set; }

        /// <summary>
        /// Gets or sets the properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IDictionary<string, string> Properties { get; set; }

    }
}
