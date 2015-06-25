namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for TransportProtocol
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransportProtocol
    {
        [EnumMember(Value = "Udp")]
        Udp,
        [EnumMember(Value = "Tcp")]
        Tcp
    }
}
