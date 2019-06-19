
namespace Microsoft.Azure.Management.StorSimple8000Series.Models
{
    using Azure;
    using Management;
    using StorSimple8000Series;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for VolumeType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum VolumeType
    {
        [EnumMember(Value = "Tiered")]
        Tiered,
        [EnumMember(Value = "Archival")]
        Archival,
        [EnumMember(Value = "LocallyPinned")]
        LocallyPinned
    }
}

