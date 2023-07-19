
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
    /// Defines values for RemoteManagementModeConfiguration.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum RemoteManagementModeConfiguration
    {
        [EnumMember(Value = "Unknown")]
        Unknown,
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "HttpsEnabled")]
        HttpsEnabled,
        [EnumMember(Value = "HttpsAndHttpEnabled")]
        HttpsAndHttpEnabled
    }
}

