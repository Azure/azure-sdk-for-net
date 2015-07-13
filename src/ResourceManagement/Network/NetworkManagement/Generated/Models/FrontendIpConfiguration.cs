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
    public partial class FrontendIpConfiguration : SubResource
    {
        /// <summary>
        /// Gets name of the resource that is unique within a resource group.
        /// This name can be used to access the resource
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is
        /// updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the IP address of the Load Balancer.This is only
        /// specified if a specific private IP address shall be allocated
        /// from the subnet specified in subnetRef
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// Gets or sets PrivateIP allocation method (Static/Dynamic).
        /// Possible values for this property include: 'Static', 'Dynamic'
        /// </summary>
        [JsonProperty(PropertyName = "properties.privateIPAllocationMethod")]
        public IpAllocationMethod? PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Gets or sets the reference of the subnet resource.A subnet from
        /// wher the load balancer gets its private frontend address
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnet")]
        public SubResource Subnet { get; set; }

        /// <summary>
        /// Gets or sets the reference of the PublicIP resource
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicIPAddress")]
        public SubResource PublicIPAddress { get; set; }

        /// <summary>
        /// Read only.Inbound rules URIs that use this frontend IP
        /// </summary>
        [JsonProperty(PropertyName = "properties.inboundNatRules")]
        public IList<SubResource> InboundNatRules { get; set; }

        /// <summary>
        /// Gets Load Balancing rules URIs that use this frontend IP
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancingRules")]
        public IList<SubResource> LoadBalancingRules { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
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
