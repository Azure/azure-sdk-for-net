namespace Microsoft.Azure.Management.Network.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// SSL certificates of application gateway
    /// </summary>
    public partial class ApplicationGatewaySslCertificate : SubResource
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
        /// Gets or sets the certificate data
        /// </summary>
        [JsonProperty(PropertyName = "properties.data")]
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the certificate password
        /// </summary>
        [JsonProperty(PropertyName = "properties.password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the certificate public data
        /// </summary>
        [JsonProperty(PropertyName = "properties.publicCertData")]
        public string PublicCertData { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the ssl certificate resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

    }
}
