namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ProtocolTypes
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProtocolTypes
    {
        [EnumMember(Value = "Http")]
        Http,
        [EnumMember(Value = "Https")]
        Https
    }
}
