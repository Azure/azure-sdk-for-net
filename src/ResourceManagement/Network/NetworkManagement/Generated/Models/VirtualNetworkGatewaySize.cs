namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VirtualNetworkGatewaySize
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VirtualNetworkGatewaySize
    {
        [EnumMember(Value = "Default")]
        Default,
        [EnumMember(Value = "HighPerformance")]
        HighPerformance
    }
}
