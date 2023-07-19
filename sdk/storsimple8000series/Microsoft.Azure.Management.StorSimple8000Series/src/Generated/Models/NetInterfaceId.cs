
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
    /// Defines values for NetInterfaceId.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum NetInterfaceId
    {
        [EnumMember(Value = "Invalid")]
        Invalid,
        [EnumMember(Value = "Data0")]
        Data0,
        [EnumMember(Value = "Data1")]
        Data1,
        [EnumMember(Value = "Data2")]
        Data2,
        [EnumMember(Value = "Data3")]
        Data3,
        [EnumMember(Value = "Data4")]
        Data4,
        [EnumMember(Value = "Data5")]
        Data5
    }
}

