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
    public partial class FrontendIpConfigurationPropertiesFormat
    {
        /// <summary>
        /// Gets or sets the IP address of the Load Balancer.This is only
        /// specified if a specific private IP address shall be allocated
        /// from the subnet specified in subnetRef
        /// </summary>
        [JsonProperty(PropertyName = "privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// Gets or sets PrivateIP allocation method (Static/Dynamic)
        /// </summary>
        [JsonProperty(PropertyName = "privateIPAllocationMethod")]
        public string PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Gets or sets the reference of the subnet resource.A subnet from
        /// wher the load balancer gets its private frontend address
        /// </summary>
        [JsonProperty(PropertyName = "subnet")]
        public ResourceId Subnet { get; set; }

        /// <summary>
        /// Gets or sets the reference of the PublicIP resource
        /// </summary>
        [JsonProperty(PropertyName = "publicIPAddress")]
        public ResourceId PublicIPAddress { get; set; }

        /// <summary>
        /// Read only.Inbound rules URIs that use this frontend IP
        /// </summary>
        [JsonProperty(PropertyName = "inboundNatRules")]
        public IList<ResourceId> InboundNatRules { get; set; }

        /// <summary>
        /// Gets Load Balancing rules URIs that use this frontend IP
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancingRules")]
        public IList<ResourceId> LoadBalancingRules { get; set; }

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
            if (this.InboundNatRules != null)
            {
                foreach ( var element in this.InboundNatRules)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.LoadBalancingRules != null)
            {
                foreach ( var element1 in this.LoadBalancingRules)
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
