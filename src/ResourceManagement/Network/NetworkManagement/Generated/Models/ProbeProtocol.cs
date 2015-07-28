namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ProbeProtocol.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ProbeProtocol
    {
        [EnumMember(Value = "Http")]
        Http,
        [EnumMember(Value = "Tcp")]
        Tcp
    }
}
