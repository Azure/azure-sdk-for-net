// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for IotHubSkuTier.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IotHubSkuTier
    {
        [EnumMember(Value = "Free")]
        Free,
        [EnumMember(Value = "Standard")]
        Standard
    }
}
