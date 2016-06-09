
namespace Microsoft.Azure.Management.Dns.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for RecordType.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RecordType
    {
        [EnumMember(Value = "A")]
        A,
        [EnumMember(Value = "AAAA")]
        AAAA,
        [EnumMember(Value = "CNAME")]
        CNAME,
        [EnumMember(Value = "MX")]
        MX,
        [EnumMember(Value = "NS")]
        NS,
        [EnumMember(Value = "PTR")]
        PTR,
        [EnumMember(Value = "SOA")]
        SOA,
        [EnumMember(Value = "SRV")]
        SRV,
        [EnumMember(Value = "TXT")]
        TXT
    }
}
