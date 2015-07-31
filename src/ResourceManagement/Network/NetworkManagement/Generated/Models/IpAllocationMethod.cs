namespace Microsoft.Azure.Management.Network.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for IpAllocationMethod.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IpAllocationMethod
    {
        [EnumMember(Value = "Static")]
        Static,
        [EnumMember(Value = "Dynamic")]
        Dynamic
    }
}
