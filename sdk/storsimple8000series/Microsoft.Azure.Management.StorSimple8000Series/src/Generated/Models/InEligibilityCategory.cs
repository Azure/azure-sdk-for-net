
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
    /// Defines values for InEligibilityCategory.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum InEligibilityCategory
    {
        [EnumMember(Value = "DeviceNotOnline")]
        DeviceNotOnline,
        [EnumMember(Value = "NotSupportedAppliance")]
        NotSupportedAppliance,
        [EnumMember(Value = "RolloverPending")]
        RolloverPending
    }
}

