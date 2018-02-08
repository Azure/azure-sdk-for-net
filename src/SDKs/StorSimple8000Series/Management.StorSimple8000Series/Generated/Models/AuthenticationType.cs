
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
    /// Defines values for AuthenticationType.
    /// </summary>
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public enum AuthenticationType
    {
        [EnumMember(Value = "Invalid")]
        Invalid,
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "Basic")]
        Basic,
        [EnumMember(Value = "NTLM")]
        NTLM
    }
}

