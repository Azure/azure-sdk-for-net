namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for CachingTypes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum CachingTypes
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "ReadOnly")]
        ReadOnly,
        [EnumMember(Value = "ReadWrite")]
        ReadWrite
    }
}
