
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
    /// Defines values for MetricUnit.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MetricUnit
    {
        [EnumMember(Value = "Bytes")]
        Bytes,
        [EnumMember(Value = "BytesPerSecond")]
        BytesPerSecond,
        [EnumMember(Value = "Count")]
        Count,
        [EnumMember(Value = "CountPerSecond")]
        CountPerSecond,
        [EnumMember(Value = "Percent")]
        Percent,
        [EnumMember(Value = "Seconds")]
        Seconds
    }
}

