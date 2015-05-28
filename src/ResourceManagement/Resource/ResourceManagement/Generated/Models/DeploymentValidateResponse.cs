using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Resources.Models
{
    /// <summary>
    /// </summary>
    public partial class DeploymentValidateResponse
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

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Error != null)
            {
                this.Error.Validate();
            }
            if (this.Properties != null)
            {
                this.Properties.Validate();
            }
        }
    }
}
