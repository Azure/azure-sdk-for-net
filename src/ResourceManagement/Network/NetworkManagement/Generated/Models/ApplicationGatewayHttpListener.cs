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
    public partial class ApplicationGatewayHttpListener : SubResource
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
        /// Gets or sets frontend IP configuration resource of application
        /// gateway
        /// </summary>
        [JsonProperty(PropertyName = "properties.frontendIpConfiguration")]
        public SubResource FrontendIpConfiguration { get; set; }

        /// <summary>
        /// Gets or sets frontend port resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "properties.frontendPort")]
        public SubResource FrontendPort { get; set; }

        /// <summary>
        /// Gets or sets the protocol. Possible values for this property
        /// include: 'Http', 'Https'
        /// </summary>
        [JsonProperty(PropertyName = "properties.protocol")]
        public ApplicationGatewayProtocol? Protocol { get; set; }

        /// <summary>
        /// Gets or sets ssl certificate resource of application gateway
        /// </summary>
        [JsonProperty(PropertyName = "properties.sslCertificate")]
        public SubResource SslCertificate { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the http listener resource
        /// Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

    }
}
