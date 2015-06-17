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
    public partial class NetworkInterfaceIpConfigurationPropertiesFormat
    {
        /// <summary>
        /// Gets or sets the privateIPAddress of the Network Interface IP
        /// Configuration
        /// </summary>
        [JsonProperty(PropertyName = "privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// Gets or sets PrivateIP allocation method (Static/Dynamic)
        /// </summary>
        [JsonProperty(PropertyName = "privateIPAllocationMethod")]
        public string PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Gets or sets the reference of the subnet resource
        /// </summary>
        [JsonProperty(PropertyName = "subnet")]
        public ResourceId Subnet { get; set; }

        /// <summary>
        /// Gets or sets the reference of the PublicIP resource
        /// </summary>
        [JsonProperty(PropertyName = "publicIPAddress")]
        public ResourceId PublicIPAddress { get; set; }

        /// <summary>
        /// Gets or sets the reference of LoadBalancerBackendAddressPool
        /// resource
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancerBackendAddressPools")]
        public IList<ResourceId> LoadBalancerBackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets list of references of LoadBalancerInboundNatRules
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancerInboundNatRules")]
        public IList<ResourceId> LoadBalancerInboundNatRules { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (this.Subnet != null)
            {
                this.Subnet.Validate();
            }
            if (this.PublicIPAddress != null)
            {
                this.PublicIPAddress.Validate();
            }
            if (this.LoadBalancerBackendAddressPools != null)
            {
                foreach ( var element in this.LoadBalancerBackendAddressPools)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.LoadBalancerInboundNatRules != null)
            {
                foreach ( var element1 in this.LoadBalancerInboundNatRules)
            {
                if (element1 != null)
            {
                element1.Validate();
            }
            }
            }
        }
    }
}
