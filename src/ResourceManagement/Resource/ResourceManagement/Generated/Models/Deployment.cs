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
    public partial class Deployment
    {
        /// <summary>
        /// Gets or sets the deployment properties.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public DeploymentProperties Properties { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Properties != null)
            {
                this.Properties.Validate();
            }
        }
    }
}
