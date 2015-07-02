namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for OperatingSystemTypes
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperatingSystemTypes
    {
        [EnumMember(Value = "Windows")]
        Windows,
        [EnumMember(Value = "Linux")]
        Linux
    }
}
