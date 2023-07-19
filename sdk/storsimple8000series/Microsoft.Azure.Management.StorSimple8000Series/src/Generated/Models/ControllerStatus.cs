
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
    /// Defines values for ControllerStatus.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ControllerStatus
    {
        [EnumMember(Value = "NotPresent")]
        NotPresent,
        [EnumMember(Value = "PoweredOff")]
        PoweredOff,
        [EnumMember(Value = "Ok")]
        Ok,
        [EnumMember(Value = "Recovering")]
        Recovering,
        [EnumMember(Value = "Warning")]
        Warning,
        [EnumMember(Value = "Failure")]
        Failure
    }
}

