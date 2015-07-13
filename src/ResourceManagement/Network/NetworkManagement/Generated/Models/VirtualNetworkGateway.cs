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
        [JsonProperty(PropertyName = "properties.ipConfigurations")]
        public IList<VirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// The type of this virtual network gateway. Possible values for this
        /// property include: 'Vpn'
        /// </summary>
        [JsonProperty(PropertyName = "properties.gatewayType")]
        public VirtualNetworkGatewayType? GatewayType { get; set; }

        /// <summary>
        /// The type of this virtual network gateway. Possible values for this
        /// property include: 'PolicyBased', 'RouteBased'
        /// </summary>
        [JsonProperty(PropertyName = "properties.vpnType")]
        public VpnType? VpnType { get; set; }

        /// <summary>
        /// EnableBgp Flag
        /// </summary>
        [JsonProperty(PropertyName = "properties.enableBgp")]
        public bool? EnableBgp { get; set; }

        /// <summary>
        /// Gets or sets Provisioning state of the VirtualNetworkGateway
        /// resource Updating/Deleting/Failed
        /// </summary>
        [JsonProperty(PropertyName = "properties.provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
