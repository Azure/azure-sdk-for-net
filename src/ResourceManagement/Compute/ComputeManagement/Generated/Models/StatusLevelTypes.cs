namespace Microsoft.Azure.Management.Compute.Models
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for StatusLevelTypes.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusLevelTypes
    {
        [EnumMember(Value = "Info")]
        Info,
        [EnumMember(Value = "Warning")]
        Warning,
        [EnumMember(Value = "Error")]
        Error
    }
}
