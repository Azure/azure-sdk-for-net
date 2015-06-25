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
    public partial class LoadBalancer : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets frontend IP addresses of the load balancer
        /// </summary>
        [JsonProperty(PropertyName = "frontendIPConfigurations")]
        public IList<FrontendIpConfiguration> FrontendIPConfigurations { get; set; }

        /// <summary>
        /// Gets or sets Pools of backend IP addresseses
        /// </summary>
        [JsonProperty(PropertyName = "backendAddressPools")]
        public IList<BackendAddressPool> BackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets loadbalancing rules
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancingRules")]
        public IList<LoadBalancingRule> LoadBalancingRules { get; set; }

        /// <summary>
        /// Gets or sets list of Load balancer probes
        /// </summary>
        [JsonProperty(PropertyName = "probes")]
        public IList<Probe> Probes { get; set; }

        /// <summary>
        /// Gets or sets list of inbound rules
        /// </summary>
        [JsonProperty(PropertyName = "inboundNatRules")]
        public IList<InboundNatRule> InboundNatRules { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.FrontendIPConfigurations != null)
            {
                foreach ( var element in this.FrontendIPConfigurations)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.BackendAddressPools != null)
            {
                foreach ( var element1 in this.BackendAddressPools)
            {
                if (element1 != null)
            {
                element1.Validate();
            }
            }
            }
            if (this.LoadBalancingRules != null)
            {
                foreach ( var element2 in this.LoadBalancingRules)
            {
                if (element2 != null)
            {
                element2.Validate();
            }
            }
            }
            if (this.Probes != null)
            {
                foreach ( var element3 in this.Probes)
            {
                if (element3 != null)
            {
                element3.Validate();
            }
            }
            }
            if (this.InboundNatRules != null)
            {
                foreach ( var element4 in this.InboundNatRules)
            {
                if (element4 != null)
            {
                element4.Validate();
            }
            }
            }
        }
    }
}
