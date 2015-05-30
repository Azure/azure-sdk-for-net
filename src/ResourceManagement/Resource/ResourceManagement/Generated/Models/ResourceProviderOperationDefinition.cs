using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Rest;
using Microsoft.Azure;

namespace Microsoft.Azure.Management.Resources.Models
{
    /// <summary>
    /// </summary>
    public partial class ResourceProviderOperationDefinition
    {
        /// <summary>
        /// Gets or sets the provider operation name.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display property of the provider operation.
        /// </summary>
        [JsonProperty(PropertyName = "display")]
        public ResourceProviderOperationDisplayProperties Display { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Display != null)
            {
                this.Display.Validate();
            }
        }
    }
}
