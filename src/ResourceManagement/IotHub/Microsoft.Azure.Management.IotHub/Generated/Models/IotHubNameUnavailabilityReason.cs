// MIT

namespace Microsoft.Azure.Management.IotHub.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for IotHubNameUnavailabilityReason.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum IotHubNameUnavailabilityReason
    {
        [EnumMember(Value = "Invalid")]
        Invalid,
        [EnumMember(Value = "AlreadyExists")]
        AlreadyExists
    }
}
