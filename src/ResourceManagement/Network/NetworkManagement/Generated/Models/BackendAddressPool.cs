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
    public partial class BackendAddressPool : SubResource
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
        /// Gets collection of references to IPs defined in NICs
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendIPConfigurations")]
        public IList<SubResource> BackendIPConfigurations { get; set; }

        /// <summary>
        /// Gets Load Balancing rules that use this Backend Address Pool
        /// </summary>
        [JsonProperty(PropertyName = "properties.loadBalancingRules")]
        public IList<SubResource> LoadBalancingRules { get; set; }

    }
}
