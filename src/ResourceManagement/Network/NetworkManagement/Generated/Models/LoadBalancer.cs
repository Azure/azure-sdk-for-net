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
        [JsonProperty(PropertyName = "properties.frontendIPConfigurations")]
        public IList<FrontendIpConfiguration> FrontendIPConfigurations { get; set; }

        /// <summary>
        /// Gets or sets Pools of backend IP addresseses
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendAddressPools")]
        public IList<BackendAddressPool> BackendAddressPools { get; set; }

        /// <summary>
        /// Gets or sets loadbalancing rules
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancingRules")]
        public IList<LoadBalancingRule> LoadBalancingRules { get; set; }

        /// <summary>
        /// Gets or sets list of Load balancer probes
        /// </summary>
        [JsonProperty(PropertyName = "properties.probes")]
        public IList<Probe> Probes { get; set; }

        /// <summary>
        /// Gets or sets list of inbound rules
        /// </summary>
        [JsonProperty(PropertyName = "properties.inboundNatRules")]
        public IList<InboundNatRule> InboundNatRules { get; set; }

    }
}
