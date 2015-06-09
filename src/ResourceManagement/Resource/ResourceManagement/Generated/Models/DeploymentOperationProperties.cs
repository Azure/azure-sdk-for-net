using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Rest.Serialization;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Resources.Models
{
    /// <summary>
    /// </summary>
    public partial class DeploymentOperationProperties
    {
        /// <summary>
        /// Gets or sets the state of the provisioning.
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the operation.
        /// </summary>
        [JsonProperty(PropertyName = "timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets operation status code.
        /// </summary>
        [JsonProperty(PropertyName = "statusCode")]
        public string StatusCode { get; set; }

        /// <summary>
        /// Gets or sets operation status message.
        /// </summary>
        [JsonProperty(PropertyName = "statusMessage")]
        public object StatusMessage { get; set; }

        /// <summary>
        /// Gets or sets the target resource.
        /// </summary>
        [JsonProperty(PropertyName = "targetResource")]
        public TargetResource TargetResource { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.TargetResource != null)
            {
                this.TargetResource.Validate();
            }
        }
    }
}
