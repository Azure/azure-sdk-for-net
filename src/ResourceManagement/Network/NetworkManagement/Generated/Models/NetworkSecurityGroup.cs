namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// NetworkSecurityGroup resource
    /// </summary>
    public partial class NetworkSecurityGroup : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets Security rules of network security group
        /// </summary>
        [JsonProperty(PropertyName = "properties.securityRules")]
        public IList<SecurityRule> SecurityRules { get; set; }

        /// <summary>
        /// Gets or sets Default security rules of network security group
        /// </summary>
        [JsonProperty(PropertyName = "properties.defaultSecurityRules")]
        public IList<SecurityRule> DefaultSecurityRules { get; set; }

        /// <summary>
        /// Gets collection of references to Network Interfaces
        /// </summary>
        [JsonProperty(PropertyName = "properties.networkInterfaces")]
        public IList<SubResource> NetworkInterfaces { get; set; }

        /// <summary>
        /// Gets collection of references to subnets
        /// </summary>
        [JsonProperty(PropertyName = "properties.subnets")]
        public IList<SubResource> Subnets { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the PublicIP resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
