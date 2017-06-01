
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
    /// Defines values for CustomSupportPackageType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum CustomSupportPackageType
    {
        [EnumMember(Value = "RegistryKeys")]
        RegistryKeys,
        [EnumMember(Value = "LogFiles")]
        LogFiles,
        [EnumMember(Value = "ClusterManagementLog")]
        ClusterManagementLog,
        [EnumMember(Value = "BmcLogs")]
        BmcLogs,
        [EnumMember(Value = "ClusterLog")]
        ClusterLog,
        [EnumMember(Value = "CbsLogs")]
        CbsLogs,
        [EnumMember(Value = "StorageCmdlets")]
        StorageCmdlets,
        [EnumMember(Value = "ClusterCmdlets")]
        ClusterCmdlets,
        [EnumMember(Value = "ConfigurationCmdlets")]
        ConfigurationCmdlets,
        [EnumMember(Value = "Performance")]
        Performance,
        [EnumMember(Value = "MdsAgentLogs")]
        MdsAgentLogs,
        [EnumMember(Value = "NetworkCmdlets")]
        NetworkCmdlets,
        [EnumMember(Value = "NetworkCmds")]
        NetworkCmds,
        [EnumMember(Value = "EtwLogs")]
        EtwLogs,
        [EnumMember(Value = "UpdateLogs")]
        UpdateLogs,
        [EnumMember(Value = "PeriodicMgmtSvcLogs")]
        PeriodicMgmtSvcLogs
    }
}

