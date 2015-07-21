namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for LoadDistribution.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LoadDistribution
    {
        [EnumMember(Value = "Default")]
        Default,
        [EnumMember(Value = "SourceIP")]
        SourceIP,
        [EnumMember(Value = "SourceIPProtocol")]
        SourceIPProtocol
    }
}
