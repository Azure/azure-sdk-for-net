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
    public partial class BackendAddressPoolPropertiesFormat
    {
        /// <summary>
        /// Gets collection of references to IPs defined in NICs
        /// </summary>
        [JsonProperty(PropertyName = "backendIPConfigurations")]
        public IList<ResourceId> BackendIPConfigurations { get; set; }

        /// <summary>
        /// Gets Load Balancing rules that use this Backend Address Pool
        /// </summary>
        [JsonProperty(PropertyName = "loadBalancingRules")]
        public IList<ResourceId> LoadBalancingRules { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
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
