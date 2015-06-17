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
        [JsonProperty(PropertyName = "securityRules")]
        public IList<SecurityRule> SecurityRules { get; set; }

        /// <summary>
        /// Gets or sets Default security rules of network security group
        /// </summary>
        [JsonProperty(PropertyName = "defaultSecurityRules")]
        public IList<SecurityRule> DefaultSecurityRules { get; set; }

        /// <summary>
        /// Gets collection of references to Network Interfaces
        /// </summary>
        [JsonProperty(PropertyName = "networkInterfaces")]
        public IList<ResourceId> NetworkInterfaces { get; set; }

        /// <summary>
        /// Gets collection of references to subnets
        /// </summary>
        [JsonProperty(PropertyName = "subnets")]
        public IList<ResourceId> Subnets { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.SecurityRules != null)
            {
                foreach ( var element in this.SecurityRules)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.DefaultSecurityRules != null)
            {
                foreach ( var element1 in this.DefaultSecurityRules)
            {
                if (element1 != null)
            {
                element1.Validate();
            }
            }
            }
            if (this.NetworkInterfaces != null)
            {
                foreach ( var element2 in this.NetworkInterfaces)
            {
                if (element2 != null)
            {
                element2.Validate();
            }
            }
            }
            if (this.Subnets != null)
            {
                foreach ( var element3 in this.Subnets)
            {
                if (element3 != null)
            {
                element3.Validate();
            }
            }
            }
        }
    }
}
