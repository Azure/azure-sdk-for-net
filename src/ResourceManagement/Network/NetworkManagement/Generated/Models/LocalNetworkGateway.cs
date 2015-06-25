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
    public partial class LocalNetworkGateway : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// IP address of local network gateway.
        /// </summary>
        [JsonProperty(PropertyName = "gatewayIpAddress")]
        public string GatewayIpAddress { get; set; }

        /// <summary>
        /// Local network site Address space
        /// </summary>
        [JsonProperty(PropertyName = "localNetworkSiteAddressSpace")]
        public AddressSpace LocalNetworkSiteAddressSpace { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.LocalNetworkSiteAddressSpace != null)
            {
                this.LocalNetworkSiteAddressSpace.Validate();
            }
        }
    }
}
