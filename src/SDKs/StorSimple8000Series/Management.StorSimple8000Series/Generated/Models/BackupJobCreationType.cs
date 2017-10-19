
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
    /// Defines values for BackupJobCreationType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum BackupJobCreationType
    {
        [EnumMember(Value = "Adhoc")]
        Adhoc,
        [EnumMember(Value = "BySchedule")]
        BySchedule,
        [EnumMember(Value = "BySSM")]
        BySSM
    }
}

