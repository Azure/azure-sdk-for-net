
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
    /// Defines values for AlertSeverity.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AlertSeverity
    {
        [EnumMember(Value = "Informational")]
        Informational,
        [EnumMember(Value = "Warning")]
        Warning,
        [EnumMember(Value = "Critical")]
        Critical
    }
}

