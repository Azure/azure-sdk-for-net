namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VpnType
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum VpnType
    {
        [EnumMember(Value = "PolicyBased")]
        PolicyBased,
        [EnumMember(Value = "RouteBased")]
        RouteBased
    }
}
