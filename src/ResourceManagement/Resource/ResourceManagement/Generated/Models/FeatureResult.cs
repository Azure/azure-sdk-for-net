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
    public partial class FeatureResult
    {
        /// <summary>
        /// Gets or sets the name of the feature.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the properties of the previewed feature.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public FeatureProperties Properties { get; set; }

        /// <summary>
        /// Gets or sets the Id of the feature.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the type of the feature.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}
