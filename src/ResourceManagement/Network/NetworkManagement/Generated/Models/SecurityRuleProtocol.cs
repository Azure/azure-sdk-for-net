namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SecurityRuleProtocol.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SecurityRuleProtocol
    {
        [EnumMember(Value = "Tcp")]
        Tcp,
        [EnumMember(Value = "Udp")]
        Udp,
        [EnumMember(Value = "*")]
        Asterisk
    }
}
