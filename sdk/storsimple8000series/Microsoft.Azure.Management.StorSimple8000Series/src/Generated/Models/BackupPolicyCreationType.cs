
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
    /// Defines values for BackupPolicyCreationType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum BackupPolicyCreationType
    {
        [EnumMember(Value = "BySaaS")]
        BySaaS,
        [EnumMember(Value = "BySSM")]
        BySSM
    }
}

