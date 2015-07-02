namespace Microsoft.Azure.Management.Compute.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class WinRMConfiguration
    {
        /// <summary>
        /// Gets or sets the list of Windows Remote Management listeners
        /// </summary>
        [JsonProperty(PropertyName = "listeners")]
        public IList<WinRMListener> Listeners { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Listeners != null)
            {
                foreach ( var element in this.Listeners)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
        }
    }
}
