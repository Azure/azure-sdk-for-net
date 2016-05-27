
namespace Microsoft.Azure.Management.CognitiveServices.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for SkuName.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SkuName
    {
        [EnumMember(Value = "F0")]
        F0,
        [EnumMember(Value = "S0")]
        S0,
        [EnumMember(Value = "S1")]
        S1,
        [EnumMember(Value = "S2")]
        S2,
        [EnumMember(Value = "S3")]
        S3,
        [EnumMember(Value = "S4")]
        S4
    }
}
