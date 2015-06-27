namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VirtualNetworkGatewayType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VirtualNetworkGatewayType
    {
        [EnumMember(Value = "Vpn")]
        Vpn
    }
}
