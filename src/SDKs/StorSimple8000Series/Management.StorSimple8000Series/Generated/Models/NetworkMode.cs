
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
    /// Defines values for NetworkMode.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum NetworkMode
    {
        [EnumMember(Value = "Invalid")]
        Invalid,
        [EnumMember(Value = "IPV4")]
        IPV4,
        [EnumMember(Value = "IPV6")]
        IPV6,
        [EnumMember(Value = "BOTH")]
        BOTH
    }
}

