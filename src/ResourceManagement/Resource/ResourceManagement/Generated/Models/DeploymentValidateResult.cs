namespace Microsoft.Azure.Management.Resources.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Information from validate template deployment response.
    /// </summary>
    public partial class DeploymentValidateResult
    {
        /// <summary>
        /// Gets or sets validation error.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public ResourceManagementErrorWithDetails Error { get; set; }

        /// <summary>
        /// Gets or sets the template deployment properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public DeploymentPropertiesExtended Properties { get; set; }

    }
}
