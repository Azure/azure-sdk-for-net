namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SecurityRuleAccess
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SecurityRuleAccess
    {
        [EnumMember(Value = "Allow")]
        Allow,
        [EnumMember(Value = "Deny")]
        Deny
    }
}
