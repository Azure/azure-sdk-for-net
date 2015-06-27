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
    public partial class VirtualNetworkGateway : Resource
    {
        /// <summary>
        /// Gets a unique read-only string that changes whenever the resource
        /// is updated
        /// </summary>
        [JsonProperty(PropertyName = "etag")]
        public string Etag { get; set; }

        /// <summary>
        /// IpConfigurations for Virtual network gateway.
        /// </summary>
        [JsonProperty(PropertyName = "ipConfigurations")]
        public IList<VirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// The type of this virtual network gateway. Possible values for this
        /// property include: 'Vpn'
        /// </summary>
        [JsonProperty(PropertyName = "gatewayType")]
        public VirtualNetworkGatewayType? GatewayType { get; set; }

        /// <summary>
        /// The type of this virtual network gateway. Possible values for this
        /// property include: 'PolicyBased', 'RouteBased'
        /// </summary>
        [JsonProperty(PropertyName = "vpnType")]
        public VpnType? VpnType { get; set; }

        /// <summary>
        /// EnableBgp Flag
        /// </summary>
        [JsonProperty(PropertyName = "enableBgp")]
        public bool? EnableBgp { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
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
