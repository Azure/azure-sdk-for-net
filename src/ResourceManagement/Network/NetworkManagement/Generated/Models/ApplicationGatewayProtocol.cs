namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ApplicationGatewayProtocol.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApplicationGatewayProtocol
    {
        [EnumMember(Value = "Http")]
        Http,
        [EnumMember(Value = "Https")]
        Https
    }
}
