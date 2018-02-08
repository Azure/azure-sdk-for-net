
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
    /// Defines values for MetricAggregationType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum MetricAggregationType
    {
        [EnumMember(Value = "Average")]
        Average,
        [EnumMember(Value = "Last")]
        Last,
        [EnumMember(Value = "Maximum")]
        Maximum,
        [EnumMember(Value = "Minimum")]
        Minimum,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Total")]
        Total
    }
}

