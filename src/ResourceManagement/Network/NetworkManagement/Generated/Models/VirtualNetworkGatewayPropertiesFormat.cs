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
    public partial class VirtualNetworkGatewayPropertiesFormat
    {
        /// <summary>
        /// IpConfigurations for Virtual network gateway.
        /// </summary>
        [JsonProperty(PropertyName = "ipConfigurations")]
        public IList<VirtualNetworkGatewayIpConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// The size of this virtual network gateway. Possible values for this
        /// property include: 'Default', 'HighPerformance'
        /// </summary>
        [JsonProperty(PropertyName = "gatewaySize")]
        public VirtualNetworkGatewaySize? GatewaySize { get; set; }

        /// <summary>
        /// The type of this virtual network gateway. Possible values for this
        /// property include: 'StaticRouting', 'DynamicRouting'
        /// </summary>
        [JsonProperty(PropertyName = "gatewayType")]
        public VpnGatewayType? GatewayType { get; set; }

        /// <summary>
        /// EnableBgp Flag
        /// </summary>
        [JsonProperty(PropertyName = "enableBgp")]
        public bool? EnableBgp { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
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
