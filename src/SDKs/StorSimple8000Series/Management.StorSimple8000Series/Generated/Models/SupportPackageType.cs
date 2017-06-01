
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
    /// Defines values for SupportPackageType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum SupportPackageType
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "IncludeDefault")]
        IncludeDefault,
        [EnumMember(Value = "IncludeAll")]
        IncludeAll,
        [EnumMember(Value = "Mini")]
        Mini,
        [EnumMember(Value = "Custom")]
        Custom
    }
}

