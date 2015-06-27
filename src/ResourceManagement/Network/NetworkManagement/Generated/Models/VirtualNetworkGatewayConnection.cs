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
    public partial class VirtualNetworkGatewayConnection : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "virtualNetworkGateway1")]
        public VirtualNetworkGateway VirtualNetworkGateway1 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "virtualNetworkGateway2")]
        public VirtualNetworkGateway VirtualNetworkGateway2 { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "localNetworkGateway2")]
        public LocalNetworkGateway LocalNetworkGateway2 { get; set; }

        /// <summary>
        /// Gateway connection type -Ipsec/Dedicated/VpnClient/Vnet2Vnet.
        /// Possible values for this property include: 'IPsec', 'Vnet2Vnet',
        /// 'ExpressRoute', 'VPNClient'
        /// </summary>
        [JsonProperty(PropertyName = "connectionType")]
        public VirtualNetworkGatewayConnectionType? ConnectionType { get; set; }

        /// <summary>
        /// The Routing weight.
        /// </summary>
        [JsonProperty(PropertyName = "routingWeight")]
        public int? RoutingWeight { get; set; }

        /// <summary>
        /// The Ipsec share key.
        /// </summary>
        [JsonProperty(PropertyName = "sharedKey")]
        public string SharedKey { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
            if (this.VirtualNetworkGateway1 != null)
            {
                this.VirtualNetworkGateway1.Validate();
            }
            if (this.VirtualNetworkGateway2 != null)
            {
                this.VirtualNetworkGateway2.Validate();
            }
            if (this.LocalNetworkGateway2 != null)
            {
                this.LocalNetworkGateway2.Validate();
            }
        }
    }
}
