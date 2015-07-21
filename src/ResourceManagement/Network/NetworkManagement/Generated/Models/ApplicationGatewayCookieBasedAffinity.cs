namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ApplicationGatewayCookieBasedAffinity.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApplicationGatewayCookieBasedAffinity
    {
        [EnumMember(Value = "Enabled")]
        Enabled,
        [EnumMember(Value = "Disabled")]
        Disabled
    }
}
