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
    public partial class VirtualNetwork : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets AddressSpace that contains an array of IP address
        /// ranges that can be used by subnets
        /// </summary>
        [JsonProperty(PropertyName = "properties.addressSpace")]
        public AddressSpace AddressSpace { get; set; }

        /// <summary>
        /// Gets or sets DHCPOptions that contains an array of DNS servers
        /// available to VMs deployed in the virtual network
        /// </summary>
        [JsonProperty(PropertyName = "properties.dhcpOptions")]
        public DhcpOptions DhcpOptions { get; set; }

        /// <summary>
        /// Gets or sets List of subnets in a VirtualNetwork
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnets")]
        public IList<Subnet> Subnets { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.Subnets != null)
            {
                foreach ( var element in this.Subnets)
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
