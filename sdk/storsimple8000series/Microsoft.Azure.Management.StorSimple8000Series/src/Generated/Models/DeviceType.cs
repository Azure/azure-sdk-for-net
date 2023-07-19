
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
    /// Defines values for DeviceType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DeviceType
    {
        [EnumMember(Value = "Invalid")]
        Invalid,
        [EnumMember(Value = "Series8000VirtualAppliance")]
        Series8000VirtualAppliance,
        [EnumMember(Value = "Series8000PhysicalAppliance")]
        Series8000PhysicalAppliance
    }
}

