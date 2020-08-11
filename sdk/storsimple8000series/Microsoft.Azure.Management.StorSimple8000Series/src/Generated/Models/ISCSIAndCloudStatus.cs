
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
    /// Defines values for ISCSIAndCloudStatus.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ISCSIAndCloudStatus
    {
        [EnumMember(Value = "Disabled")]
        Disabled,
        [EnumMember(Value = "IscsiEnabled")]
        IscsiEnabled,
        [EnumMember(Value = "CloudEnabled")]
        CloudEnabled,
        [EnumMember(Value = "IscsiAndCloudEnabled")]
        IscsiAndCloudEnabled
    }
}

