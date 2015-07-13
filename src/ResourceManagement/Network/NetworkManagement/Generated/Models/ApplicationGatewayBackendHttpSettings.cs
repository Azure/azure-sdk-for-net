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
    public partial class ApplicationGatewayBackendHttpSettings : SubResource
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
        /// Gets or sets the port
        /// </summary>
        [JsonProperty(PropertyName = "properties.port")]
        public int? Port { get; set; }

        /// <summary>
        /// Gets or sets the protocol. Possible values for this property
        /// include: 'Http', 'Https'
        /// </summary>
        [JsonProperty(PropertyName = "properties.protocol")]
        public ApplicationGatewayProtocol? Protocol { get; set; }

        /// <summary>
        /// Gets or sets the cookie affinity. Possible values for this
        /// property include: 'Enabled', 'Disabled'
        /// </summary>
        [JsonProperty(PropertyName = "properties.cookieBasedAffinity")]
        public ApplicationGatewayCookieBasedAffinity? CookieBasedAffinity { get; set; }

    }
}
