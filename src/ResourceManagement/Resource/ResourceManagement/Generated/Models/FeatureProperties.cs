namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Previewed feature information.
    /// </summary>
    public partial class FeatureProperties
    {
        /// <summary>
        /// Gets or sets the state of the previewed feature.
        /// </summary>
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

    }
}
