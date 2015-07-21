namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SecurityRuleDirection.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SecurityRuleDirection
    {
        [EnumMember(Value = "Inbound")]
        Inbound,
        [EnumMember(Value = "Outbound")]
        Outbound
    }
}
