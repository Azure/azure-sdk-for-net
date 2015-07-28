namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for ApplicationGatewayTier.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ApplicationGatewayTier
    {
        [EnumMember(Value = "Standard")]
        Standard
    }
}
