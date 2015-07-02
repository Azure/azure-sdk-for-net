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
    public partial class NetworkProfile
    {
        /// <summary>
        /// Gets or sets the network interfaces.
        /// </summary>
        [JsonProperty(PropertyName = "networkInterfaces")]
        public IList<NetworkInterfaceReference> NetworkInterfaces { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.NetworkInterfaces != null)
            {
                foreach ( var element in this.NetworkInterfaces)
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
