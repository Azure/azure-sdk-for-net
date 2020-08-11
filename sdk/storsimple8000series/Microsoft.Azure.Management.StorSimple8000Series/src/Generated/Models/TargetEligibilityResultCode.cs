
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
    /// Defines values for TargetEligibilityResultCode.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum TargetEligibilityResultCode
    {
        [EnumMember(Value = "TargetAndSourceCannotBeSameError")]
        TargetAndSourceCannotBeSameError,
        [EnumMember(Value = "TargetIsNotOnlineError")]
        TargetIsNotOnlineError,
        [EnumMember(Value = "TargetSourceIncompatibleVersionError")]
        TargetSourceIncompatibleVersionError,
        [EnumMember(Value = "LocalToTieredVolumesConversionWarning")]
        LocalToTieredVolumesConversionWarning,
        [EnumMember(Value = "TargetInsufficientCapacityError")]
        TargetInsufficientCapacityError,
        [EnumMember(Value = "TargetInsufficientLocalVolumeMemoryError")]
        TargetInsufficientLocalVolumeMemoryError,
        [EnumMember(Value = "TargetInsufficientTieredVolumeMemoryError")]
        TargetInsufficientTieredVolumeMemoryError
    }
}

