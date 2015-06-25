namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VirtualNetworkGatewayConnectionType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VirtualNetworkGatewayConnectionType
    {
        [EnumMember(Value = "IPsec")]
        IPsec,
        [EnumMember(Value = "Vnet2Vnet")]
        Vnet2Vnet,
        [EnumMember(Value = "Dedicated")]
        Dedicated,
        [EnumMember(Value = "VPNClient")]
        VPNClient
    }
}
