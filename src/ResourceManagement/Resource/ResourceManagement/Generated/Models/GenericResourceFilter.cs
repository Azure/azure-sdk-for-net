namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class GenericResourceFilter
    {
        /// <summary>
        /// Gets or sets the resource type.
        /// </summary>
        [JsonProperty(PropertyName = "resourceType")]
        public string ResourceType { get; set; }

        /// <summary>
        /// Gets or sets the tag name.
        /// </summary>
        [JsonProperty(PropertyName = "tagname")]
        public string Tagname { get; set; }

        /// <summary>
        /// Gets or sets the tag value.
        /// </summary>
        [JsonProperty(PropertyName = "tagvalue")]
        public string Tagvalue { get; set; }

    }
}
