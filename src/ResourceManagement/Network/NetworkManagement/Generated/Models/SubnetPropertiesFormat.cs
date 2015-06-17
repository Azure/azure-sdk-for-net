namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Azure;

    /// <summary>
    /// </summary>
    public partial class SubnetPropertiesFormat
    {
        /// <summary>
        /// Gets or sets Address prefix for the subnet.
        /// </summary>
        [JsonProperty(PropertyName = "addressPrefix")]
        public string AddressPrefix { get; set; }

        /// <summary>
        /// Gets or sets the reference of the NetworkSecurityGroup resource
        /// </summary>
        [JsonProperty(PropertyName = "networkSecurityGroup")]
        public ResourceId NetworkSecurityGroup { get; set; }

        /// <summary>
        /// Gets array of references to the network interface IP
        /// configurations using subnet
        /// </summary>
        [JsonProperty(PropertyName = "ipConfigurations")]
        public IList<ResourceId> IpConfigurations { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.NetworkSecurityGroup != null)
            {
                this.NetworkSecurityGroup.Validate();
            }
            if (this.IpConfigurations != null)
            {
                foreach ( var element in this.IpConfigurations)
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
