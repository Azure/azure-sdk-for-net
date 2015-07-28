namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for UsageUnit.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum UsageUnit
    {
        [EnumMember(Value = "Count")]
        Count
    }
}
