
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
    /// Defines values for RecurrenceType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum RecurrenceType
    {
        [EnumMember(Value = "Minutes")]
        Minutes,
        [EnumMember(Value = "Hourly")]
        Hourly,
        [EnumMember(Value = "Daily")]
        Daily,
        [EnumMember(Value = "Weekly")]
        Weekly
    }
}

