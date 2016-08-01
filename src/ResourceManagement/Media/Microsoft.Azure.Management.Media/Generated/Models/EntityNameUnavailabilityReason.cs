
namespace Microsoft.Azure.Management.Media.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for EntityNameUnavailabilityReason.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EntityNameUnavailabilityReason
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Invalid")]
        Invalid,
        [EnumMember(Value = "AlreadyExists")]
        AlreadyExists
    }
}
