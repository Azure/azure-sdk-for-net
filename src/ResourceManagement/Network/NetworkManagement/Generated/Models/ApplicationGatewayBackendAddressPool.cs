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
    public partial class ApplicationGatewayBackendAddressPool : SubResource
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
        /// Gets or sets backendIpConfiguration of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "backendIpConfigurations")]
        public IList<SubResource> BackendIpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets the backend addresses
        /// </summary>
        [JsonProperty(PropertyName = "backendAddresses")]
        public IList<ApplicationGatewayBackendAddress> BackendAddresses { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.BackendIpConfigurations != null)
            {
                foreach ( var element in this.BackendIpConfigurations)
            {
                if (element != null)
            {
                element.Validate();
            }
            }
            }
            if (this.BackendAddresses != null)
            {
                foreach ( var element1 in this.BackendAddresses)
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
