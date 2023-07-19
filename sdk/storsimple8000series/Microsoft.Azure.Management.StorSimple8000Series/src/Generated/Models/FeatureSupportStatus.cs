
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
    /// Defines values for FeatureSupportStatus.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum FeatureSupportStatus
    {
        [EnumMember(Value = "NotAvailable")]
        NotAvailable,
        [EnumMember(Value = "UnsupportedDeviceVersion")]
        UnsupportedDeviceVersion,
        [EnumMember(Value = "Supported")]
        Supported
    }
}

