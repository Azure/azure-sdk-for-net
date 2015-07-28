namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// Backend Address Pool of application gateway
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
        [JsonProperty(PropertyName = "properties.backendIpConfigurations")]
        public IList<SubResource> BackendIpConfigurations { get; set; }

        /// <summary>
        /// Gets or sets the backend addresses
        /// </summary>
        [JsonProperty(PropertyName = "properties.backendAddresses")]
        public IList<ApplicationGatewayBackendAddress> BackendAddresses { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the backend address pool
        /// resource Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

    }
}
