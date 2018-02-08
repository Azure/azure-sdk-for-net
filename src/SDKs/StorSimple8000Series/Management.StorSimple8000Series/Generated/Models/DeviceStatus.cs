
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
    /// Defines values for DeviceStatus.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum DeviceStatus
    {
        [EnumMember(Value = "Unknown")]
        Unknown,
        [EnumMember(Value = "Online")]
        Online,
        [EnumMember(Value = "Offline")]
        Offline,
        [EnumMember(Value = "Deactivated")]
        Deactivated,
        [EnumMember(Value = "RequiresAttention")]
        RequiresAttention,
        [EnumMember(Value = "MaintenanceMode")]
        MaintenanceMode,
        [EnumMember(Value = "Creating")]
        Creating,
        [EnumMember(Value = "Provisioning")]
        Provisioning,
        [EnumMember(Value = "Deactivating")]
        Deactivating,
        [EnumMember(Value = "Deleted")]
        Deleted,
        [EnumMember(Value = "ReadyToSetup")]
        ReadyToSetup
    }
}

