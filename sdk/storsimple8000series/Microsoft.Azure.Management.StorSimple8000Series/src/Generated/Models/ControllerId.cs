
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
    /// Defines values for ControllerId.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum ControllerId
    {
        [EnumMember(Value = "Unknown")]
        Unknown,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Controller0")]
        Controller0,
        [EnumMember(Value = "Controller1")]
        Controller1
    }
}

