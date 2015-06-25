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
        [JsonProperty(PropertyName = "backendIPConfigurations")]
        public IList<SubResource> BackendIPConfigurations { get; set; }

        /// <summary>
        /// Gets Load Balancing rules that use this Backend Address Pool
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancingRules")]
        public IList<SubResource> LoadBalancingRules { get; set; }

        /// <summary>
        /// Provisioning state of the PublicIP resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.BackendIPConfigurations != null)
            {
                foreach ( var element in this.BackendIPConfigurations)
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
