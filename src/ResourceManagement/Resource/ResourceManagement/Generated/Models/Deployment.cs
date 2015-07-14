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
    public partial class Deployment
    {
        /// <summary>
        /// Gets or sets the deployment properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public DeploymentProperties Properties { get; set; }

    }
}
