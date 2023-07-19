
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
    /// Defines values for JobType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum JobType
    {
        [EnumMember(Value = "ScheduledBackup")]
        ScheduledBackup,
        [EnumMember(Value = "ManualBackup")]
        ManualBackup,
        [EnumMember(Value = "RestoreBackup")]
        RestoreBackup,
        [EnumMember(Value = "CloneVolume")]
        CloneVolume,
        [EnumMember(Value = "FailoverVolumeContainers")]
        FailoverVolumeContainers,
        [EnumMember(Value = "CreateLocallyPinnedVolume")]
        CreateLocallyPinnedVolume,
        [EnumMember(Value = "ModifyVolume")]
        ModifyVolume,
        [EnumMember(Value = "InstallUpdates")]
        InstallUpdates,
        [EnumMember(Value = "SupportPackageLogs")]
        SupportPackageLogs,
        [EnumMember(Value = "CreateCloudAppliance")]
        CreateCloudAppliance
    }
}

