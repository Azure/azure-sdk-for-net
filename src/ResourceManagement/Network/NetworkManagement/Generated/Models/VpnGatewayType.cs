namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VpnGatewayType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VpnGatewayType
    {
        [EnumMember(Value = "StaticRouting")]
        StaticRouting,
        [EnumMember(Value = "DynamicRouting")]
        DynamicRouting
    }
}
