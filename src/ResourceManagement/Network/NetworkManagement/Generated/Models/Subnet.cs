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
    public partial class Subnet : SubResource
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
        /// Gets or sets Address prefix for the subnet.
        /// </summary>
        [JsonProperty(PropertyName = "addressPrefix")]
        public string AddressPrefix { get; set; }

        /// <summary>
        /// Gets or sets the reference of the NetworkSecurityGroup resource
        /// </summary>
        [JsonProperty(PropertyName = "networkSecurityGroup")]
        public SubResource NetworkSecurityGroup { get; set; }

        /// <summary>
        /// Gets array of references to the network interface IP
        /// configurations using subnet
        /// </summary>
        [JsonProperty(PropertyName = "ipConfigurations")]
        public IList<SubResource> IpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the PublicIP resource
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
            if (this.NetworkSecurityGroup != null)
            {
                this.NetworkSecurityGroup.Validate();
            }
            if (this.IpConfigurations != null)
            {
                foreach ( var element in this.IpConfigurations)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
        }
    }
}
